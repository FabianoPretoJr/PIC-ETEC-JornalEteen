<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContatoAdm.aspx.cs" Inherits="Jornal.UI.ContatoAdm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <h1>Administrador</h1><br/>
                <table>
                    <tr>
                        <td><a href="NoticiaAdm.aspx">Noticias</a></td>
                        <td><a href="BannerAdm.aspx">Banners</a></td>
                        <td><a href="ComentarioAdm.aspx">Comentarios</a></td>
                        <td><a href="ContatoAdm.aspx">Contato</a></td>
                        <td><asp:Button ID="btnSair" runat="server" Text="Sair" OnClick="btnSair_Click"></asp:Button></td>
                    </tr>
                </table>

                <br/>
                <br/>
                <hr/>
                <br/>
                <br/>

                                <table>
                    <tr>
                        <td><asp:TextBox ID="txtFiltro" runat="server" placeholder="Pesquise pelo nome"></asp:TextBox></td>
                        <td><asp:Button ID="btnFiltrar" runat="server" Text="Pesquisar" OnClick="btnFiltrar_Click"></asp:Button></td>
                        </tr>
                    </table>
                <br/>
                <asp:GridView ID="gvJornal" runat="server" OnRowCommand="gvResultado_RowCommand">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="btnResponder" runat="server" CausesValidation="false" CommandName="cmdResponder" Text="Responder" CommandArgument='<%#Eval("Id_Contato")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </center>
        </div>
    </form>
</body>
</html>
