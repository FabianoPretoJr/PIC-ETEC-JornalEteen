<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Jornal.UI.Login" %>

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
                <h1>Login</h1>
                <br/>
                <br/>
                <br/>
                <table>
                    <tr>
                        <td>Usuário:</td>
                        <td><asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Senha:</td>
                        <td><asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnLogar" runat="server" Text="Logar" OnClick="btnLogar_Click"></asp:Button></td>
                    </tr>
                </table>
                </center>
        </div>
    </form>
</body>
</html>
