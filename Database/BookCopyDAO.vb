Imports System.Data.OleDb

Public Class BookCopyDAO
    Private _connection As OleDbConnection

    Public Sub New(connection As OleDbConnection)
        _connection = connection
    End Sub

    Public Function GetById(copyID As Integer) As BookCopy
        Dim query As String = "SELECT * FROM BookCopy WHERE CopyID = @id"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@id", copyID)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                If reader.Read() Then Return MapToBookCopy(reader)
            End Using
        End Using
        Return Nothing
    End Function

    Public Function GetByBookID(bookID As Integer) As List(Of BookCopy)
        Dim copies As New List(Of BookCopy)
        Dim query As String = "SELECT * FROM BookCopy WHERE BookID = @bookId"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@bookId", bookID)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    copies.Add(MapToBookCopy(reader))
                End While
            End Using
        End Using
        Return copies
    End Function

    Public Function Insert(copy As BookCopy) As Integer
        Dim query As String = "INSERT INTO BookCopy (BookID, Condition, Status, ShelfLocation, DateAdded, LastUpdated) " &
                              "VALUES (@bookId, @condition, @status, @location, @added, @updated)"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@bookId", copy.BookID)
            cmd.Parameters.AddWithValue("@condition", copy.Condition)
            cmd.Parameters.AddWithValue("@status", copy.Status)
            cmd.Parameters.AddWithValue("@location", copy.ShelfLocation)
            cmd.Parameters.AddWithValue("@added", copy.DateAdded)
            cmd.Parameters.AddWithValue("@updated", copy.LastUpdated)
            cmd.ExecuteNonQuery()
        End Using

        Using cmd As New OleDbCommand("SELECT @@IDENTITY", _connection)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Public Function Update(copy As BookCopy) As Boolean
        Dim query As String = "UPDATE BookCopy SET Condition = @condition, Status = @status, " &
                              "ShelfLocation = @location, LastUpdated = @updated WHERE CopyID = @id"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@condition", copy.Condition)
            cmd.Parameters.AddWithValue("@status", copy.Status)
            cmd.Parameters.AddWithValue("@location", copy.ShelfLocation)
            cmd.Parameters.AddWithValue("@updated", DateTime.Now)
            cmd.Parameters.AddWithValue("@id", copy.CopyID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    Private Function MapToBookCopy(reader As OleDbDataReader) As BookCopy
        Return New BookCopy With {
            .CopyID = Convert.ToInt32(reader("CopyID")),
            .BookID = Convert.ToInt32(reader("BookID")),
            .Condition = reader("Condition").ToString(),
            .Status = reader("Status").ToString(),
            .ShelfLocation = reader("ShelfLocation").ToString(),
            .DateAdded = Convert.ToDateTime(reader("DateAdded")),
            .LastUpdated = Convert.ToDateTime(reader("LastUpdated"))
        }
    End Function
End Class