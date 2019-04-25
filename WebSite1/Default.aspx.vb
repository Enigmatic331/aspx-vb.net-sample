Imports System.Data.SqlClient
Imports System.Numerics
Imports System.Data

Partial Class Default2
    Inherits System.Web.UI.Page

    ' read from connection
    Public conn As New SqlConnection
    Public tDataSet As DataSet
    Public tblTransactions As DataTable
    Public tbladapter As SqlDataAdapter
    Public command As SqlCommandBuilder
    Public dvToken As DataView



    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' save data to table 'token'
        Dim sName As String
        Dim sSymbol As String
        Dim sContractAddress As String
        Dim intTotalSupply As BigInteger
        Dim intTotalHolders As Integer
        Dim row As DataRow

        ' get values from textbox
        sName = txtName.Text
        sSymbol = txtSymbol.Text
        sContractAddress = txtContractAddress.Text
        intTotalSupply = BigInteger.Parse(txtTotalSupply.Text)
        intTotalHolders = txtTotalHolders.Text

        tbladapter = New SqlDataAdapter("SELECT * FROM token WHERE symbol = @pSymbol", conn)
        command = New SqlCommandBuilder(tbladapter)
        tbladapter.SelectCommand.Parameters.Add("@pSymbol", SqlDbType.NVarChar)
        tbladapter.SelectCommand.Parameters("@pSymbol").Value = sSymbol

        tDataSet = New DataSet
        tbladapter.Fill(tDataSet, "token")
        tblTransactions = tDataSet.Tables("token")

        ' add new row
        If tblTransactions.Rows.Count > 0 Then
            row = tblTransactions.Rows(0)
            row("symbol") = sSymbol
            row("name") = sName
            row("totalSupply") = intTotalSupply.ToString
            row("contract_Address") = sContractAddress
            row("total_holders") = intTotalHolders
            Dim changedDataSet = tDataSet.GetChanges(DataRowState.Modified)
            tbladapter.Update(changedDataSet, "token")
        Else
            row = tblTransactions.NewRow
            row("symbol") = sSymbol
            row("name") = sName
            row("totalSupply") = intTotalSupply.ToString
            row("contract_Address") = sContractAddress
            row("total_holders") = intTotalHolders
            tblTransactions.Rows.Add(row)
            tbladapter.Update(tblTransactions)
        End If

        ' rebind the dataset
        tDataSet.Clear()
        tblTransactions.Clear()

        Dim sSQL = "SELECT * FROM token"
        tbladapter = New SqlDataAdapter(sSQL, conn)
        tbladapter.Fill(tDataSet, "token")
        tblTransactions = tDataSet.Tables("token")

        bindDataSet()
    End Sub

    Private Sub bindDataSet()
        'load dataset to gridview
        dvToken = tDataSet.Tables("token").DefaultView
        tblGridView.DataSource = dvToken
        tblGridView.DataBind()
    End Sub

    Protected Sub OnRowEditing(sender As Object, e As GridViewEditEventArgs)
        tblGridView.EditIndex = e.NewEditIndex
        bindDataSet()
    End Sub


    Public Sub OnRowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim row As GridViewRow = tblGridView.Rows(e.RowIndex)

        'retrieve values
        Dim sID As String = row.Cells(0).Text
        Dim sSymbol As String = TryCast(row.Cells(1).Controls(0), TextBox).Text
        Dim sName As String = TryCast(row.Cells(2).Controls(0), TextBox).Text
        Dim sContractAddress As String = TryCast(row.Cells(3).Controls(0), TextBox).Text
        Dim inttotalSupply As String = TryCast(row.Cells(4).Controls(0), TextBox).Text
        Dim inttotalHolders As String = TryCast(row.Cells(5).Controls(0), TextBox).Text


        tbladapter = New SqlDataAdapter("SELECT * FROM token", conn)
        Dim updCmd = New SqlCommand("UPDATE token SET symbol = @pSymbol, name = @pName, totalSupply = @pttlSupply, " &
                                    "contract_address = @pcontract_address, total_holders = @pttlHolders WHERE id = @pID",
                                    tbladapter.SelectCommand.Connection)

        updCmd.Parameters.Add("@pID", SqlDbType.Int)
        updCmd.Parameters("@pID").Value = sID
        updCmd.Parameters.Add("@pSymbol", SqlDbType.NVarChar)
        updCmd.Parameters("@pSymbol").Value = sSymbol
        updCmd.Parameters.Add("@pName", SqlDbType.NVarChar)
        updCmd.Parameters("@pName").Value = sName
        updCmd.Parameters.Add("@pcontract_address", SqlDbType.NVarChar)
        updCmd.Parameters("@pcontract_address").Value = sContractAddress
        updCmd.Parameters.Add("@pttlHolders", SqlDbType.Int)
        updCmd.Parameters("@pttlHolders").Value = inttotalHolders
        updCmd.Parameters.Add("@pttlSupply", SqlDbType.Int)
        updCmd.Parameters("@pttlSupply").Value = inttotalSupply
        updCmd.ExecuteNonQuery()
        'conn.Close()

        tblGridView.EditIndex = -1

        tbladapter = New SqlDataAdapter("SELECT * FROM token", conn)
        command = New SqlCommandBuilder(tbladapter)
        tDataSet = New DataSet
        tbladapter.Fill(tDataSet, "token")
        tblTransactions = tDataSet.Tables("token")
        bindDataSet()
    End Sub

    Private Function GetColID(ByVal colName As String) As Integer
        For Each col As DataControlField In tblGridView.Columns
            If col.AccessibleHeaderText = colName Then
                Dim index As Integer = tblGridView.Columns.IndexOf(col)
                Return index
            End If
        Next
    End Function

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load

        ' create connection class
        conn.ConnectionString = "Server=.;Database=connectMeThis;Trusted_Connection=True;"
        conn.Open()

        tbladapter = New SqlDataAdapter("SELECT * FROM token", conn)
        Command = New SqlCommandBuilder(tbladapter)
        tDataSet = New DataSet
        tbladapter.Fill(tDataSet, "token")
        tblTransactions = tDataSet.Tables("token")

        If tblGridView.EditIndex = -1 Then
            bindDataSet()
        End If

    End Sub
    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        txtName.Text = ""
        txtSymbol.Text = ""
        txtContractAddress.Text = ""
        txtTotalSupply.Text = ""
        txtTotalHolders.Text = ""
    End Sub
End Class
