﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADfirstpg.aspx.cs" Inherits="WebApplication4.ADfirstpg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position:center">
            <h3>WELCOME ADMIN</h3>
            <br />
            <p>
                What would you like to work on today?
            </p>
            <asp:Button ID="empdbbn" runat="server" OnClick="empdbbn_Click" Text="USER DATABASE" Width="220px" />
            <br />
            <br />
            <asp:Button ID="logdbbn" runat="server" OnClick="logdbbn_Click" Text="LOG DATABASE" Width="220px" />
            <br />
            <br />
            <asp:Button ID="prjdbbn" runat="server" OnClick="prjdbbn_Click" Text=" PROJECT DATABASE" Width="220px" />
            <br />
            <br />
        </div>
   
    </form>
</body>
</html>
