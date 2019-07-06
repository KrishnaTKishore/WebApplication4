<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
    <script>
    function validation()								 
{ 
        var id = document.getElementById("usrid_tb");
        var fn=document.getElementById("usrfname_tb");
        var mn=document.getElementById("usrmname_tb");
        var ln = document.getElementById("usrlname_tb");
        var a = document.getElementById("usrddldes_tb");
        var b = document.getElementById("usrddlcmpny");
        var c = document.getElementById("usrddlprj");
        var des =a.options[a.selectedIndex].value;
        var cmp = b.options[b.selectedIndex].value;
        var prj = c.options[c.selectedIndex].value;
        var mail = document.getElementById("usremail_tb");
        //var no = document.getElementById("usrmobno_tb");
        var pass = document.getElementById("usrpass_tb");
        var alpha = /^[A-Za-z]+$/;
        var strongRegex =/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,}$/;

        if ((id.value == "") || (id.value == " ")) {
            window.alert("Please enter user id.");
            id.focus();
            return false;
        }

        else if (fn.value == "" || (fn.value == " ")) {
            window.alert("Please enter first name.");
            fn.focus();
            return false;
        }

            /*

        else if (fn.value.patterMismatch(alpha)) {
            window.alert("Please enter valid first name.");
            fn.focus();
            return false;
        }
     


       /* else if ((mn.value!="")&&(mn.value.patterMismatch(alpha))) {
            window.alert("Please enter valid middle name.");
            mn.focus();

            return false;
        }*/
        else if ((ln.value == "") || (ln.value == " ")) {
            window.alert("Please enter last name.");
            ln.focus();
            return false;
        }
      /*  else if (ln.value.patterMismatch(alpha)) {
            window.alert("Please enter valid last name.");
            ln.focus();
            return false;
        }*/
              else if ((b.selectedIndex <= 1) || (cmp == "other")) {
            window.alert("Please enter valid company.");
            b.focus();
            return false;
        }
               else if (c.selectedIndex == 0) {
            window.alert("Please enter valid project.");
            c.focus();
            return false;
        }
              else if ((a.selectedIndex <= 1) || (des == "other")) {
            window.alert("Please enter valid designation.");
            a.focus();
            return false;
        }
        else if (mail.value == "") {
            window.alert("Please enter a valid e-mail address.");
            mail.focus();
            return false;
        }

        else if (mail.value.indexOf("@", 0) < 0) {
            window.alert("Please enter a valid e-mail address.");
            mail.focus();
            return false;
        }

        else if (mail.value.indexOf(".", 0) < 0) {
            window.alert("Please enter a valid e-mail address.");
            mail.focus();

            return false;
        }
        
     
        else if ((pass.value == "") || (pass.value == " ")) {
            window.alert("Please enter valid password.");
            pass.focus();

            return false;
        }
               else if (pass.value.patterMismatch(strongRegex)) {

            window.alert("password must be of length 8 and should contain atleast one uppercase and one lowercase and one digit ")
            pass.focus();
            return false;

        }
        else {return true;}
        
       
}</script> 

    <link href="css/StyleSheet1.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style2 {
            width: 105px;
        }
        .auto-style3 {
            width: 129px;
        }
    </style>
    </head>
