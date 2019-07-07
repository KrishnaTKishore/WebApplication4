<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication4.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style5 {
            width: 237px;
            margin-top: 41px;
        }
        .auto-style3 {
            width: 175px;
        }
        .auto-style4 {
            height: 23px;
            width: 175px;
        }
        .auto-style1 {
            height: 23px;
        }
        .auto-style6 {
            width: 175px;
            height: 26px;
        }
        .auto-style7 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server" class="auto-style5">
        &nbsp;
        <div style="align-self : center">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EMPLOYEE LOGIN</div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Employee ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="emp_id" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="password" runat="server" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label4" runat="server" EnableViewState="False" Text="Designation" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" EnableViewState="False" ReadOnly="True" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style1">
                    <asp:Button ID="Log" runat="server" BackColor="#00CC00" OnClick="Log_Click" Text="Log In" Width="126px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
