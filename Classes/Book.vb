Public Class Book
    Private _bookID As Integer
    Private _title As String
    Private _author As String
    Private _isbn As String
    Private _details As String
    Private _seriesTitle As String
    Private _createdDate As DateTime
    Private _recentBorrowHistory As List(Of Integer) ' List of BorrowID (max 5)

    Public Property BookID As Integer
        Get
            Return _bookID
        End Get
        Friend Set(value As Integer)
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

    Public Property Details As String
        Get
            Return _details
        End Get
        Set(value As String)
            _details = If(value, String.Empty)
        End Set
    End Property

    Public Property SeriesTitle As String
        Get
            Return _seriesTitle
        End Get
        Set(value As String)
            _seriesTitle = If(value, "General").Trim()
        End Set
    End Property

    Public Property CreatedDate As DateTime
        Get
            Return _createdDate
        End Get
        Friend Set(value As DateTime)
            _createdDate = value
        End Set
    End Property

    Public ReadOnly Property RecentBorrowHistory As List(Of Integer)
        Get
            Return New List(Of Integer)(_recentBorrowHistory)
        End Get
    End Property

    ' Constructor
    Public Sub New()
        _recentBorrowHistory = New List(Of Integer)()
        _seriesTitle = "General"
        _details = String.Empty
    End Sub

    Public Sub New(bookID As Integer, title As String, author As String, isbn As String, Optional seriesTitle As String = "General", Optional details As String = "")
        If bookID <= 0 Then
            Throw New ArgumentException("BookID must be positive")
        End If

        _bookID = bookID
        Me.Title = title
        Me.Author = author
        Me.ISBN = isbn
        Me.SeriesTitle = seriesTitle
        Me.Details = details
        _createdDate = DateTime.Now
        _recentBorrowHistory = New List(Of Integer)()
    End Sub

    ' Add borrow record to history (keep only last 5)
    Public Sub AddBorrowRecord(borrowID As Integer)
        If borrowID <= 0 Then
            Throw New ArgumentException("BorrowID must be positive")
        End If

        _recentBorrowHistory.Insert(0, borrowID) ' Add to beginning

        ' Keep only last 5
        If _recentBorrowHistory.Count > 5 Then
            _recentBorrowHistory.RemoveAt(5)
        End If
    End Sub

    ' Load borrow history from database
    Friend Sub LoadBorrowHistory(borrowIDs As List(Of Integer))
        _recentBorrowHistory = New List(Of Integer)(borrowIDs.Take(5))
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Title} by {Author} (ISBN: {ISBN})"
    End Function
End Class