using Framework.ExtentReport;
using Framework.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using PageObjects.TheInternet;
using System;

namespace Tests
{
    public class BaseTest
    {
        [SetUp]
        public virtual void BeforeEach()
        {
            TestContext.Progress.WriteLine("Starting Test - " + TestContext.CurrentContext.Test.Name);
            Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Driver.Init();
            Pages.Init();
        }

        [TearDown]
        public virtual void AfterEach()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            if (status == TestStatus.Failed)
            {
                string screenShotPath = Driver.TakeScreenshot(TestContext.CurrentContext.Test.Name + " " + DateTime.Now.ToString("MM dd yyyy HHmmss"));
                ExtentTestManager.Log(ExtentTestManager.LogStatus.Fail, stackTrace + errorMessage);
                ExtentTestManager.GetTest().Fail("Snapshot below: " + ExtentTestManager.GetTest().AddScreenCaptureFromPath(screenShotPath));
            }
            else if (status == TestStatus.Skipped)
            {
                ExtentTestManager.Log(ExtentTestManager.LogStatus.Skip, "Test Case Skipped");
            }
            else if (status == TestStatus.Passed)
            {
                ExtentTestManager.Log(ExtentTestManager.LogStatus.Pass, "Test Case Passed");
            }
            Driver.Quit();
            TestContext.Progress.WriteLine("Test Completed - " + TestContext.CurrentContext.Test.Name);
        }
    }

    [SetUpFixture]
    public class OneTimeSetupTeardown
    {
        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            Driver.DeleteScreenShots();
            Driver.DeleteReports();
        }

        [OneTimeTearDown]
        public virtual void AfterAll()
        {
            Extent.Flush();
        }
    }
}
