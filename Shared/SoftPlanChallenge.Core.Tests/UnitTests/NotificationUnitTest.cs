using SoftPlanChallenge.Core.Notifications;
using Xunit;

namespace SoftPlanChallenge.Core.Tests.UnitTests
{
    public class NotificationUnitTest
    {
        private readonly INotificationHandler _notification;

        public NotificationUnitTest()
        {
            _notification = new NotificationHandler();
        }

        [Fact]
        public void Should_Add_Notification()
        {
            _notification.RaiseError("Test");

            Assert.True(_notification.HasNotifications());
        }

        [Fact]
        public void Should_Get_Notifications()
        {
            _notification.RaiseError("Test");

            Assert.True(_notification.GetNotifications().Count == 1);
        }

        [Fact]
        public void Should_Has_Notifications()
        {
            _notification.RaiseError("Test");

            Assert.True(_notification.HasNotifications());
        }
    }
}
