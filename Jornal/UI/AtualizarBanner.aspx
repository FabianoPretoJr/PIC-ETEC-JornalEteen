<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AtualizarBanner.aspx.cs" Inherits="Jornal.UI.AtualizarBanner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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

                            <table>
                    <tr>
                        <td><h4>Atualizar Banner</h4></td>
                    </tr>
                                <tr>
                                    <td>Id:</td>
                                    <td><asp:Label ID="lblId" runat="server" Text=""></asp:Label></td>
                                </tr>
                    <tr>
                        <td>Imagem:</td>
                        <td><asp:FileUpload ID="fulImagem" runat="server"></asp:FileUpload></td>
                        <td><asp:Image ID="Image" runat="server"></asp:Image></td>
                        <td><asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                         <td>Categoria:</td>
                         <td><asp:DropDownList ID="ddlCategoria" runat="server">
                             <asp:ListItem Value="Comercio">Comércio</asp:ListItem>
                             <asp:ListItem Value="Educacao">Educação</asp:ListItem>
                             <asp:ListItem>Esportes</asp:ListItem>
                             <asp:ListItem Value="Etec">Notícias da Etec</asp:ListItem>
                             <asp:ListItem Value="Regiao">Notícias da Região</asp:ListItem>
                             <asp:ListItem Value="Saude">Saúde</asp:ListItem>
                             <asp:ListItem>Tecnologia</asp:ListItem>
                             </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnAtualizar" runat="server" Text="Enviar" OnClick="btnAtualizar_Click"></asp:Button></td>
                    </tr>
                </table>
                 </center>
        </div>
    </form>
</body>
</html>
