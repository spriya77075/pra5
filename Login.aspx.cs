<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="Experiment_5.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Academic Calendar & Leave Management</title>
</head>
<body>
    <form id="form1" runat="server">

        <div style="width:360px;margin:40px auto;padding:16px;border:1px solid #ccc;">

            <h3>Sign in</h3>

            <asp:Label ID="lblMsg"
                runat="server"
                ForeColor="Red">
            </asp:Label>

            <br />

            <asp:Label ID="lblUser"
                runat="server"
                Text="Username:">
            </asp:Label>

            <br />

            <asp:TextBox ID="txtUser"
                runat="server">
            </asp:TextBox>

            <br /><br />

            <asp:Label ID="lblPass"
                runat="server"
                Text="Password:">
            </asp:Label>

            <br />

            <asp:TextBox ID="txtPass"
                runat="server"
                TextMode="Password">
            </asp:TextBox>

            <br /><br />

            <asp:CheckBox ID="chkRemember"
                runat="server"
                Text="Remember me" />

            <br /><br />

            <asp:Button ID="btnLogin"
                runat="server"
                Text="Login"
                OnClick="btnLogin_Click" />

        </div>

    </form>
</body>
</html>