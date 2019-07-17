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
           <h3> WELCOME DC</h3><br />
            <br />
            <p>
            What would you like to start with?
                </p>
&nbsp;<asp:Button ID="add_prj" runat="server" Text="PROJECT DATABASE"   CssClass ="firstpgbtn" OnClick="add_prj_Click" />
            <br />
            <br />
&nbsp;<asp:Button ID="doc_db" runat="server"  Text="DOCUMENT DATABASE"  CssClass ="firstpgbtn" OnClick="doc_db_Click"  />
            <br />
            <br />
&nbsp;<asp:Button ID="vw_prj" runat="server"  Text="LOG DATABASE"       CssClass ="firstpgbtn" OnClick="vw_prj_Click"  />
            <br />
&nbsp;</div>
    </form>
</body>
</html>
