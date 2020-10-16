using Framework.ExtentReport;
using Framework.Selenium;
using NUnit.Framework;
using System;
using System.Drawing;

namespace Framework.Assertions
{
    public class ElementAsserts
    {
        private Element _element;

        public ElementAsserts(Element element)
        {
            _element = element;
        }

        public void BePresent()
        {
            Assert.That(_element.Displayed);
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, $"Assertion Passed: {_element.Name} is present");
        }

        public void BeSelected()
        {
            Assert.That(_element.Selected);
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, $"Assertion Passed: {_element.Name} is selected");
        }

        public void HaveColor(string css, string expectedhexcolor)
        {
            Color color = ColorTranslator.FromHtml(expectedhexcolor);
            int r = Convert.ToInt16(color.R);
            int g = Convert.ToInt16(color.G);
            int b = Convert.ToInt16(color.B);
            string expectedcolor = string.Format("{0}, {1}, {2}", r, g, b);
            string elementcolor = _element.GetCssValue(css);
            Assert.That(elementcolor.Contains(expectedcolor));
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, $"Assertion Passed: {_element.Name}'s color matches {expectedhexcolor}");
        }

        public void NotBePresent()
        {
            Assert.That(_element == null);
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, $"Assertion Passed: {_element.Name} is not present");
        }

        public void NotBeSelected()
        {
            Assert.That(!_element.Selected);
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, $"Assertion Passed: {_element.Name} is not selected");
        }

        public void NotHaveBrokenImage()
        {
            StringAssert.AreNotEqualIgnoringCase(_element.GetAttribute("naturalWidth"), "0");
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, $"Assertion Passed: {_element.Name}'s image is not broken");
        }
    }
}
