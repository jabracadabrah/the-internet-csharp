using Framework.Assertions;
using NUnit.Framework;
using PageObjects.TheInternet;
using System.Collections.Generic;

namespace Tests.TheInternet
{
    class AddRemoveElements : BaseTest
    {
        [Test]
        public void AddRemoveElementsTest()
        {
            Pages.Add_Remove_Elements.Goto().AddElement(20);
            Pages.Add_Remove_Elements.Map.DeleteButtonList.Count.Should().Equal(20);

            Pages.Add_Remove_Elements.DeleteAllElements();
            Pages.Add_Remove_Elements.Map.DeleteButtonList.Count.Should().Equal(0);
        }

        [Test]
        [TestCaseSource(typeof(AddRemoveElementsData), "RemoveAllElements")]
        [Parallelizable(ParallelScope.Children)]
        public void AddRemoveAllElementsTest(int elementcount)
        {
            Pages.Add_Remove_Elements.Goto().AddElement(elementcount);
            Pages.Add_Remove_Elements.Map.DeleteButtonList.Count.Should().Equal(elementcount);

            Pages.Add_Remove_Elements.DeleteAllElements();
            Pages.Add_Remove_Elements.Map.DeleteButtonList.Count.Should().Equal(0);
        }

        [Test]
        [TestCaseSource(typeof(AddRemoveElementsData), "RemoveSpecificElements")]
        [Parallelizable(ParallelScope.Children)]
        public void AddRemoveSpecificElementsTest(int elementcount, int deletenum, int endcount)
        {
            Pages.Add_Remove_Elements.Goto().AddElement(elementcount);
            Pages.Add_Remove_Elements.Map.DeleteButtonList.Count.Should().Equal(elementcount);

            Pages.Add_Remove_Elements.DeleteElement(deletenum, endcount);
            Pages.Add_Remove_Elements.Map.DeleteButtonList.Count.Should().Equal(endcount);
        }
    }

    class AddRemoveElementsData
    {
        private static IEnumerable<TestCaseData> RemoveAllElements
        {
            get
            {
                yield return new TestCaseData(20).SetName("20 Elements");
                yield return new TestCaseData(40).SetName("40 Elements");
                yield return new TestCaseData(60).SetName("60 Elements");
                yield return new TestCaseData(80).SetName("80 Elements");
                yield return new TestCaseData(100).SetName("100 Elements");
                yield return new TestCaseData(1000).SetName("1000 Elements");
            }
        }

        private static IEnumerable<TestCaseData> RemoveSpecificElements
        {
            get
            {
                yield return new TestCaseData(20, 10, 19).SetName("20 Elements, Delete 10th Element");
                yield return new TestCaseData(40, 20, 39).SetName("40 Elements, Delete 20th Element");
                yield return new TestCaseData(60, 30, 59).SetName("60 Elements, Delete 30th Element");
                yield return new TestCaseData(80, 40, 79).SetName("80 Elements, Delete 40th Element");
                yield return new TestCaseData(100, 50, 99).SetName("100 Elements, Delete 50th Element");
                yield return new TestCaseData(1000, 500, 999).SetName("1000 Elements, Delete 500th Element");
            }
        }
    }
}
