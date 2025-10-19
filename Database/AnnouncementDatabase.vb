Imports System.Data.OleDb

Public Class AnnouncementDatabase
    Private ReadOnly _dbConnection As DatabaseConnection

    Public Sub New(dbConnection As DatabaseConnection)
        _dbConnection = dbConnection
    End Sub

    ' Create Tables
    Public Sub CreateTables()
        Try
            Dim createAnnouncementsTable As String = "CREATE TABLE Announcements (
                AnnouncementID AUTOINCREMENT PRIMARY KEY,
                Title TEXT(60) NOT NULL,
                Message MEMO NOT NULL,
                PostedBy INTEGER NOT NULL,
                PostedDate DATETIME NOT NULL,
                IsDeleted BIT NOT NULL DEFAULT 0
            )"

            _dbConnection.ExecuteNonQuery(createAnnouncementsTable)
            DatabaseLogger.LogOperation("AnnouncementDatabase.CreateTables", "Announcements table created")
        Catch ex As Exception
            DatabaseLogger.LogError("AnnouncementDatabase.CreateTables", ex)
            Throw New Exception($"Error creating announcements table: {ex.Message}", ex)
        End Try
    End Sub

    ' Create Announcement
    Public Function CreateAnnouncement(title As String, message As String, postedBy As Integer) As Integer
        Try
            Dim query = "INSERT INTO Announcements (Title, Message, PostedBy, PostedDate, IsDeleted) VALUES (?, ?, ?, ?, ?)"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@Title", title)
                    cmd.Parameters.AddWithValue("@Message", message)
                    cmd.Parameters.AddWithValue("@PostedBy", postedBy)
                    cmd.Parameters.AddWithValue("@PostedDate", DateTime.Now)
                    cmd.Parameters.AddWithValue("@IsDeleted", False)

                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "SELECT @@IDENTITY"
                    Dim announcementID = Convert.ToInt32(cmd.ExecuteScalar())

                    DatabaseLogger.LogOperation("AnnouncementDatabase.CreateAnnouncement", $"Created announcement #{announcementID}")
                    Return announcementID
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("AnnouncementDatabase.CreateAnnouncement", ex)
            Throw New Exception($"Error creating announcement: {ex.Message}", ex)
        End Try
    End Function

    ' Get Announcement by ID
    Public Function GetAnnouncementByID(announcementID As Integer) As Announcement
        Try
            Dim query = "SELECT * FROM Announcements WHERE AnnouncementID = ? AND IsDeleted = 0"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AnnouncementID", announcementID)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return MapReaderToAnnouncement(reader)
                        End If
                    End Using
                End Using

                Return Nothing
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("AnnouncementDatabase.GetAnnouncementByID", ex)
            Throw New Exception($"Error getting announcement by ID: {ex.Message}", ex)
        End Try
    End Function

    ' Get All Announcements
    Public Function GetAllAnnouncements(Optional includeDeleted As Boolean = False) As List(Of Announcement)
        Dim announcements As New List(Of Announcement)()

        Try
            Dim query = If(includeDeleted,
                "SELECT * FROM Announcements ORDER BY PostedDate DESC",
                "SELECT * FROM Announcements WHERE IsDeleted = 0 ORDER BY PostedDate DESC")

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            announcements.Add(MapReaderToAnnouncement(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("AnnouncementDatabase.GetAllAnnouncements", ex)
            Throw New Exception($"Error getting all announcements: {ex.Message}", ex)
        End Try

        Return announcements
    End Function

    ' Get Recent Announcements
    Public Function GetRecentAnnouncements(count As Integer) As List(Of Announcement)
        Dim announcements As New List(Of Announcement)()

        Try
            Dim query = "SELECT TOP " & count & " * FROM Announcements WHERE IsDeleted = 0 ORDER BY PostedDate DESC"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            announcements.Add(MapReaderToAnnouncement(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("AnnouncementDatabase.GetRecentAnnouncements", ex)
            Throw New Exception($"Error getting recent announcements: {ex.Message}", ex)
        End Try

        Return announcements
    End Function

    ' Update Announcement
    Public Sub UpdateAnnouncement(announcementID As Integer, title As String, message As String)
        Try
            Dim query = "UPDATE Announcements SET Title = ?, Message = ? WHERE AnnouncementID = ? AND IsDeleted = 0"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@Title", title)
                    cmd.Parameters.AddWithValue("@Message", message)
                    cmd.Parameters.AddWithValue("@AnnouncementID", announcementID)

                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        Throw New Exception("Announcement not found or already deleted")
                    End If

                    DatabaseLogger.LogOperation("AnnouncementDatabase.UpdateAnnouncement", $"Updated announcement #{announcementID}")
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("AnnouncementDatabase.UpdateAnnouncement", ex)
            Throw New Exception($"Error updating announcement: {ex.Message}", ex)
        End Try
    End Sub

    ' Soft Delete Announcement
    Public Sub DeleteAnnouncement(announcementID As Integer)
        Try
            Dim query = "UPDATE Announcements SET IsDeleted = 1 WHERE AnnouncementID = ?"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AnnouncementID", announcementID)

                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        Throw New Exception("Announcement not found")
                    End If

                    DatabaseLogger.LogOperation("AnnouncementDatabase.DeleteAnnouncement", $"Deleted announcement #{announcementID}")
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("AnnouncementDatabase.DeleteAnnouncement", ex)
            Throw New Exception($"Error deleting announcement: {ex.Message}", ex)
        End Try
    End Sub

    ' Restore Announcement
    Public Sub RestoreAnnouncement(announcementID As Integer)
        Try
            Dim query = "UPDATE Announcements SET IsDeleted = 0 WHERE AnnouncementID = ?"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AnnouncementID", announcementID)

                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        Throw New Exception("Announcement not found")
                    End If

                    DatabaseLogger.LogOperation("AnnouncementDatabase.RestoreAnnouncement", $"Restored announcement #{announcementID}")
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("AnnouncementDatabase.RestoreAnnouncement", ex)
            Throw New Exception($"Error restoring announcement: {ex.Message}", ex)
        End Try
    End Sub

    ' Get Announcements Count
    Public Function GetAnnouncementCount(Optional includeDeleted As Boolean = False) As Integer
        Try
            Dim query = If(includeDeleted,
                "SELECT COUNT(*) FROM Announcements",
                "SELECT COUNT(*) FROM Announcements WHERE IsDeleted = 0")

            Dim result = _dbConnection.ExecuteScalar(query)
            Return Convert.ToInt32(result)
        Catch ex As Exception
            DatabaseLogger.LogError("AnnouncementDatabase.GetAnnouncementCount", ex)
            Return 0
        End Try
    End Function

    ' Helper Method - Map Reader to Announcement
    Private Function MapReaderToAnnouncement(reader As OleDbDataReader) As Announcement
        Dim announcement As New Announcement()

        announcement.AnnouncementID = Convert.ToInt32(reader("AnnouncementID"))
        announcement.Title = reader("Title").ToString()
        announcement.Message = reader("Message").ToString()
        announcement.PostedBy = Convert.ToInt32(reader("PostedBy"))
        announcement.PostedDate = Convert.ToDateTime(reader("PostedDate"))
        announcement.IsDeleted = Convert.ToBoolean(reader("IsDeleted"))

        Return announcement
    End Function
End Class