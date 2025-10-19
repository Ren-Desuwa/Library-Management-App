Public Class Transaction
    Public Property TransactionID As Integer
    Public Property AccountID As Integer
    Public Property CopyID As Integer
    Public Property TransactionType As String ' "Borrow", "Return", "Reserve", "Cancel"
    Public Property DateBorrowed As DateTime?
    Public Property DateDue As DateTime?
    Public Property DateReturned As DateTime?
    Public Property Fine As Decimal
    Public Property Status As String ' "Active", "Completed", "Overdue"

    Private Const BORROW_PERIOD_DAYS As Integer = 14

    ' Calculate due date (14 days from borrow date)
    Public Function CalculateDueDate() As DateTime
        If DateBorrowed.HasValue Then
            Return DateBorrowed.Value.AddDays(BORROW_PERIOD_DAYS)
        End If
        Return DateTime.Now.AddDays(BORROW_PERIOD_DAYS)
    End Function

    ' Calculate fine for overdue books (e.g., $1 per day)
    Public Function CalculateFine() As Decimal
        If Not DateDue.HasValue OrElse DateTime.Now <= DateDue.Value Then
            Return 0
        End If

        Dim overdueDays As Integer = (DateTime.Now - DateDue.Value).Days
        Return overdueDays * 1D ' $1 per day
    End Function

    ' Check if transaction is overdue
    Public Function IsOverdue() As Boolean
        Return DateDue.HasValue AndAlso DateTime.Now > DateDue.Value AndAlso Not DateReturned.HasValue
    End Function
End Class