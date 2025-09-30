Imports System.Data.OleDb

Public Class BookDatabaseHandler
    Private ReadOnly _dbConnection As DatabaseConnection

    Public Sub New(dbConnection As DatabaseConnection)
        _dbConnection = dbConnection
    End Sub

    ' Create Tables
    Public Sub CreateTables()
        Try
            Dim createBooksTable As String = "CREATE TABLE Books (
                BookID AUTOINCREMENT PRIMARY KEY,
                Title TEXT(255) NOT NULL,
                Author TEXT(255) NOT NULL,
                ISBN TEXT(50) NOT NULL,
                SeriesTitle TEXT(255),
                Details MEMO,
                BorrowedBy INTEGER,
                DueDate DATETIME,
                CreatedDate DATETIME NOT NULL
            )"

            Dim createHistoryTable As String = "CREATE TABLE BookHistory (
                HistoryID AUTOINCREMENT PRIMARY KEY,
                BookID INTEGER NOT NULL,
                EntryDate DATETIME NOT NULL,
                Entry MEMO NOT NULL
            )"

            _dbConnection.ExecuteNonQuery(createBooksTable)
            _dbConnection.ExecuteNonQuery(createHistoryTable)
        Catch ex As Exception
            Throw New Exception($"Error creating book tables: {ex.Message}", ex)
        End Try
    End Sub

    ' Add Book
    Public Function AddBook(title As String, author As String, isbn As String, Optional seriesTitle As String = "General", Optional details As String = "") As Integer
        Try
            Dim query = "INSERT INTO Books (Title, Author, ISBN, SeriesTitle, Details, CreatedDate) VALUES (?, ?, ?, ?, ?, ?)"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                cmd.Parameters.AddWithValue("@Title", title)
                cmd.Parameters.AddWithValue("@Author", author)
                cmd.Parameters.AddWithValue("@ISBN", isbn)
                cmd.Parameters.AddWithValue("@SeriesTitle", seriesTitle)
                cmd.Parameters.AddWithValue("@Details", If(details, String.Empty))
                cmd.Parameters.AddWithValue("@CreatedDate", Date.Now)

                _dbConnection.OpenConnection()
                cmd.ExecuteNonQuery()

                cmd.CommandText = "SELECT @@IDENTITY"
                Dim bookID = Convert.ToInt32(cmd.ExecuteScalar())
                _dbConnection.CloseConnection()

                AddBookHistory(bookID, "Book created")
                Return bookID
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error adding book: {ex.Message}", ex)
        End Try
    End Function

    ' Get Book by ID
    Public Function GetBookByID(bookID As Integer) As Book
        Try
            Dim query = "SELECT * FROM Books WHERE BookID = ?"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                cmd.Parameters.AddWithValue("@BookID", bookID)

                _dbConnection.OpenConnection()
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim book = MapReaderToBook(reader)
                        _dbConnection.CloseConnection()
                        Return book
                    End If
                End Using
                _dbConnection.CloseConnection()
            End Using

            Return Nothing
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error getting book by ID: {ex.Message}", ex)
        End Try
    End Function

    ' Get All Books
    Public Function GetAllBooks() As List(Of Book)
        Dim books As New List(Of Book)()

        Try
            Dim query = "SELECT * FROM Books ORDER BY Title"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                _dbConnection.OpenConnection()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        books.Add(MapReaderToBook(reader))
                    End While
                End Using
                _dbConnection.CloseConnection()
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error getting all books: {ex.Message}", ex)
        End Try

        Return books
    End Function

    ' Search Books
    Public Function SearchBooks(searchTerm As String) As List(Of Book)
        Dim books As New List(Of Book)()

        If String.IsNullOrWhiteSpace(searchTerm) Then
            Return GetAllBooks()
        End If

        Try
            Dim query = "SELECT * FROM Books WHERE Title LIKE ? OR Author LIKE ? OR ISBN LIKE ? ORDER BY Title"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                Dim searchPattern = $"*{searchTerm}*"
                cmd.Parameters.AddWithValue("@Search1", searchPattern)
                cmd.Parameters.AddWithValue("@Search2", searchPattern)
                cmd.Parameters.AddWithValue("@Search3", searchPattern)

                _dbConnection.OpenConnection()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        books.Add(MapReaderToBook(reader))
                    End While
                End Using
                _dbConnection.CloseConnection()
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error searching books: {ex.Message}", ex)
        End Try

        Return books
    End Function

    ' Get Available Books
    Public Function GetAvailableBooks() As List(Of Book)
        Dim books As New List(Of Book)()

        Try
            Dim query = "SELECT * FROM Books WHERE BorrowedBy IS NULL ORDER BY Title"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                _dbConnection.OpenConnection()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        books.Add(MapReaderToBook(reader))
                    End While
                End Using
                _dbConnection.CloseConnection()
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error getting available books: {ex.Message}", ex)
        End Try

        Return books
    End Function

    ' Get Borrowed Books
    Public Function GetBorrowedBooks() As List(Of Book)
        Dim books As New List(Of Book)()

        Try
            Dim query = "SELECT * FROM Books WHERE BorrowedBy IS NOT NULL ORDER BY DueDate"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                _dbConnection.OpenConnection()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        books.Add(MapReaderToBook(reader))
                    End While
                End Using
                _dbConnection.CloseConnection()
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error getting borrowed books: {ex.Message}", ex)
        End Try

        Return books
    End Function

    ' Get Overdue Books
    Public Function GetOverdueBooks() As List(Of Book)
        Dim books As New List(Of Book)()

        Try
            Dim query = "SELECT * FROM Books WHERE DueDate < ? AND BorrowedBy IS NOT NULL ORDER BY DueDate"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                cmd.Parameters.AddWithValue("@Today", Date.Today)

                _dbConnection.OpenConnection()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        books.Add(MapReaderToBook(reader))
                    End While
                End Using
                _dbConnection.CloseConnection()
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error getting overdue books: {ex.Message}", ex)
        End Try

        Return books
    End Function

    ' Get Books by Series
    Public Function GetBooksBySeries(seriesTitle As String) As List(Of Book)
        Dim books As New List(Of Book)()

        Try
            Dim query = "SELECT * FROM Books WHERE SeriesTitle = ? ORDER BY Title"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                cmd.Parameters.AddWithValue("@SeriesTitle", seriesTitle)

                _dbConnection.OpenConnection()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        books.Add(MapReaderToBook(reader))
                    End While
                End Using
                _dbConnection.CloseConnection()
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error getting books by series: {ex.Message}", ex)
        End Try

        Return books
    End Function

    ' Borrow Book
    Public Sub BorrowBook(bookID As Integer, userID As Integer, dueDate As Date)
        Try
            Dim query = "UPDATE Books SET BorrowedBy = ?, DueDate = ? WHERE BookID = ?"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                cmd.Parameters.AddWithValue("@UserID", userID)
                cmd.Parameters.AddWithValue("@DueDate", dueDate)
                cmd.Parameters.AddWithValue("@BookID", bookID)

                _dbConnection.OpenConnection()
                cmd.ExecuteNonQuery()
                _dbConnection.CloseConnection()

                AddBookHistory(bookID, $"Borrowed by user {userID} on {Date.Today:yyyy-MM-dd}, due {dueDate:yyyy-MM-dd}")
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error borrowing book: {ex.Message}", ex)
        End Try
    End Sub

    ' Return Book
    Public Sub ReturnBook(bookID As Integer)
        Try
            Dim book = GetBookByID(bookID)
            If book Is Nothing Then
                Throw New Exception("Book not found")
            End If

            Dim wasOverdue = book.IsOverdue
            Dim userID = book.BorrowedBy.Value

            Dim query = "UPDATE Books SET BorrowedBy = NULL, DueDate = NULL WHERE BookID = ?"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                cmd.Parameters.AddWithValue("@BookID", bookID)

                _dbConnection.OpenConnection()
                cmd.ExecuteNonQuery()
                _dbConnection.CloseConnection()

                Dim status = If(wasOverdue, "OVERDUE", "on time")
                AddBookHistory(bookID, $"Returned by user {userID} on {Date.Today:yyyy-MM-dd} ({status})")
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error returning book: {ex.Message}", ex)
        End Try
    End Sub

    ' Renew Book
    Public Sub RenewBook(bookID As Integer, newDueDate As Date)
        Try
            Dim book = GetBookByID(bookID)
            If book Is Nothing Then
                Throw New Exception("Book not found")
            End If

            Dim userID = book.BorrowedBy.Value

            Dim query = "UPDATE Books SET DueDate = ? WHERE BookID = ?"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                cmd.Parameters.AddWithValue("@DueDate", newDueDate)
                cmd.Parameters.AddWithValue("@BookID", bookID)

                _dbConnection.OpenConnection()
                cmd.ExecuteNonQuery()
                _dbConnection.CloseConnection()

                AddBookHistory(bookID, $"Renewed by user {userID} on {Date.Today:yyyy-MM-dd}, new due date {newDueDate:yyyy-MM-dd}")
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error renewing book: {ex.Message}", ex)
        End Try
    End Sub

    ' Update Book
    Public Sub UpdateBook(bookID As Integer, title As String, author As String, isbn As String, seriesTitle As String, details As String)
        Try
            Dim query = "UPDATE Books SET Title = ?, Author = ?, ISBN = ?, SeriesTitle = ?, Details = ? WHERE BookID = ?"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                cmd.Parameters.AddWithValue("@Title", title)
                cmd.Parameters.AddWithValue("@Author", author)
                cmd.Parameters.AddWithValue("@ISBN", isbn)
                cmd.Parameters.AddWithValue("@SeriesTitle", seriesTitle)
                cmd.Parameters.AddWithValue("@Details", If(details, String.Empty))
                cmd.Parameters.AddWithValue("@BookID", bookID)

                _dbConnection.OpenConnection()
                cmd.ExecuteNonQuery()
                _dbConnection.CloseConnection()
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error updating book: {ex.Message}", ex)
        End Try
    End Sub

    ' Delete Book
    Public Function DeleteBook(bookID As Integer) As Boolean
        Try
            Dim book = GetBookByID(bookID)
            If book Is Nothing OrElse Not book.IsAvailable Then
                Return False
            End If

            ' Delete history first
            Dim deleteHistory = "DELETE FROM BookHistory WHERE BookID = ?"
            Using cmd As New OleDbCommand(deleteHistory, _dbConnection.Connection)
                cmd.Parameters.AddWithValue("@BookID", bookID)
                _dbConnection.OpenConnection()
                cmd.ExecuteNonQuery()
                _dbConnection.CloseConnection()
            End Using

            ' Delete book
            Dim deleteABook = "DELETE FROM Books WHERE BookID = ?"
            Using cmd As New OleDbCommand(deleteABook, _dbConnection.Connection)
                cmd.Parameters.AddWithValue("@BookID", bookID)
                _dbConnection.OpenConnection()
                cmd.ExecuteNonQuery()
                _dbConnection.CloseConnection()
            End Using

            Return True
        Catch ex As Exception
            _dbConnection.CloseConnection()
            Throw New Exception($"Error deleting book: {ex.Message}", ex)
        End Try
    End Function

    ' Add Book History
    Public Sub AddBookHistory(bookID As Integer, entry As String)
        Try
            Dim query = "INSERT INTO BookHistory (BookID, EntryDate, Entry) VALUES (?, ?, ?)"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                cmd.Parameters.AddWithValue("@BookID", bookID)
                cmd.Parameters.AddWithValue("@EntryDate", Date.Now)
                cmd.Parameters.AddWithValue("@Entry", entry)

                _dbConnection.OpenConnection()
                cmd.ExecuteNonQuery()
                _dbConnection.CloseConnection()
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            ' Don't throw for history - just log
            Console.WriteLine($"Warning: Failed to add book history: {ex.Message}")
        End Try
    End Sub

    ' Get Book History
    Public Function GetBookHistory(bookID As Integer) As List(Of String)
        Dim history As New List(Of String)()

        Try
            Dim query = "SELECT EntryDate, Entry FROM BookHistory WHERE BookID = ? ORDER BY EntryDate DESC"

            Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                cmd.Parameters.AddWithValue("@BookID", bookID)

                _dbConnection.OpenConnection()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim entryDate = Convert.ToDateTime(reader("EntryDate"))
                        Dim entry = reader("Entry").ToString()
                        history.Add($"{entryDate:yyyy-MM-dd HH:mm:ss} - {entry}")
                    End While
                End Using
                _dbConnection.CloseConnection()
            End Using
        Catch ex As Exception
            _dbConnection.CloseConnection()
            ' Return empty list on error
        End Try

        Return history
    End Function

    ' Get Book Count
    Public Function GetBookCount() As Integer
        Try
            Dim query = "SELECT COUNT(*) FROM Books"
            Dim result = _dbConnection.ExecuteScalar(query)
            Return Convert.ToInt32(result)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ' Helper Method - Map Reader to Book
    Private Function MapReaderToBook(reader As OleDbDataReader) As Book
        Dim bookID = Convert.ToInt32(reader("BookID"))
        Dim title = reader("Title").ToString()
        Dim author = reader("Author").ToString()
        Dim isbn = reader("ISBN").ToString()
        Dim details = If(IsDBNull(reader("Details")), String.Empty, reader("Details").ToString())

        Dim book As New Book(bookID, title, author, isbn, details)

        If Not IsDBNull(reader("BorrowedBy")) Then
            ' Use reflection to set the read-only property
            Dim borrowedByField = GetType(Book).GetField("_borrowedBy", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
            borrowedByField?.SetValue(book, Convert.ToInt32(reader("BorrowedBy")))
        End If

        If Not IsDBNull(reader("DueDate")) Then
            ' Use reflection to set the read-only property
            Dim dueDateField = GetType(Book).GetField("_dueDate", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
            dueDateField?.SetValue(book, Convert.ToDateTime(reader("DueDate")))
        End If

        ' Load history
        Dim historyField = GetType(Book).GetField("_history", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        historyField?.SetValue(book, GetBookHistory(bookID))

        Return book
    End Function
End Class