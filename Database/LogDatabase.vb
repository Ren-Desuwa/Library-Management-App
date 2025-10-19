Imports System.Data.OleDb

Public Class LogDatabase
    Private ReadOnly _dbConnection As DatabaseConnection

    Public Sub New(dbConnection As DatabaseConnection)
        _dbConnection = dbConnection
    End Sub

    ' Create Tables
    Public Sub CreateTables()
        Try
            Dim createLogsTable As String = "CREATE TABLE Logs (
                LogID AUTOINCREMENT PRIMARY KEY,
                LogType INTEGER NOT NULL,
                AccountID INTEGER,
                TargetID INTEGER,
                TargetTable INTEGER NOT NULL,
                Description MEMO NOT NULL,
                Timestamp DATETIME NOT NULL,
                IsDeleted BIT NOT NULL DEFAULT 0
            )"

            _dbConnection.ExecuteNonQuery(createLogsTable)
            DatabaseLogger.LogOperation("LogDatabase.CreateTables", "Logs table created")
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.CreateTables", ex)
            Throw New Exception($"Error creating logs table: {ex.Message}", ex)
        End Try
    End Sub

    ' Create Log
    Public Function CreateLog(logType As LogType, description As String, Optional accountID As Integer? = Nothing, Optional targetID As Integer? = Nothing, Optional targetTable As TargetTableType = TargetTableType.None) As Integer
        Try
            Dim query = "INSERT INTO Logs (LogType, AccountID, TargetID, TargetTable, Description, Timestamp, IsDeleted) VALUES (?, ?, ?, ?, ?, ?, ?)"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@LogType", CInt(logType))
                    DatabaseHelper.AddParameter(cmd, "@AccountID", accountID)
                    DatabaseHelper.AddParameter(cmd, "@TargetID", targetID)
                    cmd.Parameters.AddWithValue("@TargetTable", CInt(targetTable))
                    cmd.Parameters.AddWithValue("@Description", description)
                    cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now)
                    cmd.Parameters.AddWithValue("@IsDeleted", False)

                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "SELECT @@IDENTITY"
                    Dim logID = Convert.ToInt32(cmd.ExecuteScalar())

                    Return logID
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.CreateLog", ex)
            Throw New Exception($"Error creating log: {ex.Message}", ex)
        End Try
    End Function

    ' Get Log by ID
    Public Function GetLogByID(logID As Integer) As Log
        Try
            Dim query = "SELECT * FROM Logs WHERE LogID = ? AND IsDeleted = 0"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@LogID", logID)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return MapReaderToLog(reader)
                        End If
                    End Using
                End Using

                Return Nothing
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.GetLogByID", ex)
            Throw New Exception($"Error getting log by ID: {ex.Message}", ex)
        End Try
    End Function

    ' Get All Logs
    Public Function GetAllLogs(Optional includeDeleted As Boolean = False) As List(Of Log)
        Dim logs As New List(Of Log)()

        Try
            Dim query = If(includeDeleted,
                "SELECT * FROM Logs ORDER BY Timestamp DESC",
                "SELECT * FROM Logs WHERE IsDeleted = 0 ORDER BY Timestamp DESC")

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            logs.Add(MapReaderToLog(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.GetAllLogs", ex)
            Throw New Exception($"Error getting all logs: {ex.Message}", ex)
        End Try

        Return logs
    End Function

    ' Get Logs by Account
    Public Function GetLogsByAccount(accountID As Integer) As List(Of Log)
        Dim logs As New List(Of Log)()

        Try
            Dim query = "SELECT * FROM Logs WHERE AccountID = ? AND IsDeleted = 0 ORDER BY Timestamp DESC"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AccountID", accountID)

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            logs.Add(MapReaderToLog(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.GetLogsByAccount", ex)
            Throw New Exception($"Error getting logs by account: {ex.Message}", ex)
        End Try

        Return logs
    End Function

    ' Get Logs by Type
    Public Function GetLogsByType(logType As LogType) As List(Of Log)
        Dim logs As New List(Of Log)()

        Try
            Dim query = "SELECT * FROM Logs WHERE LogType = ? AND IsDeleted = 0 ORDER BY Timestamp DESC"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@LogType", CInt(logType))

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            logs.Add(MapReaderToLog(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.GetLogsByType", ex)
            Throw New Exception($"Error getting logs by type: {ex.Message}", ex)
        End Try

        Return logs
    End Function

    ' Get Logs by Date Range
    Public Function GetLogsByDateRange(startDate As DateTime, endDate As DateTime) As List(Of Log)
        Dim logs As New List(Of Log)()

        Try
            Dim query = "SELECT * FROM Logs WHERE Timestamp >= ? AND Timestamp <= ? AND IsDeleted = 0 ORDER BY Timestamp DESC"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@StartDate", startDate)
                    cmd.Parameters.AddWithValue("@EndDate", endDate)

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            logs.Add(MapReaderToLog(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.GetLogsByDateRange", ex)
            Throw New Exception($"Error getting logs by date range: {ex.Message}", ex)
        End Try

        Return logs
    End Function

    ' Get Logs by Target
    Public Function GetLogsByTarget(targetTable As TargetTableType, targetID As Integer) As List(Of Log)
        Dim logs As New List(Of Log)()

        Try
            Dim query = "SELECT * FROM Logs WHERE TargetTable = ? AND TargetID = ? AND IsDeleted = 0 ORDER BY Timestamp DESC"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@TargetTable", CInt(targetTable))
                    cmd.Parameters.AddWithValue("@TargetID", targetID)

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            logs.Add(MapReaderToLog(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.GetLogsByTarget", ex)
            Throw New Exception($"Error getting logs by target: {ex.Message}", ex)
        End Try

        Return logs
    End Function

    ' Get Recent Logs
    Public Function GetRecentLogs(count As Integer) As List(Of Log)
        Dim logs As New List(Of Log)()

        Try
            Dim query = "SELECT TOP " & count & " * FROM Logs WHERE IsDeleted = 0 ORDER BY Timestamp DESC"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            logs.Add(MapReaderToLog(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.GetRecentLogs", ex)
            Throw New Exception($"Error getting recent logs: {ex.Message}", ex)
        End Try

        Return logs
    End Function

    ' Search Logs
    Public Function SearchLogs(searchTerm As String) As List(Of Log)
        Dim logs As New List(Of Log)()

        If String.IsNullOrWhiteSpace(searchTerm) Then
            Return logs
        End If

        Try
            Dim query = "SELECT * FROM Logs WHERE Description LIKE ? AND IsDeleted = 0 ORDER BY Timestamp DESC"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@Search", $"*{searchTerm}*")

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            logs.Add(MapReaderToLog(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.SearchLogs", ex)
            Throw New Exception($"Error searching logs: {ex.Message}", ex)
        End Try

        Return logs
    End Function

    ' Soft Delete Log
    Public Sub DeleteLog(logID As Integer)
        Try
            Dim query = "UPDATE Logs SET IsDeleted = 1 WHERE LogID = ?"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@LogID", logID)
                    cmd.ExecuteNonQuery()
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.DeleteLog", ex)
            Throw New Exception($"Error deleting log: {ex.Message}", ex)
        End Try
    End Sub

    ' Restore Log
    Public Sub RestoreLog(logID As Integer)
        Try
            Dim query = "UPDATE Logs SET IsDeleted = 0 WHERE LogID = ?"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@LogID", logID)
                    cmd.ExecuteNonQuery()
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.RestoreLog", ex)
            Throw New Exception($"Error restoring log: {ex.Message}", ex)
        End Try
    End Sub

    ' Get Log Count
    Public Function GetLogCount(Optional includeDeleted As Boolean = False) As Integer
        Try
            Dim query = If(includeDeleted,
                "SELECT COUNT(*) FROM Logs",
                "SELECT COUNT(*) FROM Logs WHERE IsDeleted = 0")

            Dim result = _dbConnection.ExecuteScalar(query)
            Return Convert.ToInt32(result)
        Catch ex As Exception
            DatabaseLogger.LogError("LogDatabase.GetLogCount", ex)
            Return 0
        End Try
    End Function

    ' Helper Method - Map Reader to Log
    Private Function MapReaderToLog(reader As OleDbDataReader) As Log
        Dim logType = CType(Convert.ToInt32(reader("LogType")), LogType)
        Dim description = reader("Description").ToString()
        Dim accountID = DatabaseHelper.GetSafeNullableValue(Of Integer)(reader, "AccountID")
        Dim targetID = DatabaseHelper.GetSafeNullableValue(Of Integer)(reader, "TargetID")
        Dim targetTable = CType(Convert.ToInt32(reader("TargetTable")), TargetTableType)

        Dim log As New Log(logType, description, accountID, targetID, targetTable)
        log.LogID = Convert.ToInt32(reader("LogID"))
        log.IsDeleted = Convert.ToBoolean(reader("IsDeleted"))

        ' Set timestamp using reflection
        Dim timestampField = GetType(Log).GetField("_timestamp", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        timestampField?.SetValue(log, Convert.ToDateTime(reader("Timestamp")))

        Return log
    End Function
End Class