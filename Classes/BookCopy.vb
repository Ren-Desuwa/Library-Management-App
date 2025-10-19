Public Class BookCopy
    Public Property CopyID As Integer
    Public Property BookID As Integer
    Public Property Condition As String ' "Excellent", "Good", "Fair", "Poor"
    Public Property Status As String ' "Available", "Borrowed", "Reserved", "Maintenance"
    Public Property ShelfLocation As String
    Public Property DateAdded As DateTime
    Public Property LastUpdated As DateTime

    Public Sub New()
        DateAdded = DateTime.Now
        LastUpdated = DateTime.Now
        Status = "Available"
        Condition = "Good"
    End Sub

    ' Check if copy can be borrowed
    Public Function CanBeBorrowed() As Boolean
        Return Status = "Available" OrElse Status = "Reserved"
    End Function

    ' Update copy status
    Public Sub UpdateStatus(newStatus As String)
        Status = newStatus
        LastUpdated = DateTime.Now
    End Sub
End Class