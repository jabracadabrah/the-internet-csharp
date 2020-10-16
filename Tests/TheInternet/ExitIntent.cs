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
    class ExitIntent : BaseTest
    {
        [Test]
        public void ExitIntentTitleTest()
        {
            Pages.ExitIntent.Goto()
                            .ShowExitIntentPopup()
                            .Map.ExitIntentPopupTitle.Text.Should().Equal("THIS IS A MODAL WINDOW");
        }

        [Test]
        public void ExitIntentBodyTest()
        {
            Pages.ExitIntent.Goto()
                            .ShowExitIntentPopup()
                            .Map.ExitIntentPopupBody.Text.Should()
                .Equal("It's commonly used to encourage a user to take an action (e.g., give their e-mail address to sign up for something).");
            Pages.ExitIntent.Map.ExitIntentPopupFooter.Text.Should().Equal("Close");
        }

        [Test]
        public void ExitIntentFooterTest()
        {
            Pages.ExitIntent.Goto()
                            .ShowExitIntentPopup()
                            .Map.ExitIntentPopupFooter.Text.Should().Equal("Close");
        }

        [Test]
        public void ExitIntentCloseTest()
        {
            Pages.ExitIntent.Goto()
                            .ShowExitIntentPopup()
                            .CloseExitIntentPopup()
                            .Map.ExitIntentPopupTitle.Should().NotBeDisplayed();
        }
    }
}
