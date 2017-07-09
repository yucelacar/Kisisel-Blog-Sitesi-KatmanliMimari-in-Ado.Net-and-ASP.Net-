using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogWebSite
{
    public partial class UyeKayit : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SehirGetir();
                ddlSehir_SelectedIndexChanged(null, null);
            }

        }

        private void SehirGetir()
        {

            SqlCommand cmd = new SqlCommand("Select * from Sehirler order by SehirAdi", conn);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ddlSehir.DataSource = dr;
                    ddlSehir.DataTextField = "SehirAdi";
                    ddlSehir.DataValueField = "SehirID";
                    ddlSehir.DataBind();
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
            ddlSehir.Items.Insert(0, new ListItem("Bir Şehir Seçiniz..", "0"));

        }

        protected void ddlSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSehir.SelectedIndex >= 0)
            {
                IlceGetir();
            }


        }

        private void IlceGetir()
        {
            ddlIlce.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select * from Ilceler where SehirID=@SehirID Order by IlceAdi", conn);
            cmd.Parameters.AddWithValue("@SehirID", ddlSehir.SelectedItem.Value);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ddlIlce.DataSource = dr;
                    ddlIlce.DataTextField = "IlceAdi";
                    ddlIlce.DataValueField = "IlceID";
                    ddlIlce.DataBind();
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

            ddlIlce.Items.Insert(0, new ListItem("Bir İlçe Seçiniz..", "0"));

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (ddlSehir.SelectedValue == "0" || ddlIlce.SelectedValue == "0")
            {
                return;
            }

            MembershipCreateStatus durum;
            Membership.CreateUser(txtKullaniciAdi.Text, txtSifre.Text, txtEmail.Text, "Kopek", "Dogi", true, out durum);

            if (durum == MembershipCreateStatus.Success)
            {
                Guid UyeID = (Guid)Membership.GetUser(txtKullaniciAdi.Text).ProviderUserKey;

                SqlCommand cmd = new SqlCommand("insert into UyeKisisel(UyeID,Ad,Soyad,Cinsiyet,DogumTarihi,Telefon,Adres,IlceID) values(@UyeID,@Ad,@Soyad,@Cinsiyet,@DogumTarihi,@Telefon,@Adres,@IlceID)", conn);
            cmd.Parameters.AddWithValue("@UyeID", UyeID);
            cmd.Parameters.AddWithValue("@Ad", txtAd.Text);
                cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                cmd.Parameters.AddWithValue("@DogumTarihi", Convert.ToDateTime(txtDogumTarihi.Text));
                cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                cmd.Parameters.AddWithValue("@Adres", txtAdres.Text);
                cmd.Parameters.AddWithValue("@IlceID", ddlIlce.SelectedValue);
                cmd.Parameters.AddWithValue("@Cinsiyet", rdbBay.Checked);
                

                int etkilenenSatirSayisi = 0;
                try
                {

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    etkilenenSatirSayisi=cmd.ExecuteNonQuery();
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
                if(etkilenenSatirSayisi>0)
                {
                    Helper.MesajGoster(this, "Kaydedildi");
                }
            }
        }
    }
}