Imports System.Data.OleDb

Public Class UC_user_dashboard
    Inherits UserControl

    Private Sub UC_user_dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display welcome message
        If Login_Panel.CurrentUser IsNot Nothing AndAlso Not Login_Panel.CurrentUser.IsAdmin Then
            Dim firstName As String = If(String.IsNullOrEmpty(Login_Panel.CurrentUser.FirstName), "", Login_Panel.CurrentUser.FirstName)
            Dim lastName As String = If(String.IsNullOrEmpty(Login_Panel.CurrentUser.LastName), "", Login_Panel.CurrentUser.LastName)
            lblWelcomeName.Text = $"Welcome, {firstName} {lastName}."
        Else
            lblWelcomeName.Text = "Welcome, Student."
        End If

    End Sub

    ' Load announcements into txtAnnouncements (readonly TextBox)

End Class
