using Framework.Selenium;
using OpenQA.Selenium;
using PageObjects.TheInternet;

namespace PageObjects.TheInternet
{
    public class Context_MenuPage : BasePage
    {
        public readonly Context_MenuPageMap Map;

        public Context_MenuPage()
        {
            Map = new Context_MenuPageMap();
        }

        public Context_MenuPage Goto()
        {
            Driver.Goto("https://the-internet.herokuapp.com/");
            TheInternetNav.GoToContextMenuPage();
            WaitForPageLoad();

            return this;
        }

        public Context_MenuPage WaitForPageLoad()
        {
            Driver.WaitForVisibility(Map.PageTitle);

            return this;
        }

        public Context_MenuPage DisplayContextMenuPopUp()
        {
            Map.Box.RightClick();
            Driver.WaitForAlert();

            return this;
        }
    }

    public class Context_MenuPageMap
    {
        public Element PageTitle => Driver.FindElement(By.XPath("//h3[text()='Context Menu']"), "Context Menu Page Title");

        public Element Box => Driver.FindElement(By.Id("hot-spot"), "Context Menu Box");
    }
}
