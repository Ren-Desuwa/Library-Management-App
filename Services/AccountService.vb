Public Class AccountService
    Private _db As LibraryDatabase

    Public Sub New()
        _db = LibraryDatabase.Instance
    End Sub

    ' Register a new account
    Public Function Register(username As String, password As String, name As String, email As String, role As String) As (Success As Boolean, Message As String)
        Try
            ' Check if username already exists
            Dim existing = _db.AccountDAO.GetByUsername(username)
            If existing IsNot Nothing Then
                Return (False, "Username already exists.")
            End If

            ' Create new account
            Dim account As New Account With {
                .Username = username,
                .PasswordHash = Account.HashPassword(password),
                .Name = name,
                .Email = email,
                .Role = role
            }

            Dim accountID = _db.AccountDAO.Insert(account)

            ' Log the action
            Dim log As Log = Log.RecordAction(accountID, "ACCOUNT_CREATED", $"New account registered: {username}")
            _db.LogDAO.Insert(log)

            Return (True, "Account created successfully!")
        Catch ex As Exception
            Return (False, $"Error creating account: {ex.Message}")
        End Try
    End Function

    ' Login
    Public Function Login(username As String, password As String) As (Success As Boolean, Account As Account, Message As String)
        Try
            Dim account = _db.AccountDAO.GetByUsername(username)

            If account Is Nothing Then
                Return (False, Nothing, "Invalid username or password.")
            End If

            If Not account.IsActive Then
                Return (False, Nothing, "Account is inactive.")
            End If

            If Not account.VerifyPassword(password) Then
                ' Log failed attempt
                Dim failLog As Log = Log.RecordAction(account.AccountID, "LOGIN_FAILED", "Invalid password attempt", "Warning")
                _db.LogDAO.Insert(failLog)
                Return (False, Nothing, "Invalid username or password.")
            End If

            ' Log successful login
            Dim logs As Log = Log.RecordAction(account.AccountID, "LOGIN_SUCCESS", $"User {username} logged in")
            _db.LogDAO.Insert(logs)

            Return (True, account, "Login successful!")
        Catch ex As Exception
            Return (False, Nothing, $"Error during login: {ex.Message}")
        End Try
    End Function

    ' Change password
    Public Function ChangePassword(accountID As Integer, oldPassword As String, newPassword As String) As (Success As Boolean, Message As String)
        Try
            Dim account = _db.AccountDAO.GetById(accountID)
            If account Is Nothing Then
                Return (False, "Account not found.")
            End If

            If Not account.VerifyPassword(oldPassword) Then
                Return (False, "Current password is incorrect.")
            End If

            account.PasswordHash = Account.HashPassword(newPassword)
            _db.AccountDAO.Update(account)

            ' Log the action
            Dim logs = Log.RecordAction(accountID, "PASSWORD_CHANGED", "User changed password")
            _db.LogDAO.Insert(logs)

            Return (True, "Password changed successfully!")
        Catch ex As Exception
            Return (False, $"Error changing password: {ex.Message}")
        End Try
    End Function

    ' Get unread notifications
    Public Function GetUnreadNotifications(accountID As Integer) As List(Of Notification)
        Return _db.NotificationDAO.GetUnreadByAccountID(accountID)
    End Function
End Class