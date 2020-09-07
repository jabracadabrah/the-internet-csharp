using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Framework.Utils;
using NUnit.Framework;
using System;
using System.IO;

namespace Framework.ExtentReport
{
    public class ExtentManager
    {
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return _lazy.Value; } }

        //Sets the directory where to save the report
        private static string ReportPath()
        {
            string report = EnvUtils.projectPath + $"\\Reports\\";

            return report;
        }

        //Sets the name of the report based on first test run
        private static string ReportName()
        {
            string reportname = TestContext.CurrentContext.Test.ClassName;

            return reportname;
        }

        //Creates a report instance
        static ExtentManager()
        {
            string localDate = DateTime.Now.ToString("MM dd yyyy HHmm");
            string finalpth = $"{ReportPath()}{ReportName()} - {localDate}.html";
            string localpath = new Uri(finalpth).LocalPath;
            Directory.CreateDirectory(ReportPath());
            DirectoryInfo di = new DirectoryInfo(ReportPath());
            di.Attributes |= FileAttributes.Normal;
            var htmlReporter = new ExtentV3HtmlReporter(localpath);
            htmlReporter.Config.DocumentTitle = "Selenium";
            htmlReporter.Config.ReportName = ReportName();
            htmlReporter.Config.Theme = Theme.Dark;

            Instance.AttachReporter(htmlReporter);
        }
    }
}