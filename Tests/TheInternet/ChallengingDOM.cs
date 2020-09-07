using Framework.Assertions;
using NUnit.Framework;
using PageObjects.TheInternet;
using System.Collections.Generic;

namespace Tests.TheInternet
{
    class ChallengingDOM : BaseTest
    {
        [Test]
        public void BlueButtonTest()
        {
            Pages.Challenging_Dom.Goto();

            Pages.Challenging_Dom.Map.BlueButton.Should().HaveColor("background-color", "#2ba6cb");
            Pages.Challenging_Dom.Map.BlueButton.Should().HaveColor("border-color", "#2284a1");
            Pages.Challenging_Dom.Map.BlueButton.Should().HaveColor("color", "white");

            Pages.Challenging_Dom.Map.BlueButton.Hover();
            Pages.Challenging_Dom.Map.BlueButton.Should().HaveColor("background-color", "#2284a1");
            Pages.Challenging_Dom.Map.BlueButton.Should().HaveColor("border-color", "#2284a1");
            Pages.Challenging_Dom.Map.BlueButton.Should().HaveColor("color", "white");
        }

        [Test]
        public void RedButtonTest()
        {
            Pages.Challenging_Dom.Goto();

            Pages.Challenging_Dom.Map.RedButton.Should().HaveColor("background-color", "#c60f13");
            Pages.Challenging_Dom.Map.RedButton.Should().HaveColor("border-color", "#970b0e");
            Pages.Challenging_Dom.Map.RedButton.Should().HaveColor("color", "white");

            Pages.Challenging_Dom.Map.RedButton.Hover();
            Pages.Challenging_Dom.Map.RedButton.Should().HaveColor("background-color", "#970b0e");
            Pages.Challenging_Dom.Map.RedButton.Should().HaveColor("border-color", "#970b0e");
            Pages.Challenging_Dom.Map.RedButton.Should().HaveColor("color", "white");
        }

        [Test]
        public void GreenButtonTest()
        {
            Pages.Challenging_Dom.Goto();

            Pages.Challenging_Dom.Map.GreenButton.Should().HaveColor("background-color", "#5da423");
            Pages.Challenging_Dom.Map.GreenButton.Should().HaveColor("border-color", "#457a1a");
            Pages.Challenging_Dom.Map.GreenButton.Should().HaveColor("color", "white");

            Pages.Challenging_Dom.Map.GreenButton.Hover();
            Pages.Challenging_Dom.Map.GreenButton.Should().HaveColor("background-color", "#457a1a");
            Pages.Challenging_Dom.Map.GreenButton.Should().HaveColor("border-color", "#457a1a");
            Pages.Challenging_Dom.Map.GreenButton.Should().HaveColor("color", "white");
        }

        [Test]
        public void TableLinksTest()
        {
            Pages.Challenging_Dom.Goto();

            Pages.Challenging_Dom.EditLink(0).DeleteLink(0)
                                 .EditLink(1).DeleteLink(1)
                                 .EditLink(2).DeleteLink(2)
                                 .EditLink(3).DeleteLink(3)
                                 .EditLink(4).DeleteLink(4)
                                 .EditLink(5).DeleteLink(5)
                                 .EditLink(6).DeleteLink(6)
                                 .EditLink(7).DeleteLink(7)
                                 .EditLink(8).DeleteLink(8)
                                 .EditLink(9).DeleteLink(9);
        }
    }
}
