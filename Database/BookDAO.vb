Imports System.Data.OleDb

Public Class BookDAO
    Private _connection As OleDbConnection

    Public Sub New(connection As OleDbConnection)
        _connection = connection
    End Sub

    ' Get book by ID
    Public Function GetById(bookID As Integer) As Book
        Dim query As String = "SELECT * FROM Book WHERE BookID = @id"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@id", bookID)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Return MapToBook(reader)
                End If
            End Using
        End Using
        Return Nothing
    End Function

    ' Get book by ISBN
    Public Function GetByISBN(isbn As String) As Book
        Dim query As String = "SELECT * FROM Book WHERE ISBN = @isbn"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@isbn", isbn)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Return MapToBook(reader)
                End If
            End Using
        End Using
        Return Nothing
    End Function

    ' Insert new book
    Public Function Insert(book As Book) As Integer
        Dim query As String = "INSERT INTO Book (Title, Author, Genre, ISBN, Publisher, YearPublished, Description, TotalCopies, AvailableCopies) " &
                              "VALUES (@title, @author, @genre, @isbn, @publisher, @year, @desc, @total, @available)"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@title", book.Title)
            cmd.Parameters.AddWithValue("@author", book.Author)
            cmd.Parameters.AddWithValue("@genre", book.Genre)
            cmd.Parameters.AddWithValue("@isbn", book.ISBN)
            cmd.Parameters.AddWithValue("@publisher", book.Publisher)
            cmd.Parameters.AddWithValue("@year", book.YearPublished)
            cmd.Parameters.AddWithValue("@desc", book.Description)
            cmd.Parameters.AddWithValue("@total", book.TotalCopies)
            cmd.Parameters.AddWithValue("@available", book.AvailableCopies)
            cmd.ExecuteNonQuery()
        End Using

        Dim idQuery As String = "SELECT @@IDENTITY"
        Using cmd As New OleDbCommand(idQuery, _connection)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    ' Update existing book
    Public Function Update(book As Book) As Boolean
        Dim query As String = "UPDATE Book SET Title = @title, Author = @author, Genre = @genre, " &
                              "ISBN = @isbn, Publisher = @publisher, YearPublished = @year, " &
                              "Description = @desc, TotalCopies = @total, AvailableCopies = @available " &
                              "WHERE BookID = @id"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@title", book.Title)
            cmd.Parameters.AddWithValue("@author", book.Author)
            cmd.Parameters.AddWithValue("@genre", book.Genre)
            cmd.Parameters.AddWithValue("@isbn", book.ISBN)
            cmd.Parameters.AddWithValue("@publisher", book.Publisher)
            cmd.Parameters.AddWithValue("@year", book.YearPublished)
            cmd.Parameters.AddWithValue("@desc", book.Description)
            cmd.Parameters.AddWithValue("@total", book.TotalCopies)
            cmd.Parameters.AddWithValue("@available", book.AvailableCopies)
            cmd.Parameters.AddWithValue("@id", book.BookID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Search books by title or author
    Public Function Search(searchTerm As String) As List(Of Book)
        Dim books As New List(Of Book)
        Dim query As String = "SELECT * FROM Book WHERE Title LIKE @term OR Author LIKE @term ORDER BY Title"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@term", "%" & searchTerm & "%")
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    books.Add(MapToBook(reader))
                End While
            End Using
        End Using
        Return books
    End Function

    ' Helper method
    Private Function MapToBook(reader As OleDbDataReader) As Book
        Return New Book With {
            .BookID = Convert.ToInt32(reader("BookID")),
            .Title = reader("Title").ToString(),
            .Author = reader("Author").ToString(),
            .Genre = reader("Genre").ToString(),
            .ISBN = reader("ISBN").ToString(),
            .Publisher = reader("Publisher").ToString(),
            .YearPublished = Convert.ToInt32(reader("YearPublished")),
            .Description = reader("Description").ToString(),
            .TotalCopies = Convert.ToInt32(reader("TotalCopies")),
            .AvailableCopies = Convert.ToInt32(reader("AvailableCopies"))
        }
    End Function
End Class