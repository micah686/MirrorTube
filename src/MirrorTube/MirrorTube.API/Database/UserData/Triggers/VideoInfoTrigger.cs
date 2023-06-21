using AutoMapper;
using EntityFrameworkCore.Triggered;
using MirrorTube.Common.Models.Database.UserData;

namespace MirrorTube.API.Database.UserData.Triggers
{
    public class VideoInfoTrigger : IBeforeSaveTrigger<VideoInfo>
    {
        private readonly UserDataContext _userDataContext;
        private readonly IMapper _mapper;
        public VideoInfoTrigger(UserDataContext userDataContext, IMapper mapper)
        {
            _userDataContext = userDataContext;
            _mapper = mapper;
        }

        Task IBeforeSaveTrigger<VideoInfo>.BeforeSave(ITriggerContext<VideoInfo> context, CancellationToken cancellationToken)
        {            
            if(context.ChangeType == ChangeType.Modified)
            {
                var history = _mapper.Map<VideoInfoHistory>(context.UnmodifiedEntity);
                _userDataContext.VideoInfoHistory.Add(history);
            }                                                
            return Task.CompletedTask;
        }
    }
}
