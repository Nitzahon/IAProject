<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultsPage.aspx.cs" Inherits="WebApplication.ResultsPage" %>

!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:lightgray">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1">
            <Columns>
                
                <asp:BoundField DataField="user_id" HeaderText="user_id" ReadOnly="True" SortExpression="user_id" />
                <asp:BoundField DataField="MistakesA" HeaderText="MistakesA" ReadOnly="True" SortExpression="MistakesA" />
                <asp:BoundField DataField="MistakesB" HeaderText="MistakesB" ReadOnly="True" SortExpression="MistakesB" />
                <asp:BoundField DataField="TimesA" HeaderText="TimesA" ReadOnly="True" SortExpression="TimesA" />
                <asp:BoundField DataField="TimesB" HeaderText="TimesB" ReadOnly="True" SortExpression="TimesB" />
                <asp:BoundField DataField="test_Id" HeaderText="test_Id" ReadOnly="True" SortExpression="test_Id" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            </Columns>

        </asp:GridView>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="WebApplication.TestInfoDataContext" EntityTypeName="" Select="new (user_id, Test, MistakesA, MistakesB, TimesA, TimesB, test_Id, Id)" TableName="TestResults">
        </asp:LinqDataSource>
        <br />
        <br />
        <asp:LinkButton ID="BackButton" runat="server" OnClick="BackButton_Click">Back</asp:LinkButton>
        <br />
    </div>
    </form>
</body>
</html>
