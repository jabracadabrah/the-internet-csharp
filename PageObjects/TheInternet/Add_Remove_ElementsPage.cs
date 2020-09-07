using Framework.Selenium;
using OpenQA.Selenium;
using PageObjects.TheInternet;

namespace InvoiceCloud.PageObjects
{
    public class Add_Remove_ElementsPage : BasePage
    {
        public readonly Add_Remove_ElementsPageMap Map;

        public Add_Remove_ElementsPage()
        {
            Map = new Add_Remove_ElementsPageMap();
        }

        public Add_Remove_ElementsPage Goto()
        {
            Driver.Goto("https://the-internet.herokuapp.com/");
            TheInternetNav.GoToAddRemoveElementsPage();
            WaitForPageLoad();

            return this;
        }

        public Add_Remove_ElementsPage AddElement(int clicknum)
        {
            int current = 0;

            while (current < clicknum)
            {
                current ++;
                Map.AddElementButton.Click();
                Driver.WaitForVisibility(Map.DeleteButton(current));
            }

            return this;
        }

        public Add_Remove_ElementsPage DeleteAllElements()
        {
            int buttoncount = Map.DeleteButtonList.Count;

            foreach (IWebElement delete in Map.DeleteButtonList)
            {
                Map.DeleteButton(buttoncount).Click();
                Driver.WaitForInvisibility(Map.DeleteButtonNoWait(buttoncount));
                buttoncount--;
            }

            return this;
        }

        public Add_Remove_ElementsPage DeleteElement(int num, int expcount)
        {
            Map.DeleteButton(num).Click();
            Driver.WaitForElementsCount(Map.DeleteButtonList.FoundBy, expcount);

            return this;
        }

        public Add_Remove_ElementsPage WaitForPageLoad()
        {
            Driver.WaitForVisibility(Map.PageTitle);

            return this;
        }
    }

    public class Add_Remove_ElementsPageMap
    {
        public Element PageTitle => Driver.FindElement(By.XPath("//h3[text()='Add/Remove Elements']"), "Add/Remove Elements Page Title");

        public Element AddElementButton => Driver.FindElement(By.XPath("//button[text()='Add Element']"), "Add Element Button");

        public Elements DeleteButtonList => Driver.FindElements(By.XPath("//button[text()='Delete']"));

        public Element DeleteButton(int num) => Driver.FindElement(By.XPath($"//button[text()='Delete'][{num}]"), "Delete Button");

        public Element DeleteButtonNoWait(int num) => Driver.FindElement(By.XPath($"//button[text()='Delete'][{num}]"), "Delete Button", false);
    }
}
