Imports System.Data.OleDb

Public Class TransactionDAO
    Private _connection As OleDbConnection

    Public Sub New(connection As OleDbConnection)
        _connection = connection
    End Sub

    Public Function GetById(transactionID As Integer) As Transaction
        Dim query As String = "SELECT * FROM [Transaction] WHERE TransactionID = @id"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@id", transactionID)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                If reader.Read() Then Return MapToTransaction(reader)
            End Using
        End Using
        Return Nothing
    End Function

    Public Function GetByAccountID(accountID As Integer) As List(Of Transaction)
        Dim transactions As New List(Of Transaction)
        Dim query As String = "SELECT * FROM [Transaction] WHERE AccountID = @accountId ORDER BY DateBorrowed DESC"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@accountId", accountID)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    transactions.Add(MapToTransaction(reader))
                End While
            End Using
        End Using
        Return transactions
    End Function

    Public Function Insert(transaction As Transaction) As Integer
        Dim query As String = "INSERT INTO [Transaction] (AccountID, CopyID, TransactionType, DateBorrowed, DateDue, DateReturned, Fine, Status) " &
                              "VALUES (@accountId, @copyId, @type, @borrowed, @due, @returned, @fine, @status)"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@accountId", transaction.AccountID)
            cmd.Parameters.AddWithValue("@copyId", transaction.CopyID)
            cmd.Parameters.AddWithValue("@type", transaction.TransactionType)
            cmd.Parameters.AddWithValue("@borrowed", If(transaction.DateBorrowed.HasValue, CObj(transaction.DateBorrowed.Value), DBNull.Value))
            cmd.Parameters.AddWithValue("@due", If(transaction.DateDue.HasValue, CObj(transaction.DateDue.Value), DBNull.Value))
            cmd.Parameters.AddWithValue("@returned", If(transaction.DateReturned.HasValue, CObj(transaction.DateReturned.Value), DBNull.Value))
            cmd.Parameters.AddWithValue("@fine", transaction.Fine)
            cmd.Parameters.AddWithValue("@status", transaction.Status)
            cmd.ExecuteNonQuery()
        End Using

        Using cmd As New OleDbCommand("SELECT @@IDENTITY", _connection)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Public Function Update(transaction As Transaction) As Boolean
        Dim query As String = "UPDATE [Transaction] SET DateReturned = @returned, Fine = @fine, Status = @status WHERE TransactionID = @id"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@returned", If(transaction.DateReturned.HasValue, CObj(transaction.DateReturned.Value), DBNull.Value))
            cmd.Parameters.AddWithValue("@fine", transaction.Fine)
            cmd.Parameters.AddWithValue("@status", transaction.Status)
            cmd.Parameters.AddWithValue("@id", transaction.TransactionID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    Private Function MapToTransaction(reader As OleDbDataReader) As Transaction
        Return New Transaction With {
            .TransactionID = Convert.ToInt32(reader("TransactionID")),
            .AccountID = Convert.ToInt32(reader("AccountID")),
            .CopyID = Convert.ToInt32(reader("CopyID")),
            .TransactionType = reader("TransactionType").ToString(),
            .DateBorrowed = If(IsDBNull(reader("DateBorrowed")), Nothing, Convert.ToDateTime(reader("DateBorrowed"))),
            .DateDue = If(IsDBNull(reader("DateDue")), Nothing, Convert.ToDateTime(reader("DateDue"))),
            .DateReturned = If(IsDBNull(reader("DateReturned")), Nothing, Convert.ToDateTime(reader("DateReturned"))),
            .Fine = Convert.ToDecimal(reader("Fine")),
            .Status = reader("Status").ToString()
        }
    End Function
End Class