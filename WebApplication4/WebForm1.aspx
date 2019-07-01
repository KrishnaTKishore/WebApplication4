<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
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
                          <asp:TextBox ID="empid_tb" runat="server" ></asp:TextBox>
                       
                      </td>
                    
                  </tr>
                  <tr>
                      <td> 
                          first name<span style="color:red">*</span>
                      </td>
                      <td>
                           <asp:TextBox ID="fname_tb" runat="server" ></asp:TextBox>
                      </td>
                      
                  </tr>
                  <tr>
                      <td>
                          <asp:Label ID="Label5" runat="server" Text="middle name"></asp:Label>
                      </td>
                      <td>
                         <asp:TextBox ID="mname_tb" runat="server" ></asp:TextBox>
                  </td>
                      
                  </tr>
                   <tr>
                      <td>
                           last name<span style="color:red">*</span>
                      </td>
                      <td>
                           <asp:TextBox ID="lname_tb" runat="server" ></asp:TextBox>
                      </td>
                     
                  </tr>               
     
             <tr>
                <td class="auto-style21">
                    user designation<span style="color:red">*</span></td>
                <td class="auto-style12">
                    <asp:DropDownList ID="empdes_tb" AppendDataBoundItems="true" DataTextField="emp_designation" DataValueField="emp_designation" runat="server"  AutoPostBack="True">
                       <asp:ListItem Value="other" />
                        <asp:ListItem Selected="True" Value=" ">SELECT</asp:ListItem>
                   </asp:DropDownList>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    <asp:Button ID="Button1" runat="server"  Text="ADD" />
                </td>
                
            </tr>
            
                        <tr>
                <td class="auto-style21">
                    email<span style="color:red">*</span></td>
                <td>
                    <asp:TextBox ID="email_tb" runat="server" TextMode="Email" ></asp:TextBox>
                </td>
               
            </tr>
              <tr>
                <td class="auto-style21">
                    user password<span style="color:red">*</span></td>
                <td class="auto-style5">
                    <asp:TextBox ID="emppass_tb" runat="server" Text="********" textmode="Password" ToolTip="password should include an upper-case,lower-case and a digit; the minimun length is 5" ></asp:TextBox>
                  </td>
             </tr>              
              </table></div>
        
    <div class="btncol">
        <asp:Button ID="add_btn" CssClass="button" runat="server" Text="ADD" /><br /><br />

         <asp:Button ID="update" CssClass="button"  runat="server" Text="UPDATE" /><br /><br />

         <asp:Button ID="deleteuser" CssClass="button"  runat="server" Text="DELETE" /><br /><br />

         <asp:Button ID="clear"  CssClass="button" runat="server" Text="CLEAR" /><br /><br />

    </div>
            <div class="grid" >
            <asp:GridView ID="GridView1" class="table" runat="server"  AutoGenerateSelectButton="True" ShowHeaderWhenEmpty="True">
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
                   <td><asp:Label ID="Label7" runat="server" Text="PASSWORD"></asp:Label></td>
                   <td>  <asp:Label ID="Labpass" runat="server" Text=""></asp:Label>
                       <asp:Button ID="showpass"  runat="server" Text="Show" />
                   </td>
               </tr>
           </table>
           <br />
        
                 
               
           
            
       </div>
     
        
        <div class="search">
            <table class="table">
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
                    <td>
                        &nbsp;</td>
                </tr>
                    <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="Button4"  runat="server" Text="Button" />
                    </td>
                </tr>
                    <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="Button5" runat="server" Text="Button" />
                    </td>
                </tr>
                    <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="Button6"  runat="server" Text="Button" />
                    </td>
                </tr>
                    <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="Button7"  runat="server" Text="Button" />
                    </td>
                </tr>
            </table>
            </div>
        </div>
        </form>
        
    </body>
</html>
