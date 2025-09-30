Public Class Register_Panel
    Private Sub lblForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblForgotPassword.LinkClicked
        ' Open Login Panel
        Dim login As New Login_Panel()
        login.StartPosition = FormStartPosition.CenterScreen
        login.Show()

        ' Hide current form
        Me.Hide()
    End Sub
End Class