<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignInV1.aspx.cs" Inherits="WebApp.V1.SignInV1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <asp:Label runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>

        <asp:Label runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>

        <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember Me" />

        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />

        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
