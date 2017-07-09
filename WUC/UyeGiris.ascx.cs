using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogWebSite.WUC
{
    public partial class UyeGiris : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi =(LoginView1.FindControl("txtKullaniciAdi") as TextBox).Text;
            string sifre = (LoginView1.FindControl("txtSifre") as TextBox).Text;
            bool beniHatirla= (LoginView1.FindControl("chbBeniHatirla") as CheckBox).Checked;

           bool cevap=  Membership.ValidateUser(kullaniciAdi, sifre);
            if(cevap)
            {
                FormsAuthentication.RedirectFromLoginPage(kullaniciAdi, beniHatirla);
            }
            else
            {
                Helper.MesajGoster(HttpContext.Current.CurrentHandler as Page, "Kullanıcı Adı/Sifre Hatalı");
            }
        }

        protected void lnkCikis_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
        }
    }
}