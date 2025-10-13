Public Class Student_Main_Panel

    Private Sub Student_Main_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dashboard As New StudentDashboard()
        LoadUserControl(dashboard)
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub Admin_Main_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox2.Click

    End Sub

    Private Sub Guna2ControlBox3_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox3.Click

    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click

    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        Dim dashboard As New StudentDashboard()
        LoadUserControl(dashboard)
    End Sub

    Private Sub LoadUserControl(uc As UserControl)
        MainPanel.Controls.Clear()
        uc.Dock = DockStyle.Fill
        MainPanel.Controls.Add(uc)
        uc.BringToFront()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim dashboard As New SearchBooks()
        LoadUserControl(dashboard)
    End Sub
End Class
