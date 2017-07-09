using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogWebSite
{
    public class Helper
    {
        private static string _baglantiCumlesi;

        public static string BaglantiCumlesi
        {
            get
            {
                return Helper._baglantiCumlesi;
            }

            set
            {
                Helper._baglantiCumlesi = value;
            }
        }

        public static void MesajGoster(Page targetPage,string message)
        {
           
               Literal ltr = new Literal();
            ltr.Text = "<script type=\"text/javascript\">alert('" + message + "')</script>";
            targetPage.Header.Controls.Add(ltr);
        }
    }
}