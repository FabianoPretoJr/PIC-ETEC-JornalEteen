<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComentarioUsuario.aspx.cs" Inherits="Jornal.UI.ComentarioUsuario" %>

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
                <table>
                    <tr>
                        <td>Comentário</td>
                    </tr>
                    <tr>
                        <td>Nome:</td>
                        <td><asp:TextBox ID="txtNome" runat="server"></asp:TextBox></td>
                    </tr>
                                        <tr>
                        <td>Email:</td>
                        <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                    </tr>
                                        <tr>
                        <td>Mensagem:</td>
                        <td><asp:TextBox ID="txtMensagem" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click"></asp:Button></td>
                    </tr>
                    </table>
                </center>
        </div>
    </form>
</body>
</html>
