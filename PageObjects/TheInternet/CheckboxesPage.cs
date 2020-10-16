using Framework.Selenium;
using OpenQA.Selenium;
using PageObjects.TheInternet;

namespace PageObjects.TheInternet
{
    public class CheckboxesPage : BasePage
    {
        public readonly CheckboxesPageMap Map;

        public CheckboxesPage()
        {
            Map = new CheckboxesPageMap();
        }

        public CheckboxesPage Goto()
        {
            Driver.Goto("https://the-internet.herokuapp.com/");
            TheInternetNav.GoToCheckboxesPage();
            WaitForPageLoad();

            return this;
        }

        public CheckboxesPage WaitForPageLoad()
        {
            Driver.WaitForVisibility(Map.PageTitle);

            return this;
        }

        public CheckboxesPage SelectCheckbox(int num)
        {
            if (!Map.Checkbox(num).Selected)
            {
                Map.Checkbox(num).Click();
            }

            return this;
        }

        public CheckboxesPage UnselectCheckbox(int num)
        {
            if (Map.Checkbox(num).Selected)
            {
                Map.Checkbox(num).Click();
            }

            return this;
        }
    }

    public class CheckboxesPageMap
    {
        public Element PageTitle => Driver.FindElement(By.XPath("//h3[text()='Checkboxes']"), "Checkboxes Page Title");

        public Element Checkbox(int num) => Driver.FindElement(By.XPath($"//input[{num}]"), $"Checkbox {num}");
    }
}
