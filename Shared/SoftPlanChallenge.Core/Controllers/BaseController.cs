using Microsoft.AspNetCore.Mvc;
using SoftPlanChallenge.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlanChallenge.Core.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly INotificationHandler _notificationHandler;

        public BaseController(
            INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }

        protected IActionResult HandleResponse(object data = null)
        {
            var response = GetResponse(data);

            if (_notificationHandler.HasNotifications())
                return BadRequest(response);

            return Ok(response);
        }

        private object GetResponse(object data = null)
        {
            if (_notificationHandler.HasNotifications())
                return _notificationHandler.GetNotifications();

            return data;
        }

    }
}
