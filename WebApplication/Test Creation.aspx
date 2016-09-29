<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test Creation.aspx.cs" Inherits="WebApplication.Cluster_Creation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .Mid {
            position: relative;
            top: 10px;
            left: 80px;
        }
    </style>
</head>
<body style="background-color: #CCCCCC">
    <form id="form1" runat="server">
    <div class="Mid">
        <div>
                    <asp:Label ID="Label1" runat="server" Text="Test Creation" style="text-align: left; position: relative"></asp:Label>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Test Name"></asp:Label><asp:TextBox ID="nameTB" runat="server"></asp:TextBox>
        </div>
        <div>

            <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label><asp:TextBox ID="desTB" runat="server"></asp:TextBox>

        </div>
        <div>
            &nbsp;<asp:DropDownList ID="majorPair" runat="server" DataSourceID="SqlDataSource1" DataTextField="pairname" DataValueField="pairname">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestInfoDataContext %>" SelectCommand="SELECT [pairname] FROM [Pairs]"></asp:SqlDataSource>
        </div>
        
        <div>
            &nbsp;<asp:DropDownList ID="minorPair" runat="server" DataSourceID="SqlDataSource1" DataTextField="pairname" DataValueField="pairname">
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Create Test" OnClick="Button1_Click" />
        </div>
    </div>
    </form>
</body>
</html>
