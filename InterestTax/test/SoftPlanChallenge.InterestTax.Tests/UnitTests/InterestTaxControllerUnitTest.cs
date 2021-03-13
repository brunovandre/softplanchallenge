using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SoftPlanChallenge.Core.Notifications;
using SoftPlanChallenge.InterestTax.API.Controllers;
using SoftPlanChallenge.InterestTax.Infra.Data.Interfaces;
using Xunit;

namespace SoftPlanChallenge.InterestTax.Tests.UnitTests
{
    public class InterestTaxControllerUnitTest
    {
        private readonly IInterestTaxRepository _interestTaxRepository;
        private readonly NotificationHandler _notification;

        public InterestTaxControllerUnitTest()
        {
            _interestTaxRepository = Substitute.For<IInterestTaxRepository>();
            _notification = new NotificationHandler();
        }

        [Fact]
        public void Should_Get_Interest_Tax()
        {
            var expectedResult = 0.01;

            _interestTaxRepository.GetInterestTax().ReturnsForAnyArgs(x =>
            {
                return 0.01;
            });

            var actionResult = new InterestTaxController(_notification, _interestTaxRepository).GetInterestTax();
            var result = actionResult as OkObjectResult;

            Assert.True((double)result.Value == expectedResult);
        }
    }
}
