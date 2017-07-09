using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogWebSite.Yazar
{
    public partial class MakaleEkle : System.Web.UI.Page
    {

        SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KategoriGetir();
            }
        }

        private void KategoriGetir()
        {
            SqlCommand cmd = new SqlCommand("Select * from Kategoriler order by KategoriAdi", conn);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ddlKategoriler.DataSource = dr;
                    ddlKategoriler.DataTextField = "KategoriAdi";
                    ddlKategoriler.DataValueField = "KategoriID";
                    ddlKategoriler.DataBind();
                }

            }
            catch (Exception ex)
            {
                Helper.MesajGoster(this, ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            ddlKategoriler.Items.Insert(0, new ListItem("Bir Kategori Seçiniz..", "0"));
        }

        protected void btnMakaleKaydet_Click(object sender, EventArgs e)
        {
            if (ddlKategoriler.SelectedValue != "0")
            {
                SqlCommand cmd = new SqlCommand("insert into Makaleler(Baslik,Icerik,KategoriID,YazarID) values(@Baslik,@Icerik,@KategoriID,@YazarID)",conn);
                cmd.Parameters.AddWithValue("@Baslik", txtBaslik.Text);
                cmd.Parameters.AddWithValue("@Icerik", editor1.Value);
                cmd.Parameters.AddWithValue("@KategoriID", int.Parse(ddlKategoriler.SelectedValue));
                cmd.Parameters.AddWithValue("@YazarID", (Guid)Membership.GetUser().ProviderUserKey);
                int ess = 0;
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    ess = cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Helper.MesajGoster(this, ex.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
                if (ess > 0)
                {
                    Helper.MesajGoster(this, "Makale Kaydedildi");
                }
            }

        }
    }
}