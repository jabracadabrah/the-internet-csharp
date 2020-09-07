using Framework.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Framework.Selenium
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            IE,
            Chrome,
            Firefox,
            Edge
        }

        private static string browser = TestContext.Parameters.Get("Browser");

        public static IWebDriver WebDriver(BrowserType type = BrowserType.Chrome)
        {
            IWebDriver driver;

            if (browser == null)
            {
                switch (type)
                {
                    case BrowserType.IE:
                        driver = IeDriver();
                        break;
                    case BrowserType.Firefox:
                        driver = FirefoxDriver();
                        break;
                    case BrowserType.Edge:
                        driver = EdgeDriver();
                        break;
                    default:
                        driver = ChromeDriver();
                        break;
                }
            }
            else
            {
                switch (browser)
                {
                    case "IE":
                        driver = IeDriver();
                        break;
                    case "FF":
                        driver = FirefoxDriver();
                        break;
                    case "Edge":
                        driver = EdgeDriver();
                        break;
                    default:
                        driver = ChromeDriver();
                        break;
                }
            }

            return driver;
        }

        private static IWebDriver IeDriver()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.EnsureCleanSession = true;
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            IWebDriver driver = new InternetExplorerDriver(options);
            return driver;
        }

        private static IWebDriver FirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            IWebDriver driver = new FirefoxDriver(options);
            return driver;
        }

        private static IWebDriver ChromeDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddExtension(EnvUtils.projectPath + "\\Utils\\BasicAuthUtil\\BasicAuth.crx");
            IWebDriver driver = new ChromeDriver(chromeOptions);
            return driver;
        }

        private static IWebDriver EdgeDriver()
        {
            var edgeOptions = new Microsoft.Edge.SeleniumTools.EdgeOptions();
            edgeOptions.UseChromium = true;
            IWebDriver driver = new Microsoft.Edge.SeleniumTools.EdgeDriver(edgeOptions);
            return driver;
        }
    }
}
