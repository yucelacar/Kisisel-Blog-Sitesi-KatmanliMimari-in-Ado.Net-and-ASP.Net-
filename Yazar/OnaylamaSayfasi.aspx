<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="OnaylamaSayfasi.aspx.cs" Inherits="BlogWebSite.Yazar.OnaylamaSayfasi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="view1" runat="server">
            <table class="auto-style1">
    <tr>
        <td>Ad Soyad:</td>
        <td>
            <asp:TextBox ID="txtAdSoyad" runat="server" Width="183px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Email:</td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" Width="183px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>WebSite:</td>
        <td>
            <asp:TextBox ID="txtWebSite" runat="server" Width="180px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Yorum:</td>
        <td>
            <asp:TextBox ID="txtYorum" runat="server" Height="96px" TextMode="MultiLine" Width="335px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:LinkButton ID="btnOnayla" runat="server"  OnClientClick="return confirm(&quot;Onaylamak istiyor musunuz?&quot;)" OnClick="btnOnayla_Click">Onayla</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>

        </asp:View>
        <asp:View runat="server" ID="view2">

            <a href="../Default.aspx">Yorum Onaylanmıştır. Anasayfaya dönmek için tıklayınız..</a>

        </asp:View>


    </asp:MultiView>



    




</asp:Content>
