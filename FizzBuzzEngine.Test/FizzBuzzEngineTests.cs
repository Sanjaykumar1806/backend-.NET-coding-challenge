using FizzBuzz.Rules;
using FizzBuzz.Output;
using Moq;
using FizzBuzz.Engines;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz.tests.Rules
{
    [TestClass]
    public class FizzBuzzEngineTests
    {
        [TestMethod]
        public void WithEmptyRulesObject_PrintOnlyNumbers()
        {
            // arrange
            InitMocks(out var mockOutput, out var mockRules);
            var limit = 3;
            var fizzBuzzEngine = new FizzBuzzEngines(new IRules[0] { }, mockOutput.Object);

            // act
            fizzBuzzEngine.Run(limit);

            // assert
            VerifyOutputResultPassedOnlyNumbers(3, mockOutput);
        }

        [TestMethod]
        public void ConfiguredMoreThanOneRule_ShouldCallEachRuleOnceForEeveryNumber()
        {
            // arrange
            InitMocks(out var mockOutput, out var mockRules);
            mockRules.Setup(x => x.CanApply(It.IsAny<int>())).Returns(true);
            mockRules.Setup(x => x.Apply(It.IsAny<int>())).Returns(Constants.DivBy3Output);
            var mockRule2 = new Mock<IRules>();
            mockRule2.Setup(x => x.CanApply(It.IsAny<int>())).Returns(true);
            var limit = 2;
            var fizzBuzzEngine = new FizzBuzzEngines(new IRules[] { mockRules.Object, mockRule2.Object }, mockOutput.Object);

            // act
            fizzBuzzEngine.Run(limit);

            // assert
            VerifyCanHandleWasCalledNTimes(mockRules, 2);
            VerifyCanHandleWasCalledNTimes(mockRule2, 2);
        }

        [TestMethod]
        public void PassMissMatchingRule_ShouldNotCallHandle()
        {
            // arrange
            InitMocks(out var mockOutput, out var mockRules);
            var missMatchingRule = new Mock<IRules>();
            missMatchingRule.Setup(x => x.CanApply(It.IsAny<int>())).Returns(false);
            var limit = 1;
            var fizzBuzzEngine = new FizzBuzzEngines(new IRules[] { missMatchingRule.Object }, mockOutput.Object);

            // act
            fizzBuzzEngine.Run(limit);

            // assert
            VerifyHandleWasNeverCalled(missMatchingRule);
        }

        [TestMethod]
        public void WhenRuleCanHandleReturnsTrue_ShouldCallWriteOuputWithRuleValue()
        {
            // arrange
            InitMocks(out var mockOutput, out var mockRules);
            mockRules.Setup(x => x.CanApply(It.IsAny<int>())).Returns(true);
            mockRules.Setup(x => x.Apply(It.IsAny<int>())).Returns(Constants.DivBy3Output);
            var limit = 1;
            var fizzBuzzEngine = new FizzBuzzEngines(new IRules[] { mockRules.Object }, mockOutput.Object);

            // act
            fizzBuzzEngine.Run(limit);

            // assert
            VerifyOutputResultWasCalledWithPassedValue(Times.Once(), Constants.DivBy3Output, mockOutput);
        }

        //Should be called for each test. In case, tests are running paralleling in build server.
        public void InitMocks(out Mock<IOutput> displayOutputMock, out Mock<IRules> rulesMock)
        {
            displayOutputMock = new Mock<IOutput>();
            rulesMock = new Mock<IRules>();
        }

        private void VerifyOutputResultPassedOnlyNumbers(int times, Mock<IOutput> mockOutput)
        {
            int num;
            mockOutput.Verify(x => x.DisplayResult(It.IsAny<int>(), It.Is<string>(p => int.TryParse(p, out num))), Times.Exactly(times));
        }

        private void VerifyOutputResultWasCalledWithPassedValue(Times times, string value, Mock<IOutput> mockOutput)
        {
            mockOutput.Verify(x => x.DisplayResult(It.IsAny<int>(), It.Is<string>(p => p == value)), times);
        }

        private void VerifyCanHandleWasCalledNTimes(Mock<IRules> rule, int times)
        {
            rule.Verify(x => x.CanApply(It.IsAny<int>()), Times.Exactly(times));
        }

        private void VerifyHandleWasNeverCalled(Mock<IRules> rule)
        {
            rule.Verify(x => x.Apply(It.IsAny<int>()), Times.Never());
        }
    }
}