<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pair addage.aspx.cs" Inherits="WebApplication.Pair_addage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <style type="text/css">

        .Mid {
            position: relative;
            top: 10px;
            left: 80px;
         width: 1005px;
     }
    </style>
</head>
<body style="background-color: #CCCCCC">
    <form id="form1" runat="server">
    <div class="Mid">
        <div>
                    <asp:Label ID="Label1" runat="server" Text="Pair Addage" style="text-align: left; position: relative"></asp:Label>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Group Name"></asp:Label><asp:TextBox ID="TextBox1" placeholder="Pair Name" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Inputs"></asp:Label><asp:TextBox ID="TextBox3" placeholder="Associated Words" runat="server" Width="420px"></asp:TextBox>
        </div>
        <br />
                    <asp:Label ID="Label6" runat="server" Font-Size="Small" Text="(Enter the group members as strings seperated by &quot;,&quot;)"></asp:Label>

        <br />
        <br />

        <div>

            <asp:Label ID="Label3" runat="server" Text="Group Name"></asp:Label><asp:TextBox ID="TextBox2" placeholder="Pair Name" runat="server"></asp:TextBox>

            <asp:Label ID="Label5" runat="server" Text="Inputs"></asp:Label><asp:TextBox ID="TextBox4" placeholder="Associated Words" runat="server" Width="420px"></asp:TextBox>

        </div>
        <div>

        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Create Pairing" OnClick="Button1_Click" /></div>
    </div>
        <div class="Mid">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Back to Teacher Area</asp:LinkButton></div>
    </form>
</body>
</html>
