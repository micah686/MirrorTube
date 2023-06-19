using EntityFrameworkCore.Triggered;
using MirrorTube.Common.Models.Database.UserData;

namespace MirrorTube.API.Database.UserData.Triggers
{
    public class TestTrigger : IBeforeSaveTrigger<TestUser>
    {
        private readonly UserDataContext _userDataContext;
        public TestTrigger(UserDataContext userDataContext)
        {
            _userDataContext = userDataContext;
        }

        Task IBeforeSaveTrigger<TestUser>.BeforeSave(ITriggerContext<TestUser> context, CancellationToken cancellationToken)
        {
            context.Entity.DateTime = DateTime.UtcNow;
            //_userDataContext.Users.Add(context.Entity);
            return Task.CompletedTask;
        }
    }
}
