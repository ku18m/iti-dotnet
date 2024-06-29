namespace Company_Layoff_System
{
    /// <summary>
    /// <c>LayoffException</c> is a custom exception class that is used to catch exceptions related to the Layoff System.
    /// To make it easier to catch the Layoff related exceptions, then we can catch this exception and then check the inner exception.
    /// </summary>
    public class LayoffException : Exception
    {
        public LayoffException(string message) : base(message)
        {
        }
    }

    public class VacationLayoffException : LayoffException
    {
        public VacationLayoffException(string message = "Vacation Stock Depleted") : base(message)
        {
        }
    }

    public class AgeLayoffException : LayoffException
    {
        public AgeLayoffException(string message = "Employee is over 60 years old") : base(message)
        {
        }
    }

    public class InvalidVacationRequestException : Exception
    {
        public InvalidVacationRequestException(string message = "Invalid Vacation Request") : base(message)
        {
        }
    }
}
