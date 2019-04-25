<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 1343px">
            <asp:Label ID="Label1" runat="server" Text="Save Update Token"></asp:Label>
            <br />
            <br />
            Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtName" runat="server" Width="938px"></asp:TextBox>
            <br />
            <br />
            Symbol:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtSymbol" runat="server" Width="940px"></asp:TextBox>
            <br />
            <br />
            Contract Address:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtContractAddress" runat="server" Width="946px"></asp:TextBox>
            <br />
            <br />
            Total Supply:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTotalSupply" runat="server" Width="943px"></asp:TextBox>
            <br />
            <br />
            Total Holders:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTotalHolders" runat="server" Width="942px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="106px" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDel" runat="server" Text="Refresh" />
            <br />
            <asp:Table ID="tblDisplay" runat="server" Height="752px" Width="1804px">
            </asp:Table>
        </div>
    </form>
</body>
</html>
