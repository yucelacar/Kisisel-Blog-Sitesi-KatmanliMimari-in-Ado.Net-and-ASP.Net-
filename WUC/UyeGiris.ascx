<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UyeGiris.ascx.cs" Inherits="BlogWebSite.WUC.UyeGiris" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>
<asp:LoginView ID="LoginView1" runat="server">
  
    
      <AnonymousTemplate>
          <table class="auto-style1">
        <tr>
            <td>Kullanıcı Adı:</td>
            <td>
                <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Sifre</td>
            <td>
                <asp:TextBox ID="txtSifre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:CheckBox ID="chbBeniHatirla" runat="server" Text="Beni Hatırla" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnGiris" runat="server" OnClick="btnGiris_Click" Text="Giriş" />
            </td>
        </tr>
    </table>


    </AnonymousTemplate>
    
    <LoggedInTemplate>
        Hoşgeldiniz, <a href="Profil.Aspx" > <asp:LoginName ID="LoginName1" runat="server" /> </a>
        <ul>
          
            <li>
                <a href="Yazar/MakaleEkle.aspx">Makale Ekle</a>
            </li>
              <li>
                <a href="Yazar/YorumOnayla.aspx">Yorum Onayla</a>
            </li>
              <li>
                <a href="MakaleDuzenle.aspx">Makale Düzenle</a>
            </li>
              <li> <asp:LinkButton ID="lnkCikis" Text="Çıkış" runat="server" OnClick="lnkCikis_Click"></asp:LinkButton> </li>
        </ul>


    </LoggedInTemplate>


</asp:LoginView>




