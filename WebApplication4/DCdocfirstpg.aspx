<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DCdocfirstpg.aspx.cs" Inherits="WebApplication4.DCdocfirstpg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h3> WELCOME TO DOCUMENT CONTROL AREANA</h3><br />
            <p>
            What would you like to start with?
                </p>
&nbsp;<asp:Button ID="wir" runat="server" Text="WORK INSPECTION REQUEST LOG SHEET" class="firstpgbtn" OnClick="wir_Click"  />
            <br />
            <br />
&nbsp;<asp:Button ID="mir" runat="server"   Text="MATERIAL INSPECTION REQUEST LOG SHEET" class="firstpgbtn" OnClick="mir_Click"  />
            <br />
            <br />
&nbsp;<asp:Button ID="ms"  runat="server"  Text="MATERIAL SUBMITTAL LOG SHEET" class="firstpgbtn" OnClick="ms_Click" />
            <br />
               <br />
&nbsp;<asp:Button ID="ncr" runat="server"   Text="NON CONFORMANCE REPORT LOG SHEET" class="firstpgbtn" OnClick="ncr_Click"  />
            <br />
               <br />
&nbsp;<asp:Button ID="sor" runat="server"   Text="SITE OBSERVATION REPORT LOG SHEET" class="firstpgbtn" OnClick="sor_Click"  />
            <br />
               <br />
&nbsp;<asp:Button ID="mss" runat="server"   Text="METHOD STATEMENT SUBMITTAL LOG SHEET" class="firstpgbtn" OnClick="mss_Click"  />
            <br />
               <br />
&nbsp;<asp:Button ID="scpq" runat="server"   Text="SUB CONT PRE QUALIFICATION LOG SHEET" class="firstpgbtn" OnClick="scpq_Click"  />
            <br />
               <br />
&nbsp;<asp:Button ID="abd" runat="server"   Text="AS BUILT DRAWING LOG SHEET" class="firstpgbtn" OnClick="abd_Click" />
            <br />
               <br />
&nbsp;<asp:Button ID="sds" runat="server"   Text="SHOP DRAWING SUBMITTAL LOG SHEET" class="firstpgbtn" OnClick="sds_Click"  />
            <br />
               <br />
&nbsp;<asp:Button ID="rfi" runat="server"   Text="REQUEST FOR INFORMATION LOG SHEET" class="firstpgbtn" OnClick="rfi_Click"  />
            <br />
&nbsp;</div>
    </form>
</body>
</html>
