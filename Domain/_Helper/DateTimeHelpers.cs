using System;

namespace Domain.Helper
{
    public class DateTimeHelpers
    {
        public int CalculateAge(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day)) age--;
            return age;
        }

        public DateTime TruncSeconds(DateTime date)
        {
            return date
                .AddSeconds(-date.Second)
                .AddMilliseconds(-date.Millisecond);

        }

        public DateTime TruncTime(DateTime date)
        {
            return date
                .AddHours(-date.Hour)
                .AddMinutes(-date.Minute)
                .AddSeconds(-date.Second)
                .AddMilliseconds(-date.Millisecond);
        }
    }
}
