using AutoIt;
using Framework.ExtentReport;
using Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        [ThreadStatic]
        public static Wait Wait;

        //Initializes the chrome driver maximized. Has a page load wait of 2 minutes and explicit wait of 30 seconds
        public static void Init()
        {
            _driver = BrowserFactory.WebDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            Wait = new Wait(30);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");

        public static string Title => Current.Title;

        public static string Url => Current.Url;

        public static string PageSource => Current.PageSource;

        //Navigates to a specified URL
        public static void Goto(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"https://{url}";
            }

            ExtentTestManager.Log(ExtentTestManager.LogStatus.Info, $"Navigating to \"{url}\"");
            Current.Navigate().GoToUrl(url);
        }

        //Navigates to previous page visited
        public static void Back()
        {
            ExtentTestManager.Log(ExtentTestManager.LogStatus.Info, $"Click browser back button");
            Current.Navigate().Back();
        }

        //Takes screenshot, used in conjunction with extent reports
        public static string TakeScreenshot(string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)Driver.Current;
            Screenshot screenshot = ts.GetScreenshot();
            string localpath = EnvUtils.GetDirectory("Screenshots\\", screenShotName);
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }

        //Deletes screenshots older than 14 days
        public static void DeleteScreenShots()
        {
            DirectoryInfo di = EnvUtils.GetDirectory("Screenshots\\");

            foreach (FileInfo file in di.GetFiles())
            {
                if (file.CreationTime < DateTime.Now.AddDays(-14))
                {
                    file.Delete();
                }
            }
        }

        //Deletes reports older than 14 days
        public static void DeleteReports()
        {
            DirectoryInfo di = EnvUtils.GetDirectory("Reports\\");

            foreach (FileInfo file in di.GetFiles())
            {
                if (file.CreationTime < DateTime.Now.AddDays(-14))
                {
                    file.Delete();
                }
            }
        }

        //Waits for element to be visible, can override default wait timeout by passing in option int
        public static IWebElement WaitForVisibility(IWebElement element, int timeout = 0)
        {
            if (timeout == 0)
            {
                Wait.Until(Waiting.ForElementDisplay(element));
            }
            else
            {
                WebDriverWait wait = new WebDriverWait(Current, TimeSpan.FromMilliseconds(timeout));
                wait.Until(Waiting.ForElementDisplay(element));
            }

            return element;
        }

        //Waits for expected list list count
        public static void WaitForElementsCount(By by, int count)
        {
            Wait.Until(drvr => drvr.FindElements(by).Count == count);
        }

        //Waits for browser alert to be present
        public static void WaitForAlert()
        {
            Wait.Until(ExpectedConditions.AlertIsPresent());
        }

        //Waits for element to be visible, returns element so you can do .Click() on same line
        public static Element WaitForClickability(Element element)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(element));
            return element;
        }

        //Waits for new window or tab, int passed to it should be the count of windows prior to the one you're waiting for
        public static string WaitForNewWindow(int previouswindowcount)
        {
            List<string> previousHandles = new List<string>();
            List<string> currentHandles = new List<string>();
            previousHandles.AddRange(Current.WindowHandles);
            for (int i = 0; i < 20; i++)
            {
                currentHandles.Clear();
                currentHandles.AddRange(Current.WindowHandles);
                foreach (string s in previousHandles)
                {
                    currentHandles.RemoveAll(p => p == s);
                }
                if (currentHandles.Count == previouswindowcount)
                {
                    Current.SwitchTo().Window(currentHandles[0]);
                    Thread.Sleep(100);
                    return currentHandles[0];
                }
                else
                {
                    Thread.Sleep(500);
                }
            }
            return null;
        }

        //Waits for new window or tab, int passed to it should be the count of windows after closing current window
        public static void WaitForWindowClose(int expectedwindowcount)
        {
            for (int i = 0; i < 20; i++)
            {
                if (Window.CurrentWindows.Count != expectedwindowcount)
                {
                    Thread.Sleep(500);
                }
                else
                {
                    break;
                }
            }
        }

        //Waits for url to contain the string that you've passed to it
        public static string WaitForURL(string url)
        {
            Wait.Until(ExpectedConditions.UrlContains(url));
            return url;
        }

        //Waits for an element to be invisible.
        public static IWebElement WaitForInvisibility(Element element)
        {
            Wait.Until(Waiting.ElementNotDisplayed(element));
            return element;
        }

        //Waits for text to exist in textbox value
        public static void WaitForTextInTextBox(Element element, string text)
        {
            Wait.Until(ExpectedConditions.TextToBePresentInElementValue(element, text));
        }

        //Used in teardown, quits the driver and disposes of the session
        public static void Quit()
        {
            Current.Quit();
            Current.Dispose();
        }

        //Closes the current browser window, leaves the driver instance open
        public static void Close()
        {
            int count = Current.WindowHandles.Count;
            Current.Close();
            WaitForWindowClose(count - 1);
        }

        //Finds the element, pass false to not wait at all for element to be present
        public static Element FindElement(By by, string elementname, bool wait = true)
        {
            if (wait)
            {
                var element = Wait.Until(drvr => drvr.FindElement(by));
                return new Element(element, elementname)
                {
                    FoundBy = by
                };
            }
            else
            {
                try
                {
                    return new Element(Current.FindElement(by), elementname)
                    {
                        FoundBy = by
                    };
                }
                catch (NoSuchElementException)
                {

                    return null;
                }
            }
        }

        //Gets a list of the elements
        public static Elements FindElements(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }

        //Moves mouse to specific location, useful for outside of browser
        public static void MoveMouse(int x, int y)
        {
            AutoItX.MouseMove(x, y);
        }
    }
}
