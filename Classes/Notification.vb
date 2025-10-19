Public Enum NotificationType
    BookReminder = 0        ' Reminder for upcoming due dates
    OverdueReminder = 1     ' Book is overdue
    AdminNotice = 2         ' Notice from admin
    LibrarianNotice = 3     ' Notice from librarian
    SystemNotice = 4        ' Automated system notifications
    BookAvailable = 5       ' Reserved book now available
    AccountUpdate = 6       ' Account changes/verification
    FineNotice = 7          ' Fine-related notifications
End Enum

Public Class Notification
    Private _notificationID As Integer
    Private _accountID As Integer?
    Private _title As String
    Private _content As String
    Private _createdBy As Integer?
    Private _notifType As NotificationType
    Private _attachments As String
    Private _notifDate As DateTime
    Private _isRead As Boolean
    Private _isDeleted As Boolean

    Public Property NotificationID As Integer
        Get
            Return _notificationID
        End Get
        Friend Set(value As Integer)
            _notificationID = value
        End Set
    End Property

    Public Property AccountID As Integer?
        Get
            Return _accountID
        End Get
        Friend Set(value As Integer?)
            _accountID = value
        End Set
    End Property

    Public Property Title As String
        Get
            Return _title
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Title cannot be empty")
            End If
            If value.Trim().Length > 100 Then
                Throw New ArgumentException("Title cannot exceed 100 characters")
            End If
            _title = value.Trim()
        End Set
    End Property

    Public Property Content As String
        Get
            Return _content
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Content cannot be empty")
            End If
            _content = value.Trim()
        End Set
    End Property

    Public Property CreatedBy As Integer?
        Get
            Return _createdBy
        End Get
        Friend Set(value As Integer?)
            ' -1 or Nothing means system-generated
            _createdBy = value
        End Set
    End Property

    Public Property NotifType As NotificationType
        Get
            Return _notifType
        End Get
        Friend Set(value As NotificationType)
            _notifType = value
        End Set
    End Property

    Public Property Attachments As String
        Get
            Return _attachments
        End Get
        Set(value As String)
            _attachments = If(value, String.Empty)
        End Set
    End Property

    Public Property NotifDate As DateTime
        Get
            Return _notifDate
        End Get
        Friend Set(value As DateTime)
            _notifDate = value
        End Set
    End Property

    Public Property IsRead As Boolean
        Get
            Return _isRead
        End Get
        Friend Set(value As Boolean)
            _isRead = value
        End Set
    End Property

    Public Property IsDeleted As Boolean
        Get
            Return _isDeleted
        End Get
        Friend Set(value As Boolean)
            _isDeleted = value
        End Set
    End Property

    Public ReadOnly Property IsSystemNotification As Boolean
        Get
            Return Not _createdBy.HasValue OrElse _createdBy.Value = -1
        End Get
    End Property

    Public ReadOnly Property NotificationTypeDescription As String
        Get
            Select Case _notifType
                Case NotificationType.BookReminder
                    Return "Book Reminder"
                Case NotificationType.OverdueReminder
                    Return "Overdue Reminder"
                Case NotificationType.AdminNotice
                    Return "Admin Notice"
                Case NotificationType.LibrarianNotice
                    Return "Librarian Notice"
                Case NotificationType.SystemNotice
                    Return "System Notice"
                Case NotificationType.BookAvailable
                    Return "Book Available"
                Case NotificationType.AccountUpdate
                    Return "Account Update"
                Case NotificationType.FineNotice
                    Return "Fine Notice"
                Case Else
                    Return "Unknown"
            End Select
        End Get
    End Property

    ' Constructors
    Public Sub New()
    End Sub

    ' Constructor for user-created notification
    Public Sub New(accountID As Integer?, title As String, content As String, createdBy As Integer?, notifType As NotificationType)
        Me.AccountID = accountID
        Me.Title = title
        Me.Content = content
        Me.CreatedBy = createdBy
        Me.NotifType = notifType
        _notifDate = DateTime.Now
        _isRead = False
        _isDeleted = False
        _attachments = String.Empty
    End Sub

    ' Constructor for system notification
    Public Shared Function CreateSystemNotification(accountID As Integer?, title As String, content As String, notifType As NotificationType) As Notification
        Return New Notification(accountID, title, content, -1, notifType)
    End Function

    ' Mark as read
    Public Sub MarkAsRead()
        If _isDeleted Then
            Throw New InvalidOperationException("Cannot mark deleted notification as read")
        End If
        _isRead = True
    End Sub

    ' Mark as unread
    Public Sub MarkAsUnread()
        If _isDeleted Then
            Throw New InvalidOperationException("Cannot mark deleted notification as unread")
        End If
        _isRead = False
    End Sub

    ' Soft delete
    Public Sub Delete()
        If _isDeleted Then
            Throw New InvalidOperationException("Notification is already deleted")
        End If
        _isDeleted = True
    End Sub

    ' Restore
    Public Sub Restore()
        If Not _isDeleted Then
            Throw New InvalidOperationException("Notification is not deleted")
        End If
        _isDeleted = False
    End Sub

    Public Overrides Function ToString() As String
        Dim readStatus = If(_isRead, "Read", "Unread")
        Dim deleteStatus = If(_isDeleted, " [DELETED]", "")
        Return $"[{NotificationTypeDescription}] {Title} - {readStatus} ({NotifDate:yyyy-MM-dd HH:mm}){deleteStatus}"
    End Function
End Class