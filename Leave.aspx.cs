<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leave.aspx.cs"
    Inherits="Experiment_5.Leave" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Application</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="max-width:900px;margin:24px auto;">

            <div style="float:right;">
                <asp:LinkButton ID="lnkLogout" runat="server"
                    OnClick="lnkLogout_Click">Logout</asp:LinkButton>
            </div>

            <h2>Leave Application</h2>

            <asp:Label ID="lblWelcome" runat="server"
                Font-Bold="true"></asp:Label>

            <br /><br />

            <table>
                <tr>
                    <td valign="top">

                        <asp:Calendar ID="calLeave" runat="server"
                            OnSelectionChanged="calLeave_SelectionChanged">
                        </asp:Calendar>

                    </td>

                    <td style="padding-left:24px;vertical-align:top;">

                        <asp:Label ID="Label1" runat="server"
                            Text="Employee Name:">
                        </asp:Label>
                        <br />

                        <asp:TextBox ID="txtEmpName"
                            runat="server"></asp:TextBox>

                        <br /><br />

                        <asp:Label ID="Label2" runat="server"
                            Text="Department (or Employee ID):">
                        </asp:Label>
                        <br />

                        <asp:TextBox ID="txtEmpDept"
                            runat="server"></asp:TextBox>

                        <br /><br />

                        <asp:Label ID="Label4" runat="server"
                            Text="Designation:">
                        </asp:Label>
                        <br />

                        <asp:TextBox ID="txtEmpDesig"
                            runat="server"></asp:TextBox>

                        <br /><br />

                        <asp:Label ID="Label5" runat="server"
                            Text="Leave Reason:">
                        </asp:Label>
                        <br />

                        <asp:TextBox ID="txtReason"
                            runat="server"
                            TextMode="MultiLine"
                            Rows="4">
                        </asp:TextBox>

                        <br /><br />

                        <asp:Label ID="Label3" runat="server"
                            Text="Selected Date:">
                        </asp:Label>

                        <asp:Label ID="lblDate"
                            runat="server"
                            Font-Bold="true">
                        </asp:Label>

                        <br /><br />

                        <asp:Button ID="btnApply"
                            runat="server"
                            Text="Apply for Leave"
                            OnClick="btnApply_Click" />

                        <br /><br />

                        <asp:Label ID="lblResult"
                            runat="server"
                            ForeColor="Green">
                        </asp:Label>

                    </td>
                </tr>
            </table>

            <h3>My Leaves</h3>

            <asp:GridView ID="gvLeaves"
                runat="server"
                AutoGenerateColumns="false">

                <Columns>

                    <asp:BoundField
                        DataField="Date"
                        HeaderText="Date"
                        DataFormatString="{0:d}" />

                    <asp:BoundField
                        DataField="Name"
                        HeaderText="Employee" />

                    <asp:BoundField
                        DataField="Department"
                        HeaderText="Department/ID" />

                    <asp:BoundField
                        DataField="Designation"
                        HeaderText="Designation" />

                    <asp:BoundField
                        DataField="Reason"
                        HeaderText="Reason" />

                    <asp:BoundField
                        DataField="SubmittedOn"
                        HeaderText="Submitted On"
                        DataFormatString="{0:G}" />

                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>