Imports System.Data.OleDb

Public Class Login_Panel
    ' Keep track of current user session
    Public Shared Property CurrentUser As Account = Nothing

    Private Sub Login_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Center form
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Populate role combo box
        cmbRole.Items.Clear()
        cmbRole.Items.Add("Librarian")
        cmbRole.Items.Add("Student")
        cmbRole.SelectedIndex = 0

        ' Hide error
        lblError.Text = ""
        lblError.Visible = False

        ' Mask password
        txtPassword.UseSystemPasswordChar = True

        ' Clear fields
        txtUsername.Clear()
        txtPassword.Clear()
        txtUsername.Focus()
        LoadDashboardStats()
    End Sub


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Clear previous error
        lblError.Text = ""
        lblError.Visible = False

        ' Validate inputs
        If cmbRole.SelectedItem Is Nothing Then
            ShowError("Please select a role.")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            ShowError("Please enter your User ID.")
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            ShowError("Please enter your password.")
            txtPassword.Focus()
            Return
        End If

        Dim selectedRole As String = cmbRole.SelectedItem.ToString()
        Dim isLibrarianLogin As Boolean = (selectedRole = "Librarian")

        btnLogin.Enabled = False
        btnLogin.Text = "Signing in..."

        Try
            Dim username = txtUsername.Text.Trim()
            Dim password = txtPassword.Text

            Dim acc As Account = LibraryDatabase.Instance.Accounts.Authenticate(username, password)
            If acc IsNot Nothing Then
                If isLibrarianLogin Then
                    If acc.Type = Type.Admin Then
                        acc.RecordLogin()
                        CurrentUser = acc
                        OpenAdminDashboard()
                    Else
                        ShowError("This account is not a librarian.")
                    End If
                Else
                    ' Student login
                    If Not acc.Type = Type.User Then
                        acc.RecordLogin()
                        CurrentUser = acc
                        OpenStudentDashboard()
                    Else
                        ShowError("This account is not a student.")
                    End If
                End If
            Else
                ShowError("Invalid username or password.")
            End If
        Catch ex As Exception
            ShowError($"Login error: {ex.Message}")
        Finally
            btnLogin.Enabled = True
            btnLogin.Text = "Sign In"
        End Try
    End Sub


    ' Opens the admin dashboard (placeholder)
    Private Sub OpenAdminDashboard()
        Try
            Dim dashboard As New Admin_Main_Panel()
            dashboard.StartPosition = FormStartPosition.CenterScreen
            dashboard.Show()
            Me.Hide()
        Catch ex As Exception
            ShowError($"Error opening admin dashboard: {ex.Message}")
        End Try
    End Sub

    ' Opens the student dashboard
    Private Sub OpenStudentDashboard()
        Try
            Dim dashboard As New User_Main_Panel()
            dashboard.StartPosition = FormStartPosition.CenterScreen
            dashboard.Show()
            Me.Hide()
        Catch ex As Exception
            ShowError($"Error opening student dashboard: {ex.Message}")
        End Try
    End Sub

    ' Toggle password visibility
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not CheckBox1.Checked
    End Sub

    ' Helper methods
    Private Sub ShowError(message As String)
        lblError.Text = message
        lblError.Visible = True
        lblError.ForeColor = Color.Red
    End Sub

    Private Sub ClearLoginForm()
        txtUsername.Clear()
        txtPassword.Clear()
        CheckBox1.Checked = False
        txtUsername.Focus()
    End Sub

    ' Handle Enter key
    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then e.Handled = True : txtPassword.Focus()
    End Sub
    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then e.Handled = True : btnLogin.PerformClick()
    End Sub

    Private Sub LoadDashboardStats()
        Try
            ' Total books
            Dim totalBooks As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Books"))
            lblTotalNumberofBooks.Text = totalBooks.ToString()

            ' Total members
            Dim totalMembers As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Students"))
            lblTotalNumberofMembers.Text = totalMembers.ToString()

            ' Total due today
            Dim totalDueToday As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM BorrowedBooks WHERE ReturnDate = Date()"))
            lblTotalNumberofDueToday.Text = totalDueToday.ToString()

        Catch ex As Exception
            MessageBox.Show("Error loading dashboard stats: " & ex.Message)
        End Try
    End Sub
End Class