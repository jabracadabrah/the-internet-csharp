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

        public Challenging_DomPage EditLink(int num)
        {
            Map.EditLink(num).Click();
            Driver.WaitForURL("#edit");

            return this;
        }

        public Challenging_DomPage DeleteLink(int num)
        {
            Map.DeleteLink(num).Click();
            Driver.WaitForURL("#delete");

            return this;
        }
    }

    public class Challenging_DomPageMap
    {
        public Element PageTitle => Driver.FindElement(By.XPath("//h3[text()='Challenging DOM']"), "Challenging DOM Page Title");

        public Element BlueButton => Driver.FindElement(By.XPath("//a[@class='button']"), "Blue Button");

        public Element RedButton => Driver.FindElement(By.XPath("//a[@class='button alert']"), "Red Button");

        public Element GreenButton => Driver.FindElement(By.XPath("//a[@class='button success']"), "Green Button");

        public Element EditLink(int num) => Driver.FindElement(By.XPath($"//td[text()='Phaedrum{num}']//parent::tr//td/a[text()='edit']"), $"Edit Link {num}");

        public Element DeleteLink(int num) => Driver.FindElement(By.XPath($"//td[text()='Phaedrum{num}']//parent::tr//td/a[text()='delete']"), $"Delete Link {num}");
    }
}
