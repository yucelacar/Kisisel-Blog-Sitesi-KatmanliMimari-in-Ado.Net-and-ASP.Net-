using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogWebSite.Yazar
{
    public partial class YorumOnayla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KategoriGetir();
            }

        }

        private void KategoriGetir()
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
                SqlCommand cmd = new SqlCommand("UyeBazliKategoriGetir", conn);
                cmd.Parameters.AddWithValue("@UyeID", (Guid)Membership.GetUser().ProviderUserKey);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

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
                    conn.Dispose();
                }

                ddlKategoriler.Items.Insert(0, new ListItem("Bir Kategori Seciniz", "0"));

                ddlKategoriler.Items.Add(new ListItem("Tüm Kategoriler", "null"));


            }

        }

        protected void ddlKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlKategoriler.SelectedValue == "0") { return; }

            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("yorumTablosuDoldur", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (ddlKategoriler.SelectedValue == "null")
            {
                cmd.Parameters.AddWithValue("@CatID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CatID", Convert.ToInt32(ddlKategoriler.SelectedValue));
            }
            cmd.Parameters.AddWithValue("UyeID", (Guid)Membership.GetUser().ProviderUserKey);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                { conn.Open(); }

                SqlDataReader dr = cmd.ExecuteReader();
          
                    grdYorumlar.DataSource = dr;
                    grdYorumlar.DataBind();
            
            }
            catch (Exception ex)
            {

                Helper.MesajGoster(this, ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Dispose();
            }
        }
    }
}