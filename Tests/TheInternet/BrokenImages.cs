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
    class BrokenImages : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BrokenImagesData), "TestData")]
        [Parallelizable(ParallelScope.Children)]
        public void BrokenImagesTest(int imagenumber)
        {
            Pages.Broken_Images.Goto();

            Pages.Broken_Images.Map.Images(imagenumber).Should().NotHaveBrokenImage();
        }
    }

    class BrokenImagesData
    {
        private static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(1).SetName("Image 1");
                yield return new TestCaseData(2).SetName("Image 2");
                yield return new TestCaseData(3).SetName("Image 3");
            }
        }
    }
}
