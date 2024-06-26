using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Services
{
    /// <summary>
    /// struct to represent the hiring date of an employee
    /// <para>It has three properties: year, month, and day</para>
    /// </summary>
    public struct HiringDate: IComparable<HiringDate>
    {
        int year;
        int month;
        int day;

        /// <summary>
        /// Year of hiring property
        /// <para>It must be greater than (current year - 42) maximum Emp age is 60 and minimum hiring age is 18, and less than the current year
        /// Throws <c>HiringYearException</c>HiringYearException if the year is out of range.
        /// </para>
        /// </summary>
        int Year
        {
            get { return year; }
            set { 
                if (value < (DateTime.Now.Year - 42) || value > DateTime.Now.Year)
                {
                    throw new HiringYearException($"Hiring year must be greater than ${DateTime.Now.Year - 42}");
                }
                else
                {
                    year = value;
                }
            }
        }

        /// <summary>
        /// Month of hiring property
        /// <para>
        /// Default month restriction
        /// Throws <c>HiringMonthException</c> if the month is out of range.
        /// </para>
        /// </summary>
        int Month
        {
            get { return month; }
            set {
                if (value < 1 || value > 12)
                {
                    throw new HiringMonthException();
                }
                else
                {
                    month = value;
                }
            }
        }

        /// <summary>
        /// <para>
        /// Hiring day property
        /// Throws <c>HiringDayException</c> if the day is out of range.
        /// </para>
        /// </summary>
        int Day
        {
            get { return day; }
            set {
                if (value < 1 || value > 31)
                {
                    throw new HiringDayException();
                }
                else
                {
                    day = value;
                }
            }
        }

        /// <summary>
        /// Constructor to initialize the hiring date
        /// <param name="year">Represent the hiring year</param>
        /// <param name="month">Represent the hiring month</param>
        /// <param name="day">Represent the hiring day</param>
        /// </summary>
        public HiringDate(int year, int month, int day)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }

        /// <summary>
        /// Override the ToString method to return the hiring date in the format "Year/Month/Day"
        /// </summary>
        /// <returns>String representative of the struct</returns>
        public override string ToString()
        {
            return $"{Year}/{Month}/{Day}";
        }

        /// <summary>
        /// Compare two hiring dates using IComparable interface
        /// <param name="other">hiring date to compare with</param>
        /// </summary>
        public int CompareTo(HiringDate other)
        {
            int thisDate = this.Year * 100 + this.Month * 10 + this.Day;
            int otherDate = other.Year * 100 + other.Month * 10 + other.Day;

            return thisDate.CompareTo(otherDate);
        }

        /// <summary>
        /// Overload the default operator <c><</c> to compare two hiring dates
        /// </summary>
        /// <param name="left">Left hiring date</param>
        /// <param name="right">Right hiring date</param>
        /// <returns>True if left <c><</c> right, otherwise false</returns>
        public static bool operator <(HiringDate left, HiringDate right)
        {
            int leftDate = left.Year * 100 + left.Month * 10 + left.Day;
            int rightDate = right.Year * 100 + right.Month * 10 + right.Day;
            return leftDate < rightDate;
        }

        /// <summary>
        /// Overload the default operator <c>></c> to compare two hiring dates
        /// </summary>
        /// <param name="left">Left hiring date</param>
        /// <param name="right">Right hiring date</param>
        /// <returns>True if left <c>></c> right, otherwise false</returns>
        public static bool operator >(HiringDate left, HiringDate right)
        {
            int leftDate = left.Year * 100 + left.Month * 10 + left.Day;
            int rightDate = right.Year * 100 + right.Month * 10 + right.Day;
            return leftDate > rightDate;
        }
    }
}
