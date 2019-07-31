<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DCncrpg.aspx.cs" Inherits="WebApplication4.DCncrpg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
      /*  function openpopup(){
            var winpops = window.open("search.aspx", "", "width=400,height=400,scrollbars,resizable,");
            
            //document.getElementById("TextBox1").value = "999";

           //document.getElementById("Search").click(); 
           
        }
        function opensearch() {
            document.getElementById("Search").click();
      }*/
        function validation() {
            var wir = document.getElementById("mat_desc_tb");
            var wirno = document.getElementById("matno_tb");
            //var boqref = document.getElementById("boqref_tb");
            var loc = document.getElementById("loc_tb");
            var se = document.getElementById("site_engr");
            var cd = document.getElementById("cd_tb");
            var subcon = document.getElementById("subcon_tb");
            var des = document.getElementById("decipline");
            var cssd = document.getElementById("cur_stat_sub_dt_tb");
            var csrd = document.getElementById("cur_stat_rsp_dt_tb");
            var cs = document.getElementById("cur_stat_tb");
            var csr = document.getElementById("cur_stat_rev_tb");
            var nod = document.getElementById("no_of_dys_tb");
            var remrk = document.getElementById("remrk_tb");
            //var rfod = document.getElementById("rsn_fr_over_due");
            var rsd1 = document.getElementById("rev1_sub_dt_tb");
            var rrd1 = document.getElementById("rev1_ret_dt_tb");
            var rs1 = document.getElementById("rev1_stat_tb");
            var rsd2 = document.getElementById("rev2_sub_dt_tb");
            var rrd2 = document.getElementById("rev2_ret_dt_tb");
            var rs2 = document.getElementById("rev2_stat_tb");
            var rsd3 = document.getElementById("rev3_sub_dt_tb");
            var rrd3 = document.getElementById("rev3_ret_dt_tb");
            var rs3 = document.getElementById("rev3_stat_tb");
            var rsd4 = document.getElementById("rev4_sub_dt_tb");
            var rrd4 = document.getElementById("rev4_ret_dt_tb");
            var rs4 = document.getElementById("rev4_stat_tb");
            var rsd5 = document.getElementById("rev5_sub_dt_tb");
            var rrd5 = document.getElementById("rev5_ret_dt_tb");
            var rs5 = document.getElementById("rev5_stat_tb");
            var rsd6 = document.getElementById("rev6_sub_dt_tb");
            var rrd6 = document.getElementById("rev6_ret_dt_tb");
            var rs6 = document.getElementById("rev6_stat_tb");
            if ((wir == "") || (wir == " ")) {
                window.alert("Please enter the work inspection request");
                return false;
            }
            if ((wirno == "") || (wirno == " ")) {
                window.alert("Please enter the work inspection reference number");
                return false;
            }
            if ((boqref == "") || (boqref == " ")) {
                window.alert("Please enter the boq reference number");
                return false;
            }
            if ((loc == "") || (loc == " ")) {
                window.alert("Please enter the location");
                return false;
            }
            if ((se == "") || (se == " ")) {
                window.alert("Please enter the name of the site engineer");
                return false;
            }
            if ((des == "") || (des == " ")) {
                window.alert("Please enter the decipline");
                return false;
            }

        }      
    </script>
    <style type="text/css">

.fm1 {
    width: 1200px;
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
            width: 100px;
            font-size: small;
        }
