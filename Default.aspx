<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BlogWebSite.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Repeater ID="rptArticles" runat="server">

        <ItemTemplate>

            <div class="post">
				<h2 class="title"><a href='MakaleDetay.aspx?mid=<%# Eval("MakaleID") %>'><%# Eval("Baslik") %> </a></h2>
				<p class="meta" style="margin-top:30px;"><span class="date"><%# Eval("KayitTarihi") %></span><span class="posted">Gönderen <a href="#"><%# Eval("Gonderen") %></a></span></p>
				<div style="clear: both;">&nbsp;</div>
				<div class="entry">
					<p><%# Eval("Icerik").ToString().Length>400? Eval("Icerik").ToString().Substring(0,400): Eval("Icerik").ToString() %></p>
                    <p class="links">
                        	<a href='MakaleDetay.aspx?mid=<%# Eval("MakaleID") %>'>...Fazlası</a>
                    <br />
                    <a href='MakaleDetay.aspx?mid=<%# Eval("MakaleID") %>'>Yorumlar(<%# Eval("YorumSayisi") %>)</a>

                    </p>				

				</div>
			</div>



        </ItemTemplate>

           <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
    </asp:Repeater>
    

</asp:Content>
