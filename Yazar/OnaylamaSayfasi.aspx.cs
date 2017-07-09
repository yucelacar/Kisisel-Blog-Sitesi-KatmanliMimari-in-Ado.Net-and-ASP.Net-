using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogWebSite.Yazar
{
    public partial class OnaylamaSayfasi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["yid"]))
            {
                YorumGetir(Convert.ToInt32(Request.QueryString["yid"]));
            }
        }

        private void YorumGetir(int yorumID)
        {
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("Select * from Yorumlar where YorumID=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", yorumID);

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtAdSoyad.Text = dr["AdSoyad"].ToString();
                        txtEmail.Text = dr["Email"].ToString();
                        txtWebSite.Text = dr["Websitesi"].ToString();
                        txtYorum.Text = dr["YorumIcerik"].ToString();
                    }
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

        protected void btnOnayla_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("Update Yorumlar set Onaylandimi=1 Where YorumID=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(Request.QueryString["yid"]));

            int ess = 0;
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();


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
                MultiView1.ActiveViewIndex = 1;
            }
        }
    }
}