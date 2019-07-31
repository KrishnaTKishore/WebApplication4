<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OTfirstpg.aspx.cs" Inherits="WebApplication4.OTfirstpg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.disp {
    background-color:darkgray;
    height: 200px;
    width: 400px;
}
        .auto-style11 {
            font-size: small;
        }
        .search {
    float:left;
    height:200px;
    width: 400px;
    top:40%;
}
.table {
    width: 100%;
    height: 100%;
    
}
        .auto-style12 {
            width: 700px;
        }
        .auto-style3 {
            width: 310px;
        }
        .btncol1 {
    width: 250px;
    float:left;
   
}
        .auto-style10 {
            position: center;
            width: 90%;
            height: 15%;
            font-size: small;
        }
        .grid {
    bottom: 0px;
    overflow: scroll;
    position: static;
    width: 100%;
    height: 30%;
    float: left;
    
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div class="combo2">
              <div class="notification">
        <asp:Label ID="notify" runat="server" Text="" CssClass="auto-style11"></asp:Label>
        </div>
            <div class="search">
            <table class="table">
                <tr>
                    <td class="auto-style12">
            <asp:Label ID="Label14" runat="server" Text="Document type" CssClass="auto-style11"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="seadoctyptb" runat="server" OnSelectedIndexChanged="seadoctyptb_SelectedIndexChanged">
                            <asp:ListItem Value="">SELECT</asp:ListItem>
                            <asp:ListItem Value="wir">work inspection request log sheet</asp:ListItem>
                            <asp:ListItem Value="mir">material inspection request log sheet</asp:ListItem>
                            <asp:ListItem Value="ms">material submittal log sheet</asp:ListItem>
                            <asp:ListItem Value="ncr">non-conformance report log sheet</asp:ListItem>
                            <asp:ListItem Value="sor">site observation report log sheet</asp:ListItem>
                            <asp:ListItem Value="mss">method statement submittal log sheet</asp:ListItem>
                            <asp:ListItem Value="scpq">sub cont pre qualification log sheet</asp:ListItem>
                            <asp:ListItem Value="abd">as-built drawing log sheet</asp:ListItem>
                            <asp:ListItem Value="sds">shop drawing submittal log sheet</asp:ListItem>
                            <asp:ListItem Value="rfi">request for information log sheet</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                    <tr>
                    <td class="auto-style12">
            <asp:Label ID="Label1" runat="server" Text="Project Name" CssClass="auto-style11"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        
                    <asp:DropDownList ID="seaprjNMtb" AppendDataBoundItems="true" DataTextField="usrprj" DataValueField="usrprj" runat="server">
                      
                        <asp:ListItem Selected="True" Value=" ">SELECT</asp:ListItem>
                   </asp:DropDownList>
                        </td>
                </tr> 
            </table>
            </div>
             <div class="btncol1">
                       
                
         <asp:Button ID="Search"  runat="server" CssClass="auto-style10" Text="SEARCH" OnClick="Search_Click"/><br class="auto-style11" />
         <asp:Button ID="Clearsrch" runat="server" CssClass="auto-style10" Text="CLEAR" OnClick="Clearsrch_Click" />
       </div>
       </div>
 <div class="grid" >
                 <asp:Panel ID="panel1" runat="server" Height="230px"  ScrollBars="Both" CssClass="grid">
              <asp:GridView ID="GridView1" CssClass="table1" style="height:230px;" runat="server" DataKeyNames="doc" ShowHeaderWhenEmpty="True" >
                 <Columns>
                     <asp:TemplateField>
                         <ItemTemplate>
                  <asp:LinkButton ID="LinkButton1" runat="server" Text="Download File" OnClick="LinkButton1_Click"></asp:LinkButton>
                             </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                  <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066"  />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
              </asp:GridView>  
                      </asp:Panel>
              </div> 
         
        </div>
            <asp:TextBox ID="logid" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="logdesg" runat="server" Visible="False"></asp:TextBox>
        
        <asp:TextBox ID="TextBox1" runat="server" Visible="False" CssClass="auto-style11"></asp:TextBox>
    </form>
</body>
</html>
