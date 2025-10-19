'Imports System.Data.OleDb
'Imports System.IO

'' Helper class for logging database operations
'Public Class DatabaseLogger
'    Private Shared _logPath As String = Path.Combine(Application.StartupPath, "database_log.txt")

'    Public Shared Sub LogOperation(operation As String, Optional details As String = "")
'        Try
'            Dim logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {operation}"
'            If Not String.IsNullOrEmpty(details) Then
'                logEntry &= $" - {details}"
'            End If
'            File.AppendAllText(_logPath, logEntry & Environment.NewLine)
'        Catch ex As Exception
'            ' Fail silently - don't break operations due to logging issues
'            Console.WriteLine($"Logging failed: {ex.Message}")
'        End Try
'    End Sub

'    Public Shared Sub LogError(operation As String, ex As Exception)
'        Try
'            Dim logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR in {operation}: {ex.Message}" & Environment.NewLine & ex.StackTrace
'            File.AppendAllText(_logPath, logEntry & Environment.NewLine & Environment.NewLine)
'        Catch
'            ' Fail silently
'        End Try
'    End Sub
'End Class

'' Helper class for common database operations
'Public Class DatabaseHelper
'    ' Execute operation within a transaction
'    Public Shared Sub ExecuteInTransaction(connection As OleDbConnection, action As Action(Of OleDbTransaction))
'        Dim transaction As OleDbTransaction = Nothing
'        Try
'            If connection.State <> ConnectionState.Open Then
'                connection.Open()
'            End If

'            transaction = connection.BeginTransaction()
'            action(transaction)
'            transaction.Commit()
'            DatabaseLogger.LogOperation("Transaction committed successfully")
'        Catch ex As Exception
'            DatabaseLogger.LogError("Transaction", ex)
'            If transaction IsNot Nothing Then
'                Try
'                    transaction.Rollback()
'                    DatabaseLogger.LogOperation("Transaction rolled back")
'                Catch rollbackEx As Exception
'                    DatabaseLogger.LogError("Transaction Rollback", rollbackEx)
'                End Try
'            End If
'            Throw
'        Finally
'            If connection.State = ConnectionState.Open Then
'                connection.Close()
'            End If
'        End Try
'    End Sub

'    ' Safe parameter addition
'    Public Shared Sub AddParameter(cmd As OleDbCommand, paramName As String, value As Object)
'        If value Is Nothing OrElse IsDBNull(value) Then
'            cmd.Parameters.AddWithValue(paramName, DBNull.Value)
'        Else
'            cmd.Parameters.AddWithValue(paramName, value)
'        End If
'    End Sub

'    ' Safe value retrieval from data reader
'    Public Shared Function GetSafeValue(Of T)(reader As OleDbDataReader, columnName As String, defaultValue As T) As T
'        Try
'            Dim ordinal = reader.GetOrdinal(columnName)
'            If reader.IsDBNull(ordinal) Then
'                Return defaultValue
'            End If

'            Dim value = reader(columnName)
'            If value Is Nothing OrElse IsDBNull(value) Then
'                Return defaultValue
'            End If

'            Return CType(value, T)
'        Catch ex As Exception
'            DatabaseLogger.LogError($"GetSafeValue for {columnName}", ex)
'            Return defaultValue
'        End Try
'    End Function

'    Public Shared Function GetSafeNullableValue(Of T As Structure)(reader As OleDbDataReader, columnName As String) As T?
'        Try
'            Dim ordinal = reader.GetOrdinal(columnName)
'            If reader.IsDBNull(ordinal) Then
'                Return Nothing
'            End If

'            Dim value = reader(columnName)
'            If value Is Nothing OrElse IsDBNull(value) Then
'                Return Nothing
'            End If

'            Return CType(value, T)
'        Catch ex As Exception
'            DatabaseLogger.LogError($"GetSafeNullableValue for {columnName}", ex)
'            Return Nothing
'        End Try
'    End Function
'End Class