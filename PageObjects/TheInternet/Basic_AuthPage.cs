using Framework.Selenium;
using OpenQA.Selenium;
using PageObjects.TheInternet;

namespace PageObjects.TheInternet
{
    public class Basic_AuthPage : BasePage
    {
        public readonly Basic_AuthPageMap Map;

        public Basic_AuthPage()
        {
            Map = new Basic_AuthPageMap();
        }

        public Basic_AuthPage Goto()
        {
            Driver.Goto("https://the-internet.herokuapp.com/");
            TheInternetNav.GoToBasicAuthPage();
            WaitForPageLoad();

            return this;
        }

        public Basic_AuthPage WaitForPageLoad()
        {
            Driver.WaitForVisibility(Map.PageTitle);

            return this;
        }
    }

    public class Basic_AuthPageMap
    {
        public Element PageTitle => Driver.FindElement(By.XPath("//h3[text()='Basic Auth']"), "Basic Auth Page Title");

        public Element SuccessMessage => Driver.FindElement(By.XPath("//p[contains(text(), 'Congratulations!')]"), "Successful Auth Message");
    }
}
