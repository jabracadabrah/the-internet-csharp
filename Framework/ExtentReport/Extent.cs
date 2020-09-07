using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ExtentReport
{
    public class Extent
    {
        public static void CreateTest(string testname)
        {
            ExtentTestManager.CreateParentTest(testname);
            ExtentTestManager.CreateTest(testname);
        }

        public static void Flush()
        {
            ExtentManager.Instance.Flush();
        }
    }
}
