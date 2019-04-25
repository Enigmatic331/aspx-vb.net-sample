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
            <br />
            <asp:GridView ID="tblGridView" runat="server" OnRowUpdating="OnRowUpdating" OnRowEditing="OnRowEditing" AutoGenerateColumns="False" Height="279px" Width="1675px" EmptyDataText="There are no data records to display.">
                <Columns>
                    <asp:BoundField AccessibleHeaderText="colID" DataField="ID" HeaderText="#" ReadOnly="True" />
                    <asp:BoundField AccessibleHeaderText="colSymbol" DataField="symbol" HeaderText="Symbol" />
                    <asp:BoundField AccessibleHeaderText="colName" DataField="name" HeaderText="Name" />
                    <asp:BoundField AccessibleHeaderText="colContractAdd" DataField="contract_address" HeaderText="Contract Address" />
                    <asp:BoundField AccessibleHeaderText="colTotalSupply" DataField="totalSupply" HeaderText="Total Supply" />
                    <asp:BoundField AccessibleHeaderText="colTotalHolders" DataField="total_holders" HeaderText="Total Holders" />
                    <asp:CommandField CancelText="" DeleteText="" InsertText="" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
