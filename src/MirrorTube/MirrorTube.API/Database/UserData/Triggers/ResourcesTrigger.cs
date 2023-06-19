using AutoMapper;
using EntityFrameworkCore.Triggered;
using MirrorTube.Common.Models.Database.UserData;

namespace MirrorTube.API.Database.UserData.Triggers
{
    public class ResourcesTrigger : IBeforeSaveTrigger<LookupResources>
    {
        private readonly UserDataContext _userDataContext;
        private readonly IMapper _mapper;
        public ResourcesTrigger(UserDataContext userDataContext, IMapper mapper)
        {
            _userDataContext = userDataContext;
            _mapper = mapper;
        }

        Task IBeforeSaveTrigger<LookupResources>.BeforeSave(ITriggerContext<LookupResources> context, CancellationToken cancellationToken)
        {
            if(context.ChangeType == ChangeType.Added)
            {
                
                var groupId = _userDataContext.LookupResources.Max(x => (int?)x.GroupId) ?? 0;
                if(groupId == 0)
                {
                    groupId = 1;
                }
                else
                {
                    groupId++;
                }

                context.Entity.GroupId = groupId;
                var hist = new LookupResourcesHistory()
                {
                    AcroFsId = context.Entity.AcroFsId,
                    PreviousAcroFsId = null,
                    Timestamp = DateTimeOffset.UtcNow,
                    GroupId = groupId
                };
                _userDataContext.LookupResourcesHistory.Add(hist);
            }
            else if(context.ChangeType == ChangeType.Modified)
            {
                if(context.UnmodifiedEntity != null)
                {
                    var prevEntry = _userDataContext.LookupResourcesHistory.Find(context.UnmodifiedEntity.AcroFsId);
                    var hist = new LookupResourcesHistory()
                    {
                        AcroFsId = context.Entity.AcroFsId,
                        PreviousAcroFsId = prevEntry?.AcroFsId,
                        Timestamp = DateTimeOffset.UtcNow,
                        GroupId = context.Entity.GroupId
                    };
                    _userDataContext.LookupResourcesHistory.Add(hist);
                }
            }

            return Task.CompletedTask;
        }
    }
}
