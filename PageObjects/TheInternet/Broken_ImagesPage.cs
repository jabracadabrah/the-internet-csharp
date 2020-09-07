using Framework.Selenium;
using OpenQA.Selenium;
using PageObjects.TheInternet;

namespace PageObjects.TheInternet
{
    public class Broken_ImagesPage : BasePage
    {
        public readonly Broken_ImagesPageMap Map;

        public Broken_ImagesPage()
        {
            Map = new Broken_ImagesPageMap();
        }

        public Broken_ImagesPage Goto()
        {
            Driver.Goto("https://the-internet.herokuapp.com/");
            TheInternetNav.GoToBrokenImagesPage();
            WaitForPageLoad();

            return this;
        }

        public Broken_ImagesPage WaitForPageLoad()
        {
            Driver.WaitForVisibility(Map.PageTitle);

            return this;
        }
    }

    public class Broken_ImagesPageMap
    {
        public Element PageTitle => Driver.FindElement(By.XPath("//h3[text()='Broken Images']"), "Broken Images Page Title");

        public Element Images(int num) => Driver.FindElement(By.XPath($"//div[@class='example']//img[{num}]"), $"Image {num}");
    }
}
