using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlanChallenge.CalculateInterest.Domain.Commands
{
    public class CalculateInterestCommand : IRequest<string>
    {
        public double ValorInicial { get; set; }
        public int Meses { get; set; }

        public CalculateInterestCommand(double valorInicial, int meses)
        {
            ValorInicial = valorInicial;
            Meses = meses;
        }

        public CalculateInterestCommand(){}
    }
}