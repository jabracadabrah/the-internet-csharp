using Framework.ExtentReport;
using NUnit.Framework;

namespace Framework.Assertions
{
    public class IntAsserts
    {
        private int _actual;

        public IntAsserts(int actual)
        {
            _actual = actual;
        }

        public void BeGreaterThan(int smallernum)
        {
            Assert.That(_actual, Is.GreaterThan(smallernum));
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, $"Assertion Passed: {_actual} is greater than {smallernum}");
        }

        public void BeSmallerThan(int biggernum)
        {
            Assert.That(_actual, Is.LessThan(biggernum));
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, $"Assertion Passed: {_actual} is less than {biggernum}");
        }

        public void Equal(int num)
        {
            Assert.That(_actual, Is.EqualTo(num));
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, $"Assertion Passed: {_actual} is equal {num}");
        }
    }
}
