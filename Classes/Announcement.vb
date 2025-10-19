Public Class Announcement
    Private _announcementID As Integer
    Private _title As String
    Private _message As String
    Private _postedBy As Integer
    Private _postedDate As DateTime
    Private _isDeleted As Boolean

    Public Property AnnouncementID As Integer
        Get
            Return _announcementID
        End Get
        Friend Set(value As Integer)
            _announcementID = value
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
            If value.Trim().Length > 60 Then
                Throw New ArgumentException("Title cannot exceed 60 characters")
            End If
            _title = value.Trim()
        End Set
    End Property

    Public Property Message As String
        Get
            Return _message
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Message cannot be empty")
            End If
            _message = value.Trim()
        End Set
    End Property

    Public Property PostedBy As Integer
        Get
            Return _postedBy
        End Get
        Friend Set(value As Integer)
            If value <= 0 Then
                Throw New ArgumentException("PostedBy must be a valid AccountID")
            End If
            _postedBy = value
        End Set
    End Property

    Public Property PostedDate As DateTime
        Get
            Return _postedDate
        End Get
        Friend Set(value As DateTime)
            _postedDate = value
        End Set
    End Property

    Public Property IsDeleted As Boolean
        Get
            Return _isDeleted
        End Get
        Friend Set(value As Boolean)
            _isDeleted = value
        End Set
    End Property

    ' Constructor
    Public Sub New()
    End Sub

    Public Sub New(title As String, message As String, postedBy As Integer)
        Me.Title = title
        Me.Message = message
        Me.PostedBy = postedBy
        _postedDate = DateTime.Now
        _isDeleted = False
    End Sub

    ' Edit announcement
    Public Sub Edit(newTitle As String, newMessage As String)
        If _isDeleted Then
            Throw New InvalidOperationException("Cannot edit a deleted announcement")
        End If
        Me.Title = newTitle
        Me.Message = newMessage
    End Sub

    ' Soft delete
    Public Sub Delete()
        If _isDeleted Then
            Throw New InvalidOperationException("Announcement is already deleted")
        End If
        _isDeleted = True
    End Sub

    ' Restore deleted announcement
    Public Sub Restore()
        If Not _isDeleted Then
            Throw New InvalidOperationException("Announcement is not deleted")
        End If
        _isDeleted = False
    End Sub

    Public Overrides Function ToString() As String
        Dim status = If(_isDeleted, " [DELETED]", "")
        Return $"{Title} - Posted on {PostedDate:yyyy-MM-dd}{status}"
    End Function
End Class