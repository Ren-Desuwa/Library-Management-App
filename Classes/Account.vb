Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System.Text

Public Enum Type
    Visitor = 0
    User = 1
    Librarian = 2
    Admin = 3
End Enum

Public Class Account
    Private _accountID As Integer
    Private _username As String
    Private _passwordHash As String
    Private _email As String
    Private _Type As Type
    Private _createdDate As Date
    Private _lastLoginDate As Date?

    ' Personal info
    Private _firstName As String
    Private _lastName As String
    Private _verifiedID As String
    Private _contactNo As String

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

    Public Property Type As Type
        Get
            Return _Type
        End Get
        Friend Set(value As Type)
            _Type = value
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

    Public Property FirstName As String
        Get
            Return _firstName
        End Get
        Set(value As String)
            _firstName = If(value, String.Empty).Trim()
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _lastName
        End Get
        Set(value As String)
            _lastName = If(value, String.Empty).Trim()
        End Set
    End Property

    Public Property VerifiedID As String
        Get
            Return _verifiedID
        End Get
        Set(value As String)
            _verifiedID = If(value, String.Empty).Trim()
        End Set
    End Property

    Public Property ContactNo As String
        Get
            Return _contactNo
        End Get
        Set(value As String)
            _contactNo = If(value, String.Empty).Trim()
        End Set
    End Property

    Public ReadOnly Property FullName As String
        Get
            If String.IsNullOrWhiteSpace(_firstName) AndAlso String.IsNullOrWhiteSpace(_lastName) Then
                Return _username
            End If
            Return $"{_firstName} {_lastName}".Trim()
        End Get
    End Property

    Public ReadOnly Property AccountType As String
        Get
            Select Case _Type
                Case Type.Visitor
                    Return "Visitor"
                Case Type.User
                    Return "User"
                Case Type.Librarian
                    Return "Librarian"
                Case Type.Admin
                    Return "Admin"
                Case Else
                    Return "NULL"
            End Select
        End Get
    End Property

    Public Sub New()
    End Sub

    Public Sub New(username As String, password As String, email As String, type As Type)
        Me.Username = username
        Me.Email = email
        Me.Type = type
        SetPassword(password)
        _createdDate = Date.Now
        _firstName = String.Empty
        _lastName = String.Empty
        _verifiedID = String.Empty
        _contactNo = String.Empty
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
        Return $"{Username} ({Type}) - ID: {AccountID}"
    End Function
End Class