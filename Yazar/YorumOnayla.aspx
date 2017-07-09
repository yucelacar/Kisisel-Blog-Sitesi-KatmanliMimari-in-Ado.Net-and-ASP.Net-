<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="YorumOnayla.aspx.cs" Inherits="BlogWebSite.Yazar.YorumOnayla" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    <table class="auto-style1">
        <tr>
            <td>Kategoriler:</td>
            <td>
                <asp:DropDownList ID="ddlKategoriler" runat="server" Width="150px" >                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">

                <asp:GridView ID="grdYorumlar" runat="server" AutoGenerateColumns="false" Width="303px">

                    <Columns>
                        <asp:TemplateField HeaderText="Makale Baslık">
                            <ItemTemplate>
                                <%# Eval("Baslik").ToString().Length>50? Eval("Baslik").ToString().Substring(0,50)+"...":Eval("Baslik").ToString() %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Yorum">
                            <ItemTemplate>
                                <%# Eval("YorumIcerik").ToString().Length>50 ? Eval("YorumIcerik").ToString().Substring(0,50)+"...":Eval("YorumIcerik").ToString()  %>

                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="Yazar/OnaylamaSayfasi.aspx?yid=<%# Eval("YorumID") %>">Yorumu Onayla</a>

                            </ItemTemplate>

                        </asp:TemplateField>
                    </Columns>


                </asp:GridView>

            </td>
      
        </tr>
    </table>



</asp:Content>
