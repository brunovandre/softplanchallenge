using MediatR;
using Microsoft.Extensions.Configuration;
using SoftPlanChallenge.CalculateInterest.Domain.Commands;
using SoftPlanChallenge.CalculateInterest.Domain.ServiceClients;
using SoftPlanChallenge.Core.Helpers;
using SoftPlanChallenge.Core.Notifications;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SoftPlanChallenge.CalculateInterest.Domain.CommandHandlers
{
    public class CalculateInterestHandler : IRequestHandler<CalculateInterestCommand, double>
    {
        private readonly IInterestTaxClient _interestTaxClienthttp;
        private readonly INotificationHandler _notification;
        private readonly IConfiguration _configuration;

        public CalculateInterestHandler(
            IInterestTaxClient interestTaxClienthttp,
            INotificationHandler notification,
            IConfiguration configuration)
        {
            _interestTaxClienthttp = interestTaxClienthttp;
            _notification = notification;
            _configuration = configuration;
        }

        public async Task<double> Handle(CalculateInterestCommand request, CancellationToken cancellationToken)
        {
            var interest = await _interestTaxClienthttp.GetInterestTaxAsync();
            if (string.IsNullOrWhiteSpace(interest))
            {
                _notification.RaiseError("Não foi possível obter a taxa de juros.");
                return default;
            }

            var result = request.ValorInicial * Math.Pow(1 + double.Parse(interest), request.Meses);

            return result.Truncate(2);
        }
    }
}
