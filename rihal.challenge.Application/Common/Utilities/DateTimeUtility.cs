
using System;

namespace rihal.challenge.Application.Common.Utilities
{
    public static class DateTimeUtility
    {
        private static readonly string[] DateFormats = { "dd/MM/yyyy", "dd-MM-yyyy", "d/M/yyyy", "d-M-yyyy", "M/d/yyyy", "M-d-yyyy",
            "yyyy-MM-dd", "yyyy-MM-d", "yyyy-M-dd", "yyyy-M-d" ,"dd/MM/yyyyTHH:mm:ss", "dd-MM-yyyyTHH:mm:ss","d/M/yyyyTHH:mm:ss", "d-M-yyyyTHH:mm:ss",
            "M/d/yyyyTHH:mm:ss", "M-d-yyyyTHH:mm:ss","dd/MM/yyyyTHH:mm:s", "d/M/yyyyTH:m:s", "dddd, MMMM dd,yyyy hh:mm tt","dddd, MMMM dd,yyyy"   };

        public static string ConvertDateTimeFormated(DateTime? dateTime)
        {
            if (dateTime.HasValue == false)
            {
                return string.Empty;
            }

            return dateTime.Value.ToString("ddd, MMM dd,yyyy hh:mm tt");
        }

        public static string ConvertDateFormated(DateTime? dateTime)
        {
            if (dateTime.HasValue == false)
            {
                return string.Empty;
            }

            return dateTime.Value.ToString("ddd, MMM dd,yyyy");
        }

        public static string ConvertDateFormatedShorted(DateTime? dateTime)
        {
            if (dateTime.HasValue == false)
            {
                return string.Empty;
            }

            return dateTime.Value.ToString("dd/MM/yyyy");
        }

        public static string ConvertDayFormat(DateTime? dateTime)
        {
            if (dateTime.HasValue == false)
            {
                return string.Empty;
            }

            return dateTime.Value.ToString("dddd");
        }
        public static string ConvertTime24Formatted(DateTime? dateTime)
        {
            if (dateTime.HasValue == false)
            {
                return string.Empty;
            }

            return dateTime.Value.ToString("HH:mm");
        }
        public static string ConvertToMessageTime(DateTime? dateTime)
        {
            if (dateTime.HasValue == false)
            {
                return string.Empty;
            }

            TimeSpan timeDifference = DateTime.Now.Subtract(dateTime.Value);
            if (timeDifference.Days > 0)
            {
                return dateTime.Value.ToString("MMM dd");
            }
            else
            {
                return dateTime.Value.ToString("HH:mm");
            }
        }


        public static string ConvertTimeSpentFormated(double? timeSpentSeconds)
        {
            if (timeSpentSeconds.HasValue == false)
            {
                return string.Empty;
            }

            TimeSpan timeSpan = TimeSpan.FromSeconds(timeSpentSeconds.Value);
            string timeSpentFormated = timeSpan.ToString(@"hh\:mm\:ss");

            return timeSpentFormated;
        }


    }
}
