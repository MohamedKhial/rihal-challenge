using System;
using System.Linq;

namespace rihal.challenge.Application.Common.Utilities
{
    public static class NumericUtility
    {
        public static bool ContainOnlyDigits(string valueToCheck)
        {
            bool isContainOnlyDigit = valueToCheck.ToString().All(ch => char.IsDigit(ch));
            if (isContainOnlyDigit)
            {
                return true;
            }

            return false;
        }

        public static double GetPercetange(int value, int totalValue, int deciaml = 2)
        {
            if (totalValue <= 0)
            {
                return 0;
            }

            return Math.Round(((double)(value) / totalValue) * 100.0, deciaml);
        }

        public static double GetAverage(int value, int totalValue, int deciaml = 2)
        {
            if (totalValue <= 0)
            {
                return 0;
            }

            return Math.Round(((double)(value) / totalValue), deciaml);
        }

        public static double GetAverageWithCeling(int value, int totalValue, int deciaml = 2)
        {
            if (totalValue <= 0)
            {
                return 0;
            }

            return Math.Ceiling(Math.Round(((double)(value) / totalValue), deciaml));
        }
    }
}
