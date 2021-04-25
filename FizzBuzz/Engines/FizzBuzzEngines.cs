using System;
using System.Collections.Generic;
using System.Text;
using FizzBuzz.Output;
using FizzBuzz.Rules;

namespace FizzBuzz.Engines
{
    public class FizzBuzzEngines : IFizzBuzzEngine
    {
        private readonly IEnumerable<IRules> _engineRules;
        private readonly IOutput _outputResult;

        public FizzBuzzEngines(IEnumerable<IRules> rules, IOutput displayOutput)
        {
            if (rules == null || displayOutput == null)
            {
                throw new ArgumentNullException(Constants.ObjectNullExceptionMessage);
            }

            _engineRules = rules;
            _outputResult = displayOutput;
        }

        public void Run(int limit = 100)
        {
            var output = new StringBuilder();
            try
            {
                for (int num = 1; num <= limit; num++)
                {
                    output.Clear();

                    foreach (var rule in _engineRules)
                    {
                        if (rule.CanApply(num))
                        {
                            output.Append(rule.Apply(num));
                        }
                    }

                    if (output.Length < 1)
                    {
                        output.Append(num);
                    }

                    _outputResult.DisplayResult(num, output.ToString());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(Constants.ExecutionExcpetionMessage(exception.Message, exception.InnerException.Message));
            }
        }
    }
}
