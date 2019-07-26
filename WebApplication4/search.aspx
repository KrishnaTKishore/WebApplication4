<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="WebApplication4.search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>  
       /* function closepopup() {
              opener.document.DCwirpg.wirno_tb.value = document.search.TextBox1.value;

           //winpops= self.Close();
            //winpops = window.close();
           // window.parent.open("DCwirpg.aspx", "", "width=1000, height=800");
        }*/
        function closepopup() {

            // window.onunload = refreshParent;
            SetName();
             
    
           // self.close();
           // document.getElementById("Button1").click();
        }   
   /*     function refreshParent() {
            window.opener.location.document.opensearch();
    }*/

             //opener.document.DCwirpg.wirno_tb.value = document.search.TextBox1.value;

             // window.opener.location.reload();
        
           function SetName() {
                if (window.opener != null && !window.opener.closed) {
                    var txtItemID = document.getElementById("TextBox1").value;
                 //   window.onunload = refreshParent();

                    window.opener.document.getElementById("wirno_tb").value = txtItemID;
                     //window.opener.document.getElementById("TextBox1").value ="999";

                   // window.opener.document.getElementById("Search").click();

                }
                window.close();
            }
     </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Work Inspection Reference number"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server"  Text="Search" OnClick="Button1_Click"  OnClientClick="return closepopup();" PostBackUrl="~/DCwirpg.aspx" />
        </div>
    </form>
</body>
</html>
