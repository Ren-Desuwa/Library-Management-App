Imports System.Data.OleDb

Public Class AnnouncementDAO
    Private _connection As OleDbConnection

    Public Sub New(connection As OleDbConnection)
        _connection = connection
    End Sub

    Public Function GetById(announcementID As Integer) As Announcement
        Dim query As String = "SELECT * FROM Announcement WHERE AnnouncementID = @id"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@id", announcementID)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                If reader.Read() Then Return MapToAnnouncement(reader)
            End Using
        End Using
        Return Nothing
    End Function

    Public Function Insert(announcement As Announcement) As Integer
        Dim query As String = "INSERT INTO Announcement (AdminID, Title, Message, DatePosted, ExpiryDate, Priority, IsActive) " &
                              "VALUES (@adminId, @title, @message, @posted, @expiry, @priority, @active)"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@adminId", announcement.AdminID)
            cmd.Parameters.AddWithValue("@title", announcement.Title)
            cmd.Parameters.AddWithValue("@message", announcement.Message)
            cmd.Parameters.AddWithValue("@posted", announcement.DatePosted)
            cmd.Parameters.AddWithValue("@expiry", If(announcement.ExpiryDate.HasValue, CObj(announcement.ExpiryDate.Value), DBNull.Value))
            cmd.Parameters.AddWithValue("@priority", announcement.Priority)
            cmd.Parameters.AddWithValue("@active", announcement.IsActive)
            cmd.ExecuteNonQuery()
        End Using

        Using cmd As New OleDbCommand("SELECT @@IDENTITY", _connection)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Public Function GetAllActive() As List(Of Announcement)
        Dim announcements As New List(Of Announcement)
        Dim query As String = "SELECT * FROM Announcement WHERE IsActive = True ORDER BY DatePosted DESC"
        Using cmd As New OleDbCommand(query, _connection)
            Using reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim announcement = MapToAnnouncement(reader)
                    If announcement.IsValid() Then
                        announcements.Add(announcement)
                    End If
                End While
            End Using
        End Using
        Return announcements
    End Function

    Public Function Update(announcement As Announcement) As Boolean
        Dim query As String = "UPDATE Announcement SET Title = @title, Message = @message, " &
                              "ExpiryDate = @expiry, Priority = @priority, IsActive = @active WHERE AnnouncementID = @id"
        Using cmd As New OleDbCommand(query, _connection)
            cmd.Parameters.AddWithValue("@title", announcement.Title)
            cmd.Parameters.AddWithValue("@message", announcement.Message)
            cmd.Parameters.AddWithValue("@expiry", If(announcement.ExpiryDate.HasValue, CObj(announcement.ExpiryDate.Value), DBNull.Value))
            cmd.Parameters.AddWithValue("@priority", announcement.Priority)
            cmd.Parameters.AddWithValue("@active", announcement.IsActive)
            cmd.Parameters.AddWithValue("@id", announcement.AnnouncementID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    Private Function MapToAnnouncement(reader As OleDbDataReader) As Announcement
        Return New Announcement With {
            .AnnouncementID = Convert.ToInt32(reader("AnnouncementID")),
            .AdminID = Convert.ToInt32(reader("AdminID")),
            .Title = reader("Title").ToString(),
            .Message = reader("Message").ToString(),
            .DatePosted = Convert.ToDateTime(reader("DatePosted")),
            .ExpiryDate = If(IsDBNull(reader("ExpiryDate")), Nothing, Convert.ToDateTime(reader("ExpiryDate"))),
            .Priority = reader("Priority").ToString(),
            .IsActive = Convert.ToBoolean(reader("IsActive"))
        }
    End Function
End Class