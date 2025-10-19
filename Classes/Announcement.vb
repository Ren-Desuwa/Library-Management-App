Public Class Announcement
    Public Property AnnouncementID As Integer
    Public Property AdminID As Integer
    Public Property Title As String
    Public Property Message As String
    Public Property DatePosted As DateTime
    Public Property ExpiryDate As DateTime?
    Public Property Priority As String ' "High", "Normal", "Low"
    Public Property IsActive As Boolean

    Public Sub New()
        DatePosted = DateTime.Now
        Priority = "Normal"
        IsActive = True
    End Sub

    ' Check if announcement is still valid
    Public Function IsValid() As Boolean
        If Not IsActive Then Return False
        If ExpiryDate.HasValue AndAlso DateTime.Now > ExpiryDate.Value Then Return False
        Return True
    End Function
End Class