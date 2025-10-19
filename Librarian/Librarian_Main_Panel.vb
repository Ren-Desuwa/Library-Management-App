Public Class Librarian_Main_Panel
    Private Sub Librarian_Main_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dashboard As New StudentDashboard()
        LoadUserControl(dashboard)
        Me.StartPosition = FormStartPosition.CenterScreen
        btnDashboard.PerformClick()
    End Sub

    Public Sub LoadUserControl(uc As UserControl)
        AdminMainPanel.Controls.Clear()
        uc.Dock = DockStyle.Fill
        AdminMainPanel.Controls.Add(uc)
        uc.BringToFront()
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        Dim dashboard As New LibrarianDashboard()
        LoadUserControl(dashboard)
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim dashboard As New LibrarianCataloging()
        LoadUserControl(dashboard)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Dim dashboard As New LibrarianTransactions()
        LoadUserControl(dashboard)
    End Sub
End Class