<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nota.aspx.cs" Inherits="Jornal.UI.Nota" %>

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
                        <td><asp:Button ID="btnSair" runat="server" Text="Sair"></asp:Button></td>
                    </tr>
                </table>

                <br/>
                <br/>
                <hr/>
                <br/>
                <br/>

            </center>
        </div>
    </form>
</body>
</html>
