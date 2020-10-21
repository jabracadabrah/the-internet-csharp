using Framework.Selenium;
using OpenQA.Selenium;
using PageObjects.TheInternet;

namespace PageObjects.TheInternet
{
    public class Digest_AuthPage : BasePage
    {
        public readonly Digest_AuthPageMap Map;

        public Digest_AuthPage()
        {
            Map = new Digest_AuthPageMap();
        }

        public Digest_AuthPage Goto()
        {
            Driver.Goto("https://the-internet.herokuapp.com/");
            TheInternetNav.GoToDigestAuthPage();
            WaitForPageLoad();

            return this;
        }

        public Digest_AuthPage WaitForPageLoad()
        {
            Driver.WaitForVisibility(Map.PageTitle);

            return this;
        }
    }

    public class Digest_AuthPageMap
    {
        public Element PageTitle => Driver.FindElement(By.XPath("//h3[text()='Digest Auth']"), "Digest Auth Page Title");

        public Element SuccessMessage => Driver.FindElement(By.XPath("//p[contains(text(), 'Congratulations!')]"), "Successful Auth Message");
    }
}
