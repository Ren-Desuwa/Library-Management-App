Public Class Register_Panel
    Private Sub lblForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblForgotPassword.LinkClicked
        ' Open Login Panel
        Dim login As New Login_Panel()
        login.StartPosition = FormStartPosition.CenterScreen
        login.Show()

        ' Hide current form
        Me.Hide()
    End Sub

    Private Sub Register_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtStudentID.MaxLength = 10
        txtStudentID.ForeColor = Color.Gray
        txtStudentID.Text = "e.g., 20240001-N"
        txtContactNumber.Text = "+639"
        txtContactNumber.SelectionStart = txtContactNumber.Text.Length
    End Sub

    Private Sub txtStudentID_TextChanged(sender As Object, e As EventArgs) Handles txtStudentID.TextChanged

    End Sub

    Private Sub txtStudentID_Enter(sender As Object, e As EventArgs) Handles txtStudentID.Enter
        If txtStudentID.Text = "e.g., 20240001-N" Then
            txtStudentID.Text = ""
            txtStudentID.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtStudentID_Leave(sender As Object, e As EventArgs) Handles txtStudentID.Leave
        If String.IsNullOrWhiteSpace(txtStudentID.Text) Then
            txtStudentID.ForeColor = Color.Gray
            txtStudentID.Text = "e.g., 20240001-N"
        End If
    End Sub

    Private Sub txtContactNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactNumber.KeyPress
        ' Only allow numbers after +639
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txtContactNumber.TextChanged
        If Not txtContactNumber.Text.StartsWith("+639") Then
            txtContactNumber.Text = "+639"
            txtContactNumber.SelectionStart = txtContactNumber.Text.Length
        End If
    End Sub


    Private Sub txtShowConfirmPassword_CheckedChanged(sender As Object, e As EventArgs) Handles txtShowConfirmPassword.CheckedChanged
        If txtShowConfirmPassword.Checked Then
            txtPassword.UseSystemPasswordChar = False
            txtConfirmPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
            txtConfirmPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged
        If txtPassword.Text <> txtConfirmPassword.Text Then
            lblError.Text = "Passwords do not match."
        Else
            lblError.Text = ""
        End If
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ' Clear previous error
        lblError.Text = ""

        ' Check all required fields
        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
       String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
       String.IsNullOrWhiteSpace(txtStudentID.Text) OrElse txtStudentID.Text = "e.g., 20240001-N" OrElse
       String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
       String.IsNullOrWhiteSpace(txtContactNumber.Text) OrElse txtContactNumber.Text = "+639" OrElse
       String.IsNullOrWhiteSpace(txtPassword.Text) OrElse
       String.IsNullOrWhiteSpace(txtConfirmPassword.Text) Then

            lblError.Text = "Please fill in all fields."
            Exit Sub
        End If

        ' Check password match
        If txtPassword.Text <> txtConfirmPassword.Text Then
            lblError.Text = "Passwords do not match."
            Exit Sub
        End If

        ' If everything is valid
        lblError.Text = ""
        MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' TODO: Insert registration logic here (e.g., save to database)
        Me.Visible = False
        Login_Panel.Visible = True
    End Sub

    Private Sub txtFirstName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFirstName.KeyPress
        ' Allow only letters, space, and control keys
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " "c Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtLastName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLastName.KeyPress
        ' Allow only letters, space, and control keys
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " "c Then
            e.Handled = True
        End If
    End Sub
End Class