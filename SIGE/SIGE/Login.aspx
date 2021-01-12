<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SIGE.Models.Login" %>

<!DOCTYPE html>

<html  xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Acceso</title>
    <link href="../Content/AdminLTE.css" rel="stylesheet" type="text/css" /></head>
<body class="bg-black">
    <div class="form-box" id="login-box">
        <div class="header">Iniciar Sesion</div>
        <form id="form1" runat="server">
            <div class="body bg-gray">
                <div class="form-group">
                    <asp:TextBox ID="txtusuario" runat="server" CssClass="form-control" placeHolder="Ingrese usuario"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" placeHolder="Ingrese contraseña"></asp:TextBox>
                </div>
            </div>
            <div class="footer">
                <asp:Button ID="btnLogin" runat="server" CssClass="btn bg-oliva" Text="Ingresar" OnClick="btnLogin_Click"></asp:Button>
            </div>
        </form>
    </div>
</body>
</html>
