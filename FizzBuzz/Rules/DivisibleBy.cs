using System;
using FizzBuzz.Output;

namespace FizzBuzz.Rules
{
    public class DivisibleBy : IRules
    {
        private readonly string output;
        private readonly int divisableBy;

        public DivisibleBy(string output, int divisableBy)
        {
            if (string.IsNullOrWhiteSpace(output))
            {
                throw new ArgumentNullException(nameof(output));
            }

            if (divisableBy == 0)
            {
                throw new ArgumentException(Constants.DivByExceptionMessage, nameof(divisableBy));
            }
            this.output = output;
            this.divisableBy = divisableBy;
        }

        public bool CanApply(int value)
        {
            return value % divisableBy == 0;
        }

        public string Apply(int value)
        {
            return output;
        }
    }
}
