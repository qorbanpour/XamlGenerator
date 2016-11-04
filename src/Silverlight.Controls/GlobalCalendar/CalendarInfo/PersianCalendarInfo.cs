namespace Silverlight.Controls
{
    using System;
    using System.Globalization;

    using Silverlight.Controls.Globalization;

    /// <summary>
    /// Provides globalized calendar operations based on the <see cref="PersianCalendar"/>.
    /// </summary>
    public class PersianCalendarInfo : CalendarInfo
    {
        #region Constants and Fields

        /// <summary>
        /// The Calendar that provides our date operations.
        /// </summary>
        private readonly PersianCalendar _Calendar;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersianCalendarInfo"/> class.
        /// </summary>
        public PersianCalendarInfo()
        {
            this._Calendar = new PersianCalendar();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="DateTimeFormatInfo"/> to use for formatting.
        /// </summary>
        public override DateTimeFormatInfo DateFormatInfo
        {
            get { return this._Calendar.DateTimeFormat; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a <see cref="DateTime"/> that is the specified number of days away from
        /// the specified <c>DateTime</c>.
        /// </summary>
        /// <param name="day">
        /// The <c>DateTime</c> to which to add days.
        /// </param>
        /// <param name="days">
        /// The number of days to add.
        /// </param>
        /// <returns>
        /// The <c>DateTime</c> that results from adding the specified number of days
        /// to the specified <c>DateTime</c>.
        /// </returns>
        public override DateTime? AddDays(DateTime day, int days)
        {
            try
            {
                return this._Calendar.AddDays(day, days);
            }
            catch( ArgumentException )
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> that is the specified number of months away from
        /// the specified <c>DateTime</c>.
        /// </summary>
        /// <param name="day">
        /// The <c>DateTime</c> to which to add months.
        /// </param>
        /// <param name="months">
        /// The number of months to add.
        /// </param>
        /// <returns>
        /// The <c>DateTime</c> that results from adding the specified number of months
        /// to the specified <c>DateTime</c>.
        /// </returns>
        public override DateTime? AddMonths(DateTime day, int months)
        {
            try
            {
                return this._Calendar.AddMonths(day, months);
            }
            catch( ArgumentException )
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> that is the specified number of years away from
        /// the specified <c>DateTime</c>.
        /// </summary>
        /// <param name="day">
        /// The <c>DateTime</c> to which to add years.
        /// </param>
        /// <param name="years">
        /// The number of years to add.
        /// </param>
        /// <returns>
        /// The <c>DateTime</c> that results from adding the specified number of years
        /// to the specified <c>DateTime</c>.
        /// </returns>
        public override DateTime? AddYears(DateTime day, int years)
        {
            try
            {
                return this._Calendar.AddYears(day, years);
            }
            catch( ArgumentException )
            {
                return null;
            }
        }

        /// <summary>
        /// Compares two instances of <see cref="DateTime"/> and returns an integer that
        /// indicates whether the first instance is earlier than, the same as,
        /// or later than the second instance.
        /// </summary>
        /// <param name="first">
        /// The first <c>DateTime</c>.
        /// </param>
        /// <param name="second">
        /// The second <c>DateTime</c>.
        /// </param>
        /// <returns>
        /// Less than zero indicates that first is less than second, zero
        /// indicates that first equals second, and greater than zero indicated
        /// that second is greater than first.
        /// </returns>
        public override int Compare(DateTime first, DateTime second)
        {
            if( second < this._Calendar.MinSupportedDateTime )
                second = this._Calendar.MinSupportedDateTime;
            if( first < this._Calendar.MinSupportedDateTime )
                first = this._Calendar.MinSupportedDateTime;

            return DateTime.Compare(first, second);
        }

        /// <summary>
        /// Compares the days of two instances of <see cref="DateTime"/> and returns an
        /// integer that indicates whether the first instance is earlier than,
        /// the same as, or later than the second instance.
        /// </summary>
        /// <param name="first">
        /// The first <c>DateTime</c>.
        /// </param>
        /// <param name="second">
        /// The second <c>DateTime</c>.
        /// </param>
        /// <returns>
        /// Less than zero indicates that first is less than second, zero
        /// indicates that first equals second, and greater than zero indicated
        /// that second is greater than first.
        /// </returns>
        public override int CompareDays(DateTime first, DateTime second)
        {
            return this.Compare(first.Date, second.Date);
        }

        /// <summary>
        /// Convert a <see cref="DateTime"/> to a long format string.
        /// </summary>
        /// <param name="date">
        /// The <c>DateTime</c>.
        /// </param>
        /// <returns>
        /// Long format string representation of the date.
        /// </returns>
        public override string DateToLongString(DateTime date)
        {
            int year, month, day;
            this.GetDateParts(date, out year, out month, out day);

            var dayOfWeek = this._Calendar.GetDayOfWeek(date);
            var dayName = this._Calendar.DateTimeFormat.GetDayName(dayOfWeek);
            var monthName = this._Calendar.DateTimeFormat.GetMonthName(month);

            return this._Calendar.DateTimeFormat.LongDatePattern
                .Replace("dddd", dayName)
                .Replace("dd", day.ToString())
                .Replace("MMMM", monthName)
                .Replace("yyyy", year.ToString());
        }

        /// <summary>
        /// Convert a <see cref="DateTime"/> to a string.
        /// </summary>
        /// <param name="date">
        /// The <c>DateTime</c>.
        /// </param>
        /// <returns>
        /// String representation of the date.
        /// </returns>
        public override string DateToString(DateTime date)
        {
            int year, month, day;
            this.GetDateParts(date, out year, out month, out day);

            return this._Calendar.DateTimeFormat.ShortDatePattern
                .Replace("yyyy", year.ToString())
                .Replace("MM", month.ToString())
                .Replace("dd", day.ToString());
        }

        /// <summary>
        /// Convert the day of a <see cref="DateTime"/> to a string.
        /// </summary>
        /// <param name="day">
        /// The <c>DateTime</c>.
        /// </param>
        /// <returns>
        /// String representation of the day of a <c>DateTime</c>.
        /// </returns>
        public override string DayToString(DateTime day)
        {
            return this._Calendar.GetDayOfMonth(day).ToString();
        }

        /// <summary>
        /// Convert a decade range to a string.
        /// </summary>
        /// <param name="decadeStart">
        /// The start of the decade.
        /// </param>
        /// <param name="decadeEnd">
        /// The end of the decade.
        /// </param>
        /// <returns>
        /// String representation of the decade range.
        /// </returns>
        public override string DecadeToString(int decadeStart, int decadeEnd)
        {
            // In the event that the decades are outside of DateTime.MinValue
            // and DateTime.MaxValue, we'll handle the ArgumentException and
            // just display the numbers as ints
            try
            {
                return string.Format("{0:####}-{1:####}",
                    this._Calendar.GetYear(new DateTime(decadeStart, 1, 1)),
                    this._Calendar.GetYear(new DateTime(decadeEnd, 1, 1)));
            }
            catch( ArgumentException )
            {
                return string.Format("{0}-{1}", decadeStart, decadeEnd);
            }
        }

        /// <summary>
        /// Get the day of the week of a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="day">
        /// The <c>DateTime</c>.
        /// </param>
        /// <returns>
        /// The day of the week of a <c>DateTime</c>.
        /// </returns>
        public override DayOfWeek GetDayOfWeek(DateTime day)
        {
            return this._Calendar.GetDayOfWeek(day);
        }

        /// <summary>
        /// Get the end of the DateTime's decade.
        /// </summary>
        /// <param name="day">
        /// The <c>DateTime</c>.
        /// </param>
        /// <returns>
        /// The end of the DateTime's decade.
        /// </returns>
        public override int GetDecadeEnd(DateTime day)
        {
            return this.GetDecadeStart(day) + 9;
        }

        /// <summary>
        /// Get the start of the DateTime's decade.
        /// </summary>
        /// <param name="day">
        /// The <c>DateTime</c>.
        /// </param>
        /// <returns>
        /// The start of the DateTime's decade.
        /// </returns>
        public override int GetDecadeStart(DateTime day)
        {
            var year = this._Calendar.GetYear(day);
            var start = year - (year % 10);
            return this._Calendar.ToDateTime(start + 1, 1, 1).Year;
        }

        /// <summary>
        /// Get the first day in the month of a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="day">
        /// The <c>DateTime</c>.
        /// </param>
        /// <returns>
        /// The first day in the month of a <c>DateTime</c>.
        /// </returns>
        public override DateTime GetFirstDayInMonth(DateTime day)
        {
            int year, month;
            this.GetDateParts(day, out year, out month);

            return this._Calendar.ToDateTime(year, month, 1);
        }

        /// <summary>
        /// Get the first day in the year of a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="day">
        /// The <c>DateTime</c>.
        /// </param>
        /// <returns>
        /// The first day in the year of a <c>DateTime</c>.
        /// </returns>
        public override DateTime GetFirstDayInYear(DateTime day)
        {
            var year = this._Calendar.GetYear(day);
            return this._Calendar.ToDateTime(year, 1, 1);
        }

        /// <summary>
        /// Get the number of months between two dates.
        /// </summary>
        /// <param name="first">
        /// The first date.
        /// </param>
        /// <param name="second">
        /// The second date.
        /// </param>
        /// <returns>
        /// The number of months between the two dates.
        /// </returns>
        public override int GetMonthDifference(DateTime first, DateTime second)
        {
            if( second < this._Calendar.MinSupportedDateTime )
                second = this._Calendar.MinSupportedDateTime;
            if( first < this._Calendar.MinSupportedDateTime )
                first = this._Calendar.MinSupportedDateTime;

            int fYear, fMonth, sYear, sMonth;
            this.GetDateParts(first, out fYear, out fMonth);
            this.GetDateParts(second, out sYear, out sMonth);

            return (12 * (fYear - sYear)) + (fMonth - sMonth);
        }

        /// <summary>
        /// Convert the year and month of a <see cref="DateTime"/> to a string.
        /// </summary>
        /// <param name="day">
        /// The <c>DateTime</c>.
        /// </param>
        /// <returns>
        /// String representation of the year and month of a <c>DateTime</c>.
        /// </returns>
        public override string MonthAndYearToString(DateTime day)
        {
            int year, month;
            this.GetDateParts(day, out year, out month);

            return new DateTime(year, month, 1).ToString("Y", this._Calendar.DateTimeFormat);
        }

        /// <summary>
        /// Converts the specified string representation of a date and time to
        /// its <see cref="T:System.DateTime"/> equivalent using the current
        /// culture information.
        /// </summary>
        /// <param name="date">
        /// A string that contains a date to convert.
        /// </param>
        /// <returns>
        /// An object that is equivalent to the date and time contained
        /// in the <paramref name="date"/> parameter, as specified by the
        /// current culture information.
        /// </returns>
        public override DateTime Parse(string date)
        {
            const string FormatExceptionMessage = "Specified date is not correct.";

            if( date == null )
                throw new FormatException(FormatExceptionMessage);
            if( string.IsNullOrWhiteSpace(date) )
                throw new FormatException(FormatExceptionMessage);

            var parts = date.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if( parts.Length != 3 )
                throw new FormatException(FormatExceptionMessage);

            var year = int.Parse(parts[0]);
            var month = int.Parse(parts[1]);
            var day = int.Parse(parts[2]);

            if( month > 12 || month < 1 || day < 1 || (month < 7 && day > 31) || (month > 7 && day > 30) )
                throw new FormatException(FormatExceptionMessage);

            if( day > 1000 )
            {
                var temp = day;
                day = year;
                year = temp;
            }

            return this._Calendar.ToDateTime(year, month, day);
        }

        /// <summary>
        /// Convert the year of a <see cref="DateTime"/> to a string.
        /// </summary>
        /// <param name="day">
        /// The <c>DateTime</c>.
        /// </param>
        /// <returns>
        /// String representation of the year of a <c>DateTime</c>.
        /// </returns>
        public override string YearToString(DateTime day)
        {
            return this._Calendar.GetYear(day).ToString();
        }

        #endregion

        #region Methods

        private void GetDateParts(DateTime date, out int year, out int month)
        {
            int day;
            this.GetDateParts(date, out year, out month, out day);
        }

        private void GetDateParts(DateTime date, out int year, out int month, out int day)
        {
            year = this._Calendar.GetYear(date);
            month = this._Calendar.GetMonth(date);
            day = this._Calendar.GetDayOfMonth(date);
        }

        #endregion
    }
}