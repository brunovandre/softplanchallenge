using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftPlanChallenge.Core.Notifications
{
    public class NotificationHandler : INotificationHandler
    {
        private List<Notification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
            => _notifications;

        public bool HasNotifications()
            => _notifications.Any();

        public void RaiseError(string message)
          =>  _notifications.Add(new Notification(message));
    }
}
