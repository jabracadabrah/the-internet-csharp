namespace PageObjects.TheInternet
{
    public abstract class BasePage
    {
        public readonly TheInternetNav TheInternetNav;

        public BasePage()
        {
            TheInternetNav = new TheInternetNav();
        }
    }
}
