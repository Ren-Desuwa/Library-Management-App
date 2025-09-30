Imports System.Data.OleDb

Public Class AccountDatabase
    Private ReadOnly _dbConnection As DatabaseConnection

    Public Sub New(dbConnection As DatabaseConnection)
        _dbConnection = dbConnection
    End Sub

    ' Create Tables
    Public Sub CreateTables()
        Try
            Dim createAccountsTable As String = "CREATE TABLE Accounts (
                AccountID AUTOINCREMENT PRIMARY KEY,
                Username TEXT(50) NOT NULL UNIQUE,
                PasswordHash TEXT(255) NOT NULL,
                Email TEXT(100) NOT NULL UNIQUE,
                IsAdmin YESNO NOT NULL,
                CreatedDate DATETIME NOT NULL,
                LastLoginDate DATETIME
            )"

            Dim createBorrowedBooksTable As String = "CREATE TABLE BorrowedBooks (
                BorrowID AUTOINCREMENT PRIMARY KEY,
                UserID INTEGER NOT NULL,
                BookID INTEGER NOT NULL,
                BorrowDate DATETIME NOT NULL,
                ReturnDate DATETIME
            )"

            _dbConnection.ExecuteNonQuery(createAccountsTable)
            _dbConnection.ExecuteNonQuery(createBorrowedBooksTable)
        Catch ex As Exception
            Throw New Exception($"Error creating account tables: {ex.Message}", ex)
        End Try
    End Sub

    ' Create Account
    Public Function CreateAccount(username As String, password As String, email As String, isAdmin As Boolean) As Integer
        Try
            Dim passwordHash = Account.HashPassword(password)
            Dim query = "INSERT INTO Accounts (Username, PasswordHash, Email, IsAdmin, CreatedDate) VALUES (?, ?, ?, ?, ?)"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@Username", username)
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@IsAdmin", isAdmin)
                    cmd.Parameters.AddWithValue("@CreatedDate", Date.Now)

                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "SELECT @@IDENTITY"
                    Dim accountID = Convert.ToInt32(cmd.ExecuteScalar())

                    Return accountID
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw New Exception($"Error creating account: {ex.Message}", ex)
        End Try
    End Function

    ' Get Account by ID
    Public Function GetAccountByID(accountID As Integer) As Account
        Dim query As String = "SELECT * FROM Accounts WHERE AccountID = ?"

        Try
            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AccountID", accountID)

                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return MapReaderToAccount(reader)
                        End If
                    End Using
                End Using

                Return Nothing
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw New Exception($"Error getting account by ID: {ex.Message}", ex)
        End Try
    End Function

    ' Get Account by Username
    Public Function GetAccountByUsername(username As String) As Account
        Try
            Dim query = "SELECT * FROM Accounts WHERE Username = ?"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@Username", username)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return MapReaderToAccount(reader)
                        End If
                    End Using
                End Using

                Return Nothing
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw New Exception($"Error getting account by username: {ex.Message}", ex)
        End Try
    End Function

    ' Authenticate
    Public Function Authenticate(username As String, password As String) As Account
        Try
            ' Get account and verify password in single connection session
            Dim query = "SELECT * FROM Accounts WHERE Username = ?"

            _dbConnection.OpenConnection()
            Try
                Dim account As Account = Nothing

                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("?", username)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            account = MapReaderToAccount(reader)
                        End If
                    End Using
                End Using


                ' Verify password after closing reader
                If account IsNot Nothing AndAlso account.VerifyPassword(password) Then
                    ' Update last login in same connection
                    MessageBox.Show("Login successful!")
                    Dim updateQuery As String = "UPDATE Accounts SET LastLoginDate = ? WHERE AccountID = ?"
                    Using updateCmd As New OleDbCommand(updateQuery, _dbConnection.Connection)
                        ' Explicitly use OleDbType.Date
                        updateCmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now   ' Current date/time
                        updateCmd.Parameters.Add("?", OleDbType.Integer).Value = account.AccountID

                        updateCmd.ExecuteNonQuery()
                    End Using
                    MessageBox.Show("Login successful!1")
                    account.RecordLogin()
                    MessageBox.Show("Login successful!2")
                    Return account
                End If
                MessageBox.Show("Login successful!3")
                Return Nothing
            Finally
                MessageBox.Show("Login successful!4")
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw New Exception($"Error authenticating user: {ex.Message}", ex)
        End Try
    End Function

    ' Update Account
    Public Sub UpdateAccount(accountID As Integer, username As String, email As String)
        Try
            Dim query = "UPDATE Accounts SET Username = ?, Email = ? WHERE AccountID = ?"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@Username", username)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@AccountID", accountID)

                    cmd.ExecuteNonQuery()
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw New Exception($"Error updating account: {ex.Message}", ex)
        End Try
    End Sub

    ' Change Password
    Public Sub ChangePassword(accountID As Integer, newPassword As String)
        Try
            Dim passwordHash = Account.HashPassword(newPassword)
            Dim query = "UPDATE Accounts SET PasswordHash = ? WHERE AccountID = ?"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash)
                    cmd.Parameters.AddWithValue("@AccountID", accountID)

                    cmd.ExecuteNonQuery()
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw New Exception($"Error changing password: {ex.Message}", ex)
        End Try
    End Sub

    ' Delete Account
    Public Function DeleteAccount(accountID As Integer) As Boolean
        Try
            _dbConnection.OpenConnection()
            Try
                ' Check if user has borrowed books
                Dim checkQuery = "SELECT COUNT(*) FROM BorrowedBooks WHERE UserID = ? AND ReturnDate IS NULL"
                Using checkCmd As New OleDbCommand(checkQuery, _dbConnection.Connection)
                    checkCmd.Parameters.AddWithValue("@UserID", accountID)
                    Dim borrowedCount = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If borrowedCount > 0 Then
                        Return False
                    End If
                End Using

                ' Delete borrow history
                Dim deleteHistory = "DELETE FROM BorrowedBooks WHERE UserID = ?"
                Using cmd As New OleDbCommand(deleteHistory, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@UserID", accountID)
                    cmd.ExecuteNonQuery()
                End Using

                ' Delete account
                Dim deleteAnAccount = "DELETE FROM Accounts WHERE AccountID = ?"
                Using cmd As New OleDbCommand(deleteAnAccount, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AccountID", accountID)
                    cmd.ExecuteNonQuery()
                End Using

                Return True
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw New Exception($"Error deleting account: {ex.Message}", ex)
        End Try
    End Function

    ' Get All Accounts
    Public Function GetAllAccounts() As List(Of Account)
        Dim accounts As New List(Of Account)()

        Try
            Dim query = "SELECT * FROM Accounts ORDER BY Username"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            accounts.Add(MapReaderToAccount(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw New Exception($"Error getting all accounts: {ex.Message}", ex)
        End Try

        Return accounts
    End Function

    ' Get All Users
    Public Function GetAllUsers() As List(Of Account)
        Dim users As New List(Of Account)()

        Try
            Dim query = "SELECT * FROM Accounts WHERE IsAdmin = False ORDER BY Username"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            users.Add(MapReaderToAccount(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw New Exception($"Error getting all users: {ex.Message}", ex)
        End Try

        Return users
    End Function

    ' Get All Admins
    Public Function GetAllAdmins() As List(Of Account)
        Dim admins As New List(Of Account)()

        Try
            Dim query = "SELECT * FROM Accounts WHERE IsAdmin = True ORDER BY Username"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            admins.Add(MapReaderToAccount(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw New Exception($"Error getting all admins: {ex.Message}", ex)
        End Try

        Return admins
    End Function

    ' Record Borrow
    Public Sub RecordBorrow(userID As Integer, bookID As Integer)
        Try
            Dim query = "INSERT INTO BorrowedBooks (UserID, BookID, BorrowDate) VALUES (?, ?, ?)"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@BookID", bookID)
                    cmd.Parameters.AddWithValue("@BorrowDate", Date.Now)

                    cmd.ExecuteNonQuery()
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw New Exception($"Error recording borrow: {ex.Message}", ex)
        End Try
    End Sub

    ' Record Return
    Public Sub RecordReturn(userID As Integer, bookID As Integer)
        Try
            Dim query = "UPDATE BorrowedBooks SET ReturnDate = ? WHERE UserID = ? AND BookID = ? AND ReturnDate IS NULL"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@ReturnDate", Date.Now)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.Parameters.AddWithValue("@BookID", bookID)

                    cmd.ExecuteNonQuery()
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw New Exception($"Error recording return: {ex.Message}", ex)
        End Try
    End Sub

    ' Get User Borrowed Book Count
    Public Function GetUserBorrowedBookCount(userID As Integer) As Integer
        Try
            Dim query = "SELECT COUNT(*) FROM BorrowedBooks WHERE UserID = ? AND ReturnDate IS NULL"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ' Get User Borrow History
    Public Function GetUserBorrowHistory(userID As Integer) As List(Of Dictionary(Of String, Object))
        Dim history As New List(Of Dictionary(Of String, Object))()

        Try
            Dim query = "SELECT BookID, BorrowDate, ReturnDate FROM BorrowedBooks WHERE UserID = ? ORDER BY BorrowDate DESC"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@UserID", userID)

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim record As New Dictionary(Of String, Object)
                            record("BookID") = reader("BookID")
                            record("BorrowDate") = reader("BorrowDate")
                            record("ReturnDate") = If(IsDBNull(reader("ReturnDate")), Nothing, reader("ReturnDate"))
                            history.Add(record)
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            ' Return empty list on error
        End Try

        Return history
    End Function

    ' Get Account Count
    Public Function GetAccountCount() As Integer
        Try
            Dim query = "SELECT COUNT(*) FROM Accounts"
            Dim result = _dbConnection.ExecuteScalar(query)
            Return Convert.ToInt32(result)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ' Helper Method - Map Reader to Account
    Private Function MapReaderToAccount(reader As OleDbDataReader) As Account
        Dim account As New Account()

        account.AccountID = Convert.ToInt32(reader("AccountID"))
        account.Username = reader("Username").ToString()
        account.PasswordHash = reader("PasswordHash").ToString()
        account.Email = reader("Email").ToString()
        account.IsAdmin = Convert.ToBoolean(reader("IsAdmin"))
        account.CreatedDate = Convert.ToDateTime(reader("CreatedDate"))

        If Not IsDBNull(reader("LastLoginDate")) Then
            account.LastLoginDate = Convert.ToDateTime(reader("LastLoginDate"))
        End If

        Return account
    End Function
End Class