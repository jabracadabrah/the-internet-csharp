using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using System;
using System.Runtime.CompilerServices;

namespace Framework.ExtentReport
{
    public class ExtentTestManager
    {
        [ThreadStatic]
        private static ExtentTest _parentTest;

        [ThreadStatic]
        private static ExtentTest _childTest;

        public enum LogStatus
        {
            Fail,
            Info,
            Pass,
            Skip,
            Warning
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateParentTest(string testName)
        {
            _parentTest = ExtentManager.Instance.CreateTest(testName);
            return _parentTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string testName)
        {
            _childTest = _parentTest.CreateNode(testName);
            return _childTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetParentTest()
        {
            return _parentTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        {
            return _childTest;
        }

        public static void Log(LogStatus status, string details)
        {
            switch (status)
            {
                case LogStatus.Info:
                    GetTest().Log(Status.Info, details);
                    break;
                case LogStatus.Fail:
                    GetTest().Log(Status.Fail, MarkupHelper.CreateLabel(details, ExtentColor.Red));
                    break;
                case LogStatus.Pass:
                    GetTest().Log(Status.Pass, MarkupHelper.CreateLabel(details, ExtentColor.Green));
                    break;
                case LogStatus.Skip:
                    GetTest().Log(Status.Skip, MarkupHelper.CreateLabel(details, ExtentColor.Blue));
                    break;
                case LogStatus.Warning:
                    GetTest().Log(Status.Warning, MarkupHelper.CreateLabel(details, ExtentColor.Amber));
                    break;
            }
        }
    }
}
