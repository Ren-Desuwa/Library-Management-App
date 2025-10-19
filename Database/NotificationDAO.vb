Imports System.Data.OleDb

Public Class NotificationDAO
    Private _connection As OleDbConnection

    Public Sub New(connection As OleDbConnection)
        _connection = connection
    End Sub

    Public Function Insert(notification As Notification) As Integer
        Dim query As String = "INSERT INTO Notification (AccountID, TransactionID, Message, DateSent, IsRead, NotificationType) " &
                              "VALUES (@accountId, @transactionId, @message, @date, @read, @type)"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@accountId", notification.AccountID)
            cmd.Parameters.AddWithValue("@transactionId", If(notification.TransactionID.HasValue, CObj(notification.TransactionID.Value), DBNull.Value))
            cmd.Parameters.AddWithValue("@message", notification.Message)
            cmd.Parameters.AddWithValue("@date", notification.DateSent)
            cmd.Parameters.AddWithValue("@read", notification.IsRead)
            cmd.Parameters.AddWithValue("@type", notification.NotificationType)
            cmd.ExecuteNonQuery()
        End Using

        Using cmd As New OleDbCommand("SELECT @@IDENTITY", _connection)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Public Function GetUnreadByAccountID(accountID As Integer) As List(Of Notification)
        Dim notifications As New List(Of Notification)
        Dim query As String = "SELECT * FROM Notification WHERE AccountID = @accountId AND IsRead = False ORDER BY DateSent DESC"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@accountId", accountID)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    notifications.Add(MapToNotification(reader))
                End While
            End Using
        End Using
        Return notifications
    End Function

    Public Function MarkAsRead(notificationID As Integer) As Boolean
        Dim query As String = "UPDATE Notification SET IsRead = True WHERE NotificationID = @id"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@id", notificationID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    Private Function MapToNotification(reader As OleDbDataReader) As Notification
        Return New Notification With {
            .NotificationID = Convert.ToInt32(reader("NotificationID")),
            .AccountID = Convert.ToInt32(reader("AccountID")),
            .TransactionID = If(IsDBNull(reader("TransactionID")), Nothing, Convert.ToInt32(reader("TransactionID"))),
            .Message = reader("Message").ToString(),
            .DateSent = Convert.ToDateTime(reader("DateSent")),
            .IsRead = Convert.ToBoolean(reader("IsRead")),
            .NotificationType = reader("NotificationType").ToString()
        }
    End Function
End Class