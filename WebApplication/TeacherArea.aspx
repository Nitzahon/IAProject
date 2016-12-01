<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherArea.aspx.cs" Inherits="WebApplication.TeacherArea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:lightgray">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="testName" HeaderText="Test Name" ReadOnly="True" SortExpression="testName" />
                <asp:BoundField DataField="description" HeaderText="description" ReadOnly="True" SortExpression="description" />
                <asp:BoundField DataField="majorPairName" HeaderText="Major Pair" ReadOnly="True" SortExpression="majorPairName" />
                <asp:BoundField DataField="minorPairName" HeaderText="Minor Pair" ReadOnly="True" SortExpression="minorPairName" />
            </Columns>

        </asp:GridView>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Create Pairs</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Test Creation</asp:LinkButton>
        <br /><br />
        <asp:LinkButton ID="UserReg" runat="server" OnClick="UserReg_Click">UserRegistration</asp:LinkButton>
         <br /><br />
        <asp:LinkButton ID="TestResults" runat="server" OnClick="TestResults_Click">Test Results</asp:LinkButton>
    </div>
    </form>
</body>
</html>
