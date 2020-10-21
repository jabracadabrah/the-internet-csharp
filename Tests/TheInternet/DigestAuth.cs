using Framework.Assertions;
using NUnit.Framework;
using PageObjects.TheInternet;
using System.Collections.Generic;

namespace Tests.TheInternet
{
    class DigestAuth : BaseTest
    {
        [Test]
        public void DigestAuthTest()
        {
            Pages.Basic_Auth.Goto()
                            .Map.SuccessMessage.Text.Should().Contain("Congratulations! You must have the proper credentials.");
        }
    }
}
