Imports System.Linq

Public Enum LogType
    ' Authentication
    Login = 0
    Logout = 1

    ' Book operations
    BookAdded = 10
    BookEdited = 11
    BookDeleted = 12
    BookMarkedLost = 13
    BookBorrowed = 14
    BookReturned = 15
    BookRenewed = 16

    ' Account operations
    AccountCreated = 20
    AccountEdited = 21
    AccountDeleted = 22
    AccountVerified = 23

    ' Fine/Transaction operations
    FineAdded = 30
    FinePaid = 31
    FineWaived = 32

    ' Announcement operations
    AnnouncementCreated = 40
    AnnouncementEdited = 41
    AnnouncementDeleted = 42

    ' Notification operations
    NotificationSent = 50
    NotificationDeleted = 51

    ' System operations
    SystemError = 60
    DatabaseBackup = 61
    SystemMaintenance = 62
End Enum

Public Enum TargetTableType
    None = 0              ' For actions without a specific target (e.g., Login)
    Account = 1           ' TargetID refers to Accounts table
    Book = 2              ' TargetID refers to Books table
    BorrowedBook = 3      ' TargetID refers to BorrowedBooks table
    Transaction = 4       ' TargetID refers to Transactions table (fines)
    Announcement = 5      ' TargetID refers to Announcements table
    Notification = 6      ' TargetID refers to Notifications table
End Enum

Public Class Log
    Private _logID As Integer
    Private _logType As LogType
    Private _accountID As Integer?
    Private _targetID As Integer?
    Private _targetTable As TargetTableType
    Private _description As String
    Private _timestamp As DateTime
    Private _isDeleted As Boolean

    Public Property LogID As Integer
        Get
            Return _logID
        End Get
        Friend Set(value As Integer)
            _logID = value
        End Set
    End Property

    Public ReadOnly Property LogType As LogType
        Get
            Return _logType
        End Get
    End Property

    Public ReadOnly Property AccountID As Integer?
        Get
            Return _accountID
        End Get
    End Property

    Public ReadOnly Property TargetID As Integer?
        Get
            Return _targetID
        End Get
    End Property

    Public ReadOnly Property TargetTable As TargetTableType
        Get
            Return _targetTable
        End Get
    End Property

    Public ReadOnly Property Description As String
        Get
            Return _description
        End Get
    End Property

    Public ReadOnly Property Timestamp As DateTime
        Get
            Return _timestamp
        End Get
    End Property

    Public Property IsDeleted As Boolean
        Get
            Return _isDeleted
        End Get
        Friend Set(value As Boolean)
            _isDeleted = value
        End Set
    End Property

    Public ReadOnly Property LogTypeDescription As String
        Get
            Select Case _logType
                Case LogType.Login
                    Return "Login"
                Case LogType.Logout
                    Return "Logout"
                Case LogType.BookAdded
                    Return "Book Added"
                Case LogType.BookEdited
                    Return "Book Edited"
                Case LogType.BookDeleted
                    Return "Book Deleted"
                Case LogType.BookMarkedLost
                    Return "Book Marked Lost"
                Case LogType.BookBorrowed
                    Return "Book Borrowed"
                Case LogType.BookReturned
                    Return "Book Returned"
                Case LogType.BookRenewed
                    Return "Book Renewed"
                Case LogType.AccountCreated
                    Return "Account Created"
                Case LogType.AccountEdited
                    Return "Account Edited"
                Case LogType.AccountDeleted
                    Return "Account Deleted"
                Case LogType.AccountVerified
                    Return "Account Verified"
                Case LogType.FineAdded
                    Return "Fine Added"
                Case LogType.FinePaid
                    Return "Fine Paid"
                Case LogType.FineWaived
                    Return "Fine Waived"
                Case LogType.AnnouncementCreated
                    Return "Announcement Created"
                Case LogType.AnnouncementEdited
                    Return "Announcement Edited"
                Case LogType.AnnouncementDeleted
                    Return "Announcement Deleted"
                Case LogType.NotificationSent
                    Return "Notification Sent"
                Case LogType.NotificationDeleted
                    Return "Notification Deleted"
                Case LogType.SystemError
                    Return "System Error"
                Case LogType.DatabaseBackup
                    Return "Database Backup"
                Case LogType.SystemMaintenance
                    Return "System Maintenance"
                Case Else
                    Return "Unknown"
            End Select
        End Get
    End Property

    Public ReadOnly Property TargetTableDescription As String
        Get
            Select Case _targetTable
                Case TargetTableType.None
                    Return "None"
                Case TargetTableType.Account
                    Return "Account"
                Case TargetTableType.Book
                    Return "Book"
                Case TargetTableType.BorrowedBook
                    Return "Borrowed Book"
                Case TargetTableType.Transaction
                    Return "Transaction"
                Case TargetTableType.Announcement
                    Return "Announcement"
                Case TargetTableType.Notification
                    Return "Notification"
                Case Else
                    Return "Unknown"
            End Select
        End Get
    End Property

    ' Constructor - immutable after creation
    Public Sub New()
    End Sub

    Public Sub New(logType As LogType, description As String, Optional accountID As Integer? = Nothing, Optional targetID As Integer? = Nothing, Optional targetTable As TargetTableType = TargetTableType.None)
        If String.IsNullOrWhiteSpace(description) Then
            Throw New ArgumentException("Description cannot be empty")
        End If

        _logType = logType
        _accountID = accountID
        _targetID = targetID
        _targetTable = targetTable
        _description = description.Trim()
        _timestamp = DateTime.Now
        _isDeleted = False
    End Sub

    ' Factory methods for common log types
    Public Shared Function CreateLoginLog(accountID As Integer) As Log
        Return New Log(LogType.Login, $"User logged in", accountID, accountID, TargetTableType.Account)
    End Function

    Public Shared Function CreateLogoutLog(accountID As Integer) As Log
        Return New Log(LogType.Logout, $"User logged out", accountID, accountID, TargetTableType.Account)
    End Function

    Public Shared Function CreateBookBorrowedLog(accountID As Integer, borrowID As Integer, bookTitle As String) As Log
        Return New Log(LogType.BookBorrowed, $"Book '{bookTitle}' borrowed", accountID, borrowID, TargetTableType.BorrowedBook)
    End Function

    Public Shared Function CreateBookReturnedLog(accountID As Integer, borrowID As Integer, bookTitle As String) As Log
        Return New Log(LogType.BookReturned, $"Book '{bookTitle}' returned", accountID, borrowID, TargetTableType.BorrowedBook)
    End Function

    Public Shared Function CreateBookAddedLog(accountID As Integer, bookID As Integer, bookTitle As String) As Log
        Return New Log(LogType.BookAdded, $"Book '{bookTitle}' added to library", accountID, bookID, TargetTableType.Book)
    End Function

    Public Shared Function CreateAccountCreatedLog(creatorAccountID As Integer?, newAccountID As Integer, username As String) As Log
        Return New Log(LogType.AccountCreated, $"Account '{username}' created", creatorAccountID, newAccountID, TargetTableType.Account)
    End Function

    Public Shared Function CreateFineAddedLog(accountID As Integer, transactionID As Integer, amount As Decimal, reason As String) As Log
        Return New Log(LogType.FineAdded, $"Fine of ${amount:F2} added: {reason}", accountID, transactionID, TargetTableType.Transaction)
    End Function

    ' Soft delete - logs are immutable but can be marked as deleted
    Public Sub Delete()
        If _isDeleted Then
            Throw New InvalidOperationException("Log is already deleted")
        End If
        _isDeleted = True
    End Sub

    ' Restore soft-deleted log
    Public Sub Restore()
        If Not _isDeleted Then
            Throw New InvalidOperationException("Log is not deleted")
        End If
        _isDeleted = False
    End Sub

    ' Create a corrected version of this log (creates new log, doesn't modify existing)
    Public Function CreateCorrectedLog(newDescription As String) As Log
        If String.IsNullOrWhiteSpace(newDescription) Then
            Throw New ArgumentException("New description cannot be empty")
        End If
        Return New Log(_logType, $"[CORRECTED] {newDescription}", _accountID, _targetID, _targetTable)
    End Function

    Public Overrides Function ToString() As String
        Dim accountInfo = If(_accountID.HasValue, $"Account {_accountID.Value}", "System")
        Dim targetInfo = If(_targetID.HasValue, $" -> {TargetTableDescription} #{_targetID.Value}", "")
        Dim deleteStatus = If(_isDeleted, " [DELETED]", "")
        Return $"[{Timestamp:yyyy-MM-dd HH:mm:ss}] {LogTypeDescription} by {accountInfo}{targetInfo}: {Description}{deleteStatus}"
    End Function
