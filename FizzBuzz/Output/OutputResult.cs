using System;
namespace FizzBuzz.Output
{
    public class OutputResult : IOutput
    {
        public void DisplayResult(int value, string input)
        {
            Console.WriteLine("{0}: {1}", value, input);
        }
    }
}
