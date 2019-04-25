Imports System.Data.SqlClient
Imports System.Numerics
Imports System.Data

Partial Class Default2
    Inherits System.Web.UI.Page

    Public conn As SqlConnection
    Public tDataSet As New DataSet
    Public tblTransactions As DataTable
    Public tbladapter As SqlDataAdapter
    Public command As SqlCommandBuilder


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' save data to table 'token'
        Dim sName As String
        Dim sSymbol As String
        Dim sContractAddress As String
        Dim intTotalSupply As BigInteger
        Dim intTotalHolders As Integer

        ' get values from textbox
        sName = txtName.Text
        sSymbol = txtSymbol.Text
        sContractAddress = txtContractAddress.Text
        intTotalSupply = BigInteger.Parse(txtTotalSupply.Text)
        intTotalHolders = txtTotalHolders.Text

        Dim row As DataRow = tblTransactions.NewRow
        row("symbol") = sSymbol
        row("name") = sName
        row("totalSupply") = intTotalSupply.ToString
        row("contract_Address") = sContractAddress
        row("total_holders") = intTotalHolders
        tblTransactions.Rows.Add(row)
        tbladapter.Update(tblTransactions)


        Dim sSQL = "SELECT * FROM token"
        tbladapter = New SqlDataAdapter(sSQL, conn)

        Dim newDataSet As New DataSet
        tbladapter.Fill(newDataSet, "token")

        Dim loadtblTransactions = newDataSet.Tables("token")

        For Each row In loadtblTransactions.Rows
            Dim tblRow = New TableRow
            For Each col In loadtblTransactions.Columns
                Dim cell As New TableCell
                cell.Text = row.Item(col.ColumnName).ToString
                tblRow.Cells.Add(cell)
            Next
            tblDisplay.Rows.Add(tblRow)
        Next

    End Sub

    Private Sub Edit()
        ' to edit, retrieve ID from cell, construct SQL update and push acros with SqlCommand

    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        ' create connection class
        conn = New SqlConnection
        conn.ConnectionString = "Server=.;Database=connectMeThis;Trusted_Connection=True;"
        conn.Open()

        'Dim retValue As Integer
        'Dim sCmd = New SqlCommand("TRUNCATE TABLE Transactions", conn)
        'retValue = sCmd.ExecuteNonQuery()

        tbladapter = New SqlDataAdapter("SELECT * FROM token", conn)
        command = New SqlCommandBuilder(tbladapter)

        tbladapter.Fill(tDataSet, "token")
        tblTransactions = tDataSet.Tables("token")
    End Sub
    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        txtName.Text = ""
        txtSymbol.Text = ""
        txtContractAddress.Text = ""
        txtTotalSupply.Text = ""
        txtTotalHolders.Text = ""
    End Sub
End Class
