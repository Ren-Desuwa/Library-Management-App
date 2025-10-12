Imports System.Data.OleDb

Public Class UC_books
    ' Track whether user is editing a book
    Private isEditing As Boolean = False

    Private Sub UC_Books_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure DataGridView
        dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBooks.MultiSelect = False
        dgvBooks.ReadOnly = True
        dgvBooks.AllowUserToAddRows = False

        LoadBooks()
    End Sub

    ' Load all books from the database
    Private Sub LoadBooks()
        Try
            Dim query As String = "SELECT BookID, Title, Author, ISBN, SeriesTitle, Details, BorrowedBy, DueDate, CreatedDate FROM Books"
            Dim dt As DataTable = DatabaseConnection.Instance.ExecuteQuery(query)
            dgvBooks.DataSource = dt

            ClearInputs()
        Catch ex As Exception
            MessageBox.Show("Error loading books: " & ex.Message)
        End Try
    End Sub

    ' Add a new book
    Private Sub btnAddBook_Click(sender As Object, e As EventArgs) Handles btnAddBook.Click
        ' Prevent adding while editing
        If isEditing Then
            MessageBox.Show("You are currently editing a book. Click 'Clear Selection' to add a new one.")
            Return
        End If

        ' Validate required fields
        If String.IsNullOrWhiteSpace(txtTitle.Text) Or String.IsNullOrWhiteSpace(txtAuthor.Text) Then
            MessageBox.Show("Title and Author are required.")
            Return
        End If

        Try
            Dim query As String = "INSERT INTO Books (Title, Author, ISBN, SeriesTitle, Details, BorrowedBy, DueDate, CreatedDate) " &
                                  "VALUES (?, ?, ?, ?, ?, ?, ?, ?)"

            Dim params As OleDbParameter() = {
                New OleDbParameter("?", OleDbType.VarChar) With {.Value = txtTitle.Text},
                New OleDbParameter("?", OleDbType.VarChar) With {.Value = txtAuthor.Text},
                New OleDbParameter("?", OleDbType.VarChar) With {.Value = txtISBN.Text},
                New OleDbParameter("?", OleDbType.VarChar) With {.Value = txtSeriesTitle.Text},
                New OleDbParameter("?", OleDbType.LongVarChar) With {.Value = txtDetails.Text},
                New OleDbParameter("?", OleDbType.Integer) With {.Value = DBNull.Value},
                New OleDbParameter("?", OleDbType.Date) With {.Value = DBNull.Value},
                New OleDbParameter("?", OleDbType.Date) With {.Value = DateTime.Now}
            }

            DatabaseConnection.Instance.ExecuteNonQuery(query, params)
            MessageBox.Show("Book added successfully!")
            LoadBooks()
        Catch ex As Exception
            MessageBox.Show("Error adding book: " & ex.Message)
        End Try
    End Sub

    ' Edit selected book
    Private Sub btnEditBook_Click(sender As Object, e As EventArgs) Handles btnEditBook.Click
        ' Make sure a row is selected AND we are in editing mode
        If dgvBooks.SelectedRows.Count = 0 OrElse Not isEditing Then
            MessageBox.Show("Please select a book to edit from the table first.")
            Return
        End If

        ' Also, validate required fields
        If String.IsNullOrWhiteSpace(txtTitle.Text) Or String.IsNullOrWhiteSpace(txtAuthor.Text) Then
            MessageBox.Show("Title and Author are required.")
            Return
        End If

        Dim bookID As Integer = Convert.ToInt32(dgvBooks.SelectedRows(0).Cells("BookID").Value)

        Try
            Dim query As String = "UPDATE Books SET Title=?, Author=?, ISBN=?, SeriesTitle=?, Details=? WHERE BookID=?"
            Dim params As OleDbParameter() = {
            New OleDbParameter("?", OleDbType.VarChar) With {.Value = txtTitle.Text},
            New OleDbParameter("?", OleDbType.VarChar) With {.Value = txtAuthor.Text},
            New OleDbParameter("?", OleDbType.VarChar) With {.Value = txtISBN.Text},
            New OleDbParameter("?", OleDbType.VarChar) With {.Value = txtSeriesTitle.Text},
            New OleDbParameter("?", OleDbType.LongVarChar) With {.Value = txtDetails.Text},
            New OleDbParameter("?", OleDbType.Integer) With {.Value = bookID}
        }

            DatabaseConnection.Instance.ExecuteNonQuery(query, params)
            MessageBox.Show("Book updated successfully!")
            LoadBooks()
        Catch ex As Exception
            MessageBox.Show("Error updating book: " & ex.Message)
        End Try
    End Sub

    ' Remove selected book
    Private Sub btnRemoveBook_Click(sender As Object, e As EventArgs) Handles btnRemoveBook.Click
        If dgvBooks.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a book to remove.")
            Return
        End If

        Dim bookID As Integer = Convert.ToInt32(dgvBooks.SelectedRows(0).Cells("BookID").Value)

        Try
            Dim query As String = "DELETE FROM Books WHERE BookID = ?"
            Dim param As New OleDbParameter("?", OleDbType.Integer) With {.Value = bookID}

            DatabaseConnection.Instance.ExecuteNonQuery(query, {param})
            MessageBox.Show("Book removed successfully!")
            LoadBooks()
        Catch ex As Exception
            MessageBox.Show("Error removing book: " & ex.Message)
        End Try
    End Sub

    ' Populate textboxes when clicking a row (for editing)
    Private Sub dgvBooks_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBooks.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvBooks.Rows(e.RowIndex)
            txtTitle.Text = row.Cells("Title").Value.ToString()
            txtAuthor.Text = row.Cells("Author").Value.ToString()
            txtISBN.Text = If(row.Cells("ISBN").Value IsNot Nothing, row.Cells("ISBN").Value.ToString(), "")
            txtSeriesTitle.Text = If(row.Cells("SeriesTitle").Value IsNot Nothing, row.Cells("SeriesTitle").Value.ToString(), "")
            txtDetails.Text = If(row.Cells("Details").Value IsNot Nothing, row.Cells("Details").Value.ToString(), "")

            isEditing = True
        End If
    End Sub

    ' Clear textboxes and reset editing mode
    Private Sub ClearInputs()
        txtTitle.Clear()
        txtAuthor.Clear()
        txtISBN.Clear()
        txtSeriesTitle.Clear()
        txtDetails.Clear()
        isEditing = False
    End Sub

    ' New Book / Clear Selection button
    Private Sub btnClearSelection_Click(sender As Object, e As EventArgs) Handles btnClearSelection.Click
        dgvBooks.ClearSelection()
        ClearInputs()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = txtSearch.Text.Trim()

        If String.IsNullOrEmpty(searchTerm) Then
            ' If empty, reload all books
            LoadBooks()
            Return
        End If

        Try
            Dim query As String = "SELECT BookID, Title, Author, ISBN, SeriesTitle, Details, BorrowedBy, DueDate, CreatedDate " &
                                  "FROM Books WHERE Title LIKE ? OR Author LIKE ? OR ISBN LIKE ? OR SeriesTitle LIKE ?"

            Dim paramValue As String = "%" & searchTerm & "%"

            Dim params As OleDbParameter() = {
                New OleDbParameter("?", OleDbType.VarChar) With {.Value = paramValue},
                New OleDbParameter("?", OleDbType.VarChar) With {.Value = paramValue},
                New OleDbParameter("?", OleDbType.VarChar) With {.Value = paramValue},
                New OleDbParameter("?", OleDbType.VarChar) With {.Value = paramValue}
            }

            Dim dt As DataTable = DatabaseConnection.Instance.ExecuteQuery(query, params)
            dgvBooks.DataSource = dt
            ClearInputs()
        Catch ex As Exception
            MessageBox.Show("Error searching books: " & ex.Message)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        btnSearch.PerformClick()
    End Sub
End Class
