<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication4.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .fm9{
            width: 250px;
        }
        .auto-style1 {
            width: 150px;
        }
    </style>
    <link href="css/StyleSheet1.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form2" class="fm9" runat="server" >
        <p style="text-align: center;">EMPLOYEE LOGIN</p>
        <table>
            
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Employee ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="emp_id" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="password" runat="server" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" EnableViewState="False" Text="Designation" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" EnableViewState="False" ReadOnly="True" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" ></td>
                <td >
                    <asp:Button ID="Log" runat="server" BackColor="#00CC00" OnClick="Log_Click" Text="Log In" Width="126px" />
                </td>
            </tr>
        </table>
        
            <asp:TextBox ID="logid" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="logdesg" runat="server" Visible="False"></asp:TextBox>
    </form>
</body>
</html>
