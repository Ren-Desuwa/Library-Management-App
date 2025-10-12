Imports System.Data.OleDb

Public Class UC_user_history
    Private studentID As Integer = Login_Panel.CurrentUser.AccountID

    Private Sub UC_user_history_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup DataGridView
        dgvBorrowedBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBorrowedBooks.MultiSelect = False
        dgvBorrowedBooks.ReadOnly = True
        dgvBorrowedBooks.AllowUserToAddRows = False

        ' Setup ComboBox filter
        cmbDateFilter.Items.Clear()
        cmbDateFilter.Items.AddRange({"All", "Today", "Yesterday", "This Week"})
        cmbDateFilter.SelectedIndex = 0 ' Default: All

        ' Load borrowed books
        LoadBorrowedBooks()
    End Sub

    ' Load borrowed books with optional search and date filter
    Private Sub LoadBorrowedBooks(Optional searchTerm As String = "")
        Try
            Dim query As String = "SELECT b.BorrowId, bk.Title, bk.Author, b.BorrowDate, b.DueDate, b.ReturnDate, b.Status " &
                                  "FROM BorrowedBooks b INNER JOIN Books bk ON b.BookID = bk.BookID " &
                                  "WHERE b.UserID = ?"
            Dim paramList As New List(Of OleDbParameter)
            paramList.Add(New OleDbParameter("?", OleDbType.Integer) With {.Value = studentID})

            ' Apply search
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                query &= " AND (bk.Title LIKE ? OR bk.Author LIKE ?)"
                paramList.Add(New OleDbParameter("?", "%" & searchTerm & "%"))
                paramList.Add(New OleDbParameter("?", "%" & searchTerm & "%"))
            End If

            ' Apply date filter
            Select Case cmbDateFilter.SelectedItem.ToString()
                Case "Today"
                    query &= " AND b.BorrowDate = ?"
                    paramList.Add(New OleDbParameter("?", Date.Today))
                Case "Yesterday"
                    query &= " AND b.BorrowDate = ?"
                    paramList.Add(New OleDbParameter("?", Date.Today.AddDays(-1)))
                Case "This Week"
                    Dim firstDay As Date = Date.Today.AddDays(-(Date.Today.DayOfWeek))
                    Dim lastDay As Date = firstDay.AddDays(6)
                    query &= " AND b.BorrowDate BETWEEN ? AND ?"
                    paramList.Add(New OleDbParameter("?", firstDay))
                    paramList.Add(New OleDbParameter("?", lastDay))
            End Select

            Dim dt As DataTable = DatabaseConnection.Instance.ExecuteQuery(query, paramList.ToArray())
            dgvBorrowedBooks.DataSource = dt
            dgvBorrowedBooks.ClearSelection()

            ' Highlight overdue books
            For Each row As DataGridViewRow In dgvBorrowedBooks.Rows
                If row.Cells("Status").Value.ToString() = "Borrowed" AndAlso
                   Convert.ToDateTime(row.Cells("DueDate").Value) < Date.Today Then
                    row.DefaultCellStyle.ForeColor = Color.Red
                Else
                    row.DefaultCellStyle.ForeColor = Color.Black
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading borrowed books: " & ex.Message)
        End Try
    End Sub

    ' Return selected borrowed book
    Private Sub btnReturnBook_Click(sender As Object, e As EventArgs) Handles btnReturnBook.Click
        If dgvBorrowedBooks.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a borrowed book to return.")
            Return
        End If

        Dim borrowID As Integer = Convert.ToInt32(dgvBorrowedBooks.SelectedRows(0).Cells("BorrowId").Value)
        Dim returnDate As Date = Date.Today

        Try
            Dim query As String = "UPDATE BorrowedBooks SET ReturnDate = ?, Status = ? WHERE BorrowId = ?"
            Dim param As OleDbParameter() = {
                New OleDbParameter("?", OleDbType.Date) With {.Value = returnDate},
                New OleDbParameter("?", OleDbType.VarChar) With {.Value = "Returned"},
                New OleDbParameter("?", OleDbType.Integer) With {.Value = borrowID}
            }

            DatabaseConnection.Instance.ExecuteNonQuery(query, param)
            MessageBox.Show("Book returned successfully!")
            LoadBorrowedBooks(txtSearch.Text.Trim())
        Catch ex As Exception
            MessageBox.Show("Error returning book: " & ex.Message)
        End Try
    End Sub

    ' Clear selection
    Private Sub btnClearSelection_Click(sender As Object, e As EventArgs) Handles btnClearSelection.Click
        dgvBorrowedBooks.ClearSelection()
    End Sub

    ' Search instantly as user types
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadBorrowedBooks(txtSearch.Text.Trim())
    End Sub

    ' Reload when date filter changes
    Private Sub cmbDateFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDateFilter.SelectedIndexChanged
        LoadBorrowedBooks(txtSearch.Text.Trim())
    End Sub
End Class
