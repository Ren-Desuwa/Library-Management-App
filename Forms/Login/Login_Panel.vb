Public Class Login_Panel
    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Hardcoded credentials
        Dim librarianUser As String = "admin"
        Dim librarianPass As String = "12345"

        ' Check role first
        If cmbRole.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a role.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRole As String = cmbRole.SelectedItem.ToString()

        If selectedRole = "Librarian" Then
            ' Validate credentials
            If txtUsername.Text = librarianUser AndAlso txtPassword.Text = librarianPass Then
                MessageBox.Show("Welcome Librarian!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Open Admin Dashboard
                Dim dashboard As New Admin_Main_Panel()
                dashboard.StartPosition = FormStartPosition.CenterScreen
                dashboard.Show()

                ' Hide the login form
                Me.Hide()
            Else
                MessageBox.Show("Invalid librarian username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        ElseIf selectedRole = "User" Then
            MessageBox.Show("User login not yet implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class