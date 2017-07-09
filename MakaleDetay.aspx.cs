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

    public partial class MakaleDetay : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
            {
                ViewState["MakaleID"] = Convert.ToInt32(Request.QueryString["mid"]);
                OkunmaSayisiArtir();

                MakaleGetirByID(Convert.ToInt32(Request.QueryString["mid"]));

             
            
                YorumGetir(Convert.ToInt32(Request.QueryString["mid"]));
            }
        }

        private void MakaleGetirByID(int MakaleID)
        {

            SqlCommand cmd = new SqlCommand("Select m.Icerik,m.Baslik,m.KayitTarihi,a.UserName,m.OkunmaSayisi from Makaleler as m join aspnet_Users as a on a.UserId=m.YazarID where m.MakaleID=@mid ", conn);
            cmd.Parameters.Add("@mid", System.Data.SqlDbType.Int).Value = MakaleID;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ltrBaslik.Text = dr["Baslik"].ToString();
                    ltrGonderen.Text = dr["UserName"].ToString();
                    ltrIcerik.Text = dr["Icerik"].ToString();
                    ltrTarih.Text = Convert.ToDateTime(dr["KayitTarihi"]).ToString();
                    ltrOkunmaSayisi.Text = dr["OkunmaSayisi"].ToString();
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

        protected void lnkKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Yorumlar(AdSoyad,YorumIcerik,Email,MakaleID,Websitesi,Onaylandimi) values (@adSoyad,@Icerik,@Email,@MakaleID,@Site,@Onaylandimi) ", conn);

            cmd.Parameters.Add("@adSoyad", SqlDbType.NVarChar, 100).Value = txtAdSoyad.Text;
            cmd.Parameters.Add("@Icerik", SqlDbType.NVarChar, 1000).Value = txtYorum.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = txtEmail.Text;
            cmd.Parameters.Add("@Site", SqlDbType.NVarChar, 100).Value = txtWebSite.Text;
            cmd.Parameters.Add("@Onaylandimi", SqlDbType.Bit).Value = true;
            cmd.Parameters.Add("@MakaleID", SqlDbType.Int).Value = Convert.ToInt32(ViewState["MakaleID"]);
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
                conn.Dispose();
            }
            if(ess>0)
            {
                Helper.MesajGoster(this, "Yorumunuz Kaydedilmiştir.");
            }

        }


        private void YorumGetir(int MakaleID)
        {
            SqlCommand cmd = new SqlCommand("Select AdSoyad,YorumIcerik,yorumTarihi from Yorumlar where MakaleID=@MakaleID",conn);

            cmd.Parameters.AddWithValue("@MakaleID", MakaleID);

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                rptYorumlar.DataSource = dr;
                rptYorumlar.DataBind();
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

        private void OkunmaSayisiArtir()
        {
            SqlCommand cmd = new SqlCommand("Update Makaleler set OkunmaSayisi=isnull(OkunmaSayisi,0)+1 where MakaleID=@MakaleID",conn);

            cmd.Parameters.AddWithValue("@MakaleID", Convert.ToInt32(ViewState["MakaleID"]));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}