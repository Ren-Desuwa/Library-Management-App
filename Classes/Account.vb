Imports System.Security.Cryptography
Imports System.Text

Public Class Account
    Public Property AccountID As Integer
    Public Property Username As String
    Public Property PasswordHash As String
    Public Property Role As String ' "Admin", "Librarian", "Member"
    Public Property Name As String
    Public Property Email As String
    Public Property DateCreated As DateTime
    Public Property IsActive As Boolean

    Public Sub New()
        DateCreated = DateTime.Now
        IsActive = True
    End Sub

    ' Hash password using SHA256
    Public Shared Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    ' Verify password against stored hash
    Public Function VerifyPassword(password As String) As Boolean
        Return HashPassword(password) = Me.PasswordHash
    End Function

    ' Check if account has admin privileges
    Public Function IsAdmin() As Boolean
        Return Role.Equals("Admin", StringComparison.OrdinalIgnoreCase)
    End Function
End Class