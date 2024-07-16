namespace Exceptions
{
    /// <summary>
    /// Class <c>NameNotCapitalizedException</c> is an exception for when a name is not capitalized
    /// <param><c>message</c> is the message to be displayed when the exception is thrown</param>
    /// </summary>
    public class NameNotCapitalizedException : BaseException
    {
        public NameNotCapitalizedException(string message = "Name must be Capitalized") : base(message) { }

        public NameNotCapitalizedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Class <c>NameTooShortException</c> is an exception for when a name is too short
    /// <param><c>message</c> is the message to be displayed when the exception is thrown</param>
    /// </summary>
    public class NameTooShortException : BaseException
    {
        public NameTooShortException(string message = "Name is too short, must be 3 characters or more") : base(message) { }

        public NameTooShortException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Class <c>NameTooLongException</c> is an exception for when a name is too long
    /// <param><c>message</c> is the message to be displayed when the exception is thrown</param>
    /// </summary>
    public class NameTooLongException : BaseException
    {
        public NameTooLongException(string message = "Name is too long, must be 10 characters or less") : base(message) { }

        public NameTooLongException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
