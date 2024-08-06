<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectSessionLogin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <center>

        <div>
            <asp:Label runat="server" Text="Usernane" ID="ctl08"></asp:Label>
            <br />
            
            <asp:TextBox runat="server" ID="txtUsername" Text="username"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Password" ID="Label1"></asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtPassword" Text="password"></asp:TextBox></div>
            <asp:Button runat="server" Text="Login" ID="btnLogin" OnClick="btnLogin_Click"></asp:Button>
        </div>

        </center>
    </form>
</body>
</html>
