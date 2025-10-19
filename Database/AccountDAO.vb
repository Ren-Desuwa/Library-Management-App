Imports System.Data.OleDb

Public Class AccountDAO
    Private _connection As OleDbConnection

    Public Sub New(connection As OleDbConnection)
        _connection = connection
    End Sub

    ' Get account by ID
    Public Function GetById(accountID As Integer) As Account
        Dim query As String = "SELECT * FROM Account WHERE AccountID = @id"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@id", accountID)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Return MapToAccount(reader)
                End If
            End Using
        End Using
        Return Nothing
    End Function

    ' Get account by username
    Public Function GetByUsername(username As String) As Account
        Dim query As String = "SELECT * FROM Account WHERE Username = @username"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@username", username)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Return MapToAccount(reader)
                End If
            End Using
        End Using
        Return Nothing
    End Function

    ' Insert new account
    Public Function Insert(account As Account) As Integer
        Dim query As String = "INSERT INTO Account (Username, PasswordHash, Role, Name, Email, DateCreated, IsActive) " &
                              "VALUES (@username, @password, @role, @name, @email, @date, @active)"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@username", account.Username)
            cmd.Parameters.AddWithValue("@password", account.PasswordHash)
            cmd.Parameters.AddWithValue("@role", account.Role)
            cmd.Parameters.AddWithValue("@name", account.Name)
            cmd.Parameters.AddWithValue("@email", account.Email)
            cmd.Parameters.AddWithValue("@date", account.DateCreated)
            cmd.Parameters.AddWithValue("@active", account.IsActive)
            cmd.ExecuteNonQuery()
        End Using

        ' Get the inserted ID
        Dim idQuery As String = "SELECT @@IDENTITY"
        Using cmd As New OleDbCommand(idQuery, _connection)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    ' Update existing account
    Public Function Update(account As Account) As Boolean
        Dim query As String = "UPDATE Account SET Username = @username, PasswordHash = @password, " &
                              "Role = @role, Name = @name, Email = @email, IsActive = @active " &
                              "WHERE AccountID = @id"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@username", account.Username)
            cmd.Parameters.AddWithValue("@password", account.PasswordHash)
            cmd.Parameters.AddWithValue("@role", account.Role)
            cmd.Parameters.AddWithValue("@name", account.Name)
            cmd.Parameters.AddWithValue("@email", account.Email)
            cmd.Parameters.AddWithValue("@active", account.IsActive)
            cmd.Parameters.AddWithValue("@id", account.AccountID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Delete account
    Public Function Delete(accountID As Integer) As Boolean
        Dim query As String = "DELETE FROM Account WHERE AccountID = @id"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@id", accountID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Get all accounts
    Public Function GetAll() As List(Of Account)
        Dim accounts As New List(Of Account)
        Dim query As String = "SELECT * FROM Account ORDER BY Username"
        Using cmd As New OleDbCommand(query, _connection)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    accounts.Add(MapToAccount(reader))
                End While
            End Using
        End Using
        Return accounts
    End Function

    ' Helper method to map DataReader to Account object
    Private Function MapToAccount(reader As OleDbDataReader) As Account
        Return New Account With {
            .AccountID = Convert.ToInt32(reader("AccountID")),
            .Username = reader("Username").ToString(),
            .PasswordHash = reader("PasswordHash").ToString(),
            .Role = reader("Role").ToString(),
            .Name = reader("Name").ToString(),
            .Email = reader("Email").ToString(),
            .DateCreated = Convert.ToDateTime(reader("DateCreated")),
            .IsActive = Convert.ToBoolean(reader("IsActive"))
        }
    End Function
End Class