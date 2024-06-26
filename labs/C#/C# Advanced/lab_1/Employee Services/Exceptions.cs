using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Services
{
    /// <summary>
    /// Base exception class for all exceptions in the application
    /// Ready to implement more features in its constructor if need
    /// But for now, it just takes a message and passes it to the base class
    /// </summary>
    public class BaseException : Exception
    {
        public BaseException(string message = "An error occured") : base(message)
        {
        }
    }

    /// <summary>
    /// Hiring year exception
    /// Derived from <c>BaseException</c>
    /// Only throw the default/givin message to the base class
    /// </summary>
    public class HiringYearException : BaseException
    {
        public HiringYearException(string message = "Invalid Hiring year") : base(message)
        {
        }
    }

    /// <summary>
    /// Hiring month exception
    /// Derived from <c>BaseException</c>
    /// Only throw the default/givin message to the base class
    /// </summary>
    public class HiringMonthException : BaseException
    {
        public HiringMonthException(string message = "Invalid Hiring month") : base(message)
        {
        }
    }

    /// <summary>
    /// Hiring day exception
    /// Derived from <c>BaseException</c>
    /// Only throw the default/givin message to the base class
    /// </summary>
    public class HiringDayException : BaseException
    {
        public HiringDayException(string message = "Invalid Hiring day") : base(message)
        {
        }
    }
}
