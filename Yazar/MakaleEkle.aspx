<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="BlogWebSite.Yazar.MakaleEkle" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    <table class="auto-style1">
        <tr>
            <td>Kategorisi:</td>
            <td>
                <asp:DropDownList ID="ddlKategoriler" runat="server" Height="16px" Width="161px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Başlık:</td>
            <td>
                <asp:TextBox ID="txtBaslik" runat="server" Height="51px" TextMode="MultiLine" Width="209px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Makale İçerik:</td>
            <td>
                <textarea runat="server" class="ckeditor" id="editor1" name="S1" style="height: 117px; width: 302px" ></textarea></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnMakaleKaydet" runat="server" OnClick="btnMakaleKaydet_Click" Text="Makale Kaydet" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>



</asp:Content>
