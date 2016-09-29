<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<div class="Mid">
        <div>
                    <asp:Label ID="Label1" runat="server" Text="User Registration" style="text-align: left; position: relative"></asp:Label>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Username:"></asp:Label><asp:TextBox ID="UsrName" placeholder="Pair Name" runat="server"></asp:TextBox>
        </div>

        <div>

            <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label><asp:TextBox ID="PwdText" placeholder="Pair Name" runat="server"></asp:TextBox>

        </div>
        <asp:CheckBox ID="IsTeacher" runat="server" Text="Teacher Account:" TextAlign="Left" />
        <br />

        <br />
        <asp:Label ID="warningLabel" runat="server" Text="Username already exists" Visible="False"></asp:Label>
        <br />

        <div>

        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" /></div>
    </div>
        <div class="Mid">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Back to Teacher Area</asp:LinkButton></div>

    </form>
</body>
</html>
