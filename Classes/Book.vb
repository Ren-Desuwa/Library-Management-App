Public Class Book
    Public Property BookID As Integer
    Public Property Title As String
    Public Property Author As String
    Public Property Genre As String
    Public Property ISBN As String
    Public Property Publisher As String
    Public Property YearPublished As Integer
    Public Property Description As String
    Public Property TotalCopies As Integer
    Public Property AvailableCopies As Integer

    ' Get formatted book information
    Public Function GetFullTitle() As String
        Return $"{Title} by {Author} ({YearPublished})"
    End Function

    ' Check if book is available for borrowing
    Public Function IsAvailable() As Boolean
        Return AvailableCopies > 0
    End Function
End Class