Imports System.Data.OleDb
Imports System.IO

Public Class DatabaseConnection
    Private Shared _instance As DatabaseConnection
    Private Shared ReadOnly _lock As New Object()

    Private ReadOnly _dbPath As String
    Private ReadOnly _connectionString As String
    Private _connection As OleDbConnection

    ' Private constructor for singleton
    Private Sub New()
        _dbPath = Path.Combine(Application.StartupPath, "..\..\..\Database\Library.accdb")
        _connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};Persist Security Info=False;"
        _connection = New OleDbConnection(_connectionString)
    End Sub

    ' Singleton instance
    Public Shared ReadOnly Property Instance As DatabaseConnection
        Get
            If _instance Is Nothing Then
                SyncLock _lock
                    If _instance Is Nothing Then
                        _instance = New DatabaseConnection()
                    End If
                End SyncLock
            End If
            Return _instance
        End Get
    End Property

    ' Get connection
    Public ReadOnly Property Connection As OleDbConnection
        Get
            Return _connection
        End Get
    End Property

    ' Connection string property
    Public ReadOnly Property ConnectionString As String
        Get
            Return _connectionString
        End Get
    End Property

    ' Database path property
    Public ReadOnly Property DatabasePath As String
        Get
            Return _dbPath
        End Get
    End Property

    ' Open connection
    Public Sub OpenConnection()
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
        Catch ex As Exception
            Throw New Exception($"Failed to open database connection: {ex.Message}", ex)
        End Try
    End Sub

    ' Close connection
    Public Sub CloseConnection()
        Try
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
        Catch ex As Exception
            ' Log but don't throw on close
            Console.WriteLine($"Warning: Failed to close connection: {ex.Message}")
        End Try
    End Sub

    ' Test connection
    Public Function TestConnection() As Boolean
        Try
            OpenConnection()
            CloseConnection()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Check if database file exists
    Public Function DatabaseExists() As Boolean
        Return File.Exists(_dbPath)
    End Function

    ' Execute scalar query
    Public Function ExecuteScalar(query As String, ParamArray parameters As OleDbParameter()) As Object
        Try
            Using cmd As New OleDbCommand(query, _connection)
                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters)
                End If

                OpenConnection()
                Dim result = cmd.ExecuteScalar()
                CloseConnection()
                Return result
            End Using
        Catch ex As Exception
            CloseConnection()
            Throw New Exception($"Error executing scalar query: {ex.Message}", ex)
        End Try
    End Function

    ' Execute non-query
    Public Function ExecuteNonQuery(query As String, ParamArray parameters As OleDbParameter()) As Integer
        Try
            Using cmd As New OleDbCommand(query, _connection)
                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters)
                End If

                OpenConnection()
                Dim rowsAffected = cmd.ExecuteNonQuery()
                CloseConnection()
                Return rowsAffected
            End Using
        Catch ex As Exception
            CloseConnection()
            Throw New Exception($"Error executing non-query: {ex.Message}", ex)
        End Try
    End Function
End Class