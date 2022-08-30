using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace rihal.challenge.Application.Common.Utilities
{
    public static class StringsUtiltiy
    {
        public static string GetRandomString(int noChar = 10)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, noChar)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool IsAllEnglishAndNumbersChars(string stringToCheck)
        {
            Regex regexEng = new Regex(@"^[A-Za-z\d\s*()_-]+$");
            return regexEng.IsMatch(stringToCheck);
        }

        public static bool IsAllArabicAndNumbersChars(string stringToCheck)
        {
            Regex regexAr = new Regex(@"^[\u0600-\u06FF\d\s*()]+$");
            return regexAr.IsMatch(stringToCheck);
        }

        public static string SplitCamelCase(string inputCamelCaseString)
        {
            string sTemp = Regex.Replace(inputCamelCaseString, "([A-Z][a-z])", " $1", RegexOptions.Compiled).Trim();
            return Regex.Replace(sTemp, "([A-Z][A-Z])", " $1", RegexOptions.Compiled).Trim();
        }

        public static bool IsStartWithEnglishChar(string stringToCheck)
        {
            if (string.IsNullOrEmpty(stringToCheck))
            {
                return false;
            }

            return IsAllEnglishAndNumbersChars(stringToCheck[0].ToString());
        }

        public static T[] ConvertStringCommaSeperatedArray<T>(string stringToSplit)
        {
            if (stringToSplit.LastOrDefault() == ',')
            {
                stringToSplit = stringToSplit.Remove(stringToSplit.Length - 1);
            }

            string[] array = stringToSplit.Split(',');
            T[] convertedArray = Array.ConvertAll(array, x => (T)Convert.ChangeType(x, typeof(T)));
            return convertedArray;
        }
    }
}
