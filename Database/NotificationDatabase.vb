Imports System.Data.OleDb

Public Class NotificationDatabase
    Private ReadOnly _dbConnection As DatabaseConnection

    Public Sub New(dbConnection As DatabaseConnection)
        _dbConnection = dbConnection
    End Sub

    ' Create Tables
    Public Sub CreateTables()
        Try
            Dim createNotificationsTable As String = "CREATE TABLE Notifications (
                NotificationID AUTOINCREMENT PRIMARY KEY,
                AccountID INTEGER,
                Title TEXT(100) NOT NULL,
                Content MEMO NOT NULL,
                CreatedBy INTEGER,
                NotifType INTEGER NOT NULL,
                Attachments TEXT(255),
                NotifDate DATETIME NOT NULL,
                IsRead BIT NOT NULL DEFAULT 0,
                IsDeleted BIT NOT NULL DEFAULT 0
            )"

            _dbConnection.ExecuteNonQuery(createNotificationsTable)
            DatabaseLogger.LogOperation("NotificationDatabase.CreateTables", "Notifications table created")
        Catch ex As Exception
            DatabaseLogger.LogError("NotificationDatabase.CreateTables", ex)
            Throw New Exception($"Error creating notifications table: {ex.Message}", ex)
        End Try
    End Sub

    ' Create Notification
    Public Function CreateNotification(accountID As Integer?, title As String, content As String, createdBy As Integer?, notifType As NotificationType, Optional attachments As String = "") As Integer
        Try
            Dim query = "INSERT INTO Notifications (AccountID, Title, Content, CreatedBy, NotifType, Attachments, NotifDate, IsRead, IsDeleted) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    DatabaseHelper.AddParameter(cmd, "@AccountID", accountID)
                    cmd.Parameters.AddWithValue("@Title", title)
                    cmd.Parameters.AddWithValue("@Content", content)
                    DatabaseHelper.AddParameter(cmd, "@CreatedBy", createdBy)
                    cmd.Parameters.AddWithValue("@NotifType", CInt(notifType))
                    cmd.Parameters.AddWithValue("@Attachments", If(attachments, String.Empty))
                    cmd.Parameters.AddWithValue("@NotifDate", DateTime.Now)
                    cmd.Parameters.AddWithValue("@IsRead", False)
                    cmd.Parameters.AddWithValue("@IsDeleted", False)

                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "SELECT @@IDENTITY"
                    Dim notificationID = Convert.ToInt32(cmd.ExecuteScalar())

                    DatabaseLogger.LogOperation("NotificationDatabase.CreateNotification", $"Created notification #{notificationID}")
                    Return notificationID
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("NotificationDatabase.CreateNotification", ex)
            Throw New Exception($"Error creating notification: {ex.Message}", ex)
        End Try
    End Function

    ' Get Notification by ID
    Public Function GetNotificationByID(notificationID As Integer) As Notification
        Try
            Dim query = "SELECT * FROM Notifications WHERE NotificationID = ? AND IsDeleted = 0"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@NotificationID", notificationID)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return MapReaderToNotification(reader)
                        End If
                    End Using
                End Using

                Return Nothing
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("NotificationDatabase.GetNotificationByID", ex)
            Throw New Exception($"Error getting notification by ID: {ex.Message}", ex)
        End Try
    End Function

    ' Get All Notifications
    Public Function GetAllNotifications(Optional includeDeleted As Boolean = False) As List(Of Notification)
        Dim notifications As New List(Of Notification)()

        Try
            Dim query = If(includeDeleted,
                "SELECT * FROM Notifications ORDER BY NotifDate DESC",
                "SELECT * FROM Notifications WHERE IsDeleted = 0 ORDER BY NotifDate DESC")

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            notifications.Add(MapReaderToNotification(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("NotificationDatabase.GetAllNotifications", ex)
            Throw New Exception($"Error getting all notifications: {ex.Message}", ex)
        End Try

        Return notifications
    End Function

    ' Get Notifications by Account
    Public Function GetNotificationsByAccount(accountID As Integer, Optional includeRead As Boolean = True) As List(Of Notification)
        Dim notifications As New List(Of Notification)()

        Try
            Dim query = If(includeRead,
                "SELECT * FROM Notifications WHERE (AccountID = ? OR AccountID IS NULL) AND IsDeleted = 0 ORDER BY NotifDate DESC",
                "SELECT * FROM Notifications WHERE (AccountID = ? OR AccountID IS NULL) AND IsRead = 0 AND IsDeleted = 0 ORDER BY NotifDate DESC")

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AccountID", accountID)

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            notifications.Add(MapReaderToNotification(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("NotificationDatabase.GetNotificationsByAccount", ex)
            Throw New Exception($"Error getting notifications by account: {ex.Message}", ex)
        End Try

        Return notifications
    End Function

    ' Get Unread Notifications Count
    Public Function GetUnreadNotificationCount(accountID As Integer) As Integer
        Try
            Dim query = "SELECT COUNT(*) FROM Notifications WHERE (AccountID = ? OR AccountID IS NULL) AND IsRead = 0 AND IsDeleted = 0"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AccountID", accountID)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("NotificationDatabase.GetUnreadNotificationCount", ex)
            Return 0
        End Try
    End Function

    ' Mark Notification as Read
    Public Sub MarkAsRead(notificationID As Integer)
        Try
            Dim query = "UPDATE Notifications SET IsRead = 1 WHERE NotificationID = ?"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@NotificationID", notificationID)
                    cmd.ExecuteNonQuery()

                    DatabaseLogger.LogOperation("NotificationDatabase.MarkAsRead", $"Marked notification #{notificationID} as read")
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("NotificationDatabase.MarkAsRead", ex)
            Throw New Exception($"Error marking notification as read: {ex.Message}", ex)
        End Try
    End Sub

    ' Mark All as Read
    Public Sub MarkAllAsRead(accountID As Integer)
        Try
            Dim query = "UPDATE Notifications SET IsRead = 1 WHERE (AccountID = ? OR AccountID IS NULL) AND IsRead = 0"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AccountID", accountID)
                    cmd.ExecuteNonQuery()

                    DatabaseLogger.LogOperation("NotificationDatabase.MarkAllAsRead", $"Marked all notifications for account #{accountID} as read")
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("NotificationDatabase.MarkAllAsRead", ex)
            Throw New Exception($"Error marking all notifications as read: {ex.Message}", ex)
        End Try
    End Sub

    ' Soft Delete Notification
    Public Sub DeleteNotification(notificationID As Integer)
        Try
            Dim query = "UPDATE Notifications SET IsDeleted = 1 WHERE NotificationID = ?"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@NotificationID", notificationID)
                    cmd.ExecuteNonQuery()

                    DatabaseLogger.LogOperation("NotificationDatabase.DeleteNotification", $"Deleted notification #{notificationID}")
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("NotificationDatabase.DeleteNotification", ex)
            Throw New Exception($"Error deleting notification: {ex.Message}", ex)
        End Try
    End Sub

    ' Delete Old Notifications (cleanup)
    Public Sub DeleteOldNotifications(daysOld As Integer)
        Try
            Dim cutoffDate = DateTime.Now.AddDays(-daysOld)
            Dim query = "UPDATE Notifications SET IsDeleted = 1 WHERE NotifDate < ? AND IsRead = 1"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@CutoffDate", cutoffDate)
                    Dim rowsAffected = cmd.ExecuteNonQuery()

                    DatabaseLogger.LogOperation("NotificationDatabase.DeleteOldNotifications", $"Deleted {rowsAffected} old notifications")
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("NotificationDatabase.DeleteOldNotifications", ex)
            Throw New Exception($"Error deleting old notifications: {ex.Message}", ex)
        End Try
    End Sub

    ' Get Notification Count
    Public Function GetNotificationCount(Optional includeDeleted As Boolean = False) As Integer
        Try
            Dim query = If(includeDeleted,
                "SELECT COUNT(*) FROM Notifications",
                "SELECT COUNT(*) FROM Notifications WHERE IsDeleted = 0")

            Dim result = _dbConnection.ExecuteScalar(query)
            Return Convert.ToInt32(result)
        Catch ex As Exception
            DatabaseLogger.LogError("NotificationDatabase.GetNotificationCount", ex)
            Return 0
        End Try
    End Function

    ' Helper Method - Map Reader to Notification
    Private Function MapReaderToNotification(reader As OleDbDataReader) As Notification
        Dim accountID = DatabaseHelper.GetSafeNullableValue(Of Integer)(reader, "AccountID")
        Dim title = reader("Title").ToString()
        Dim content = reader("Content").ToString()
        Dim createdBy = DatabaseHelper.GetSafeNullableValue(Of Integer)(reader, "CreatedBy")
        Dim notifType = CType(Convert.ToInt32(reader("NotifType")), NotificationType)

        Dim notification As New Notification(accountID, title, content, createdBy, notifType)
        notification.NotificationID = Convert.ToInt32(reader("NotificationID"))
        notification.Attachments = DatabaseHelper.GetSafeValue(reader, "Attachments", String.Empty)
        notification.NotifDate = Convert.ToDateTime(reader("NotifDate"))
        notification.IsRead = Convert.ToBoolean(reader("IsRead"))
        notification.IsDeleted = Convert.ToBoolean(reader("IsDeleted"))

        Return notification
    End Function
End Class