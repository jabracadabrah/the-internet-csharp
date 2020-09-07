using Framework.ExtentReport;
using NUnit.Framework;

namespace Framework.Assertions
{
    public class StringAsserts
    {
        private string _actual;

        public StringAsserts(string actual)
        {
            _actual = actual;
        }

        public void Contain(string expected)
        {
            StringAssert.Contains(expected, _actual);
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, $"Assertion Passed: Element's text contains ''{expected}''");
        }

        public void Equal(string expected)
        {
            StringAssert.AreEqualIgnoringCase(expected, _actual);
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, $"Assertion Passed: Element's text equals ''{expected}''");
        }

        public void NotContain(string expected)
        {
            StringAssert.DoesNotContain(expected, _actual);
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, $"Assertion Passed: Element's text does not contain ''{expected}''");
        }
    }
}
