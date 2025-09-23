Public Class Main

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Nothing special here anymore
        ' Just make sure PanelMain (with btnUser and btnAdmin) is visible
    End Sub

    ' Open User Login Form
    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        Dim userLogin As New UserLoginForm()
        userLogin.Show()
        Me.Hide()
    End Sub

    ' Open Admin Login Form
    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Dim adminLogin As New AdminLoginForm()
        adminLogin.Show()
        Me.Hide()
    End Sub

End Class
