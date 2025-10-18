Imports Guna.UI2.WinForms

Public Class Student_Main_Panel

    Private Sub Student_Main_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dashboard As New StudentDashboard()
        LoadUserControl(dashboard)
        Me.StartPosition = FormStartPosition.CenterScreen
        btnDashboard.PerformClick()
    End Sub

    Private Sub Admin_Main_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox2.Click

    End Sub

    Private Sub Guna2ControlBox3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click

    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        Dim dashboard As New StudentDashboard()
        LoadUserControl(dashboard)
    End Sub

    Public Sub LoadUserControl(uc As UserControl)
        MainPanel.Controls.Clear()
        uc.Dock = DockStyle.Fill
        MainPanel.Controls.Add(uc)
        uc.BringToFront()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim dashboard As New SearchBooks()
        LoadUserControl(dashboard)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Dim dashboard As New StudentHistory()
        LoadUserControl(dashboard)
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Dim dashboard As New StudentSettings()
        LoadUserControl(dashboard)
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        ' Show a message box asking for confirmation
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to Logout?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check what the user clicked
        If result = DialogResult.Yes Then
            Me.Close() ' Close the form
        Else
            ' Do nothing, just return to the form
        End If
    End Sub
End Class
