Imports System.Linq
Public Class BookDatabase
    Private _books As Dictionary(Of Integer, Book)
    Private _bookSeries As Dictionary(Of String, Books)
    Private _nextBookID As Integer = 1

    Public Sub New()
        _books = New Dictionary(Of Integer, Book)()
        _bookSeries = New Dictionary(Of String, Books)()
    End Sub

    ' Book Management
    Public Function AddBook(title As String, author As String, isbn As String, Optional seriesTitle As String = "General", Optional details As String = "") As Book
        Dim book As New Book(_nextBookID, title, author, isbn, details)
        _books.Add(_nextBookID, book)

        ' Add to series
        If Not _bookSeries.ContainsKey(seriesTitle) Then
            _bookSeries.Add(seriesTitle, New Books(seriesTitle))
        End If
        _bookSeries(seriesTitle).AddBook(book)

        _nextBookID += 1
        Return book
    End Function

    Public Function GetBook(bookID As Integer) As Book
        If _books.ContainsKey(bookID) Then
            Return _books(bookID)
        End If
        Return Nothing
    End Function

    Public Function RemoveBook(bookID As Integer) As Boolean
        Dim book = GetBook(bookID)
        If book IsNot Nothing AndAlso book.IsAvailable Then
            _books.Remove(bookID)
            ' Remove from series as well
            For Each series In _bookSeries.Values
                series.RemoveBook(bookID)
            Next
            Return True
        End If
        Return False
    End Function

    Public Function GetAllBooks() As List(Of Book)
        Return _books.Values.ToList()
    End Function

    Public Function GetAvailableBooks() As List(Of Book)
        Return _books.Values.Where(Function(b) b.IsAvailable).ToList()
    End Function

    Public Function GetBorrowedBooks() As List(Of Book)
        Return _books.Values.Where(Function(b) Not b.IsAvailable).ToList()
    End Function

    Public Function GetOverdueBooks() As List(Of Book)
        Return _books.Values.Where(Function(b) b.IsOverdue).ToList()
    End Function

    Public Function SearchBooks(searchTerm As String) As List(Of Book)
        If String.IsNullOrWhiteSpace(searchTerm) Then
            Return New List(Of Book)()
        End If

        Return _books.Values.Where(Function(b) _
            b.Title.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 OrElse
            b.Author.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 OrElse
            b.ISBN.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
    End Function

    ' Series Management
    Public Function GetSeries(seriesTitle As String) As Books
        If _bookSeries.ContainsKey(seriesTitle) Then
            Return _bookSeries(seriesTitle)
        End If
        Return Nothing
    End Function

    Public Function GetAllSeries() As List(Of Books)
        Return _bookSeries.Values.ToList()
    End Function

    Public ReadOnly Property TotalBooks As Integer
        Get
            Return _books.Count
        End Get
    End Property

    Public ReadOnly Property AvailableBooksCount As Integer
        Get
            Return _bookList.Where(Function(b) b.IsAvailable).Count()
        End Get
    End Property

    Public ReadOnly Property BorrowedBooksCount As Integer
        Get
            Return _bookList.Where(Function(b) Not b.IsAvailable).Count()
        End Get
    End Property
End Class
