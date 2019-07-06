<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DCfirstpg.aspx.cs" Inherits="WebApplication4.DCfirstpg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            WELCOME DC<br />
            <br />
            What would you like to start with?<br />
            <br />
&nbsp;<asp:Button ID="add_prj" runat="server" OnClick="add_prj_Click" Text="ADD A PROJECT" />
            <br />
&nbsp;<asp:Button ID="del_prj" runat="server" Text="DELETE A PROJECT" />
            <br />
&nbsp;<asp:Button ID="vw_prj" runat="server" Text="VIEW DETAILS OF A PROJECT" />
            <br />
&nbsp;<asp:Button ID="Button4" runat="server" Text="Button" />
        </div>
    </form>
</body>
</html>
