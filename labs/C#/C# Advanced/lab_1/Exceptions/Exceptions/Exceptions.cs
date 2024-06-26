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

    public class SerializableException
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public string HelpLink { get; set; }

        public SerializableException() { }

        public SerializableException(BaseException exception)
        {
            Message = exception.Message;
            StackTrace = exception.StackTrace;
            Source = exception.Source;
            HelpLink = exception.HelpLink;
        }

        public BaseException ToBaseException()
        {
            return new BaseException(Message)
            {
                Source = this.Source,
                HelpLink = this.HelpLink
            };
        }
    }
}
