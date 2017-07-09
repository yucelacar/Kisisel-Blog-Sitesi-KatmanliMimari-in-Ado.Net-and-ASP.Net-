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
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
        protected void Page_Load(object sender, EventArgs e)
        {
            MakaleListesiGetir();
        }

        private void MakaleListesiGetir()
        {
            SqlCommand cmd = new SqlCommand("MakaleListele", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
           

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    rptArticles.DataSource = dr;              
                    rptArticles.DataBind();
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
        }
    }
}