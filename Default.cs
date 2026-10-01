<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="Experiment_5.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Academic Calendar - Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="max-width:900px;margin:24px auto;">

            <div style="float:right;">
                <asp:LinkButton ID="lnkLogout" runat="server"
                    OnClick="lnkLogout_Click">Logout</asp:LinkButton>
            </div>

            <h2>Academic Calendar</h2>

            <asp:Label ID="lblWelcome" runat="server"
                Font-Bold="true"></asp:Label>
            <br /><br />

            <asp:Calendar ID="calMain" runat="server"
                OnSelectionChanged="calMain_SelectionChanged">
            </asp:Calendar>

            <div style="display:inline-block;vertical-align:top;margin-left:24px;">

                <asp:Label ID="lblSelected" runat="server"
                    Text="Selected Date: ">
                </asp:Label>

                <asp:Label ID="lblDate" runat="server"
                    Font-Bold="true">
                </asp:Label>

                <br /><br />

                <asp:Button ID="btnApply" runat="server"
                    Text="Apply for Leave on Selected Date"
                    OnClick="btnApply_Click" />

            </div>
        </div>
    </form>
</body>
</html>