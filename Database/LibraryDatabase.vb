Public Class LibraryDatabase
    Private Shared _instance As LibraryDatabase
    Private Shared ReadOnly _lock As New Object()

    Private ReadOnly _dbConnection As DatabaseConnection
    Private ReadOnly _book As BookDatabase
    Private ReadOnly _account As AccountDatabase

    ' Private constructor for singleton
    Private Sub New()
        _dbConnection = DatabaseConnection.Instance
        _book = New BookDatabase(_dbConnection)
        _account = New AccountDatabase(_dbConnection)
    End Sub

    ' Singleton instance
    Public Shared ReadOnly Property Instance As LibraryDatabase
        Get
            If _instance Is Nothing Then
                SyncLock _lock
                    If _instance Is Nothing Then
                        _instance = New LibraryDatabase()
                    End If
                End SyncLock
            End If
            Return _instance
        End Get
    End Property

    ' Access to book operations
    Public ReadOnly Property Books As BookDatabase
        Get
            Return _book
        End Get
    End Property

    ' Access to account operations
    Public ReadOnly Property Accounts As AccountDatabase
        Get
            Return _account
        End Get
    End Property

    ' Access to database connection
    Public ReadOnly Property Connection As DatabaseConnection
        Get
            Return _dbConnection
        End Get
    End Property

    ' Initialize database (create tables if needed)
    Public Sub InitializeDatabase()
        Try
            If Not _dbConnection.DatabaseExists() Then
                Throw New Exception("Database file not found at: " & _dbConnection.DatabasePath)
            End If

            If Not _dbConnection.TestConnection() Then
                Throw New Exception("Unable to connect to database")
            End If

            ' Try to create tables (will fail silently if they already exist)
            Try
                _book.CreateTables()
            Catch ex As Exception
                ' Tables might already exist
                Console.WriteLine($"Note: Book tables may already exist: {ex.Message}")
            End Try

            Try
                _account.CreateTables()
            Catch ex As Exception
                ' Tables might already exist
                Console.WriteLine($"Note: Account tables may already exist: {ex.Message}")
            End Try

        Catch ex As Exception
            Throw New Exception($"Failed to initialize database: {ex.Message}", ex)
        End Try
    End Sub

    ' Test database connection
    Public Function TestConnection() As Boolean
        Return _dbConnection.TestConnection()
    End Function

    ' Check if database exists
    Public Function DatabaseExists() As Boolean
        Return _dbConnection.DatabaseExists()
    End Function

    ' Get database statistics
    Public Function GetDatabaseStatistics() As Dictionary(Of String, Integer)
        Dim stats As New Dictionary(Of String, Integer)

        Try
            stats("TotalBooks") = _book.GetBookCount()
            stats("AvailableBooks") = _book.GetAvailableBooks().Count
            stats("BorrowedBooks") = _book.GetBorrowedBooks().Count
            stats("OverdueBooks") = _book.GetOverdueBooks().Count
            stats("TotalAccounts") = _account.GetAccountCount()
            stats("UserAccounts") = _account.GetAllUsers().Count
            stats("AdminAccounts") = _account.GetAllAdmins().Count
        Catch ex As Exception
            ' Return empty stats on error
        End Try

        Return stats
    End Function
End Class