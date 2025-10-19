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
    Public Property NotificationID As Integer
    Public Property AccountID As Integer
    Public Property TransactionID As Integer?
    Public Property Message As String
    Public Property DateSent As DateTime
    Public Property IsRead As Boolean
    Public Property NotificationType As String ' "DueReminder", "Overdue", "Reserved", "General"

    Public Sub New()
        DateSent = DateTime.Now
        IsRead = False
    End Sub

    ' Mark notification as read
    Public Sub MarkAsRead()
        IsRead = True
    End Sub

    ' Create a due reminder notification
    Public Shared Function CreateDueReminder(accountID As Integer, transactionID As Integer, dueDate As DateTime) As Notification
        Return New Notification With {
            .AccountID = accountID,
            .TransactionID = transactionID,
            .Message = $"Reminder: Your book is due on {dueDate:MMM dd, yyyy}",
            .NotificationType = "DueReminder"
        }
    End Function
End Class