End Class

' Helper class for querying logs
Public Class LogQuery
    Private _logs As List(Of Log)

    Public Sub New(logs As List(Of Log))
        _logs = If(logs, New List(Of Log)())
    End Sub

    ' Filter by account
    Public Function GetLogsByAccount(accountID As Integer) As List(Of Log)
        Return _logs.Where(Function(l) l.AccountID.HasValue AndAlso l.AccountID.Value = accountID AndAlso Not l.IsDeleted).ToList()
    End Function

    ' Filter by log type
    Public Function GetLogsByType(logType As LogType) As List(Of Log)
        Return _logs.Where(Function(l) l.LogType = logType AndAlso Not l.IsDeleted).ToList()
    End Function

    ' Filter by date range
    Public Function GetLogsByDateRange(startDate As DateTime, endDate As DateTime) As List(Of Log)
        Return _logs.Where(Function(l) l.Timestamp >= startDate AndAlso l.Timestamp <= endDate AndAlso Not l.IsDeleted).ToList()
    End Function

    ' Filter by target
    Public Function GetLogsByTarget(targetTable As TargetTableType, targetID As Integer) As List(Of Log)
        Return _logs.Where(Function(l) l.TargetTable = targetTable AndAlso l.TargetID.HasValue AndAlso l.TargetID.Value = targetID AndAlso Not l.IsDeleted).ToList()
    End Function

    ' Get recent logs
    Public Function GetRecentLogs(count As Integer) As List(Of Log)
        Return _logs.Where(Function(l) Not l.IsDeleted).OrderByDescending(Function(l) l.Timestamp).Take(count).ToList()
    End Function

    ' Get logs for today
    Public Function GetTodaysLogs() As List(Of Log)
        Dim today = DateTime.Today
        Return GetLogsByDateRange(today, today.AddDays(1).AddSeconds(-1))
    End Function

    ' Search logs by description
    Public Function SearchLogs(searchTerm As String) As List(Of Log)
        If String.IsNullOrWhiteSpace(searchTerm) Then
            Return New List(Of Log)()
        End If

        Return _logs.Where(Function(l) l.Description.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 AndAlso Not l.IsDeleted).ToList()
    End Function
End Class