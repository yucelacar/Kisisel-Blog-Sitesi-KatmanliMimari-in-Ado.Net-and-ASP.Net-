using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogWebSite
{
    public partial class site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            KategoriGetir();
        }
        private void KategoriGetir()
        {
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("KategoriGetir", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                if(conn.State==ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataReader dr = cmd.ExecuteReader();
                rptCategories.DataSource = dr;
                rptCategories.DataBind();

            }
            catch (Exception ex)
            {
                Helper.MesajGoster(HttpContext.Current.CurrentHandler as Page, ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Dispose();
            }
        }
    }
}