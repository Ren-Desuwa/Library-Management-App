Public Class Login_Panel

    Private Sub Login_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Get the singleton instance
            Dim library = LibraryDatabase.Instance

            ' Initialize database (creates tables if needed)

            library.InitializeDatabase()

            ' Test connection
            If library.TestConnection() Then
                MessageBox.Show("Database connected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show($"Error initializing system: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '' Center the form on the screen
        'Me.StartPosition = FormStartPosition.CenterScreen
        '' Populate role combo box
        'cmbRole.Items.Clear()
        'cmbRole.Items.Add("Librarian")
        'cmbRole.Items.Add("User")
        'cmbRole.SelectedIndex = -1 ' No selection by default
        '' Hide error label initially
        'lblError.Text = ""
        'lblError.Visible = False
        '' Set password textbox to mask characters
        'txtPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Hardcoded credentials
        Dim librarianUser As String = "admin"
        Dim librarianPass As String = "12345"

        ' Clear previous error
        lblError.Text = ""
        lblError.Visible = False

        ' Check role first
        If cmbRole.SelectedItem Is Nothing Then
            lblError.Text = "⚠ Please select a role."
            lblError.Visible = True
            Return
        End If

        Dim selectedRole As String = cmbRole.SelectedItem.ToString()

        If selectedRole = "Librarian" Then
            ' Validate credentials
            If txtUsername.Text = librarianUser AndAlso txtPassword.Text = librarianPass Then
                ' Success
                Dim dashboard As New Admin_Main_Panel()
                dashboard.StartPosition = FormStartPosition.CenterScreen
                dashboard.Show()

                ' Close login form completely
                Me.Hide()
            Else
                lblError.Text = "❌ Invalid librarian username or password."
                lblError.Visible = True
            End If

        ElseIf selectedRole = "User" Then
            lblError.Text = "ℹ User login not yet implemented."
            lblError.Visible = True
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            ' Show the password as plain text
            txtPassword.UseSystemPasswordChar = False
        Else
            ' Mask the password with bullets
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub lblForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblForgotPassword.LinkClicked
        ' Clear previous error
        lblError.Text = ""
        lblError.Visible = False

        ' Check if a role is selected
        If cmbRole.SelectedItem Is Nothing Then
            lblError.Text = "⚠ Please select a role first to reset password."
            lblError.Visible = True
            Return
        End If

        ' Get selected role (normalize text)
        Dim selectedRole As String = cmbRole.SelectedItem.ToString().Trim().ToLower()

        If selectedRole = "librarian" Then
            lblError.Text = "ℹ Password reset option for Librarian is not implemented yet."
            lblError.Visible = True
        ElseIf selectedRole = "user" Then
            lblError.Text = "ℹ Password reset option for User is not implemented yet."
            lblError.Visible = True
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ' Open the Sign Up panel
        Dim signupForm As New Register_Panel()
        signupForm.StartPosition = FormStartPosition.CenterScreen
        signupForm.Show()

        ' Close the login form completely
        Me.Hide()
    End Sub
End Class