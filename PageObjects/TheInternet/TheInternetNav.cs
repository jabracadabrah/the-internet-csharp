using Framework.Selenium;
using OpenQA.Selenium;

namespace PageObjects.TheInternet
{
    public class TheInternetNav
    {
        public readonly TheInternetNavMap Map;

        public TheInternetNav()
        {
            Map = new TheInternetNavMap();
        }

        public void GoToAddRemoveElementsPage()
        {
            Driver.WaitForVisibility(Map.AddRemoveElements).Click();
        }

        public void GoToBasicAuthPage()
        {
            Driver.WaitForVisibility(Map.BasicAuth).Click();
        }

        public void GoToBrokenImagesPage()
        {
            Driver.WaitForVisibility(Map.BrokenImages).Click();
        }

        public void GoToChallengingDOMPage()
        {
            Driver.WaitForVisibility(Map.ChallengingDOM).Click();
        }
    }

    public class TheInternetNavMap
    {
        public Element AddRemoveElements => Driver.FindElement(By.LinkText("Add/Remove Elements"), "Add/Remove Elements");

        public Element BasicAuth => Driver.FindElement(By.LinkText("Basic Auth"), "Basic Auth");

        public Element BrokenImages => Driver.FindElement(By.LinkText("Broken Images"), "Broken Images");

        public Element ChallengingDOM => Driver.FindElement(By.LinkText("Challenging DOM"), "Challenging DOM");

        public Element ForkMeOnGitHub => Driver.FindElement(By.CssSelector("[alt='Fork me on GitHub']"), "Fork me on Github");

        public Element FooterElementalSelenium => Driver.FindElement(By.LinkText("Elemental Selenium"), "Elemental Selenium Footer Link");
    }
}
