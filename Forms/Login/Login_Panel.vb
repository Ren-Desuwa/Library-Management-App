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
            Using con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\xx\Source\Repos\Library-Management-App\Database\Library.accdb;")
                con.Open()
                Dim cmd As OleDbCommand
                Dim reader As OleDbDataReader

                If isLibrarianLogin Then
                    ' Librarian/Admin login
                    cmd = New OleDbCommand("SELECT * FROM Accounts WHERE Username=@Username", con)
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                    reader = cmd.ExecuteReader()

                    If reader.Read() Then
                        Dim storedHash As String = reader("PasswordHash").ToString()
                        If Account.HashPassword(txtPassword.Text) = storedHash Then
                            ' Build account object
                            Dim acc As New Account()
                            acc.AccountID = Convert.ToInt32(reader("AccountID"))
                            acc.Username = reader("Username").ToString()
                            acc.PasswordHash = storedHash
                            acc.Email = reader("Email").ToString()
                            acc.IsAdmin = True
                            acc.RecordLogin()

                            CurrentUser = acc
                            OpenAdminDashboard()
                        Else
                            ShowError("Invalid password.")
                        End If
                    Else
                        ShowError("Username not found.")
                    End If
                    reader.Close()

                Else
                    ' Student login
                    cmd = New OleDbCommand("SELECT * FROM Students WHERE StudentID=@StudentID AND [Password]=@Password", con)
                    cmd.Parameters.AddWithValue("@StudentID", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text)
                    reader = cmd.ExecuteReader()

                    If reader.Read() Then
                        ' Build account object for student
                        Dim student As New Account()
                        student.AccountID = Convert.ToInt32(reader("ID"))
                        student.Username = reader("StudentID").ToString()
                        student.FirstName = reader("FirstName").ToString()
                        student.LastName = reader("LastName").ToString()
                        student.Email = reader("Email").ToString()
                        student.IsAdmin = False
                        student.RecordLogin()

                        CurrentUser = student
                        OpenStudentDashboard()
                    Else
                        ShowError("Invalid student ID or password.")
                    End If
                    reader.Close()
                End If
            End Using
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
