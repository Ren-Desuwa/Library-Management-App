Public Class AdminLoginForm
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnAdminLogin.Click
        If txtAdminUsername.Text.Trim().ToUpper() = "ADMIN" AndAlso txtAdminPassword.Text = "admin123" Then
            Dim dashboard As New AdminDashboard()
            dashboard.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid Admin credentials!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Return button (go back to Main)
    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Dim mainForm As New Main()
        mainForm.Show()
        Me.Close()
    End Sub
End Class
