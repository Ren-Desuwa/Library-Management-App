Imports System.Data.OleDb

Public Class Login_Panel
    ' Keep track of current user session
    Public Shared Property CurrentUser As Account = Nothing

    Private Sub Login_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Get the singleton instance
            Dim library = LibraryDatabase.Instance

            ' Initialize database silently (creates tables if needed)
            library.InitializeDatabase()

            ' Only show error if connection fails
            If Not library.TestConnection() Then
                lblError.Text = "Database connection failed. Please check configuration."
                lblError.Visible = True
            End If

        Catch ex As Exception
            lblError.Text = $"System initialization error: {ex.Message}"
            lblError.Visible = True
        End Try

        ' Center the form on the screen
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Populate role combo box (clear designer items first)
        cmbRole.Items.Clear()
        cmbRole.Items.Add("Librarian")
        cmbRole.Items.Add("Student")
        cmbRole.SelectedIndex = 0 ' Default to Librarian

        ' Hide error label initially
        lblError.Text = ""
        lblError.Visible = False

        ' Set password textbox to mask characters
        txtPassword.UseSystemPasswordChar = True

        ' Clear any previous inputs
        txtUsername.Clear()
        txtPassword.Clear()

        ' Focus on username field
        txtUsername.Focus()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Clear previous error
        lblError.Text = ""
        lblError.Visible = False

        ' Validate all inputs
        If cmbRole.SelectedItem Is Nothing Then
            ShowError("Please select a role.")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            ShowError("Please enter your username.")
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            ShowError("Please enter your password.")
            txtPassword.Focus()
            Return
        End If

        ' Get selected role
        Dim selectedRole As String = cmbRole.SelectedItem.ToString()
        Dim isLibrarianLogin As Boolean = (selectedRole = "Librarian")

        ' Disable login button to prevent double-clicks
        btnLogin.Enabled = False
        btnLogin.Text = "Signing in..."

        Try
            ' Authenticate using database
            Dim library = LibraryDatabase.Instance
            Dim account = library.Accounts.Authenticate(txtUsername.Text.Trim(), txtPassword.Text)

            If account IsNot Nothing Then
                ' Verify role matches account type
                If (isLibrarianLogin AndAlso account.IsAdmin) Then
                    ' Librarian login successful
                    CurrentUser = account
                    OpenAdminDashboard()

                ElseIf (Not isLibrarianLogin AndAlso Not account.IsAdmin) Then
                    ' Student login successful
                    CurrentUser = account
                    OpenStudentDashboard()

                Else
                    ' Role mismatch
                    If isLibrarianLogin Then
                        ShowError("This account is not registered as a Librarian.")
                    Else
                        ShowError("This account is not registered as a Student.")
                    End If
                End If
            Else
                ' Authentication failed
                ShowError("Invalid username or password.")
            End If

        Catch ex As Exception
            ShowError($"Login error: {ex.Message}")

        Finally
            ' Re-enable login button
            btnLogin.Enabled = True
            btnLogin.Text = "Sign In"
        End Try
    End Sub

    Private Sub OpenAdminDashboard()
        Try
            ' TODO: Uncomment when Admin_Main_Panel is ready
            Dim dashboard As New Admin_Main_Panel()
            dashboard.StartPosition = FormStartPosition.CenterScreen
            dashboard.Show()
            Me.Hide()

            ' Temporary placeholder
            MessageBox.Show($"Welcome, {CurrentUser.Username}!" & vbCrLf &
                          "Admin dashboard will open here." & vbCrLf & vbCrLf &
                          "Role: Librarian" & vbCrLf &
                          $"Last Login: {CurrentUser.LastLoginDate}",
                          "Login Successful",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information)

            ' For now, just clear the form
            ClearLoginForm()

        Catch ex As Exception
            ShowError($"Error opening admin dashboard: {ex.Message}")
        End Try
    End Sub

    Private Sub OpenStudentDashboard()
        Try
            ' TODO: Create and uncomment Student_Main_Panel
            ' Dim dashboard As New Student_Main_Panel()
            ' dashboard.StartPosition = FormStartPosition.CenterScreen
            ' dashboard.Show()
            ' Me.Hide()

            ' Temporary placeholder
            MessageBox.Show($"Welcome, {CurrentUser.Username}!" & vbCrLf &
                          "Student dashboard will open here." & vbCrLf & vbCrLf &
                          "Role: Student" & vbCrLf &
                          $"Last Login: {CurrentUser.LastLoginDate}",
                          "Login Successful",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information)

            ' For now, just clear the form
            ClearLoginForm()

        Catch ex As Exception
            ShowError($"Error opening student dashboard: {ex.Message}")
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        ' Toggle password visibility
        txtPassword.UseSystemPasswordChar = Not CheckBox1.Checked
    End Sub

    Private Sub lblForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblForgotPassword.LinkClicked
        ' Clear previous error
        lblError.Text = ""
        lblError.Visible = False

        ' Check if a role is selected
        If cmbRole.SelectedItem Is Nothing Then
            ShowError("Please select a role first.")
            Return
        End If

        ' Check if username is provided
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            ShowError("Please enter your username to recover password.")
            txtUsername.Focus()
            Return
        End If

        Try
            ' TODO: Uncomment when Recovery_Panel is implemented
            ' Dim recoveryForm As New Recovery_Panel()
            ' recoveryForm.Username = txtUsername.Text.Trim()
            ' recoveryForm.IsAdmin = (cmbRole.SelectedItem.ToString() = "Librarian")
            ' recoveryForm.StartPosition = FormStartPosition.CenterScreen
            ' recoveryForm.ShowDialog() ' Use ShowDialog to keep login form visible

            ' Temporary placeholder
            MessageBox.Show("Password recovery feature coming soon." & vbCrLf & vbCrLf &
                          $"Username: {txtUsername.Text}" & vbCrLf &
                          $"Role: {cmbRole.SelectedItem.ToString()}" & vbCrLf & vbCrLf &
                          "Please contact your system administrator.",
                          "Password Recovery",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information)

        Catch ex As Exception
            ShowError($"Error opening recovery: {ex.Message}")
        End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            ' TODO: Uncomment when SignUp_Panel is implemented
            ' Dim signupForm As New SignUp_Panel()
            ' signupForm.StartPosition = FormStartPosition.CenterScreen
            ' signupForm.Show()
            ' Me.Hide()

            ' Temporary placeholder
            Dim result = MessageBox.Show("Registration feature coming soon." & vbCrLf & vbCrLf &
                          "This will allow new students to create accounts." & vbCrLf &
                          "Librarian accounts must be created by administrators." & vbCrLf & vbCrLf &
                          "Would you like to see the registration form template?",
                          "Registration",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Information)

            If result = DialogResult.Yes Then
                ' Show what fields would be needed
                MessageBox.Show("Registration Form Fields:" & vbCrLf & vbCrLf &
                              "- Username (unique)" & vbCrLf &
                              "- Email Address" & vbCrLf &
                              "- Password" & vbCrLf &
                              "- Confirm Password" & vbCrLf &
                              "- Full Name" & vbCrLf &
                              "- Student ID (for students)" & vbCrLf &
                              "- Terms & Conditions acceptance",
                              "Registration Fields",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            ShowError($"Error opening registration: {ex.Message}")
        End Try
    End Sub

    ' Handle Enter key press on username field
    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPassword.Focus()
        End If
    End Sub

    ' Handle Enter key press on password field
    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnLogin.PerformClick()
        End If
    End Sub

    ' Helper method to show error messages
    Private Sub ShowError(message As String)
        lblError.Text = message
        lblError.Visible = True
        lblError.ForeColor = Color.Red
    End Sub

    ' Helper method to show success messages
    Private Sub ShowSuccess(message As String)
        lblError.Text = message
        lblError.Visible = True
        lblError.ForeColor = Color.Green
    End Sub

    ' Clear login form
    Private Sub ClearLoginForm()
        txtUsername.Clear()
        txtPassword.Clear()
        CheckBox1.Checked = False
        txtUsername.Focus()
    End Sub

    ' Override form closing to handle logout
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If CurrentUser IsNot Nothing Then
            Dim result = MessageBox.Show("Are you sure you want to exit?",
                                       "Confirm Exit",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question)

            If result = DialogResult.No Then
                e.Cancel = True
                Return
            End If

            CurrentUser = Nothing
        End If

        MyBase.OnFormClosing(e)
    End Sub
End Class