Public Enum BorrowStatus
    Active = 0      ' Currently borrowed
    Returned = 1    ' Returned on time
    Overdue = 2     ' Currently overdue
    ReturnedLate = 3 ' Was returned but was overdue
End Enum

Public Class BorrowedBook
    Private _borrowID As Integer
    Private _userID As Integer
    Private _bookID As Integer
    Private _borrowDate As DateTime
    Private _dueDate As DateTime
    Private _returnDate As DateTime?
    Private _status As String

    Public Property BorrowID As Integer
        Get
            Return _borrowID
        End Get
        Friend Set(value As Integer)
            _borrowID = value
        End Set
    End Property

    Public Property UserID As Integer
        Get
            Return _userID
        End Get
        Friend Set(value As Integer)
            If value <= 0 Then
                Throw New ArgumentException("UserID must be positive")
            End If
            _userID = value
        End Set
    End Property

    Public Property BookID As Integer
        Get
            Return _bookID
        End Get
        Friend Set(value As Integer)
            If value <= 0 Then
                Throw New ArgumentException("BookID must be positive")
            End If
            _bookID = value
        End Set
    End Property

    Public Property BorrowDate As DateTime
        Get
            Return _borrowDate
        End Get
        Friend Set(value As DateTime)
            _borrowDate = value
        End Set
    End Property

    Public Property DueDate As DateTime
        Get
            Return _dueDate
        End Get
        Friend Set(value As DateTime)
            _dueDate = value
        End Set
    End Property

    Public Property ReturnDate As DateTime?
        Get
            Return _returnDate
        End Get
        Friend Set(value As DateTime?)
            _returnDate = value
        End Set
    End Property

    Public Property Status As String
        Get
            Return _status
        End Get
        Friend Set(value As String)
            _status = value
        End Set
    End Property

    Public ReadOnly Property IsReturned As Boolean
        Get
            Return _returnDate.HasValue
        End Get
    End Property

    Public ReadOnly Property IsOverdue As Boolean
        Get
            If _returnDate.HasValue Then
                ' Already returned - check if it was late
                Return _returnDate.Value > _dueDate
            Else
                ' Still borrowed - check if past due date
                Return DateTime.Now > _dueDate
            End If
        End Get
    End Property

    Public ReadOnly Property DaysOverdue As Integer
        Get
            If Not IsOverdue Then Return 0

            Dim compareDate As DateTime
            If _returnDate.HasValue Then
                compareDate = _returnDate.Value
            Else
                compareDate = DateTime.Now
            End If

            Dim overdueDays = (compareDate - _dueDate).Days
            Return Math.Max(0, overdueDays)
        End Get
    End Property

    Public ReadOnly Property StatusDescription As String
        Get
            If _returnDate.HasValue Then
                If IsOverdue Then
                    Return $"Returned Late ({DaysOverdue} days overdue)"
                Else
                    Return "Returned On Time"
                End If
            Else
                If IsOverdue Then
                    Return $"Overdue ({DaysOverdue} days)"
                Else
                    Return "Active"
                End If
            End If
        End Get
    End Property

    Public Sub New()
    End Sub

    Public Sub New(userID As Integer, bookID As Integer, borrowDate As DateTime, dueDate As DateTime)
        If userID <= 0 Then Throw New ArgumentException("UserID must be positive")
        If bookID <= 0 Then Throw New ArgumentException("BookID must be positive")
        If dueDate <= borrowDate Then Throw New ArgumentException("Due date must be after borrow date")

        _userID = userID
        _bookID = bookID
        _borrowDate = borrowDate
        _dueDate = dueDate
        _returnDate = Nothing
        _status = "Active"
    End Sub

    Public Sub MarkAsReturned()
        If _returnDate.HasValue Then
            Throw New InvalidOperationException("Book is already marked as returned")
        End If

        _returnDate = DateTime.Now

        If IsOverdue Then
            _status = "Returned Late"
        Else
            _status = "Returned On Time"
        End If
    End Sub

    Public Sub ExtendDueDate(newDueDate As DateTime)
        If _returnDate.HasValue Then
            Throw New InvalidOperationException("Cannot extend due date for returned book")
        End If

        If newDueDate <= DateTime.Now Then
            Throw New ArgumentException("New due date must be in the future")
        End If

        _dueDate = newDueDate
    End Sub

    Public Overrides Function ToString() As String
        Return $"Borrow #{BorrowID}: User {UserID} - Book {BookID} ({StatusDescription})"
    End Function
End Class
