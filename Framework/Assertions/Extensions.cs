using Framework.Selenium;

namespace Framework.Assertions
{
    public static class Extensions
    {
        public static StringAsserts Should(this string actual)
        {
            return new StringAsserts(actual);
        }

        public static IntAsserts Should(this int actual)
        {
            return new IntAsserts(actual);
        }

        public static ElementAsserts Should(this Element actual)
        {
            return new ElementAsserts(actual);
        }
    }
}
