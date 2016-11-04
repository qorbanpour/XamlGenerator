// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersianCalendar.cs" company="Mr.T">
//   Copyright (c) 2011 All Right Reserved.
//
// This source is subject to the Microsoft Permissive License.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// </copyright>
// <author>Mohammadreza Taikandi</author>
// <email>mrtaikandi@gmail.com</email>
// <date>2011-10-2</date>
// <summary>
//   Contains class and functions requries to convert Gregorian calendar to Persian and viseversa. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Silverlight.Controls.Globalization
{
    using System;
    using System.Globalization;

    ////////////////////////////////////////////////////////////////////////////
    // Notes about PersianCalendar
    ////////////////////////////////////////////////////////////////////////////
    /*
    **  Calendar support range:
    **      Calendar    Minimum     Maximum
    **      ==========  ==========  ==========
    **      Gregorian   0622/03/21   9999/12/31
    **      Persian     0001/01/01   9378/10/10
    */

    /// <summary>
    /// Represents time in divisions, such as weeks, months, and years for Persian calendar.
    /// </summary>
    public class PersianCalendar : Calendar
    {
        // Number of 100ns (10E-7 second) ticks per time unit
        // private const int DEFAULT_TWO_DIGIT_YEAR_MAX = 1410;
        #region Constants and Fields

        /// <summary>
        /// Represents the current era. This field is constant.
        /// </summary>
        public static readonly int PersianEra = 1;

        private const int DateCycle = 33;
        private const int DatePartDay = 3;
        private const int DatePartDayOfYear = 1;
        private const int DatePartMonth = 2;
        private const int DatePartYear = 0;
        private const long DaysPerCycle = DateCycle * 365 + LeapYearsPerCycle;
        private const long GregorianOffset = 226894; // GregorianCalendar.GetAbsoluteDate(622, 3, 21);
        private const int LeapYearsPerCycle = 8;

        private const int MaxCalendarDay = 10;
        private const int MaxCalendarMonth = 10;

        /// <summary>
        /// <c>DateTime.MaxValue</c> = Persian calendar (year:9378, month: 10, day: 10).
        /// </summary> 
        private const int MaxCalendarYear = 9378;

        private const long MaxSeconds = Int64.MaxValue / TicksPerSecond;
        private const int MillisPerSecond = 1000;
        private const long MinSeconds = Int64.MinValue / TicksPerSecond;
        private const long TicksPerDay = TicksPerHour * 24;
        private const long TicksPerHour = TicksPerMinute * 60;
        private const long TicksPerMillisecond = 10000;
        private const long TicksPerMinute = TicksPerSecond * 60;
        private const long TicksPerSecond = TicksPerMillisecond * 1000;
        private static readonly int[] DaysToMonth = { 0, 31, 62, 93, 124, 155, 186, 216, 246, 276, 306, 336 };

        /// <summary>
        /// Leap years, if <c>Y % 33</c> is 1,5,9,13,17,22,26,30.
        /// </summary>
        private static readonly int[] LeapYears33 = 
                                                    {
                                                        0, 1, 0, 0, 0, // 0  [1]  2   3   4
                                                        1, 0, 0, 0, 1, // [5]  6   7   8  [9]
                                                        0, 0, 0, 1, 0, // 10  11  12 [13] 14
                                                        0, 0, 1, 0, 0, // 15  16 [17] 18  19
                                                        0, 0, 1, 0, 0, // 20  21 [22] 23  24
                                                        0, 1, 0, 0, 0, // 25 [26] 27  28  29
                                                        1, 0, 0
                                                    }; // [30] 31  32

        private static readonly DateTime MaxDate = DateTime.MaxValue;

        /// <summary>
        /// Persian calendar (year: 1, month: 1, day:1 ) = Gregorian (year: 622, month: 3, day: 21)
        /// This is the minimal Gregorian date that we support in the <c>PersianCalendar</c>.
        /// </summary>
        private static readonly DateTime MinDate = new DateTime(622, 3, 21);

        #endregion

        /*
                private const int CalendarGregorian = 1;     // Gregorian (localized) calendar
                private const int CalendarGregorianUs = 2;     // Gregorian (U.S.) calendar
                private const int CalendarPersian = 22;
        */
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersianCalendar"/> class.
        /// </summary>
        public PersianCalendar()
        {
            var shortestDayNames = new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
            var monthNames = new[]
                {
                    "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", 
                    "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", string.Empty
                };
            var dayNames = new[] { "یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه" };

            this.DateTimeFormat = new DateTimeFormatInfo
                {
                    ShortestDayNames = shortestDayNames,
                    AbbreviatedMonthNames = monthNames,
                    AbbreviatedDayNames = shortestDayNames,
                    AbbreviatedMonthGenitiveNames = monthNames,
                    MonthNames = monthNames,
                    AMDesignator = "بامداد",
                    PMDesignator = "شامگاه",
                    DayNames = dayNames,
                    FirstDayOfWeek = DayOfWeek.Saturday,
                    YearMonthPattern = "yyyy، MMMM",
                    FullDateTimePattern = "dddd، dd MMMM yyyy HH:mm:ss",
                    LongDatePattern = "dddd، dd MMMM yyyy",
                    MonthDayPattern = "dd MMMM",
                    ShortDatePattern = "yyyy/MM/dd"
                };
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the type of the Persian calendar.
        /// </summary>
        public CalendarAlgorithmType AlgorithmType
        {
            get { return CalendarAlgorithmType.SolarCalendar; }
        }

        ///<summary>
        /// Returns an instance of <see cref="DateTimeFormatInfo"/> base on the Persian calendar.
        ///</summary>
        public DateTimeFormatInfo DateTimeFormat { get; private set; }

        /// <summary>
        /// Gets the list of eras in the current calendar.
        /// </summary>
        /// <value></value>
        /// <returns>An array of integers that represents the eras in the current calendar.</returns>
        public override int[] Eras
        {
            get { return new[] { PersianEra }; }
        }

        /// <summary>
        /// Gets the latest date and time supported by this <see cref="T:System.Globalization.Calendar"/> object.
        /// </summary>
        /// <value></value>
        /// <returns>The latest date and time supported by this calendar. The default is <see cref="F:System.DateTime.MaxValue"/>.</returns>
        public override DateTime MaxSupportedDateTime
        {
            get { return MaxDate; }
        }

        /// <summary>
        /// Gets the earliest date and time supported by this <see cref="T:System.Globalization.Calendar"/> object.
        /// </summary>
        /// <value></value>
        /// <returns>The earliest date and time supported by this calendar. The default is <see cref="F:System.DateTime.MinValue"/>.</returns>
        public override DateTime MinSupportedDateTime
        {
            get { return MinDate; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a <see cref="T:System.DateTime"/> that is the specified number of months away from the specified <see cref="T:System.DateTime"/>.
        /// </summary>
        /// <param name="time">
        /// The <see cref="T:System.DateTime"/> to which to add months.
        /// </param>
        /// <param name="months">
        /// The number of months to add.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.DateTime"/> that results from adding the specified number of months to the specified <see cref="T:System.DateTime"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        /// The resulting <see cref="T:System.DateTime"/> is outside the supported range of this calendar. 
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="months"/> is outside the supported range of the <see cref="T:System.DateTime"/> return value. 
        /// </exception>
        public override DateTime AddMonths(DateTime time, int months)
        {
            if( months < -120000 || months > 120000 )
                throw new ArgumentOutOfRangeException("months");

            // Get the date in Persian calendar.
            var y = this.GetDatePart(time.Ticks, DatePartYear);
            var m = this.GetDatePart(time.Ticks, DatePartMonth);
            var d = this.GetDatePart(time.Ticks, DatePartDay);
            var i = m - 1 + months;

            if( i >= 0 )
            {
                m = i % 12 + 1;
                y = y + i / 12;
            }
            else
            {
                m = 12 + (i + 1) % 12;
                y = y + (i - 11) / 12;
            }

            var days = this.GetDaysInMonth(y, m);
            if( d > days )
                d = days;

            var ticks = this.GetAbsoluteDatePersian(y, m, d) * TicksPerDay + time.Ticks % TicksPerDay;
            CheckAddResult(ticks, this.MinSupportedDateTime, this.MaxSupportedDateTime);

            return new DateTime(ticks);
        }

        /// <summary>
        /// Adds the years.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// </returns>
        public override DateTime AddYears(DateTime time, int value)
        {
            return this.AddMonths(time, value * 12);
        }

        /// <summary>
        /// Returns the day of the month in the specified <see cref="T:System.DateTime"/>.
        /// </summary>
        /// <param name="time">
        /// The <see cref="T:System.DateTime"/> to read.
        /// </param>
        /// <returns>
        /// A positive integer that represents the day of the month in the <paramref name="time"/> parameter.
        /// </returns>
        public override int GetDayOfMonth(DateTime time)
        {
            time = NormalizeDate(time);
            return this.GetDatePart(time.Ticks, DatePartDay);
        }

        /// <summary>
        /// Returns the day of the week in the specified <see cref="T:System.DateTime"/>.
        /// </summary>
        /// <param name="time">
        /// The <see cref="T:System.DateTime"/> to read.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.DayOfWeek"/> value that represents the day of the week in the <paramref name="time"/> parameter.
        /// </returns>
        public override DayOfWeek GetDayOfWeek(DateTime time)
        {
            return (DayOfWeek)((int)(time.Ticks / TicksPerDay + 1) % 7);
        }

        /// <summary>
        /// Returns the day of the year in the specified <see cref="T:System.DateTime"/>.
        /// </summary>
        /// <param name="time">
        /// The <see cref="T:System.DateTime"/> to read.
        /// </param>
        /// <returns>
        /// A positive integer that represents the day of the year in the <paramref name="time"/> parameter.
        /// </returns>
        public override int GetDayOfYear(DateTime time)
        {
            return this.GetDatePart(time.Ticks, DatePartDayOfYear);
        }

        /// <summary>
        /// Returns the number of days in the specified month, year, and era.
        /// </summary>
        /// <param name="year">
        /// An integer that represents the year.
        /// </param>
        /// <param name="month">
        /// A positive integer that represents the month.
        /// </param>
        /// <param name="era">
        /// An integer that represents the era.
        /// </param>
        /// <returns>
        /// The number of days in the specified month in the specified year in the specified era.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="year"/> is outside the range supported by the calendar.-or- <paramref name="month"/> is outside the range supported by the calendar.-or- <paramref name="era"/> is outside the range supported by the calendar. 
        /// </exception>
        public override int GetDaysInMonth(int year, int month, int era)
        {
            CheckYearMonthRange(year, month, era);

            if( (month == MaxCalendarMonth) && (year == MaxCalendarYear) )
                return MaxCalendarDay;

            if( month == 12 )
            {
                // For the 12th month, leap year has 30 days, and common year has 29 days.
                return this.IsLeapYear(year, CurrentEra) ? 30 : 29;
            }

            // Other months first 6 months are 31 and the reset are 30 days.
            return (month > 6) ? 30 : 31;
        }

        /// <summary>
        /// Returns the number of days in the specified year and era.
        /// </summary>
        /// <param name="year">
        /// An integer that represents the year.
        /// </param>
        /// <param name="era">
        /// An integer that represents the era.
        /// </param>
        /// <returns>
        /// The number of days in the specified year in the specified era.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="year"/> is outside the range supported by the calendar.-or- <paramref name="era"/> is outside the range supported by the calendar. 
        /// </exception>
        public override int GetDaysInYear(int year, int era)
        {
            CheckYearRange(year, era);
            if( year == MaxCalendarYear )
                return DaysToMonth[MaxCalendarMonth - 1] + MaxCalendarDay;

            // Common years have 365 days.  Leap years have 366 days.
            return this.IsLeapYear(year, CurrentEra) ? 366 : 365;
        }

        /// <summary>
        /// Returns the era in the specified <see cref="T:System.DateTime"/>.
        /// </summary>
        /// <param name="time">
        /// The <see cref="T:System.DateTime"/> to read.
        /// </param>
        /// <returns>
        /// An integer that represents the era in <paramref name="time"/>.
        /// </returns>
        public override int GetEra(DateTime time)
        {
            CheckTicksRange(time.Ticks);
            return PersianEra;
        }

        /// <summary>
        /// Calculates the leap month for a specified year and era.
        /// </summary>
        /// <param name="year">
        /// A year.
        /// </param>
        /// <param name="era">
        /// An era.
        /// </param>
        /// <returns>
        /// A positive integer that indicates the leap month in the specified year and era.-or-Zero if this calendar does not support a leap month or if the <paramref name="year"/> and <paramref name="era"/> parameters do not specify a leap year.
        /// </returns>
        public override int GetLeapMonth(int year, int era)
        {
            CheckYearRange(year, era);
            return 0;
        }

        /// <summary>
        /// Returns the month in the specified <see cref="T:System.DateTime"/>.
        /// </summary>
        /// <param name="time">
        /// The <see cref="T:System.DateTime"/> to read.
        /// </param>
        /// <returns>
        /// A positive integer that represents the month in <paramref name="time"/>.
        /// </returns>
        public override int GetMonth(DateTime time)
        {
            time = NormalizeDate(time);
            return this.GetDatePart(time.Ticks, DatePartMonth);
        }

        /// <summary>
        /// Returns the number of months in the specified year in the specified era.
        /// </summary>
        /// <param name="year">
        /// An integer that represents the year.
        /// </param>
        /// <param name="era">
        /// An integer that represents the era.
        /// </param>
        /// <returns>
        /// The number of months in the specified year in the specified era.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="year"/> is outside the range supported by the calendar.-or- <paramref name="era"/> is outside the range supported by the calendar. 
        /// </exception>
        public override int GetMonthsInYear(int year, int era)
        {
            CheckYearRange(year, era);
            if( year == MaxCalendarYear )
                return MaxCalendarMonth;
            return 12;
        }

        /// <summary>
        /// Returns the year in the specified <see cref="T:System.DateTime"/>.
        /// </summary>
        /// <param name="time">
        /// The <see cref="T:System.DateTime"/> to read.
        /// </param>
        /// <returns>
        /// An integer that represents the year in <paramref name="time"/>.
        /// </returns>
        public override int GetYear(DateTime time)
        {
            time = NormalizeDate(time);

            return this.GetDatePart(time.Ticks, DatePartYear);
        }

        /// <summary>
        /// Determines whether the specified date in the specified era is a leap day.
        /// </summary>
        /// <param name="year">
        /// An integer that represents the year.
        /// </param>
        /// <param name="month">
        /// A positive integer that represents the month.
        /// </param>
        /// <param name="day">
        /// A positive integer that represents the day.
        /// </param>
        /// <param name="era">
        /// An integer that represents the era.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified day is a leap day; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="year"/> is outside the range supported by the calendar.-or- <paramref name="month"/> is outside the range supported by the calendar.-or- <paramref name="day"/> is outside the range supported by the calendar.-or- <paramref name="era"/> is outside the range supported by the calendar. 
        /// </exception>
        public override bool IsLeapDay(int year, int month, int day, int era)
        {
            // The year/month/era value checking is done in GetDaysInMonth().
            var daysInMonth = this.GetDaysInMonth(year, month, era);
            if( day < 1 || day > daysInMonth )
                throw new ArgumentOutOfRangeException("day");
            return this.IsLeapYear(year, era) && month == 12 && day == 30;
        }

        /// <summary>
        /// Determines whether the specified month in the specified year in the specified era is a leap month.
        /// </summary>
        /// <param name="year">
        /// An integer that represents the year.
        /// </param>
        /// <param name="month">
        /// A positive integer that represents the month.
        /// </param>
        /// <param name="era">
        /// An integer that represents the era.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified month is a leap month; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="year"/> is outside the range supported by the calendar.-or- <paramref name="month"/> is outside the range supported by the calendar.-or- <paramref name="era"/> is outside the range supported by the calendar. 
        /// </exception>
        public override bool IsLeapMonth(int year, int month, int era)
        {
            CheckYearMonthRange(year, month, era);
            return false;
        }

        /// <summary>
        /// Determines whether the specified year in the specified era is a leap year.
        /// </summary>
        /// <param name="year">
        /// An integer that represents the year.
        /// </param>
        /// <param name="era">
        /// An integer that represents the era.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified year is a leap year; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="year"/> is outside the range supported by the calendar.-or- <paramref name="era"/> is outside the range supported by the calendar. 
        /// </exception>
        public override bool IsLeapYear(int year, int era)
        {
            CheckYearRange(year, era);
            return LeapYears33[year % DateCycle] == 1;
        }

        /// <summary>
        /// Returns the date and time converted to a <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="year">
        /// An integer that represents the year.
        /// </param>
        /// <param name="month">
        /// A positive integer that represents the month.
        /// </param>
        /// <param name="day">
        /// A positive integer that represents the day.
        /// </param>
        /// <param name="hour">
        /// An integer from 0 to 23 that represents the hour.
        /// </param>
        /// <param name="minute">
        /// An integer from 0 to 59 that represents the minute.
        /// </param>
        /// <param name="second">
        /// An integer from 0 to 59 that represents the second.
        /// </param>
        /// <param name="millisecond">
        /// An integer from 0 to 999 that represents the millisecond.
        /// </param>
        /// <param name="era">
        /// An integer that represents the era.
        /// </param>
        /// <returns>
        /// Returns the date and time converted to a <c>DateTime</c> value.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="year"/> is outside the range supported by the calendar.-or- <paramref name="month"/> is outside the range supported by the calendar.-or- <paramref name="day"/> is outside the range supported by the calendar.-or- <paramref name="hour"/> is less than zero or greater than 23.-or- <paramref name="minute"/> is less than zero or greater than 59.-or- <paramref name="second"/> is less than zero or greater than 59.-or- <paramref name="millisecond"/> is less than zero or greater than 999.-or- <paramref name="era"/> is outside the range supported by the calendar. 
        /// </exception>
        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
        {
            // The year/month/era checking is done in GetDaysInMonth().
            var daysInMonth = this.GetDaysInMonth(year, month, era);
            if( day < 1 || day > daysInMonth )
                throw new ArgumentOutOfRangeException("day");

            var lDate = this.GetAbsoluteDatePersian(year, month, day);

            if( lDate >= 0 )
                return new DateTime(lDate * TicksPerDay + TimeToTicks(hour, minute, second, millisecond));

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Returns the date and time converted to a <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="year">
        /// The year.
        /// </param>
        /// <param name="month">
        /// The month.
        /// </param>
        /// <param name="day">
        /// The day.
        /// </param>
        /// <returns>
        /// </returns>
        public DateTime ToDateTime(int year, int month, int day)
        {
            return this.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Converts the specified year to a four-digit year by using the <see cref="P:System.Globalization.Calendar.TwoDigitYearMax"/> property to determine the appropriate century.
        /// </summary>
        /// <param name="year">
        /// A two-digit or four-digit integer that represents the year to convert.
        /// </param>
        /// <returns>
        /// An integer that contains the four-digit representation of <paramref name="year"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="year"/> is outside the range supported by the calendar. 
        /// </exception>
        public override int ToFourDigitYear(int year)
        {
            if( year < 100 )
                return base.ToFourDigitYear(year);

            if( year > MaxCalendarYear )
                throw new ArgumentOutOfRangeException("year");
            return year;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Return the tick count corresponding to the given hour, minute, second.
        /// Will check the if the parameters are valid.
        /// </summary>
        /// <param name="hour">
        /// </param>
        /// <param name="minute">
        /// </param>
        /// <param name="second">
        /// </param>
        /// <param name="millisecond">
        /// </param>
        /// <returns>
        /// </returns>
        internal static long TimeToTicks(int hour, int minute, int second, int millisecond)
        {
            if( hour >= 0 && hour < 24 && minute >= 0 && minute < 60 && second >= 0 && second < 60 )
            {
                if( millisecond < 0 || millisecond >= MillisPerSecond )
                    throw new ArgumentOutOfRangeException("millisecond");
                return TimeToTicks(hour, minute, second) + millisecond * TicksPerMillisecond;
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Return the tick count corresponding to the given hour, minute, second.
        /// Will check the if the parameters are valid.
        /// </summary>
        /// <param name="hour">
        /// The hour.
        /// </param>
        /// <param name="minute">
        /// The minute.
        /// </param>
        /// <param name="second">
        /// The second.
        /// </param>
        /// <returns>
        /// </returns>
        internal static long TimeToTicks(int hour, int minute, int second)
        {
            // totalSeconds is bounded by 2^31 * 2^12 + 2^31 * 2^8 + 2^31,
            // which is less than 2^44, meaning we won't overflow totalSeconds.
            long totalSeconds = (long)hour * 3600 + (long)minute * 60 + second;
            if( totalSeconds > MaxSeconds || totalSeconds < MinSeconds )
                throw new ArgumentOutOfRangeException();
            return totalSeconds * TicksPerSecond;
        }

        /// <summary>
        /// Checks the add result.
        /// </summary>
        /// <param name="ticks">
        /// The ticks.
        /// </param>
        /// <param name="minValue">
        /// The min value.
        /// </param>
        /// <param name="maxValue">
        /// The max value.
        /// </param>
        private static void CheckAddResult(long ticks, DateTime minValue, DateTime maxValue)
        {
            if( ticks < minValue.Ticks || ticks > maxValue.Ticks )
                throw new ArgumentException();
        }

        /// <summary>
        /// Checks the era range.
        /// </summary>
        /// <param name="era">
        /// The era.
        /// </param>
        private static void CheckEraRange(int era)
        {
            if( era != CurrentEra && era != PersianEra )
                throw new ArgumentOutOfRangeException("era", "Invalid ERA.");
        }

        /// <summary>
        /// Checks the ticks range.
        /// </summary>
        /// <param name="ticks">
        /// The ticks.
        /// </param>
        private static void CheckTicksRange(long ticks)
        {
            if( ticks < MinDate.Ticks || ticks > MaxDate.Ticks )
            {
                throw new ArgumentOutOfRangeException("ticks",
                    String.Format(CultureInfo.InvariantCulture, "tick must be between {0} and {1}", MinDate, MaxDate));
            }
        }

        /// <summary>
        /// Checks the year month range.
        /// </summary>
        /// <param name="year">
        /// The year.
        /// </param>
        /// <param name="month">
        /// The month.
        /// </param>
        /// <param name="era">
        /// The era.
        /// </param>
        private static void CheckYearMonthRange(int year, int month, int era)
        {
            CheckYearRange(year, era);
            if( year == MaxCalendarYear )
            {
                if( month > MaxCalendarMonth )
                    throw new ArgumentOutOfRangeException("month");
            }

            if( month < 1 || month > 12 )
                throw new ArgumentOutOfRangeException("month");
        }

        /// <summary>
        /// Checks the year range.
        /// </summary>
        /// <param name="year">
        /// The year.
        /// </param>
        /// <param name="era">
        /// The era.
        /// </param>
        private static void CheckYearRange(int year, int era)
        {
            CheckEraRange(era);
            if( year < 1 || year > MaxCalendarYear )
            {
                throw new ArgumentOutOfRangeException(
                    "year",
                    String.Format(
                                  CultureInfo.CurrentCulture,
                        "year must be between {0} and {1}",
                        1,
                        MaxCalendarYear));
            }
        }

        /// <summary>
        /// Normalizes the date to be between the possible minimum and maximum.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <returns>
        /// </returns>
        private static DateTime NormalizeDate(DateTime time)
        {
            if( time.Year < MinDate.Year )
                time = MinDate;
            if( time.Year > MaxDate.Year )
                time = MaxDate;
            return time;
        }

        /// <summary>
        /// Gets the total number of days (absolute date) up to the given Persian Year. The absolute date means the number of days from January 1st, 1 A.D.
        /// </summary>
        /// <param name="persianYear">
        /// <paramref name="persianYear"/> year value in Persian calendar.
        /// </param>
        /// <returns>
        /// Returns the total number of days (absolute date) up to the given Persian Year.
        /// </returns>
        private long DaysUpToPersianYear(int persianYear)
        {
            // Compute the number of 33 years cycles.
            var numCycles = (persianYear - 1) / DateCycle;

            // Compute the number of years left.  This is the number of years
            // into the 33 year cycle for the given year.
            var numYearsLeft = (persianYear - 1) % DateCycle;

            // Compute the number of absolute days up to the given year.
            var numDays = numCycles * DaysPerCycle + GregorianOffset;
            while( numYearsLeft > 0 )
            {
                numDays += 365;

                // Common year is 365 days, and leap year is 366 days.
                if( this.IsLeapYear(numYearsLeft, CurrentEra) )
                    numDays++;
                numYearsLeft--;
            }

            // Return the number of absolute days.
            return numDays;
        }

        /// <summary>
        /// Gets the Absolute date for the given Persian date. The absolute date means the number of days from January 1st, 1 A.D.
        /// </summary>
        /// <param name="year">
        /// </param>
        /// <param name="month">
        /// </param>
        /// <param name="day">
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        /// <returns>
        /// Returns the Absolute date for the given Persian date.
        /// </returns>
        private long GetAbsoluteDatePersian(int year, int month, int day)
        {
            if( year >= 1 && year <= MaxCalendarYear && month >= 1 && month <= 12 )
                return this.DaysUpToPersianYear(year) + DaysToMonth[month - 1] + day - 1;
            throw new ArgumentOutOfRangeException(null, "The value of the year, month or day parameters is out of range.");
        }

        /// <summary>
        /// Returns a given date part of this <see cref="DateTime"/>. This method is used to compute the year, day-of-year, month, or day part.
        /// </summary>
        /// <param name="ticks">
        /// </param>
        /// <param name="part">
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// if part is incorrect.
        /// </exception>
        /// <remarks>
        /// First, we get the absolute date (the number of days from January 1st, 1 A.C) for the given ticks.
        /// Use the formula (((AbsoluteDate - 226894) * 33) / (33 * 365 + 8)) + 1, we can a rough value for the Persian year.
        /// In order to get the exact Persian year, we compare the exact absolute date for PersianYear and (PersianYear + 1).
        /// From here, we can get the correct Persian year.
        /// </remarks>
        /// <returns>
        /// Returns a given date part of this <c>DateTime</c>.
        /// </returns>
        private int GetDatePart(long ticks, int part)
        {
            CheckTicksRange(ticks);

            // Get the absolute date.  The absolute date is the number of days from January 1st, 1 A.D.
            // 1/1/0001 is absolute date 1.
            var numDays = ticks / TicksPerDay + 1;

            // Calculate the approximate Persian Year from this magic formula.
            var persianYear = (int)(((numDays - GregorianOffset) * DateCycle) / DaysPerCycle) + 1;

            var daysToPersianYear = this.DaysUpToPersianYear(persianYear); // The absolute date for PersianYear
            var daysOfPersianYear = this.GetDaysInYear(persianYear, CurrentEra); // The number of days for (PersianYear+1) year.

            if( numDays < daysToPersianYear )
            {
                daysToPersianYear -= daysOfPersianYear;
                persianYear--;
            }
            else if( numDays == daysToPersianYear )
            {
                persianYear--;
                daysToPersianYear -= this.GetDaysInYear(persianYear, CurrentEra);
            }
            else
            {
                if( numDays > daysToPersianYear + daysOfPersianYear )
                {
                    daysToPersianYear += daysOfPersianYear;
                    persianYear++;
                }
            }

            if( part == DatePartYear )
                return persianYear;

            // Calculate the Persian Month.
            numDays -= daysToPersianYear;

            if( part == DatePartDayOfYear )
                return (int)numDays;

            var persianMonth = 0;
            while( (persianMonth < 12) && (numDays > DaysToMonth[persianMonth]) )
            {
                persianMonth++;
            }

            if( part == DatePartMonth )
                return persianMonth;

            // Calculate the Persian Day.
            var persianDay = (int)(numDays - DaysToMonth[persianMonth - 1]);

            if( part == DatePartDay )
                return persianDay;

            // Incorrect part value.
            throw new InvalidOperationException("Incorrect part value.");
        }

        #endregion

        ///// <summary>
        ///// Returns a <see cref="System.String"/> that represents the specified converted value of the specified <see cref="DateTime"/>.
        ///// </summary>
        ///// <param name="date">The date.</param>
        ///// <param name="format">The format.</param>
        ///// <returns>
        ///// A <see cref="System.String"/> that represents the specified converted value of the specified <see cref="DateTime"/>.
        ///// </returns>
        // public string ToString(DateTime date, string format)
        // {
        // return GetDateTime(date).ToString(format, this.DateTimeFormat);
        // }

        ///// <summary>
        ///// Returns a converted instance of <see cref="DateTime"/> to the Persian calendar.
        ///// </summary>
        ///// <param name="year">The year.</param>
        ///// <param name="month">The month.</param>
        ///// <param name="day">The day.</param>
        // public DateTime GetDateTime(int year, int month, int day)
        // {
        // return GetDateTime(new DateTime(year, month, day));
        // }
        ///// <summary>
        ///// Returns a converted instance of <see cref="DateTime"/> to the Persian calendar.
        ///// </summary>
        ///// <param name="date">The date.</param>
        // public DateTime GetDateTime(DateTime date)
        // {
        // var year = GetDatePart(date.Ticks, DatePartYear);
        // var month = GetDatePart(date.Ticks, DatePartMonth);
        // var day = GetDatePart(date.Ticks, DatePartDay);

        // return new DateTime(year, month, day, date.Hour, date.Minute, date.Second, date.Millisecond);
        // }
    }
}