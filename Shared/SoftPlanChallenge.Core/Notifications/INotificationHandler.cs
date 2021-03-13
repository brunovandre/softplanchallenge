using System;
using System.Collections.Generic;

namespace SoftPlanChallenge.Core.Notifications
{
    public interface INotificationHandler
    {
        bool HasNotifications();
        List<Notification> GetNotifications();
        void RaiseError(string message);
    }
}
