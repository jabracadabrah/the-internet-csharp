using Framework.Selenium;
using OpenQA.Selenium;
using PageObjects.TheInternet;

namespace PageObjects.TheInternet
{
    public class Challenging_DomPage : BasePage
    {
        public readonly Challenging_DomPageMap Map;

        public Challenging_DomPage()
        {
            Map = new Challenging_DomPageMap();
        }

        public Challenging_DomPage Goto()
        {
            Driver.Goto("https://the-internet.herokuapp.com/");
            TheInternetNav.GoToChallengingDOMPage();
            WaitForPageLoad();

            return this;
        }

        public Challenging_DomPage WaitForPageLoad()
        {
            Driver.WaitForVisibility(Map.PageTitle);

            return this;
        }
    }

    public class Challenging_DomPageMap
    {
        public Element PageTitle => Driver.FindElement(By.XPath("//h3[text()='Challenging DOM']"), "Challenging DOM Page Title");

        public Element BlueButton => Driver.FindElement(By.XPath("//a[@class='button']"), "Blue Button");

        public Element RedButton => Driver.FindElement(By.XPath("//a[@class='button alert']"), "Red Button");

        public Element GreenButton => Driver.FindElement(By.XPath("//a[@class='button success']"), "Green Button");
    }
}
