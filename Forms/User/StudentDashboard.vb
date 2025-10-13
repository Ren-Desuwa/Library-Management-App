Public Class StudentDashboard
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim announcementsForm As New AllAnnouncements()
        announcementsForm.Show()
    End Sub
End Class
