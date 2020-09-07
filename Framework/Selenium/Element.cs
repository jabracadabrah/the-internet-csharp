using System.Collections.ObjectModel;
using System.Drawing;
using Framework.Assertions;
using Framework.ExtentReport;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Framework.Selenium
{
    public class Element : IWebElement
    {
        private readonly IWebElement _element;

        public readonly string Name;

        public By FoundBy { get; set; }

        public Element(IWebElement element, string name)
        {
            _element = element;
            Name = name;
        }

        public IWebElement Current => _element ?? throw new System.NullReferenceException("_element is null");

        public string TagName => Current.TagName;

        public string Text => Current.Text;

        public bool Enabled => Current.Enabled;

        public bool Selected => Current.Selected;

        public Point Location => Current.Location;

        public Size Size => Current.Size;

        public bool Displayed => Current.Displayed;

        public void Clear()
        {
            Current.Clear();
        }

        public void Click()
        {
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Info, $"Click {Name}");
            Current.Click();
        }

        public IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return Current.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return Current.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {
            return Current.GetProperty(propertyName);
        }

        public void SendKeys(string text)
        {
            if (Name.ToLower().Contains("password"))
            {
                ExtentTestManager.Log(ExtentTestManager.LogStatus.Info, $"Insert a password into {Name}");
            }
            //In case of trouble clicking on an element and using Keys.Space or Keys.Enter to click
            //Logging click instead of inserted text
            else if (text.Contains(Keys.Space) || text.Contains(Keys.Enter))
            {
                ExtentTestManager.Log(ExtentTestManager.LogStatus.Info, $"Click {Name}");
            }
            else
            {
                ExtentTestManager.Log(ExtentTestManager.LogStatus.Info, $"Insert ''{text}'' into {Name}");
            }
            Current.SendKeys(text);
        }

        public void Submit()
        {
            Current.Submit();
        }

        //Selects an item from a drop-down, pass an element and a string for partial selection
        public void DropDownPartialText(string value)
        {
            var selectElement = new SelectElement(Current);
            selectElement.SelectByText(value, true);
        }

        //Selects an item from a drop-down, pass an element and a string represent exact text selection
        public void DropDownExactText(string value)
        {
            var selectElement = new SelectElement(Current);
            selectElement.SelectByText(value);
        }

        //Selects an item by index
        public void DropDownSelectIndex(int index)
        {
            var selectElement = new SelectElement(Current);
            selectElement.SelectByIndex(index);
        }

        //Hovers the mouse cursor over the element
        public void Hover()
        {
            By by = this.FoundBy;
            RemoteWebElement element = (RemoteWebElement)Current.FindElement(by);
            Actions action = new Actions(Driver.Current);
            action.MoveToElement(element).Perform();
        }
    }
}
