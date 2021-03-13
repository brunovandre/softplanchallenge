using Microsoft.AspNetCore.Mvc;
using SoftPlanChallenge.Core.Controllers;
using SoftPlanChallenge.Core.Notifications;

namespace SoftPlanChallenge.CalculateInterest.API.Controllers
{
    [Route(RouteConsts.ShowMeTheCode)]
    [ApiController]
    public class ShowMeTheCodeController : BaseController
    {
        public ShowMeTheCodeController
            (INotificationHandler notification) : base(notification){ }
        
        [HttpGet]
        public IActionResult ShowMeTheCode()
        {
            var response = "https://github.com/brunovandre/softplanchallenge";

            return HandleResponse(response);
        }
    }
}
