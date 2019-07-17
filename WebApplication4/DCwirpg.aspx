<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DCwirpg.aspx.cs" Inherits="WebApplication4.ADcmppg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.fm1 {
    width: 1000px;
}

.info {
    float: left;
    width: 60%;
    height: 70%;
}
.table {
    width: 100%;
    height: 100%
}
        .auto-style5 {
            width: 231px;
        }
.btncol {
    width: 20%;
    float: right;
    left:60%;
}
.button {
    width: 90%;
    height:19%;
}
.grid {
    bottom: 0px;
    overflow: scroll;
    position: static;
    width: 100%;
    height: 30%;
    float: left;
}

.notification {
    background-color:lavender;
    height:10%;
    width: 100%;
}
.disp {
    background-color:darkgray;
    height: 30%;
    width: 100%;
}
.search {
    float:left;
    height:60%;
    width: 40%;
    top:40%;
}
.auto-style7 {
            width: 44px;
        }
.auto-style6 {
            width: 128px;
        }
.btncol1 {
    width: 20%;
    float: right;
    top:42%;
    left:60%;
}
.button1 {
    position: center;
    width: 90%;
    height: 15%;
}
.tab1{
    width:50%;
}
.tab11{
    float:left;
    width:40%;
}
.tab2{
    float:left;
    width: 30%;
    height:70%;
    left:60%;
}
.tables{
    width:70%;
}
.hlf{
    height:50%;
    width:100%;
}
.auto-style9 {
            width: 383px;
            height: 42px;
}
.auto-style10 {
            height: 42px;
}
.auto-style11 {
            width: 383px;
}
    </style>
    <link href="css/StyleSheet1.css" rel="stylesheet" type="text/css" />

</head>
<body >
    <form id="form1" class="fm1" runat="server">
               <div class="hlf">
                <div class="tab11">
        <table class="table">
           
            <tr>
                <td class="auto-style11">ID:</td>
                <td>
                    <asp:TextBox ID="prjnm_tb" runat="server"></asp:TextBox>
                    </td>
               </tr>
            <tr>
                <td class="auto-style11">work inspection request:</td>
                <td>
                    <asp:TextBox ID="wir_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">work inspection ref no.:</td>
                <td>
                    <asp:TextBox ID="wirno_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style11">boq ref.:</td>
                <td>
                    <asp:TextBox ID="boqref_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style11">location:</td>
                <td>
                    <asp:TextBox ID="loc_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style11">site engineer:</td>
                <td>
                    <asp:TextBox ID="site_engr" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style11">reason of C & D:</td>
                <td>
                    <asp:TextBox ID="cd_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style11">sub-contractor:</td>
                <td>
                    <asp:TextBox ID="subcon_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td class="auto-style11">decipline:</td>
                <td>
                    <asp:TextBox ID="decipline" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">Current Status</td>
                
            </tr>
        <tr>
            <td class="auto-style11"> submitted date:</td>
                <td>
                    <asp:TextBox ID="cur_stat_sub_dt_tb" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style11"> responsed date:</td>
                <td>
                    <asp:TextBox ID="cur_stat_rsp_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style11">status:</td>
                <td>
                    <asp:TextBox ID="cur_stat_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style11">total no. of revisions:</td>
                <td>
                    <asp:TextBox ID="cur_stat_rev_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style11">No. of days:</td>
                <td>
                    <asp:TextBox ID="no_of_dys_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">Remark:</td>
                <td>
                    <asp:TextBox ID="remrk_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">reason for over due:</td>
                <td class="auto-style10">
                    <asp:TextBox ID="rsn_fr_over_due" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
