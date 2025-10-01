Imports System.Data.OleDb

Public Class UC_search_books
    Private studentID As Integer = Login_Panel.CurrentUser.AccountID

    Private Sub UC_search_books_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup DataGridView
        dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBooks.MultiSelect = False
        dgvBooks.ReadOnly = True
        dgvBooks.AllowUserToAddRows = False

        ' Load books
        LoadBooks()
    End Sub

    ' Load all books into dgvBooks with optional search
    Private Sub LoadBooks(Optional searchTerm As String = "")
        Try
            Dim query As String = "SELECT BookID, Title, Author, ISBN, SeriesTitle FROM Books"
            Dim dt As DataTable

            If String.IsNullOrWhiteSpace(searchTerm) Then
                dt = DatabaseConnection.Instance.ExecuteQuery(query)
            Else
                query &= " WHERE Title LIKE ? OR Author LIKE ?"
                Dim param As OleDbParameter() = {
                    New OleDbParameter("?", "%" & searchTerm & "%"),
                    New OleDbParameter("?", "%" & searchTerm & "%")
                }
                dt = DatabaseConnection.Instance.ExecuteQuery(query, param)
            End If

            dgvBooks.DataSource = dt
            dgvBooks.ClearSelection()
        Catch ex As Exception
            MessageBox.Show("Error loading books: " & ex.Message)
        End Try
    End Sub

    ' Borrow selected book
    Private Sub btnBorrowBook_Click(sender As Object, e As EventArgs) Handles btnBorrowBook.Click
        If dgvBooks.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a book to borrow.")
            Return
        End If

        Dim bookID As Integer = Convert.ToInt32(dgvBooks.SelectedRows(0).Cells("BookID").Value)
        Dim borrowDate As Date = Date.Today
        Dim dueDate As Date = borrowDate.AddDays(3)

        Try
            Dim query As String = "INSERT INTO BorrowedBooks (UserID, BookID, BorrowDate, DueDate, Status) " &
                                  "VALUES (?, ?, ?, ?, ?)"
            Dim param As OleDbParameter() = {
                New OleDbParameter("?", OleDbType.Integer) With {.Value = studentID},
                New OleDbParameter("?", OleDbType.Integer) With {.Value = bookID},
                New OleDbParameter("?", OleDbType.Date) With {.Value = borrowDate},
                New OleDbParameter("?", OleDbType.Date) With {.Value = dueDate},
                New OleDbParameter("?", OleDbType.VarChar) With {.Value = "Borrowed"}
            }

            DatabaseConnection.Instance.ExecuteNonQuery(query, param)
            MessageBox.Show($"Book borrowed successfully! Due date: {dueDate.ToShortDateString()}")
        Catch ex As Exception
            MessageBox.Show("Error borrowing book: " & ex.Message)
        End Try
    End Sub

    ' Clear selection
    Private Sub btnClearSelection_Click(sender As Object, e As EventArgs) Handles btnClearSelection.Click
        dgvBooks.ClearSelection()
    End Sub

    ' Instant search as user types
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadBooks(txtSearch.Text.Trim())
    End Sub
End Class
