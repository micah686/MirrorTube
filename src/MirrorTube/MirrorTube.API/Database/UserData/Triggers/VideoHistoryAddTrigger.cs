using EntityFrameworkCore.Triggered;
using MirrorTube.Common.Models.Database.UserData;

namespace MirrorTube.API.Database.UserData.Triggers
{
    public class VideoHistoryAddTrigger : IBeforeSaveTrigger<VideoInfo>
    {
        private readonly UserDataContext _userDataContext;
        public VideoHistoryAddTrigger(UserDataContext context)
        {
            _userDataContext = context;
        }

        Task IBeforeSaveTrigger<VideoInfo>.BeforeSave(ITriggerContext<VideoInfo> context, CancellationToken cancellationToken)
        {
            if(context.ChangeType == ChangeType.Modified)
            {
                if(context.UnmodifiedEntity != null)
                {
                    _userDataContext.VideoInfoHistory.Add(new VideoInfoHistory
                    {
                        ExternalVideoID = context.UnmodifiedEntity.ExternalVideoID //TODO: Set up automapper
                    });
                }
            }
            
            return Task.CompletedTask;
        }
    }
}
