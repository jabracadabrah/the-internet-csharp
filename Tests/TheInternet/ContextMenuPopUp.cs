using Framework.Assertions;
using Framework.Selenium;
using NUnit.Framework;
using PageObjects.TheInternet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TheInternet
{
    class ContextMenuPopUp : BaseTest
    {
        [Test]
        public void ContextMenuPopUpTest()
        {
            Pages.Context_Menu.Goto()
                              .DisplayContextMenuPopUp();

            Window.AlertText().Should().Equal("You selected a context menu");
        }
    }
}