.btncol {
    width: 290px;
    float:left;
    
}
.button {
    width: 90%;
    height:19%;
}
.grid {
    bottom: 0px;
    position: static;
    width: 100%;
    float:left;
    bottom:0px;
   
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

.tab11{
    float:left;
    width:450px;
}
.tab2{
    float:left;
    width: 280px;
    height:70%;
}
.tab3{
    float:left;
    width: 280px;
    height:70%;
}
.tables{
    width:70%;
}
.hlf{
    height:50%;
    width:100%;
}
.auto-style9 {
            width: 139px;
            height: 42px;
            font-size: small;
        }
.auto-style10 {
            height: 42px;
}
.generate{
    float:right;
    width:280px;
    background-color:burlywood;
}

        .auto-style12 {
            width: 100px;
            font-size: small;
        }
        .auto-style13 {
            font-size: small;
            width:210px;
        }
        .auto-style14 {
            width: 90%;
            height: 19%;
            font-size: small;
        }

        .auto-style15 {
            width: 210px;
            font-size: small;
        }

    </style>
</head>
<body>
    <form id="form2" runat="server">
              <div class="hlf">
              <div class="tab11">
                  <br />
              <table >
             
              <tr>
                <td class="auto-style15">Non-conformance ref no.<span style="color:red" class="auto-style6">*</span>:</td>
              <td>
                    <asp:TextBox ID="ncr_ref_no_tb" runat="server" CssClass="auto-style13"></asp:TextBox>
                </td>
              </tr>
                   <tr>
                <td class="auto-style15">Description<span style="color:red" class="auto-style6">*</span>:</td>
              <td>
                    <asp:TextBox ID="ncr_desc_tb" runat="server" CssClass="auto-style13"></asp:TextBox>
                </td>
              </tr>
                  <tr>
                      <td class="auto-style15">
                          <span class="auto-style15">Project</span><span style="color:red" class="auto-style6">*</span></td>
                <td class="auto-style9">
                    <asp:DropDownList ID="usrddlprj" AppendDataBoundItems="true" DataTextField="usrprj" DataValueField="usrprj" runat="server">
                      
                        <asp:ListItem Selected="True" Value=" ">SELECT</asp:ListItem>
                   </asp:DropDownList>
                
                </td>
                      </tr>
                         <tr>
                      <td class="auto-style15">
                          <span class="auto-style15">Originator</span><span style="color:red" class="auto-style6">*</span></td>
                <td class="auto-style9">
                     <asp:TextBox ID="org_tb" runat="server" CssClass="auto-style13"></asp:TextBox>
               
                
                </td>
                             </tr>
                      
                   <tr>
                <td class="auto-style15">Date issued<span style="color:red" class="auto-style6">*</span>:</td>
              <td>
                    <asp:TextBox ID="dt_iss_tb" runat="server" TextMode="Date" CssClass="auto-style13"></asp:TextBox>
                  </td>
             </tr>
                    <tr>
                <td class="auto-style15">Root cause:</td>
                <td>
                    <asp:TextBox ID="root_cse_tb" runat="server" CssClass="auto-style13" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style15">Decipline:</td>
                <td>
                    <asp:TextBox ID="desp_tb" runat="server" CssClass="auto-style13"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style15">Site's engineer name:</td>
                <td>
                    <asp:TextBox ID="site_eng_tb" runat="server" CssClass="auto-style13"></asp:TextBox>
                </td>
            </tr>
                    <tr>
                <td class="auto-style15">Issued:</td>
                <td>
                    <asp:TextBox ID="iss_tb" runat="server" CssClass="auto-style13" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            
              <tr>
                <td class="auto-style15">Proposed corrective action:</td>
                <td>
                    <asp:TextBox ID="pca_tb" runat="server" TextMode="Date" CssClass="auto-style13"></asp:TextBox>
                </td>
            </tr>
            
              <tr>
                <td class="auto-style15">Approved corrective action:</td>
                <td>
                    <asp:TextBox ID="aca_tb" runat="server" CssClass="auto-style13" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            
              <tr>
                <td class="auto-style15">Corrective action implementation date:</td>
                <td>
                    <asp:TextBox ID="cai_tb" runat="server" CssClass="auto-style13" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style15">Verification of corrective action date:</td>
                <td>
                      <asp:TextBox ID="vca_tb" runat="server" CssClass="auto-style13" TextMode="Date"></asp:TextBox>
               </td>
            </tr>
              <tr>
                <td class="auto-style9">Date of consultant decision:</td>
                <td class="auto-style10">
                    <asp:TextBox ID="dcd_tb" runat="server" TextMode="Date" CssClass="auto-style13"></asp:TextBox>
                  </td>
            </tr>
       
              <tr>
<td class="auto-style15">Document:</td>
                <td>

                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="auto-style13" />

                </td>
            </tr>
            </table></div> 
              <div class="tab11">
                <table class="table">
                                   <tr>
                <td class="auto-style15">No. of days open:</td>
                <td>
                    <asp:TextBox ID="no_dys_tb" runat="server" CssClass="auto-style13"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style15">Action Owner:</td>
                <td>
                    <asp:TextBox ID="act_owner_tb" runat="server" CssClass="auto-style13" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
                      <tr>
                <td class="auto-style15">Current Status:</td>
                <td>
                    <asp:TextBox ID="cur_stat_tb" runat="server" CssClass="auto-style13"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style15">Reason for exceeding 14 days<span style="color:red" class="auto-style6">*</span>:</td>
              <td>
                    <asp:TextBox ID="rea_ex_tb" runat="server" CssClass="auto-style13" TextMode="MultiLine"></asp:TextBox>
                </td>
              </tr>
                   <tr>
                <td class="auto-style15">Closer sheet no.:<span style="color:red" class="auto-style6">*</span>:</td>
              <td>
                    <asp:TextBox ID="clsr_sht_tb" runat="server" CssClass="auto-style13"></asp:TextBox>
                </td>
              </tr>
                  <tr>
                      <td class="auto-style15">
                          <span class="auto-style15">Contract or Submitted date</span><span style="color:red" class="auto-style6">*</span></td>
                <td class="auto-style9">
                    <asp:TextBox ID="consub_tb" runat="server" CssClass="auto-style13" TextMode="Date"></asp:TextBox>
               
                </td>
                      </tr>
                   <tr>
                <td class="auto-style15">Corrective Action<span style="color:red" class="auto-style6">*</span>:</td>
              <td>
                    <asp:TextBox ID="ca_tb" runat="server" TextMode="MultiLine" CssClass="auto-style13"></asp:TextBox>
                  </td>
             </tr>
                    <tr>
                <td class="auto-style15">Consultant response date:</td>
                <td>
                    <asp:TextBox ID="crd_tb" runat="server" CssClass="auto-style13" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style15">Remarks:</td>
                <td>
                    <asp:TextBox ID="ca_rmk_tb" runat="server" CssClass="auto-style13"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style15">Contractor implementation date:</td>
                <td>
                    <asp:TextBox ID="cid_tb" runat="server" CssClass="auto-style13" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
                    <tr>
                <td class="auto-style15">consultant verification date:</td>
                <td>
                    <asp:TextBox ID="cvd_tb" runat="server" CssClass="auto-style13" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            
              <tr>
                <td class="auto-style15">originator remarks:</td>
                <td>
                    <asp:TextBox ID="org_rmk_tb" runat="server" TextMode="MultiLine" CssClass="auto-style13"></asp:TextBox>
                </td>
            </tr>
            
              <tr>
                <td class="auto-style15">closing date:</td>
                <td>
                    <asp:TextBox ID="cls_dt_tb" runat="server" CssClass="auto-style13" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            
              <tr>
                <td class="auto-style15">remaks:</td>
                <td>
                    <asp:TextBox ID="vc_rmk_tb" runat="server" CssClass="auto-style13" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>           
                    </table>
                     </div>
              
              <div class="btncol">
              <div class="notification">
        
        <asp:Label ID="notify" runat="server" Text="" CssClass="auto-style13"></asp:Label>
                        </div> 
            <br class="auto-style13" />
                    <br class="auto-style13" />
         <asp:Button ID="add_btn" CssClass="auto-style14" runat="server" Text="ADD"    OnClick="add_btn_Click" OnClientClick="return validation();"/><br class="auto-style13" /><br class="auto-style13" />
         <asp:Button ID="Update" CssClass="auto-style14"  runat="server" Text="UPDATE" OnClick="Update_Click"  OnClientClick="return validation();" /><br class="auto-style13" /><br class="auto-style13" />
         <asp:Button ID="Delete" CssClass="auto-style14"  runat="server" Text="DELETE" OnClick="Delete_Click" /><br class="auto-style13" /><br class="auto-style13" />
         <asp:Button ID="Search" CssClass="auto-style14"  runat="server" Text="SEARCH" OnClick="Search_Click" /><br class="auto-style13" /><br class="auto-style13" />
         
         <asp:Button ID="Clear"  CssClass="auto-style14"  runat="server" Text="CLEAR"  OnClick="Clear_Click"  /><br class="auto-style13" /><br class="auto-style13" />
            
                   
                  </div>
                  <asp:TextBox ID="TextBox1" runat="server" Visible="False" CssClass="auto-style13"></asp:TextBox>
       </div>
              <div class="grid" >
                 <asp:Panel ID="panel1" runat="server" Height="230px"  ScrollBars="Both" CssClass="grid">
              <asp:GridView ID="GridView1" CssClass="table1" style="height:230px;" runat="server" DataKeyNames="doc" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True">
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
        
                    <asp:TextBox ID="logid" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="logdesg" runat="server" Visible="False"></asp:TextBox>
    </form>
</body>
</html>
