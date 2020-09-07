using Framework.Assertions;
using NUnit.Framework;
using PageObjects.TheInternet;
using System.Collections.Generic;

namespace Tests.TheInternet
{
    class BasicAuth : BaseTest
    {
        [Test]
        public void BasicAuthTest()
        {
            Pages.Basic_Auth.Goto();

            Pages.Basic_Auth.Map.SuccessMessage.Text.Should().Contain("Congratulations! You must have the proper credentials.");
        }
    }
}
