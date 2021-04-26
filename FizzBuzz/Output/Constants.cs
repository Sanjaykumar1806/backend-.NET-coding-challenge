using System;
namespace FizzBuzz.Output
{
    public static class Constants
    {
        #region Engine Constants
        public static readonly string DivBy3 = "div by 3";
        public static readonly string DivBy5 = "div by 5";
        public static readonly string DivBy3Output = "Fizz";
        public static readonly string DivBy5Output = "Buzz";
        #endregion

        #region Error Message
        public static readonly string DivByExceptionMessage = "Dividing by 0 is not allowed.";
        public static readonly string ObjectNullExceptionMessage = "Rules or Output objects cannot be null.";

        public static readonly Func<string, string, string> ExecutionExcpetionMessage = (exceptionMessage, innerExceptionMessage) => $"Unable to set the result. Exception Message:{exceptionMessage}, InnerException: {innerExceptionMessage}";
        #endregion
    }
}
