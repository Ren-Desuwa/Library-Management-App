Imports System.Data.OleDb
Imports System.IO

Public Class DatabaseConnection
    Private Shared _instance As DatabaseConnection
    Private _connection As OleDbConnection
    Private ReadOnly _connectionString As String
    Private ReadOnly _dbPath As String
    Private Shared ReadOnly _lock As New Object()

    Private Sub New()
        _dbPath = Path.Combine(Application.StartupPath, "..\..\Database\Library.accdb")
        _connectionString = $"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={_dbPath};"
        _connection = New OleDbConnection(_connectionString)
    End Sub

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

    Public ReadOnly Property Connection As OleDbConnection
        Get
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            Return _connection
        End Get
    End Property

    ' Test connection
    Public Function TestConnection() As Boolean
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Close connection
    Public Sub CloseConnection()
        If _connection IsNot Nothing AndAlso _connection.State <> ConnectionState.Closed Then
            _connection.Close()
        End If
    End Sub
End Class