using System;

namespace SmartExtensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets a DateTime representing the first day of the month of DateTime
        /// </summary>
        /// <param name="current">The current date</param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime current)
        {
            DateTime first = current.AddDays(1 - current.Day);
            return first;
        }

        /// <summary>
        /// Gets a DateTime representing the first specific day of the month of the provided DateTime
        /// </summary>
        /// <param name="current">The current day</param>
        /// <param name="dayOfWeek">The current day of week</param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime current, DayOfWeek dayOfWeek)
        {
            DateTime first = current.FirstDayOfMonth();

            if (first.DayOfWeek != dayOfWeek)
            {
                first = first.NextSpecificDay(dayOfWeek);
            }

            return first;
        }

        /// <summary>
        /// Gets a DateTime representing the first date following the current date which falls on the given day of the week
        /// </summary>
        /// <param name="current">The current date</param>
        /// <param name="dayOfWeek">The day of week for the next date to get</param>
        public static DateTime NextSpecificDay(this DateTime current, DayOfWeek dayOfWeek)
        {
            int offsetDays = dayOfWeek - current.DayOfWeek;

            if (offsetDays <= 0)
            {
                offsetDays += 7;
            }

            DateTime result = current.AddDays(offsetDays);
            return result;
        }

        /// <summary>
        /// Gets a DateTime representing the last day of the month in the provided DateTime
        /// </summary>
        /// <param name="current">The current date</param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime current)
        {
            int daysInMonth = DateTime.DaysInMonth(current.Year, current.Month);

            DateTime last = current.FirstDayOfMonth().AddDays(daysInMonth - 1);
            return last;
        }

        /// <summary>
        /// Gets a DateTime representing the last specific day of the month in the provided DateTime
        /// </summary>
        /// <param name="current">The current date</param>
        /// <param name="dayOfWeek">The current day of week</param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime current, DayOfWeek dayOfWeek)
        {
            DateTime last = current.LastDayOfMonth();

            last = last.AddDays(Math.Abs(dayOfWeek - last.DayOfWeek) * -1);
            return last;
        }

        /// <summary>
        /// Gets a DateTime representing midnight on the current date
        /// </summary>
        /// <param name="current">The current date</param>
        public static DateTime GetMidnight(this DateTime current)
        {
            DateTime midnight = new DateTime(current.Year, current.Month, current.Day);
            return midnight;
        }

        /// <summary>
        /// Gets a DateTime representing noon on the current date
        /// </summary>
        /// <param name="current">The current date</param>
        public static DateTime GetNoon(this DateTime current)
        {
            DateTime noon = new DateTime(current.Year, current.Month, current.Day, 12, 0, 0);
            return noon;
        }
        /// <summary>
        /// Sets the time of the current date with minute precision
        /// </summary>
        /// <param name="current">The current date</param>
        /// <param name="hour">The hour</param>
        /// <param name="minute">The minute</param>
        public static DateTime SetTime(this DateTime current, int hour, int minute)
        {
            return current.SetTime(hour, minute, 0, 0);
        }

        /// <summary>
        /// Sets the time of the current date with second precision
        /// </summary>
        /// <param name="current">The current date</param>
        /// <param name="hour">The hour</param>
        /// <param name="minute">The minute</param>
        /// <param name="second">The second</param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime current, int hour, int minute, int second)
        {
            return current.SetTime(hour, minute, second, 0);
        }

        /// <summary>
        /// Sets the time of the current date with millisecond precision
        /// </summary>
        /// <param name="current">The current date</param>
        /// <param name="hour">The hour</param>
        /// <param name="minute">The minute</param>
        /// <param name="second">The second</param>
        /// <param name="millisecond">The millisecond</param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime current, int hour, int minute, int second, int millisecond)
        {
            DateTime atTime = new DateTime(current.Year, current.Month, current.Day, hour, minute, second, millisecond);
            return atTime;
        }

        /// <summary>
        /// Gets the age of a person
        /// </summary>
        /// <param name="dateOfBirth">The date of birth</param>
        public static int Age(this DateTime dateOfBirth)
        {
            if (DateTime.Today.Month < dateOfBirth.Month ||
                DateTime.Today.Month == dateOfBirth.Month &&
                DateTime.Today.Day < dateOfBirth.Day)
            {
                return DateTime.Today.Year - dateOfBirth.Year - 1;
            }

            return DateTime.Today.Year - dateOfBirth.Year;
        }
    }
}