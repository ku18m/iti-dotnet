using ErrorsLog;


namespace Exceptions
{
    /// <summary>
    /// Class <c>BaseException</c> is the base class for all exceptions in this namespace
    /// <param><c>message</c> is the message to be displayed when the exception is thrown</param>
    /// </summary>
    [Serializable]
    public class BaseException : Exception
    {
        public BaseException(string message = "An Error occurred!") : base(message) {
            Logger.Log(this);
        }

        public BaseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
