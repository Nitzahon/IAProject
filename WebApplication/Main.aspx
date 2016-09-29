<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="WebApplication.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="z-index: 1; margin-left: auto; margin-right: auto;">
    <fieldset style ="width:200px;">
    <legend>Login page </legend>
        <asp:TextBox ID="txtusername" placeholder="username" runat="server" Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtpassword" placeholder="password" runat="server" Width="180px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnsubmit" runat="server" Text="Submit"
           Width="81px" onclick="btnsubmit_Click" />
            <br />
           
    </fieldset>
    </div>

    </form>
</body>
</html>
