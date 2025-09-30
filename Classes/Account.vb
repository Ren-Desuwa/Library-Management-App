Public Class Account
    Private _AccountID As Integer
    Private _Username As String
    Private _Password As String
    Private _Email As String
    Private _IsAdmin As Boolean
    Private _BorrowedBooks As List(Of Books)

    Public Property AccountID As Integer
        Get
            Return _AccountID
        End Get
        Set(value As Integer)
            _AccountID = value
        End Set
    End Property
    Public Property Username As String
        Get
            Return _Username
        End Get
        Set(value As String)
            _Username = value
        End Set
    End Property
    Public Property Password As String
        Get
            Return _Password
        End Get
        Set(value As String)
            _Password = value
        End Set
    End Property
    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            _Email = value
        End Set
    End Property
    Public Property IsAdmin As Boolean
        Get
            Return _IsAdmin
        End Get
        Set(value As Boolean)
            _IsAdmin = value
        End Set
    End Property
    Public Property BorrowedBooks As List(Of Books)
        Get
            Return _BorrowedBooks
        End Get
        Set(value As List(Of Books))
            _BorrowedBooks = value
        End Set
    End Property

    Public Sub New()
        _BorrowedBooks = New List(Of Books)()
    End Sub

End Class
