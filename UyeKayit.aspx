<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UyeKayit.aspx.cs" Inherits="BlogWebSite.UyeKayit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 17px;
        }
        th{
            font-weight:bold;
            font-size:11px;
            font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
            color:#4f6b72;
            border-right:1px solid #C1DAD7;
            border-left:1px solid #C1DAD7;
            border-top:1px solid #C1DAD7;
            border-bottom:1px solid #C1DAD7;
            letter-spacing:2px;
            padding:5px 5px 5px 5px;
            text-align:left;
            background:#CAE8EA;

        }
        td{
            border-right:1px solid #C1DAD7;
            border-bottom:1px solid #C1DAD7;
            padding:6px 6px 6px 6px;
            color:#4f6b72;
            background:#fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <asp:scriptmanager runat="server" EnableScriptGlobalization="true" ></asp:scriptmanager>

    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="Right" TargetControlID="txtDogumTarihi"  />


    <table class="auto-style1">
        <thead>
            <tr>
                <th>Üye Kayıt</th>
            </tr>
        </thead>
        <tr>
            <td>KullanıcıAdı:</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Şifre:</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtSifre" runat="server" style="height: 22px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>ŞifreTekrar:</td>
            <td>
                <asp:TextBox ID="txtSifreTekrar" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Ad:</td>
            <td>
                <asp:TextBox ID="txtAd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Soyad</td>
            <td>
                <asp:TextBox ID="txtSoyad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>DogumTarihi:</td>
            <td>
                <asp:TextBox ID="txtDogumTarihi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Cinsiyet:</td>
            <td>
                <asp:RadioButton ID="rdbBay" runat="server" GroupName="Cinsiyet" Text="Bay" />
                <asp:RadioButton ID="rdbBayan" runat="server" GroupName="Cinsiyet" Text="Bayan" />
            </td>
        </tr>
        <tr>
            <td>Telefon:</td>
            <td>
                <asp:TextBox ID="txtTelefon" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Sehir:</td>
            <td>
                <asp:DropDownList ID="ddlSehir" runat="server" Width="129px" AutoPostBack="True" OnSelectedIndexChanged="ddlSehir_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Ilçe:</td>
            <td>
                <asp:DropDownList ID="ddlIlce" runat="server" Width="126px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Adres</td>
            <td>
                <asp:TextBox ID="txtAdres" runat="server" Height="56px" TextMode="MultiLine" Width="272px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnKaydet" runat="server" OnClick="btnKaydet_Click" Text="Kaydet" />
            </td>
        </tr>
    </table>
</asp:Content>
