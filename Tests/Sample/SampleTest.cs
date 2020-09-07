using Framework.Assertions;
using NUnit.Framework;

namespace Tests.Sample
{
    class SampleTest : BaseTest
    {
        [Test]
        public void SampleAssertions()
        {
            string text = "abc";
            text.Should().Contain("a");
            text.Should().Contain("ab");
            text.Should().Contain("abc");
            text.Should().Equal("abc");
            text.Should().NotContain("def");

            int num = 123;
            num.Should().BeGreaterThan(122);
            num.Should().BeSmallerThan(124);
            num.Should().Equal(123);
        }
    }
}