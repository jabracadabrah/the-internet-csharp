using InvoiceCloud.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.TheInternet
{
    public class Pages
    {
        [ThreadStatic]
        public static Add_Remove_ElementsPage Add_Remove_Elements;

        [ThreadStatic]
        public static Basic_AuthPage Basic_Auth;

        [ThreadStatic]
        public static Broken_ImagesPage Broken_Images;

        [ThreadStatic]
        public static Challenging_DomPage Challenging_Dom;

        [ThreadStatic]
        public static CheckboxesPage Checkboxes;

        [ThreadStatic]
        public static Context_MenuPage Context_Menu;

        [ThreadStatic]
        public static ExitIntentPage ExitIntent;

        public static void Init()
        {
            Add_Remove_Elements = new Add_Remove_ElementsPage();

            Basic_Auth = new Basic_AuthPage();

            Broken_Images = new Broken_ImagesPage();

            Challenging_Dom = new Challenging_DomPage();

            Checkboxes = new CheckboxesPage();

            Context_Menu = new Context_MenuPage();

            ExitIntent = new ExitIntentPage();
        }
    }
}
