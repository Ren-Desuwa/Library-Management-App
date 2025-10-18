Imports Guna.UI2.WinForms

Public Class StudentDashboard
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim announcementsForm As New AllAnnouncements()
        announcementsForm.Show()
    End Sub

    Private Sub Guna2Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel2.Paint

    End Sub

    Private Sub StudentDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2HtmlToolTip1.SetToolTip(Guna2Panel4, "You have 1 overdue item(s)." & vbCrLf & "Click to view all overdue items and return history.")
    End Sub

    Private Sub Guna2HtmlToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles Guna2HtmlToolTip1.Popup

    End Sub

    Private Sub Guna2HtmlToolTip1_LinkClicked(sender As Object, e As TheArtOfDevHtmlRenderer.Core.Entities.HtmlLinkClickedEventArgs) Handles Guna2HtmlToolTip1.LinkClicked

    End Sub
End Class
