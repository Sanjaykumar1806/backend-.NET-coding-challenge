using System;
namespace FizzBuzz.Output
{
    public static class Constants
    {
        #region Engine Constants
        public static string DivBy3 = "div by 3";
        public static string DivBy5 = "div by 5";
        public static string DivBy3Output = "Fizz";
        public static string DivBy5Output = "Buzz";
        #endregion

        #region Error Message
        public static string DivByExceptionMessage = "Dividing by 0 is not allowed.";
        public static string ObjectNullExceptionMessage = "Rules or Output objects cannot be null.";

        public static Func<string, string, string> ExecutionExcpetionMessage = (exceptionMessage, innerExceptionMessage) => $"Unable to set the result. Exception Message:{exceptionMessage}, InnerException: {innerExceptionMessage}";
        #endregion
    }
}
