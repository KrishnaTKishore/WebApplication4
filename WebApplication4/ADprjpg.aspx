<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADprjpg.aspx.cs" Inherits="WebApplication4.DCprjpg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script>
         function validation() {
             var id = document.getElementById("prjid_tb");
             var nm = document.getElementById("prjnm_tb");
             var cd = document.getElementById("prjcd_tb");
             var com = document.getElementById("prjcom_tb");
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
                     if (!((nm.value.charAt(i) >= 'a' && nm.value.charAt(i) <= 'z') || (nm.value.charAt(i) >= 'A' && nm.value.charAt(i) <= 'Z')||(nm.value.charAt(i)==" "))) {
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
             if (com.value == "01/01/1900") {
                 if (com.value < cd.value) {
                     window.alert("Please enter the completed date as a date after the created date ");
                 }
             }
           /*  if (com.value == "") {
                 com.value = "00/00/0000 00:00:00";
             }*/
         }
         </script>
    <style type="text/css">
        
.fm{
    
    height:1200px;
    width:100%;
}

.info {
    float: left;
    width: 600px;
}

.table {
    width: 100%;
    height: 100%;
}

.btncol {
    width: 200px;
}
.combo {
    width: 400px;
}
.notification {
    background-color: lavender;
    height: 20px;
    width: 100%;
}










.fm1 {
    width: 800px;
}
.bodyh{
    width: 1000px;
    height: 1000px;
}
.tab11 {
    float: left;
    width: 450px;
}

.tab2 {
    float: left;
    width: 280px;
    height: 70%;
}

.tab3 {
    float: left;
    width: 280px;
    height: 70%;
}
  
.btncol1 {
    width: 250px;
    float:left;
   
}
.button {
    position:center;
    width: 90%;
    height:50px;
}
.button1 {
    position: center;
    width: 90%;
    height: 15%;
}

.disp {
    background-color:darkgray;
    height: 200px;
    width: 400px;
}
.search {
    float:left;
    height:200px;
    width: 200px;
    top:40%;
}
.table1 {
    overflow: scroll;
    width: 100%;
    height: 100%;
}
.grid {
    bottom: 0px;
    overflow: scroll;
    position: static;
    width: 100%;
    height: 30%;
    float: left;
    
}
.firstpgbtn{
    width: 300px;
}

    </style>
</head>
<body  >
    <form id="form1" runat="server">
     
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
                <td class="auto-style5">client name:</td>
                <td>
                    <asp:TextBox ID="clnt_tb" runat="server" ></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style5">employer name:</td>
                <td>
                    <asp:TextBox ID="emp_tb" runat="server" ></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style5">consultant name:</td>
                <td>
                    <asp:TextBox ID="cnslt_tb" runat="server" ></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style5">contractor name:</td>
                <td>
                    <asp:TextBox ID="cntrctr_tb" runat="server" ></asp:TextBox>
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
                   </td>
                <td>
                    <asp:DropDownList ID="prjstat_tb" runat="server">
                        <asp:ListItem>STATUS</asp:ListItem>
                        <asp:ListItem>completed</asp:ListItem>
                        <asp:ListItem>ongoing</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        </div>
        <div class="btncol">
           
         <asp:Button ID="add_btn" CssClass="button" runat="server" Text="ADD"    OnClick="add_btn_Click" OnClientClick="return validation();" /><br />
         <asp:Button ID="Update" CssClass="button"  runat="server" Text="UPDATE" OnClick="Update_Click"  OnClientClick="return validation();" /><br />
         <asp:Button ID="Delete" CssClass="button"  runat="server" Text="DELETE" OnClick="Delete_Click" /><br />
         <asp:Button ID="Clear"  CssClass="button"  runat="server" Text="CLEAR"  OnClick="Clear_Click"  /><br />
            </div>
    
        <div class="combo">
    <div class="notification">
        <asp:Label ID="notify" runat="server" Text=""></asp:Label>
        </div>
       <div class="disp">
           <table class="auto-style8">
               <tr>
                   <td><asp:Label ID="Label3" runat="server" Text="PROJECT ID"></asp:Label></td>
                   <td><asp:Label ID="lab_prjid" runat="server" Text=""></asp:Label></td>
                   <td><asp:Label ID="Label13" runat="server" Text="PROJECT NAME"></asp:Label></td>
                   <td><asp:Label ID="Lab_prjnm" runat="server" Text=""></asp:Label></td>
               </tr>
                              <tr>
                   <td><asp:Label ID="Label2" runat="server" Text="CLIENT NAME"></asp:Label></td>
                   <td><asp:Label ID="Lab_clnt" runat="server" Text=""></asp:Label></td>
                   <td><asp:Label ID="Label7" runat="server" Text="EMPLOYER NAME"></asp:Label></td>
                   <td><asp:Label ID="Lab_emp" runat="server" Text=""></asp:Label></td>
               </tr>
                              <tr>
                   <td><asp:Label ID="Label10" runat="server" Text="CONSULTANT NAME"></asp:Label></td>
                   <td><asp:Label ID="Lab_cnslt" runat="server" Text=""></asp:Label></td>
                   <td><asp:Label ID="Label12" runat="server" Text="CONTRACTOR NAME"></asp:Label></td>
                   <td><asp:Label ID="Lab_cntrctr" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td><asp:Label ID="Label4" runat="server" Text="CREATED ON"></asp:Label> </td>
                   <td><asp:Label ID="Lab_cre" runat="server" Text=""></asp:Label></td>
                   <td><asp:Label ID="Label6" runat="server" Text="COMPLETED ON"></asp:Label></td>
                   <td><asp:Label ID="Lab_com" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td> <asp:Label ID="Label9" runat="server" Text="STATUS"></asp:Label> </td>
                   <td> <asp:Label ID="Lab_stat" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
           </table>
           <br />
       </div>
        <div class="search">
            <table class="auto-style8">
                <tr>
                    <td class="auto-style7">
            <asp:Label ID="Label14" runat="server" Text="Project ID"></asp:Label>
                    </td>
                    <td class="auto-style6">
            <asp:TextBox ID="seaprjIDtb" runat="server"></asp:TextBox></td>
                </tr>
                    <tr>
                    <td class="auto-style7">
            <asp:Label ID="Label1" runat="server" Text="Project Name"></asp:Label>
                    </td>
                    <td class="auto-style6">
            <asp:TextBox ID="seaprjNMtb" runat="server"></asp:TextBox></td>
                </tr> 
            </table>
            </div>
            <div class="btncol1">
         <asp:Button ID="Search"  runat="server" CssClass="button1" Text="SEARCH" OnClick="Search_Click"/><br />
         <asp:Button ID="Lodbtn"  runat="server"  CssClass="button1" Text="LOAD" OnClick="Lodbtn_Click" /><br />
         <asp:Button ID="Clearsrch" runat="server" CssClass="button1" Text="CLEAR" OnClick="Clearsrch_Click" />
                 </div>
       
       </div>
       
        <div class="grid" >
            <asp:GridView ID="GridView1" class="table1" runat="server"  AutoGenerateSelectButton="True" ShowHeaderWhenEmpty="True" ShowHeader="true"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True"  ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066"  />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>   </div>
         <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                 <br />
            <asp:TextBox ID="logid" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="logdesg" runat="server" Visible="False"></asp:TextBox>
            
    </form>
</body>
</html>
