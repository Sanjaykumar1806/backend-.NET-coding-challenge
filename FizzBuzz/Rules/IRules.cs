/*
 * Interface for implementing different Rules, which can be implemented/extended by different Rules in the future as well. 
 */


namespace FizzBuzz.Rules
{
    public interface IRules
    {
        bool CanApply(int value);
        string Apply(int value);
    }
}
