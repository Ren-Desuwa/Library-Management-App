Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System.Text

Public Class Account
    Private _accountID As Integer
    Private _username As String
    Private _passwordHash As String
    Private _email As String
    Private _isAdmin As Boolean
    Private _createdDate As Date
    Private _lastLoginDate As Date?

    ' Student info
    Private _firstName As String
    Private _lastName As String

    Public Property AccountID As Integer
        Get
            Return _accountID
        End Get
        Friend Set(value As Integer)
            _accountID = value
        End Set
    End Property

    Public Property Username As String
        Get
            Return _username
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then Throw New ArgumentException("Username cannot be empty")
            _username = value.Trim()
        End Set
    End Property

    Public Property PasswordHash As String
        Get
            Return _passwordHash
        End Get
        Friend Set(value As String)
            _passwordHash = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            If Not IsValidEmail(value) Then Throw New ArgumentException("Invalid email format")
            _email = value.Trim().ToLower()
        End Set
    End Property

    Public Property IsAdmin As Boolean
        Get
            Return _isAdmin
        End Get
        Friend Set(value As Boolean)
            _isAdmin = value
        End Set
    End Property

    Public Property CreatedDate As Date
        Get
            Return _createdDate
        End Get
        Friend Set(value As Date)
            _createdDate = value
        End Set
    End Property

    Public Property LastLoginDate As Date?
        Get
            Return _lastLoginDate
        End Get
        Friend Set(value As Date?)
            _lastLoginDate = value
        End Set
    End Property

    ' Student name
    Public Property FirstName As String
        Get
            Return _firstName
        End Get
        Friend Set(value As String)
            _firstName = value
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _lastName
        End Get
        Friend Set(value As String)
            _lastName = value
        End Set
    End Property

    Public ReadOnly Property FullName As String
        Get
            Return $"{_firstName} {_lastName}"
        End Get
    End Property

    Public ReadOnly Property AccountType As String
        Get
            Return If(_isAdmin, "Admin", "User")
        End Get
    End Property

    Public Sub New()
    End Sub

    Public Sub New(username As String, password As String, email As String, isAdmin As Boolean)
        Me.Username = username
        Me.Email = email
        Me.IsAdmin = isAdmin
        SetPassword(password)
        _createdDate = Date.Now
    End Sub

    Public Sub SetPassword(password As String)
        If String.IsNullOrWhiteSpace(password) Then Throw New ArgumentException("Password cannot be empty")
        _passwordHash = HashPassword(password)
    End Sub

    Public Function VerifyPassword(password As String) As Boolean
        Return Not String.IsNullOrWhiteSpace(password) AndAlso String.Equals(_passwordHash, HashPassword(password), StringComparison.OrdinalIgnoreCase)
    End Function

    Public Sub RecordLogin()
        _lastLoginDate = Date.Now
    End Sub

    Public Shared Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(password)
            Dim hashBytes = sha256.ComputeHash(bytes)
            Return Convert.ToBase64String(hashBytes)
        End Using
    End Function

    Private Shared Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False
        Dim regex As New Regex("^[^@\s]+@[^@\s]+\.[^@\s]+$")
        Return regex.IsMatch(email.Trim())
    End Function

    Public Overrides Function ToString() As String
        Return $"{Username} ({AccountType}) - ID: {AccountID}"
    End Function
End Class
