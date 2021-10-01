// ***********************************************************************
// Assembly         : PSC.Extensions
// Author           : enric
// Blog             :
// Blog URL         :
// Created          : 09-24-2021
//
// Last Modified By : enric
// Last Modified On : 09-24-2021
// ***********************************************************************
// <copyright file="DateExtensions.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini
// </copyright>
// <summary></summary>
// ***********************************************************************
using PSC.Extensions.Enums;
using System;

namespace PSC.Extensions
{
	/// <summary>
	/// Date Extensions
	/// </summary>
	public static class DateExtensions
	{
		/// <summary>
		/// Calculate Ascencion day
		/// </summary>
		/// <param name="selectDate">Current date (but not before 1583)</param>
		/// <returns>DateTime</returns>
		/// <remarks>Ascencion day is always 10 days before Whit Sunday.</remarks>
		public static DateTime AscensionDay(this DateTime selectDate)
		{
			return EasterSunday(selectDate).AddDays(39);
		}

		/// <summary>
		/// Calculate Ash Wednesday
		/// </summary>
		/// <param name="selectDate">Current date (but not before 1583)</param>
		/// <returns>DateTime</returns>
		/// <remarks>Ash Wednesday marks the start of Lent. This is the 40 day period between before Easter</remarks>
		public static DateTime AshWednesday(this DateTime selectDate)
		{
			return EasterSunday(selectDate).AddDays(-46);
		}

		/// <summary>
		/// Get the first day of christmas
		/// </summary>
		/// <param name="selectDate">Date</param>
		/// <returns>DateTime</returns>
		/// <remarks>Is always on December 25.</remarks>
		public static DateTime ChristmasDay(this DateTime selectDate)
		{
			return new DateTime(selectDate.Year, 12, 25);
		}

		/// <summary>
		/// Calculate the first Sunday of Advent
		/// </summary>
		/// <param name="selectDate">Current date (but not before 1583)</param>
		/// <returns>DateTime</returns>
		/// <remarks>The first sunday of advent is the first sunday at least 4 weeks before christmas</remarks>
		public static DateTime FirstSundayOfAdvent(this DateTime selectDate)
		{
			int weeks = 4;
			int correction = 0;
			DateTime christmas = ChristmasDay(selectDate);

			if (christmas.DayOfWeek != DayOfWeek.Sunday)
			{
				weeks--;
				correction = ((int)christmas.DayOfWeek - (int)DayOfWeek.Sunday);
			}

			return christmas.AddDays(-1 * ((weeks * 7) + correction));
		}

		/// <summary>
		/// Generate random DateTime between range
		/// </summary>
		/// <param name="min">The minimum.</param>
		/// <param name="max">The maximum.</param>
		/// <returns>DateTime.</returns>
		public static DateTime GetRandomDateTime(this DateTime? min, DateTime? max = null)
		{
			min = min ?? new DateTime(1753, 01, 01);
			max = max ?? new DateTime(9999, 12, 31);

			var rnd = new Random();
			var range = max.Value - min.Value;
			var randomUpperBound = (Int32)range.TotalSeconds;
			if (randomUpperBound <= 0)
				randomUpperBound = rnd.Next(1, Int32.MaxValue);

			var randTimeSpan = TimeSpan.FromSeconds((Int64)(range.TotalSeconds - rnd.Next(0, randomUpperBound)));
			return min.Value.Add(randTimeSpan);
		}

		/// <summary>
		/// Calculate Good Friday
		/// </summary>
		/// <param name="selectDate">Current date (but not before 1583)</param>
		/// <returns>DateTime</returns>
		/// <remarks>Good Friday is the Friday before easter.</remarks>
		public static DateTime GoodFriday(this DateTime selectDate)
		{
			return EasterSunday(selectDate).AddDays(-2);
		}

		/// <summary>
		/// Calculate Easter Sunday day
		/// </summary>
		/// <param name="selectDate">Current date (but not before 1583)</param>
		/// <returns>DateTime.</returns>
		public static DateTime EasterSunday(this DateTime selectDate)
		{
			int day = 0;
			int month = 0;
			int year = selectDate.Year;

			int g = year % 19;
			int c = year / 100;
			int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
			int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

			day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
			month = 3;

			if (day > 31)
			{
				month++;
				day -= 31;
			}

			return new DateTime(year, month, day);
		}

		/// <summary>
		/// Calculate Palm Sunday
		/// </summary>
		/// <param name="selectDate">Current date (but not before 1583)</param>
		/// <returns>DateTime</returns>
		/// <remarks>Palm Sunday is the sunday one week before easter.</remarks>
		public static DateTime PalmSunday(this DateTime selectDate)
		{
			return EasterSunday(selectDate).AddDays(-7);
		}

		/// <summary>
		/// Calculate Whit Sunday
		/// </summary>
		/// <param name="selectDate">Current date (but not before 1583)</param>
		/// <returns>DateTime</returns>
		/// <remarks>Whit Sunday is always 7 weeks after Easter</remarks>
		public static DateTime WhitSunday(this DateTime selectDate)
		{
			return EasterSunday(selectDate).AddDays(49);
		}

		/// <summary>
		/// Dates the difference.
		/// </summary>
		/// <param name="dtStart">The dt start.</param>
		/// <param name="dtEnd">The dt end.</param>
		/// <param name="interval">The interval.</param>
		/// <returns>System.Int32.</returns>
		public static double DateDiff(this DateTime dtStart, DateTime dtEnd, DateInterval interval)
		{
			double rtn = 0;
			TimeSpan timespan = (dtStart - dtEnd);

			switch (interval)
			{
				case DateInterval.Day:
					rtn = timespan.TotalDays;
					break;

				case DateInterval.Hour:
					rtn = timespan.TotalHours;
					break;

				case DateInterval.Minute:
					rtn = timespan.TotalMinutes;
					break;

				case DateInterval.Second:
					rtn = timespan.TotalSeconds;
					break;
			}

			return rtn;
		}
	}
}