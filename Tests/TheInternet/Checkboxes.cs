using Framework.Assertions;
using NUnit.Framework;
using PageObjects.TheInternet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TheInternet
{
    class Checkboxes : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(SelectCheckboxesData), "TestData")]
        [Parallelizable(ParallelScope.Children)]
        public void SelectCheckboxesTest(int checkboxnumber)
        {
            Pages.Checkboxes.Goto()
                            .SelectCheckbox(checkboxnumber)
                            .Map.Checkbox(checkboxnumber).Should().BeSelected();
        }

        [Test]
        [TestCaseSource(typeof(UnselectCheckboxesData), "TestData")]
        [Parallelizable(ParallelScope.Children)]
        public void UnselectCheckboxesTest(int checkboxnumber)
        {
            Pages.Checkboxes.Goto()
                            .UnselectCheckbox(checkboxnumber)
                            .Map.Checkbox(checkboxnumber).Should().NotBeSelected();
        }
    }

    class SelectCheckboxesData
    {
        private static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(1).SetName("Select Checkbox 1");
                yield return new TestCaseData(2).SetName("Select Checkbox 2");
            }
        }
    }

    class UnselectCheckboxesData
    {
        private static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(1).SetName("Unselect Checkbox 1");
                yield return new TestCaseData(2).SetName("Unselect Checkbox 2");
            }
        }
    }
}
