﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DCprjpg.aspx.cs" Inherits="WebApplication4.DCprjpg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script>
         function validation() {
             var id = document.getElementById("prjid_tb");
             var nm = document.getElementById("prjnm_tb");
             var cd = document.getElementById("prjcd_tb");
            // var com = document.getElementById("prjcom_tb");
            // var stat = document.getElementById("prjstat_tb");

             if ((id.value == "") || (id.value == " ")) {
                 window.alert("Please enter project id.");
                 id.focus();
                 return false;
             }

             if ((nm.value == "") || (nm.value == " ")) {
                 window.alert("Please enter project name.");
                 nm.focus();
                 return false;
             }

             else {
                 for (var i = 0; i < nm.value.length; i++) {
                     if (!((nm.value.charAt(i) >= 'a' && nm.value.charAt(i) <= 'z') || (nm.value.charAt(i) >= 'A' && nm.value.charAt(i) <= 'Z'))) {
                         window.alert("enter alphabets only in project name field");
                         nm.focus();
                         return false;
                     }
                 }
             }

             if (cd.value == "")
                 {
                 window.alert("Please enter created date.");
                 cd.focus();
                 return false;
             }
         }
         </script>
            
    <style type="text/css">


        .auto-style5 {
            width: 231px;
        }
        </style>
   <link href="css/StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body class="bodyh" >
    <form id="form1" class="bodyh" runat="server">
     
        <div class="combo1">
            <div class="info">
        <table class="table">
            <tr>
                <td class="auto-style5">project id:</td>
                <td>
                    <asp:TextBox ID="prjid_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">project name:</td>
                <td>
                    <asp:TextBox ID="prjnm_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">project creation date:</td>
                <td>
                    <asp:TextBox ID="prjcd_tb" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">project completion date:</td>
                <td>
                    <asp:TextBox ID="prjcom_tb" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
        
            <tr>
                <td class="auto-style5">project status: 
                    completed : checked
                   </td>
                <td>
                    <asp:DropDownList ID="prjstat_tb" runat="server">
                        <asp:ListItem>True</asp:ListItem>
                        <asp:ListItem>False</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table></div>
        <div class="btncol">
            
            <br />
            <asp:Button ID="add_btn" runat="server" CssClass="button"  OnClick="add_btn_Click" Text="ADD"  /><br /><br />
         <asp:Button ID="Update" CssClass="button"  runat="server" Text="UPDATE" OnClick="Update_Click" /><br /><br />

         <asp:Button ID="Delete" CssClass="button"  runat="server" Text="DELETE" OnClick="Delete_Click" /><br /><br />

         <asp:Button ID="Clear"  CssClass="button" runat="server" Text="CLEAR" OnClick="Clear_Click" /><br /><br />

            </div>
                <div class="grid" >
            <asp:GridView ID="GridView1" class="table" runat="server"  AutoGenerateSelectButton="True" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066"  />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>   </div> </div>


        <div class="combo">
    <div class="notification">
        <asp:Label ID="notify" runat="server" Text=""></asp:Label>
        </div>
       <div class="disp">
           <table class="table">
               <tr>
                   <td><asp:Label ID="Label3" runat="server" Text="PROJECT ID"></asp:Label></td>
                   <td><asp:Label ID="lab_prjid" runat="server" Text=""></asp:Label></td>
                   <td><asp:Label ID="Label13" runat="server" Text="PROJECT NAME"></asp:Label></td>
                   <td><asp:Label ID="Lab_prjnm" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td><asp:Label ID="Label4" runat="server" Text="CREATED ON"></asp:Label> </td>
                   <td><asp:Label ID="Lab_cre" runat="server" Text=""></asp:Label></td>
                   <td><asp:Label ID="Label6" runat="server" Text="COMPLETED ON"></asp:Label></td>
                   <td><asp:Label ID="Lab_com" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td> <asp:Label ID="Label9" runat="server" Text="STATUS"></asp:Label> </td>
                   <td> <asp:Label ID="Lab_stat" runat="server" Text=""></asp:Label></td>
               </tr>

           </table>
           <br />
        
                 
               
           
            
       </div>
     
        
        <div class="search">
            <table class="table">
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label14" runat="server" Text="Project ID"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="seaprjIDtb" runat="server"></asp:TextBox></td>
                   
                </tr>
                    <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Project Name"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="seaprjNMtb" runat="server"></asp:TextBox></td>
                   
                </tr>
   
                   
 
                    
            </table>
            </div>
       
        
       
             <div class="btncol1">
                 <br /><br />
         <asp:Button ID="Search"  runat="server" CssClass="button" Text="SEARCH" OnClick="Search_Click" ToolTip="Fill only two fields for searching" /><br /><br />

         <asp:Button ID="Lodbtn"  runat="server"  CssClass="button" Text="LOAD" OnClick="Lodbtn_Click" /><br /><br />

         <asp:Button ID="Clearsrch" runat="server" CssClass="button" Text="CLEAR" OnClick="Clearsrch_Click" />

        <!-- <asp:Button ID="GrpSRCH"  runat="server" CssClass="button1" Text="GROUP SEARCH" />  -->

   
       </div>
       </div>
    </form>
   
</body>
</html>