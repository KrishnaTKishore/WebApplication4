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
                      <td>
                          <asp:Label ID="Label2" runat="server" Text="user id"></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                      </td>
                    
                  </tr>
                  <tr>
                      <td>
                          <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                      </td>
                      
                  </tr>
                  <tr>
                      <td>
                          <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                      </td>
                      
                  </tr>
                   <tr>
                      <td>
                          <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                      </td>
                     
                  </tr>
                   <tr>
                      <td>
                          <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                      </td>
                      
                  </tr>
                   <tr>
                      <td>
                          <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                      </td>
                      
                  </tr>
                   <tr>
                      <td>
                          <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                      </td>
                      
                  </tr>
              </table></div>
        
    <div class="btncol">
        <asp:Button ID="add" CssClass="button" runat="server" Text="ADD" /><br /><br />

         <asp:Button ID="update" CssClass="button"  runat="server" Text="UPDATE" /><br /><br />

         <asp:Button ID="delete" CssClass="button"  runat="server" Text="DELETE" /><br /><br />

         <asp:Button ID="clear"  CssClass="button" runat="server" Text="CLEAR" /><br /><br />

    </div>
            <div class="grid" >
            <asp:GridView ID="GridView1" class="table" runat="server"></asp:GridView>
        </div> </div>
   <div class="combo">
    <div class="notification">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
       <div class="disp">
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label><br />

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
                        <asp:Button ID="Button4" class="button" runat="server" Text="Button" />
                    </td>
                </tr>
                    <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="Button5" CssClass="button" runat="server" Text="Button" />
                    </td>
                </tr>
                    <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="Button6" class="button" runat="server" Text="Button" />
                    </td>
                </tr>
                    <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="Button7" class="button" runat="server" Text="Button" />
                    </td>
                </tr>
            </table>
            </div>
    </div>
        </form>
        
    </body>
</html>
