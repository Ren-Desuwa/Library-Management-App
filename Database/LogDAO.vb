Imports System.Data.OleDb

Public Class LogDAO
    Private _connection As OleDbConnection

    Public Sub New(connection As OleDbConnection)
        _connection = connection
    End Sub

    Public Function Insert(log As Log) As Integer
        Dim query As String = "INSERT INTO Log (AccountID, Action, Timestamp, Details, IPAddress, Severity) " &
                              "VALUES (@accountId, @action, @timestamp, @details, @ip, @severity)"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@accountId", If(log.AccountID.HasValue, CObj(log.AccountID.Value), DBNull.Value))
            cmd.Parameters.AddWithValue("@action", log.Action)
            cmd.Parameters.AddWithValue("@timestamp", log.Timestamp)
            cmd.Parameters.AddWithValue("@details", log.Details)
            cmd.Parameters.AddWithValue("@ip", If(log.IPAddress, ""))
            cmd.Parameters.AddWithValue("@severity", log.Severity)
            cmd.ExecuteNonQuery()
        End Using

        Using cmd As New OleDbCommand("SELECT @@IDENTITY", _connection)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Public Function GetByAccountID(accountID As Integer, limit As Integer) As List(Of Log)
        Dim logs As New List(Of Log)
        Dim query As String = $"SELECT TOP {limit} * FROM Log WHERE AccountID = @accountId ORDER BY Timestamp DESC"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@accountId", accountID)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    logs.Add(MapToLog(reader))
                End While
            End Using
        End Using
        Return logs
    End Function

    Public Function GetRecent(limit As Integer) As List(Of Log)
        Dim logs As New List(Of Log)
        Dim query As String = $"SELECT TOP {limit} * FROM Log ORDER BY Timestamp DESC"
        Using cmd As New OleDbCommand(query, _connection)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    logs.Add(MapToLog(reader))
                End While
            End Using
        End Using
        Return logs
    End Function

    Public Function GetBySeverity(severity As String, limit As Integer) As List(Of Log)
        Dim logs As New List(Of Log)
        Dim query As String = $"SELECT TOP {limit} * FROM Log WHERE Severity = @severity ORDER BY Timestamp DESC"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@severity", severity)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    logs.Add(MapToLog(reader))
                End While
            End Using
        End Using
        Return logs
    End Function

    Private Function MapToLog(reader As OleDbDataReader) As Log
        Return New Log With {
            .LogID = Convert.ToInt32(reader("LogID")),
            .AccountID = If(IsDBNull(reader("AccountID")), Nothing, Convert.ToInt32(reader("AccountID"))),
            .Action = reader("Action").ToString(),
            .Timestamp = Convert.ToDateTime(reader("Timestamp")),
            .Details = reader("Details").ToString(),
            .IPAddress = reader("IPAddress").ToString(),
            .Severity = reader("Severity").ToString()
        }
    End Function
End Class