<td class="auto-style11">document:</td>
                <td>

                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="upld_btn" runat="server" OnClick="upld_btn_Click" Text="Upload" />

                </td>
            </tr>
            </table></div> 
                    <div class="tab2">
                <table class="table">
                              <tr><td colspan="2">Revision 01</td></tr>
              <tr>
                <td class="auto-style5">submitted date:</td>
                <td>
                    <asp:TextBox ID="rev1_sub_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style5">returned date:</td>
                <td>
                    <asp:TextBox ID="rev1_ret_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style5">status:</td>
                <td>
                    <asp:TextBox ID="rev1_stat_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
                              <tr><td colspan="2">Revision 02</td></tr>
              <tr>
                <td class="auto-style5">submitted date:</td>
                <td>
                    <asp:TextBox ID="rev2_sub_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style5">returned date:</td>
                <td>
                    <asp:TextBox ID="rev2_ret_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style5">status:</td>
                <td>
                    <asp:TextBox ID="rev2_stat_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
                              <tr><td colspan="2">Revision 03</td></tr>
              <tr>
                <td class="auto-style5">submitted date:</td>
                <td>
                    <asp:TextBox ID="rev3_sub_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style5">returned date:</td>
                <td>
                    <asp:TextBox ID="rev3_ret_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style5">status:</td>
                <td>
                    <asp:TextBox ID="rev3_stat_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
                              <tr><td colspan="2">Revision 04</td></tr>
              <tr>
                <td class="auto-style5">submitted date:</td>
                <td>
                    <asp:TextBox ID="rev4_sub_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style5">returned date:</td>
                <td>
                    <asp:TextBox ID="rev4_ret_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style5">status:</td>
                <td>
                    <asp:TextBox ID="rev4_stat_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
                              <tr><td colspan="2">Revision 05</td></tr>
              <tr>
                <td class="auto-style5">submitted date:</td>
                <td>
                    <asp:TextBox ID="rev5_sub_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style5">returned date:</td>
                <td>
                    <asp:TextBox ID="rev5_ret_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style5">status:</td>
                <td>
                    <asp:TextBox ID="rev5_stat_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
                              <tr><td colspan="2">Revision 06</td></tr>
              <tr>
                <td class="auto-style5">submitted date:</td>
                <td>
                    <asp:TextBox ID="rev6_sub_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style5">returned date:</td>
                <td>
                    <asp:TextBox ID="rev6_ret_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style5">status:</td>
                <td>
                    <asp:TextBox ID="rev6_stat_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
                              <tr><td colspan="2">Revision 07</td></tr>
              <tr>
                <td class="auto-style5">submitted date:</td>
                <td>
                    <asp:TextBox ID="rev7_sub_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style5">returned date:</td>
                <td>
                    <asp:TextBox ID="rev7_ret_dt_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style5">status:</td>
                <td>
                    <asp:TextBox ID="rev7_stat_tb" runat="server"></asp:TextBox>
                </td>
            </tr>
              
        </table>
      
                </div>
                   
                <div class="btncol">
                    <div class="notification">
        
        <asp:Label ID="notify" runat="server" Text=""></asp:Label>
                        </div> 
            <br />
                    <br />
         <asp:Button ID="add_btn" CssClass="button" runat="server" Text="ADD"    OnClick="add_btn_Click" OnClientClick="return validation();"/><br /><br />
         <asp:Button ID="Update" CssClass="button"  runat="server" Text="UPDATE" OnClick="Update_Click"  OnClientClick="return validation();" /><br /><br />
         <asp:Button ID="Delete" CssClass="button"  runat="server" Text="DELETE" OnClick="Delete_Click" /><br /><br />
         <asp:Button ID="Clear"  CssClass="button"  runat="server" Text="CLEAR"  OnClick="Clear_Click"  /><br /><br />
            </div>
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
            </asp:GridView>   </div> 
                <div>
    <div class="notification">
        </div>
        <div class="search">
            <table class="table">
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
                       <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                 <br />
         <asp:Button ID="Search"  runat="server" CssClass="button1" Text="SEARCH" OnClick="Search_Click"/><br /><br />
         <asp:Button ID="Clearsrch" runat="server" CssClass="button1" Text="CLEAR" OnClick="Clearsrch_Click" />
       </div>
       </div>
    </form>
</body>
</html>
