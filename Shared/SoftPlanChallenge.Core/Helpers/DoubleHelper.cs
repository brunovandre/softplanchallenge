using System;

namespace SoftPlanChallenge.Core.Helpers
{
    public static class DoubleHelper
    {
        public static double Truncate(this double value, int decimalPlaces)
        {
            var tmp = Math.Pow(10, decimalPlaces);
            var truncatedValue = Math.Truncate(tmp * value);
            return truncatedValue / tmp;
        }
    }
}
