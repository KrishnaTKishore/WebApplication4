
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DCprjpg.aspx.cs" Inherits="WebApplication4.DCprjpg1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    
   <link href="css/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 103px;
        }
        .auto-style3 {
            width: 310px;
        }
        .auto-style4 {
            width: 122px;
        }
        .auto-style5 {
            width: 290px;
        }
        .auto-style6 {
            width: 103px;
            height: 23px;
        }
        .auto-style7 {
            width: 300px;
            height: 23px;
        }
        .auto-style8 {
            width: 122px;
            height: 23px;
        }
        .auto-style9 {
            width: 290px;
            height: 23px;
        }
        .auto-style10 {
            position: center;
            width: 90%;
            height: 15%;
            font-size: small;
        }
        .auto-style11 {
            font-size: small;
        }
        .auto-style12 {
            width: 700px;
        }
    </style>
</head>
<body class="fm">
    <form runat="server"> 
        <div><h3 class="auto-style11">PROJECT DATABASE</h3></div>
        <div class="combo2">
    <div class="notification">
        <asp:Label ID="notify" runat="server" Text="" CssClass="auto-style11"></asp:Label>
        </div>
       <div class="disp">
           <table class="table">
               <tr>
                   <td class="auto-style6"><asp:Label ID="Label3" runat="server" Text="Project ID" CssClass="auto-style11"></asp:Label></td>
                   <td class="auto-style7"><asp:Label ID="lab_prjid" runat="server" Text="" CssClass="auto-style11"></asp:Label></td>
                   <td class="auto-style8"><asp:Label ID="Label13" runat="server" Text="Project Name" CssClass="auto-style11"></asp:Label></td>
                   <td class="auto-style9"><asp:Label ID="Lab_prjnm" runat="server" Text="" CssClass="auto-style11"></asp:Label></td>
               </tr>
               <tr>
                   <td class="auto-style1"><asp:Label ID="Label4" runat="server" Text="Created On" CssClass="auto-style11"></asp:Label> </td>
                   <td class="firstpgbtn"><asp:Label ID="Lab_cre" runat="server" Text="" CssClass="auto-style11"></asp:Label></td>
                   <td class="auto-style4"><asp:Label ID="Label6" runat="server" Text="Completed On" CssClass="auto-style11"></asp:Label></td>
                   <td class="auto-style5"><asp:Label ID="Lab_com" runat="server" Text="" CssClass="auto-style11"></asp:Label></td>
               </tr>
               <tr>
                   <td class="auto-style1"> <asp:Label ID="Label9" runat="server" Text="Status" CssClass="auto-style11"></asp:Label> </td>
                   <td class="firstpgbtn"> <asp:Label ID="Lab_stat" runat="server" Text="" CssClass="auto-style11"></asp:Label>
                   </td>
               </tr>
           </table>
           <br class="auto-style11" />
       </div>
        <div class="search">
            <table class="table">
                <tr>
                    <td class="auto-style12">
            <asp:Label ID="Label14" runat="server" Text="Project ID" CssClass="auto-style11"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="seaprjIDtb" runat="server" CssClass="auto-style11"></asp:TextBox></td>
                </tr>
                    <tr>
                    <td class="auto-style12">
            <asp:Label ID="Label1" runat="server" Text="Project Name" CssClass="auto-style11"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="seaprjNMtb" runat="server" CssClass="auto-style11"></asp:TextBox></td>
                </tr> 
            </table>
            </div>
             <div class="btncol1">
                       
                
         <asp:Button ID="Search"  runat="server" CssClass="auto-style10" Text="SEARCH" OnClick="Search_Click"/><br class="auto-style11" />
         <asp:Button ID="Clearsrch" runat="server" CssClass="auto-style10" Text="CLEAR" OnClick="Clearsrch_Click" />
       </div>
       </div>
     <div class="grid" >
            <asp:GridView ID="GridView1" class="table1" runat="server" ShowHeaderWhenEmpty="True" >
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066"  />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>   </div>
        <asp:TextBox ID="TextBox1" runat="server" Visible="False" CssClass="auto-style11"></asp:TextBox>
        
                    <asp:TextBox ID="logid" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="logdesg" runat="server" Visible="False"></asp:TextBox>
    </form>
</body>
</html>
