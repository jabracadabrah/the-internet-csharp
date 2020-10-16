using Framework.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using PageObjects.TheInternet;

namespace PageObjects.TheInternet
{
    public class ExitIntentPage : BasePage
    {
        public readonly ExitIntentPageMap Map;

        public ExitIntentPage()
        {
            Map = new ExitIntentPageMap();
        }

        public ExitIntentPage Goto()
        {
            Driver.Goto("https://the-internet.herokuapp.com/");
            TheInternetNav.GoToExitIntentPage();
            WaitForPageLoad();

            return this;
        }

        public ExitIntentPage WaitForPageLoad()
        {
            Driver.WaitForVisibility(Map.PageTitle);

            return this;
        }

        public ExitIntentPage ShowExitIntentPopup()
        {
            Driver.MoveMouse(960, 540);
            Driver.MoveMouse(1, 1);
            Driver.WaitForVisibility(Map.ExitIntentPopupTitle);

            return this;
        }

        public ExitIntentPage CloseExitIntentPopup()
        {
            Map.ExitIntentPopupFooter.Click();

            return this;
        }
    }

    public class ExitIntentPageMap
    {
        public Element PageTitle => Driver.FindElement(By.XPath("//h3[text()='Exit Intent']"), "Exit Intent Page Title");

        public Element ExitIntentPopupTitle => Driver.FindElement(By.ClassName("modal-title"), "Exit Intent Popup Title");

        public Element ExitIntentPopupBody => Driver.FindElement(By.ClassName("modal-body"), "Exit Intent Popup Body");

        public Element ExitIntentPopupFooter => Driver.FindElement(By.ClassName("modal-footer"), "Exit Intent Popup Footer");
    }
}
