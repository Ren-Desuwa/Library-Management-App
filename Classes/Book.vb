Public Class Book
    Private _bookID As Integer
    Private _title As String
    Private _author As String
    Private _isbn As String
    Private _borrowedBy As Integer?
    Private _dueDate As Date?
    Private _details As String
    Private _history As List(Of String)

    ' Properties with validation
    Public Property BookID As Integer
        Get
            Return _bookID
        End Get
        Private Set(value As Integer)
            _bookID = value
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
            _title = value.Trim()
        End Set
    End Property

    Public Property Author As String
        Get
            Return _author
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Author cannot be empty")
            End If
            _author = value.Trim()
        End Set
    End Property

    Public Property ISBN As String
        Get
            Return _isbn
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("ISBN cannot be empty")
            End If
            _isbn = value.Trim()
        End Set
    End Property

    Public ReadOnly Property BorrowedBy As Integer?
        Get
            Return _borrowedBy
        End Get
    End Property

    Public ReadOnly Property DueDate As Date?
        Get
            Return _dueDate
        End Get
    End Property

    Public Property Details As String
        Get
            Return _details
        End Get
        Set(value As String)
            _details = If(value, String.Empty)
        End Set
    End Property

    Public ReadOnly Property History As List(Of String)
        Get
            Return New List(Of String)(_history) ' Return a copy to prevent external modification
        End Get
    End Property

    Public ReadOnly Property IsAvailable As Boolean
        Get
            Return Not _borrowedBy.HasValue
        End Get
    End Property

    Public ReadOnly Property IsOverdue As Boolean
        Get
            Return _dueDate.HasValue AndAlso _dueDate.Value < Date.Today
        End Get
    End Property

    ' Constructor
    Public Sub New(bookID As Integer, title As String, author As String, isbn As String, Optional details As String = "")
        If bookID <= 0 Then
            Throw New ArgumentException("BookID must be positive")
        End If

        _bookID = bookID
        Me.Title = title ' Uses property setter for validation
        Me.Author = author
        Me.ISBN = isbn
        Me.Details = details
        _history = New List(Of String)()

        AddHistoryEntry("Book created")
    End Sub

    ' Methods for borrowing and returning
    Public Sub BorrowBook(memberID As Integer, dueDate As Date)
        If Not IsAvailable Then
            Throw New InvalidOperationException($"Book '{Title}' is already borrowed")
        End If

        If dueDate <= Date.Today Then
            Throw New ArgumentException("Due date must be in the future")
        End If

        _borrowedBy = memberID
        _dueDate = dueDate
        AddHistoryEntry($"Borrowed by member {memberID} on {Date.Today:yyyy-MM-dd}, due {dueDate:yyyy-MM-dd}")
    End Sub

    Public Sub ReturnBook()
        If IsAvailable Then
            Throw New InvalidOperationException($"Book '{Title}' is not currently borrowed")
        End If

        Dim wasOverdue = IsOverdue
        Dim returnedBy = _borrowedBy.Value

        _borrowedBy = Nothing
        _dueDate = Nothing

        Dim status = If(wasOverdue, "OVERDUE", "on time")
        AddHistoryEntry($"Returned by member {returnedBy} on {Date.Today:yyyy-MM-dd} ({status})")
    End Sub

    Public Sub RenewBook(newDueDate As Date)
        If IsAvailable Then
            Throw New InvalidOperationException($"Book '{Title}' is not currently borrowed")
        End If

        If newDueDate <= Date.Today Then
            Throw New ArgumentException("New due date must be in the future")
        End If

        Dim oldDueDate = _dueDate.Value
        _dueDate = newDueDate
        AddHistoryEntry($"Renewed by member {_borrowedBy.Value} on {Date.Today:yyyy-MM-dd}, new due date {newDueDate:yyyy-MM-dd}")
    End Sub

    Private Sub AddHistoryEntry(entry As String)
        _history.Add($"{Date.Now:yyyy-MM-dd HH:mm:ss} - {entry}")
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Title} by {Author} (ID: {BookID})"
    End Function
End Class
