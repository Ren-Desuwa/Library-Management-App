Imports System.Data.OleDb

Public Class UC_transactions
    Private Sub UC_transactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup combo box
        cmbDateFilter.Items.Clear()
        cmbDateFilter.Items.AddRange({"Today", "Yesterday", "This Week", "All"})
        cmbDateFilter.SelectedItem = "All"

        ' Load transactions
        LoadTransactions()
    End Sub

    Private Sub LoadTransactions(Optional searchTerm As String = "")
        Try
            Dim filterCondition As String = ""
            Dim selectedDateFilter As String = cmbDateFilter.SelectedItem.ToString()

            Select Case selectedDateFilter
                Case "Today"
                    filterCondition = "DateValue(bb.BorrowDate) = Date()"
                Case "Yesterday"
                    filterCondition = "DateValue(bb.BorrowDate) = DateAdd('d', -1, Date())"
                Case "This Week"
                    filterCondition = "bb.BorrowDate >= DateAdd('d', -(Weekday(Date()) - 1), Date())"
                Case "All"
                    filterCondition = "1=1"
            End Select

            Dim query As String = "SELECT bb.BorrowId, s.StudentID, s.FirstName & ' ' & s.LastName AS StudentName, " &
                                  "b.Title AS BookTitle, bb.BorrowDate, bb.DueDate, bb.ReturnDate " &
                                  "FROM (BorrowedBooks bb INNER JOIN Students s ON bb.UserID = s.ID) " &
                                  "INNER JOIN Books b ON bb.BookID = b.BookID " &
                                  "WHERE " & filterCondition

            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                query &= " AND (s.StudentID LIKE ? OR s.FirstName LIKE ? OR s.LastName LIKE ? OR b.Title LIKE ?)"
            End If

            Dim parameters As New List(Of OleDbParameter)
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                Dim term As String = "%" & searchTerm & "%"
                parameters.Add(New OleDbParameter("?", term))
                parameters.Add(New OleDbParameter("?", term))
                parameters.Add(New OleDbParameter("?", term))
                parameters.Add(New OleDbParameter("?", term))
            End If

            Dim dt As DataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters.ToArray())
            dgvRecentTransactions.DataSource = dt

            ' Make DataGridView read-only and selectable
            dgvRecentTransactions.ReadOnly = True
            dgvRecentTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvRecentTransactions.MultiSelect = False
            dgvRecentTransactions.AllowUserToAddRows = False

            ' Highlight overdue books in red
            For Each row As DataGridViewRow In dgvRecentTransactions.Rows
                If row.Cells("DueDate").Value IsNot Nothing AndAlso row.Cells("ReturnDate").Value Is Nothing Then
                    Dim dueDate As Date
                    If Date.TryParse(row.Cells("DueDate").Value.ToString(), dueDate) Then
                        If dueDate < Date.Today Then
                            row.DefaultCellStyle.ForeColor = Color.Red
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading transactions: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadTransactions(txtSearch.Text.Trim())
    End Sub

    Private Sub cmbDateFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDateFilter.SelectedIndexChanged
        LoadTransactions(txtSearch.Text.Trim())
    End Sub

    Private Sub btnClearSelection_Click(sender As Object, e As EventArgs) Handles btnClearSelection.Click
        txtSearch.Clear()
        LoadTransactions(txtSearch.Text.Trim()) ' Reload data first
        dgvRecentTransactions.ClearSelection()  ' Then clear selection
        dgvRecentTransactions.CurrentCell = Nothing ' Prevent automatic first-row selection
    End Sub
End Class
