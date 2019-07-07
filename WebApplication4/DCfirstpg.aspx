<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DCfirstpg.aspx.cs" Inherits="WebApplication4.DCfirstpg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
      
<body>
    <form id="form1" runat="server">
        <div>
            WELCOME DC<br />
            <br />
            What would you like to start with?<br />
            <br />
&nbsp;<asp:Button ID="add_prj" runat="server" CssClass="button" OnClick="add_prj_Click" Text="Project Database"  />
            <br />
            <br />
&nbsp;<asp:Button ID="doc_db" runat="server"  CssClass="button" Text="Document Database" />
            <br />
            <br />
&nbsp;<asp:Button ID="vw_prj" runat="server"  CssClass="button" Text="Log Database" />
            <br />
&nbsp;</div>
    </form>
</body>
</html>
