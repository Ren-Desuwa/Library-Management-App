Imports System.Linq
Public Class Books
    Private _seriesTitle As String
    Private _bookList As List(Of Book)

    Public Property SeriesTitle As String
        Get
            Return _seriesTitle
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Series title cannot be empty")
            End If
            _seriesTitle = value.Trim()
        End Set
    End Property

    Public ReadOnly Property BookCount As Integer
        Get
            Return _bookList.Count
        End Get
    End Property

    Public ReadOnly Property AvailableCount As Integer
        Get
            Return _bookList.Where(Function(b) b.IsAvailable).Count()
        End Get
    End Property

    Public ReadOnly Property BorrowedCount As Integer
        Get
            Return _bookList.Where(Function(b) Not b.IsAvailable).Count()
        End Get
    End Property

    ' Constructor
    Public Sub New(seriesTitle As String)
        Me.SeriesTitle = seriesTitle
        _bookList = New List(Of Book)()
    End Sub

    ' Add book with duplicate checking
    Public Sub AddBook(book As Book)
        If book Is Nothing Then
            Throw New ArgumentNullException(NameOf(book))
        End If

        If _bookList.Any(Function(b) b.BookID = book.BookID) Then
            Throw New InvalidOperationException($"Book with ID {book.BookID} already exists in series")
        End If

        _bookList.Add(book)
    End Sub

    ' Remove book
    Public Function RemoveBook(bookID As Integer) As Boolean
        Dim book = GetBookByID(bookID)
        If book IsNot Nothing Then
            If Not book.IsAvailable Then
                Throw New InvalidOperationException($"Cannot remove book '{book.Title}' - it is currently borrowed")
            End If
            Return _bookList.Remove(book)
        End If
        Return False
    End Function

    ' Get book by ID
    Public Function GetBookByID(bookID As Integer) As Book
        Return _bookList.FirstOrDefault(Function(b) b.BookID = bookID)
    End Function

    ' Get all books
    Public Function GetAllBooks() As List(Of Book)
        Return New List(Of Book)(_bookList) ' Return a copy
    End Function

    ' Get available books
    Public Function GetAvailableBooks() As List(Of Book)
        Return _bookList.Where(Function(b) b.IsAvailable).ToList()
    End Function

    ' Get borrowed books
    Public Function GetBorrowedBooks() As List(Of Book)
        Return _bookList.Where(Function(b) Not b.IsAvailable).ToList()
    End Function

    ' Get overdue books
    Public Function GetOverdueBooks() As List(Of Book)
        Return _bookList.Where(Function(b) b.IsOverdue).ToList()
    End Function

    ' Search books by title
    Public Function SearchByTitle(searchTerm As String) As List(Of Book)
        If String.IsNullOrWhiteSpace(searchTerm) Then
            Return New List(Of Book)()
        End If

        Return _bookList.Where(Function(b) b.Title.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
    End Function

    ' Search books by author
    Public Function SearchByAuthor(searchTerm As String) As List(Of Book)
        If String.IsNullOrWhiteSpace(searchTerm) Then
            Return New List(Of Book)()
        End If

        Return _bookList.Where(Function(b) b.Author.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
    End Function

    ' Get books borrowed by specific member
    Public Function GetBooksBorrowedByMember(memberID As Integer) As List(Of Book)
        Return _bookList.Where(Function(b) b.BorrowedBy.HasValue AndAlso b.BorrowedBy.Value = memberID).ToList()
    End Function

    Public Overrides Function ToString() As String
        Return $"{SeriesTitle} ({BookCount} books, {AvailableCount} available)"
    End Function
End Class