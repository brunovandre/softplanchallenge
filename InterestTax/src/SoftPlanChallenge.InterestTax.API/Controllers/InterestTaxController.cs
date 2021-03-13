using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftPlanChallenge.Core.Controllers;
using SoftPlanChallenge.Core.Notifications;
using SoftPlanChallenge.InterestTax.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftPlanChallenge.InterestTax.API.Controllers
{
    [Route(RouteConsts.InterestTax)]
    [ApiController]
    public class InterestTaxController : BaseController
    {
        private readonly IInterestTaxRepository _interestTaxRepository;

        public InterestTaxController(
            INotificationHandler notification,
            IInterestTaxRepository interestTaxRepository) : base(notification)
        {
            _interestTaxRepository = interestTaxRepository;
        }
        
        [HttpGet]
        public IActionResult GetInterestTax()
        {
            var response = _interestTaxRepository.GetInterestTax();

            return HandleResponse(response);
        }
    }
}
