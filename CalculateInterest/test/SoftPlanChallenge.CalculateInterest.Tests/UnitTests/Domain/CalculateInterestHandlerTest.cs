using Microsoft.Extensions.Configuration;
using NSubstitute;
using SoftPlanChallenge.CalculateInterest.Domain.CommandHandlers;
using SoftPlanChallenge.CalculateInterest.Domain.Commands;
using SoftPlanChallenge.CalculateInterest.Domain.ServiceClients;
using SoftPlanChallenge.Core.Notifications;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SoftPlanChallenge.CalculateInterest.Tests.UnitTests.Domain
{
    public class CalculateInterestHandlerTest
    {
        private readonly INotificationHandler _notification;
        private readonly IInterestTaxClient _http;
        private readonly IConfiguration _configuration;

        public CalculateInterestHandlerTest()
        {
            _notification = new NotificationHandler();
            _http = Substitute.For<IInterestTaxClient>();
            _configuration = Substitute.For<IConfiguration>();
        }

        [Theory]
        [InlineData(100, 5, "105.10")]
        [InlineData(120, 3, "123.63")]
        [InlineData(550, 8, "595.57")]
        public async Task Should_Calculate_Interest(double initialValue, int months, string expectedResult)
        {
            _http.GetInterestTaxAsync().ReturnsForAnyArgs(x =>
            {
                return Task.FromResult("0.01");
            });

            var calculateInterestCommand = new CalculateInterestCommand(initialValue, months);

            var result = await new CalculateInterestHandler(_http, _notification, _configuration).Handle(calculateInterestCommand, new CancellationToken());

            Assert.True(result == expectedResult);
            Assert.True(!_notification.HasNotifications());
        }

        [Fact]
        public async Task Should_Not_Calculate_Interest_Because_Has_Notification()
        {
            var calculateInterestCommand = new CalculateInterestCommand(100, 5);

            await new CalculateInterestHandler(_http, _notification, _configuration).Handle(calculateInterestCommand, new CancellationToken());

            Assert.True(_notification.HasNotifications());
        }
    }
}
