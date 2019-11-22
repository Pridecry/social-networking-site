using System;

namespace DieteticSNS.Application.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static string TimeAgo(this DateTime dateTime)
        {
            TimeZoneInfo localZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, localZone);

            var dateTimeNow = DateTime.UtcNow;
            var timeSpan = dateTimeNow - dateTime;

            if (dateTime.Year != dateTimeNow.Year)
            {
                return localTime.ToString("MMMM d, yyyy");
            }
            else if (timeSpan.Days > 30)
            {
                return localTime.ToString("MMMM d");
            }
            else if (timeSpan.Days > 1)
            {
                return localTime.ToString("MMMM d 'at' h:mm tt");
            }
            else if (timeSpan.Days == 1)
            {
                return "Yesterday at " + dateTime.ToString("h:mm tt");
            }
            else if (timeSpan.Hours > 0)
            {
                return timeSpan.Hours == 1 ? "an hour ago" : $"{ timeSpan.Hours } hours ago";
            }
            else if (timeSpan.Minutes > 0)
            {
                return timeSpan.Minutes == 1 ? "a minute ago" : $"{ timeSpan.Minutes } minutes ago";
            }
            else if (timeSpan.Seconds >= 0)
            {
                return "just now";
            }
            else return "";
        }
    }
}
