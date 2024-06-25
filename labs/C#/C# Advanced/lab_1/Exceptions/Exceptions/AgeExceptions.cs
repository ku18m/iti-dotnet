using Exceptions;

namespace AgeExceptions
{
    /// <summary>
    /// Class <c>AgeTooYoungException</c> is an exception for when an age is too young
    /// <param><c>message</c> is the message to be displayed when the exception is thrown</param>
    /// </summary>
    public class AgeTooYoungException : BaseException
    {
        public AgeTooYoungException(string message = "Age is too young, must be 18 or older") : base(message) { }

        public AgeTooYoungException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Class <c>AgeTooOldException</c> is an exception for when an age is too old
    /// <param><c>message</c> is the message to be displayed when the exception is thrown</param>
    /// </summary>
    public class AgeTooOldException : BaseException
    {
        public AgeTooOldException(string message = "Age is too old, must be 28 or younger") : base(message) { }

        public AgeTooOldException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}