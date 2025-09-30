Public Class User_Main_Panel
    Private Sub LoadControl(ctrl As UserControl)
        PanelContent.Controls.Clear()
        ctrl.Dock = DockStyle.Fill
        PanelContent.Controls.Add(ctrl)
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Dim loginForm As New Login_Panel()
                loginForm.StartPosition = FormStartPosition.CenterScreen

                ' Show login form first, then hide current form so app doesn't exit unexpectedly
                loginForm.Show()

                ' Option A: hide this form and close it when loginForm closes
                Me.Hide()
                AddHandler loginForm.FormClosed, Sub(s, ev) Me.Close()

                ' (Option B alternative: Me.Close() directly — only safe if Shutdown mode is "When last form closes")
                ' Me.Close()

            Catch ex As Exception
                MessageBox.Show("Failed to open login: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub lnkDashboard_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDashboard.LinkClicked
        LoadControl(New UC_user_dashboard())
    End Sub

    Private Sub lnkBooks_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkBooks.LinkClicked
        LoadControl(New UC_search_books())
    End Sub

    Private Sub lnkTransactions_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTransactions.LinkClicked
        LoadControl(New UC_user_history())
    End Sub

    Private Sub lnkSettings_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSettings.LinkClicked
        LoadControl(New UC_user_settings())
    End Sub
End Class