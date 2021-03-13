using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftPlanChallenge.CalculateInterest.Domain.Commands;
using SoftPlanChallenge.Core.Controllers;
using SoftPlanChallenge.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftPlanChallenge.CalculateInterest.API.Controllers
{
    [Route(RouteConsts.CalculateInterest)]
    [ApiController]
    public class CalculateInterestController : BaseController
    {
        private readonly IMediator _mediator;

        public CalculateInterestController(
            INotificationHandler notification,
            IMediator mediator) :base(notification)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CalculateInterestAsync([FromQuery] CalculateInterestCommand command)
        {
            var response = await _mediator.Send(command);

            return HandleResponse(response);
        }
    }
}
