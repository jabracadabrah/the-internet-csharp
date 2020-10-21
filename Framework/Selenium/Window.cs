using AventStack.ExtentReports;
using Framework.ExtentReport;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Selenium
{
    public class Window
    {
        public static ReadOnlyCollection<string> CurrentWindows => Driver.Current.WindowHandles;

        public static void SwitchToWindow(string pagename, int prevwincount = 0)
        {
            var _currentwindows = CurrentWindows;

            if (prevwincount > 0)
            {
                Driver.WaitForNewWindow(prevwincount);
            }

            foreach (string s in _currentwindows)
            {
                try
                {
                    if (s != Driver.Current.CurrentWindowHandle)
                    {
                        SwitchTo(s);
                        if (Driver.Url.ToLower().Contains(pagename.ToLower()))
                        {
                            ExtentTestManager.Log(ExtentTestManager.LogStatus.Info, $"Switched to window that contains {pagename}");
                            break;
                        }
                        else if (s == _currentwindows.Last())
                        {
                            throw new Exception($"No window found with {pagename} in URL");
                        }
                    }
                }
                catch (NoSuchWindowException)
                {
                    SwitchTo(s);
                    if (Driver.Url.Contains(pagename))
                    {
                        ExtentTestManager.Log(ExtentTestManager.LogStatus.Info, $"Switched to window that contains {pagename}");
                        break;
                    }
                    else
                    {
                        throw new Exception($"No window found with {pagename} in URL");
                    }
                }
            }
        }

        public static void SwitchToFrame()
        {
            Driver.Current.SwitchTo().Frame(0);
        }

        public static void SwitchToDefaultContent()
        {
            Driver.Current.SwitchTo().DefaultContent();
        }

        public static void SwitchTo(string window)
        {
            Driver.Current.SwitchTo().Window(window);
        }

        public static void AcceptAlert()
        {
            Driver.Current.SwitchTo().Alert().Accept();
        }

        public static string AlertText()
        {
            string text = Driver.Current.SwitchTo().Alert().Text;

            return text;
        }
    }
}
