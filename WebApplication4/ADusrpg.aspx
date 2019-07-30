<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADusrpg.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
    <script>
        function validation() {
            var id = document.getElementById("usrid_tb");
            var fn = document.getElementById("usrfname_tb");
            var mn = document.getElementById("usrmname_tb");
            var ln = document.getElementById("usrlname_tb");
            var a = document.getElementById("usrddldes_tb");
            var b = document.getElementById("usrddlcmpny");
            var c = document.getElementById("usrddlprj");
            var des = a.options[a.selectedIndex].value;
            var cmp = b.options[b.selectedIndex].value;
            var prj = c.options[c.selectedIndex].value;
            var mail = document.getElementById("usremail_tb");
            var pass = document.getElementById("usrpass_tb");
            var no = document.getElementById("usrmobnotb");
            
            if ((id.value == "") || (id.value == " ")) {
                window.alert("Please enter user id.");
                id.focus();
                return false;
            }

             if ((fn.value == "") || (fn.value == " ")) {
                window.alert("Please enter first name.");
                fn.focus();
                return false;
            }
            
            else {
                    for (var i = 0; i < fn.value.length; i++) {
                        if (!((fn.value.charAt(i) >= 'a' && fn.value.charAt(i) <= 'z') || (fn.value.charAt(i) >= 'A' && fn.value.charAt(i) <= 'Z'))) {
                            window.alert("enter alphabets only in first name field");
                            fn.focus();
                            return false;
                        }
                    }
                }
            
            if (mn.value != "") {
                for (var j = 0; j < mn.value.length;j++) {
                    if (!((mn.value.charAt(j) >= 'a' && mn.value.charAt(j) <= 'z') || (mn.value.charAt(j) >= 'A' && mn.value.charAt(j) <= 'Z'))) {
                        window.alert("enter alphabets only in middle name field");
                        mn.focus();
                        return false;
                    }
                }
            }
         
            if ((ln.value == "") || (ln.value == " ")) {
                window.alert("Please enter last name.");
                ln.focus();
                return false;
            }
            else {
                for (var i = 0; i < ln.value.length; i++) {
                    if (!((ln.value.charAt(i) >= 'a' && ln.value.charAt(i) <= 'z') || (ln.value.charAt(i) >= 'A' && ln.value.charAt(i) <= 'Z'))) {
                        window.alert("enter apphabets only in last name field");
                        return false;
                    }
                }
            }

     
            if ((b.selectedIndex <= 1) || (cmp == "other")) {
                window.alert("Please enter valid company.");
                b.focus();
                return false;
            }
           if (c.selectedIndex == 0) {
                window.alert("Please enter valid project.");
                c.focus();
                return false;
            }
             if ((a.selectedIndex <= 1) || (des == "other")) {
                window.alert("Please enter valid designation.");
                a.focus();
                return false;
            }
            if (mail.value == "") {
                window.alert("Please enter a valid e-mail address.");
                mail.focus();
                return false;
            }

             if (mail.value.indexOf("@", 0) < 0) {
                window.alert("Please enter a valid e-mail address.");
                mail.focus();
                return false;
            }

            if (mail.value.indexOf(".", 0) < 0) {
                window.alert("Please enter a valid e-mail address.");
                mail.focus();

                return false;
            }

            if (no.value.length != 10) {
                window.alert("Please enter a valid phone no.");
                no.focus();

                return false;
            }

            if ((pass.value == "") || (pass.value == " ")) {
                window.alert("Please enter valid password.");
                pass.focus();

                return false;
            }

            if (pass.value.length < 8) {


                window.alert("password must be of minimum length 8 ")
                pass.focus();
                return false;

            }
             if (pass.value != "") {
                var c = 0;
                var a = 0;
                var b = 0;
                 var d = 0;
                 var s = 0;

                for (var i = 0; i < pass.value.length; i++) {
                    if (pass.value[i] >= 'a' && pass.value[i] <= 'z') {
                        c++;

                    }
                    else if (pass.value[i] >= 'A' && pass.value[i] <= 'Z') {
                        a++;

                    }
                    else if (pass.value[i] >= '0' && pass.value[i] <= '9') {
                        b++;
                    }
                    else if (pass.value[i] == " ")
                    {
                        s++;
                    }

                    else 
                    {
                        d++;
                       
                    }
                    
                 }
                 if (c == 0) {
                      window.alert("password should contain atleast one lowercase ")
                    pass.focus();
                    return false;

                 }
                   if (a == 0) {
                      window.alert("password should contain atleast one uppercase ")
                    pass.focus();
                    return false;

                 }
                 if (b == 0) {
                         window.alert("password should contain atleast one digit ")
                    pass.focus();
                    return false;

                 }
                if  (d == 0) {
                    window.alert("password should contain atleast one special character ")
                    pass.focus();
                    return false;
                 }
                   if  (s != 0) {
                    window.alert("password should not contain spaces ")
                    pass.focus();
                    return false;
                 }

            }
            
                return true;
        }</script> 

    <link href="css/StyleSheet1.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style2 {
            width: 200px;
        }
        .auto-style3 {
            width: 129px;
        }
        .auto-style4 {
            background-color: darkgray;
            height: 200px;
            width: 100%;
            font-size: small;
        }
        .auto-style5 {
            width: 100%;
            height: 100%;
            font-size: small;
        }
        .auto-style6 {
            font-size: small;
        }
        .auto-style8 {
            font-size: small;
            width: 200px;
        }
        .auto-style9 {
            width: 100%;
        }
    </style>
    </head>
