<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="BlogWebSite.MakaleDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="post">
				<h2 class="title"><a href="#">
                    <asp:Literal ID="ltrBaslik" Text="text" runat="server" /> </a></h2>
				<p class="meta"><span class="date"> <asp:Literal ID="ltrTarih" Text="text" runat="server" /></span><span class="posted">Gönderen <a href="#"> <asp:Literal ID="ltrGonderen" Text="text" runat="server" /></a></span></p>
				<div style="clear: both;">&nbsp;</div>
				<div class="entry">
					<p> 
                        <asp:Literal ID="ltrIcerik" Text="text" runat="server" />

					</p>
					
				</div>
			</div>

    <table style="width:100%">
        <tr>
            <th> OkunmaSayisi:</th>
        <td>
            <asp:Literal ID="ltrOkunmaSayisi" Text="text" runat="server" />
        </td>
        </tr>
        
    </table>

    <div style="margin-top:10px; margin-bottom:10px">
        <asp:Repeater ID="rptYorumlar" runat="server">
            <ItemTemplate> 
                <div>
                    <a href="#"><%# Eval("AdSoyad") %></a>
                    <div> <a href="#"><%# Eval("yorumTarihi") %></a> </div>
                </div>
                <div >
                    <p> <%# Eval("YorumIcerik") %></p>
                </div>

            </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
    </div>


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
            <asp:LinkButton ID="lnkKaydet" runat="server" OnClick="lnkKaydet_Click" OnClientClick="return confirm(&quot;Kaydetmek istiyor musunuz?&quot;)">Kaydet</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>





</asp:Content>