<body class="bodyh" >
    <form id="form1" class="bodyh" runat="server" >
   <div class="combo1">
          <div class="info">

              <table class="table">
                  <tr>
                      <td>user ID<span style="color:red" id="nnnn">*</span></td>
                      <td>
                          <asp:TextBox ID="usrid_tb" runat="server"  ></asp:TextBox>
                       
                      </td>
                    
                  </tr>
                  <tr>
                      <td> 
                          first name<span style="color:red">*</span>
                      </td>
                      <td>
                           <asp:TextBox ID="usrfname_tb" runat="server" ></asp:TextBox>
                      </td>
                      
                  </tr>
                  <tr>
                      <td>
                          <asp:Label ID="Label5" runat="server" Text="middle name"></asp:Label>
                      </td>
                      <td>
                         <asp:TextBox ID="usrmname_tb" runat="server" ></asp:TextBox>
                  </td>
                      
                  </tr>
                   <tr>
                      <td>
                           last name<span style="color:red">*</span>
                      </td>
                      <td>
                           <asp:TextBox ID="usrlname_tb" runat="server" ></asp:TextBox>
                      </td>
                     
                  </tr>               
     
                       <tr>
                <td class="auto-style21">
                    user Company<span style="color:red">*</span></td>
                <td class="auto-style12">
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
                <td class="auto-style21">
                    user project<span style="color:red">*</span></td>
                <td class="auto-style12">
                    <asp:DropDownList ID="usrddlprj" AppendDataBoundItems="true" DataTextField="usrprj" DataValueField="usrprj" runat="server">
                      
                        <asp:ListItem Selected="True" Value=" ">SELECT</asp:ListItem>
                   </asp:DropDownList>
                
                </td>
                
            </tr>
             <tr>
                <td class="auto-style21">
                    user designation<span style="color:red">*</span></td>
                <td class="auto-style12">
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
                <td class="auto-style21">
                    email<span style="color:red">*</span></td>
                <td>
                    <asp:TextBox ID="usremail_tb" runat="server" TextMode="Email" ></asp:TextBox>
                </td>
               
            </tr>
                       <tr>
                <td class="auto-style21">
                    mobile no.</td>
                <td>
                    <asp:TextBox ID="usrmobnotb" runat="server" TextMode="Phone"  ></asp:TextBox>
                </td>
               
            </tr>
              <tr>
                <td class="auto-style21">
                    user password<span style="color:red">*</span></td>
                <td class="auto-style5">
                    <asp:TextBox ID="usrpass_tb" runat="server" ToolTip="password should include an upper-case,lower-case and a digit; the minimun length is 5" ></asp:TextBox>
                    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                  </td>
             </tr>              
              </table></div>
        
    <div class="btncol">
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
        <asp:Button ID="Add_btn" CssClass="button" runat="server" Text="ADD" OnClientClick="return validation();" OnClick="Add_btn_Click" ViewStateMode="Enabled" /><br /><br />

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
                   <td> <asp:Label ID="Label3" runat="server" Text="USER ID"></asp:Label></td>
                   <td> <asp:Label ID="lab_id" runat="server" Text=""></asp:Label></td>
                   <td><asp:Label ID="Label13" runat="server" Text="PROJECT"></asp:Label></td>
                   <td><asp:Label ID="Labprj" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td> <asp:Label ID="Label4" runat="server" Text="FIRST NAME"></asp:Label> </td>
                   <td> <asp:Label ID="Labfnm" runat="server" Text=""></asp:Label></td>
                   <td> <asp:Label ID="Label6" runat="server" Text="DESIGNATION"></asp:Label></td>
                   <td><asp:Label ID="Labdesg" runat="server" Text=""></asp:Label></td>
               </tr>
               <tr>
                   <td> <asp:Label ID="Label9" runat="server" Text="MIDDLE NAME"></asp:Label> </td>
                   <td> <asp:Label ID="Labmnm" runat="server" Text=""></asp:Label></td>
                   <td><asp:Label ID="Label2" runat="server" Text="E-MAIL ID"></asp:Label></td>
                   <td><asp:Label ID="Labmail" runat="server" Text=""></asp:Label></td>
               </tr>

                 <tr>
                   <td> <asp:Label ID="Label10" runat="server" Text="LAST NAME"></asp:Label> </td>
                   <td> <asp:Label ID="Lablnm" runat="server" Text=""></asp:Label></td>
                   <td>  <asp:Label ID="Label8" runat="server" Text="MOBILE No."></asp:Label></td>
                   <td> <asp:Label ID="Labmob" runat="server" Text=""></asp:Label></td>
               </tr>
                 <tr>
                   <td> <asp:Label ID="Label11" runat="server" Text="COMPANY NAME"></asp:Label> </td>
                   <td> <asp:Label ID="Labcmpy" runat="server" Text=""></asp:Label></td>
                   <td><asp:Label ID="Label7" runat="server" Text="PASSWORD"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                     </td>
                   <td>  <asp:Label ID="Labpass" runat="server" Text=""></asp:Label>
                       <asp:Button ID="showpass"  runat="server" Text="Show" OnClick="showpass_Click" />
                   </td>
               </tr>
           </table>
           <br />
        
                 
               
           
            
       </div>
     
        
        <div class="search">
            <table class="table">
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
         <asp:Button ID="Search"  runat="server" CssClass="button1" Text="SEARCH" OnClick="Search_Click" ToolTip="Fill only two fields for searching" /><br /><br />

         <asp:Button ID="Lodbtn"  runat="server"  CssClass="button1" Text="LOAD" OnClick="Lodbtn_Click" /><br /><br />

         <asp:Button ID="Clearsrch" runat="server" CssClass="button1" Text="CLEAR" OnClick="Clearsrch_Click" /><br /><br />

         <asp:Button ID="GrpSRCH"  runat="server" CssClass="button1" Text="GROUP SEARCH" /><br /><br />

   
       </div>
       </div>
        </form>
        
    </body>
</html>