<body  >
    <form id="form1"  runat="server" >
        <div class="hlf">   
          <div class="tab11">
              <table>
                  <tr>
                      <td class="auto-style2"><span class="auto-style6">User ID</span><span style="color:red" id="nnnn" class="auto-style6">*</span></td>
                      <td class="auto-style9">
                          <asp:TextBox ID="usrid_tb" runat="server"  ></asp:TextBox>                       
                      </td>                    
                  </tr>
                  <tr>
                      <td class="auto-style2"> 
                          <span class="auto-style6">First name</span><span style="color:red" class="auto-style6">*</span><span class="auto-style6"> </span>
                      </td>
                      <td class="auto-style9">
                           <asp:TextBox ID="usrfname_tb" runat="server" ></asp:TextBox>
                      </td>
                      
                  </tr>
                  <tr>
                      <td class="auto-style2">
                          <asp:Label ID="Label5" runat="server" Text="Middle Name" CssClass="auto-style6"></asp:Label>
                      </td>
                      <td class="auto-style9">
                         <asp:TextBox ID="usrmname_tb" runat="server" ></asp:TextBox>
                  </td>                      
                  </tr>
                   <tr>
                      <td class="auto-style2">
                           <span class="auto-style6">Last Name</span><span style="color:red" class="auto-style6">*</span><span class="auto-style6"> </span>
                      </td>
                      <td class="auto-style9">
                           <asp:TextBox ID="usrlname_tb" runat="server" ></asp:TextBox>
                      </td>                     
                  </tr>    
                       <tr>
                <td class="auto-style2">
                    <span class="auto-style6">User Company</span><span style="color:red" class="auto-style6">*</span></td>
                <td class="auto-style9">
                    <asp:DropDownList ID="usrddlcmpny" AppendDataBoundItems="true" DataTextField="usrcomp" DataValueField="usrcomp" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="usrddlcmpny_SelectedIndexChanged">
                       <asp:ListItem Value="other" />
                        <asp:ListItem Selected="True" Value=" ">SELECT</asp:ListItem>
                   </asp:DropDownList>                    
                    <asp:TextBox ID="newcomptb" runat="server" ></asp:TextBox>
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                    <asp:Button ID="addnewcompbtn" runat="server"  Text="ADD" OnClick="addnewcompbtn_Click" />
                </td>                
            </tr>
                      <tr>
                <td class="auto-style2">
                    <span class="auto-style6">User Project</span><span style="color:red" class="auto-style6">*</span></td>
                <td class="auto-style9">
                    <asp:CheckBoxList ID="usrddlprj" runat="server">
                    </asp:CheckBoxList>
                </td>                
            </tr>
             <tr>
                <td class="auto-style2">
                    <span class="auto-style6">User Designation</span><span style="color:red" class="auto-style6">*</span></td>
                <td class="auto-style9">
                    <asp:DropDownList ID="usrddldes_tb" AppendDataBoundItems="true" DataTextField="emp_designation" DataValueField="emp_designation" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="usrddldes_tb_SelectedIndexChanged">
                       <asp:ListItem Value="other" />
                        <asp:ListItem Selected="True" Value=" ">SELECT</asp:ListItem>
                   </asp:DropDownList>
                    <asp:TextBox ID="newusrdesgtb" runat="server"></asp:TextBox>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    <asp:Button ID="addnewdesbtn" runat="server"  Text="ADD" OnClick="addnewdesbtn_Click" />
                </td>                
            </tr>            
                        <tr>
                <td class="auto-style2">
                    <span class="auto-style6">Email</span><span style="color:red" class="auto-style6">*</span></td>
                <td class="auto-style9">
                    <asp:TextBox ID="usremail_tb" runat="server" TextMode="Email" ></asp:TextBox>
                </td>               
            </tr>
                       <tr>
                <td class="auto-style8">
                    Mobile no.</td>
                <td class="auto-style9">
                    <asp:TextBox ID="usrmobnotb" runat="server" TextMode="Number"  ></asp:TextBox>
                </td>               
            </tr>
              <tr>
                <td class="auto-style2">
                    <span class="auto-style6">User Password</span><span style="color:red" class="auto-style6">*</span></td>
                <td class="auto-style5">
                    <asp:TextBox ID="usrpass_tb" runat="server" ToolTip="password should include an upper-case,lower-case and a digit; the minimun length is 5" ></asp:TextBox>                    
                  </td>
             </tr>              
              </table></div>        
          <div class="btncol1">
        
        <asp:Button ID="Add_btn" CssClass="button" runat="server" Text="ADD" OnClientClick="return validation();" OnClick="Add_btn_Click" /><br />

         <asp:Button ID="Update" CssClass="button"  runat="server" Text="UPDATE" OnClientClick="return validation();" OnClick="Update_Click" /><br />

         <asp:Button ID="Delete" CssClass="button"  runat="server" Text="DELETE" OnClick="Delete_Click" /><br />

         <asp:Button ID="Clear"  CssClass="button" runat="server" Text="CLEAR" OnClick="Clear_Click" /><br />

    </div>            
          <div class="notification">
        <asp:Label ID="notify" runat="server" Text=""></asp:Label>
        </div>
          <div class="auto-style4">
           <table class="table">
               <tr>
                   <td> <asp:Label ID="Label3" runat="server" Text="USER ID"></asp:Label></td>
                   <td> <asp:Label ID="lab_id" runat="server" Text=""></asp:Label></td>
                   <td> <asp:Label ID="Label6" runat="server" Text="DESIGNATION"></asp:Label></td>
                   <td><asp:Label ID="Labdesg" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td> <asp:Label ID="Label4" runat="server" Text="FIRST NAME"></asp:Label> </td>
                   <td> <asp:Label ID="Labfnm" runat="server" Text=""></asp:Label></td>
                   <td><asp:Label ID="Label2" runat="server" Text="E-MAIL ID"></asp:Label></td>
                   <td><asp:Label ID="Labmail" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td> <asp:Label ID="Label9" runat="server" Text="MIDDLE NAME"></asp:Label> </td>
                   <td> <asp:Label ID="Labmnm" runat="server" Text=""></asp:Label></td>
                   <td>  <asp:Label ID="Label8" runat="server" Text="MOBILE No."></asp:Label></td>
                   <td> <asp:Label ID="Labmob" runat="server" Text=""></asp:Label></td>
               </tr>

                 <tr>
                   <td> <asp:Label ID="Label10" runat="server" Text="LAST NAME"></asp:Label> </td>
                   <td> <asp:Label ID="Lablnm" runat="server" Text=""></asp:Label></td>
               </tr>
                 <tr>
                   <td> <asp:Label ID="Label11" runat="server" Text="COMPANY NAME"></asp:Label> </td>
                   <td> <asp:Label ID="Labcmpy" runat="server" Text=""></asp:Label></td>
                   <td><asp:Label ID="Label7" runat="server" Text="PASSWORD"></asp:Label>
                    
                     </td>
                   <td>  <asp:Label ID="Labpass" runat="server" Text=""></asp:Label>
                       <asp:Button ID="showpass"  runat="server" Text="Show" OnClick="showpass_Click" Width="60px" />
                       <asp:Button ID="Hide" runat="server" OnClick="Hide_Click" Text="Hide" Width="60px" />
                   </td>
               </tr>
           </table>
           <br />
        
            
       </div>
          <div class="search">
            <table class="auto-style5">
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label14" runat="server" Text="User ID"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="seausrIDtb" runat="server"></asp:TextBox></td>
                   
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label15" runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="seausrFNtb" runat="server"></asp:TextBox></td>
                   
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label16" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="seausrLNtb" runat="server"></asp:TextBox></td>
                   
                </tr>
                    <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label20" runat="server" Text="Project Name"></asp:Label>
                    </td>
                    <td class="auto-style3">
             <asp:DropDownList ID="ddlseaprj" AppendDataBoundItems="true" DataTextField="usrprj" DataValueField="usrprj" runat="server"  AutoPostBack="True">
                      
                        <asp:ListItem Selected="True" Value=" ">SELECT</asp:ListItem>
                   </asp:DropDownList></td>
                   
                </tr>
                    <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label21" runat="server" Text="Company Name"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlseacomp" AppendDataBoundItems="true" DataTextField="usrprj" DataValueField="usrprj" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlseacomp_SelectedIndexChanged">
                 
                        <asp:ListItem Selected="True" Value=" ">SELECT</asp:ListItem>
                   </asp:DropDownList></td>
             
                </tr>
                    <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label22" runat="server" Text="Designation"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="seausrdesgtb" AppendDataBoundItems="true" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlseacomp_SelectedIndexChanged">
                 
                        <asp:ListItem Selected="True" Value=" ">SELECT</asp:ListItem>
                   </asp:DropDownList></td>
                   
                </tr>
                    
            </table>
            </div>
          <div class="btncol1">
                
         <asp:Button ID="Search"  runat="server" CssClass="button1" Text="SEARCH" OnClick="Search_Click" ToolTip="Fill only two fields for searching" /><br />

         <asp:Button ID="Lodbtn"  runat="server"  CssClass="button1" Text="LOAD" OnClick="Lodbtn_Click" /><br />

         <asp:Button ID="Clearsrch" runat="server" CssClass="button1" Text="CLEAR" OnClick="Clearsrch_Click" />

        <!-- <asp:Button ID="GrpSRCH"  runat="server" CssClass="button1" Text="GROUP SEARCH" />  -->

   
       </div>
       
            </div>
        <div class="grid" >
            <asp:GridView ID="GridView1" class="table1" runat="server"  AutoGenerateSelectButton="True" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
        </form>
        
    </body>
</html>
