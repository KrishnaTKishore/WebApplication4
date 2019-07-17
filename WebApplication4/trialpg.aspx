<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trialpg.aspx.cs" Inherits="WebApplication4.trialpg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
                          <asp:TextBox ID="usrid_tb" runat="server"  ></asp:TextBox>
                       
            <asp:Panel ID="pnlTextBoxes" runat="server">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                </asp:CheckBoxList>
            </asp:Panel>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:Button ID="trialadd" runat="server" OnClick="trialadd_Click" Text="ADD" />
        </div>
    </form>
</body>
</html>
