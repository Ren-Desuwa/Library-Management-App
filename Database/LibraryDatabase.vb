Public Class LibraryDatabase
    Private Shared _instance As LibraryDatabase
    Private Shared ReadOnly _lock As New Object()

    Public ReadOnly Property AccountDAO As AccountDAO
    Public ReadOnly Property BookDAO As BookDAO
    Public ReadOnly Property BookCopyDAO As BookCopyDAO
    Public ReadOnly Property TransactionDAO As TransactionDAO
    Public ReadOnly Property NotificationDAO As NotificationDAO
    Public ReadOnly Property AnnouncementDAO As AnnouncementDAO
    Public ReadOnly Property LogDAO As LogDAO

    Private Sub New()
        Dim conn = DatabaseConnection.Instance.Connection
        AccountDAO = New AccountDAO(conn)
        BookDAO = New BookDAO(conn)
        BookCopyDAO = New BookCopyDAO(conn)
        TransactionDAO = New TransactionDAO(conn)
        NotificationDAO = New NotificationDAO(conn)
        AnnouncementDAO = New AnnouncementDAO(conn)
        LogDAO = New LogDAO(conn)
    End Sub

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
End Class