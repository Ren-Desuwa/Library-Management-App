Public Class Admin_Main_Panel

    Private Sub Admin_Main_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load the dashboard by default
        LoadControl(New UC_dashboard())
    End Sub


    ' Reusable method to load any UserControl into PanelMain
    Private Sub LoadControl(ctrl As UserControl)
        PanelContent.Controls.Clear()
        ctrl.Dock = DockStyle.Fill
        PanelContent.Controls.Add(ctrl)
    End Sub

    ' When you click the Dashboard link
    Private Sub lnkDashboard_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDashboard.LinkClicked
        LoadControl(New UC_dashboard())
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkBooks.LinkClicked
        LoadControl(New UC_books())
    End Sub

    Private Sub lnkMember_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMember.LinkClicked
        LoadControl(New UC_members())
    End Sub

    Private Sub lnkTransactions_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTransactions.LinkClicked
        LoadControl(New UC_transactions())
    End Sub

    Private Sub lnkOverdue_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOverdue.LinkClicked
        LoadControl(New UC_overdue())
    End Sub

    Private Sub lnkReports_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkReports.LinkClicked
        LoadControl(New UC_reports())
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

    Private Sub lnkSettings_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSettings.LinkClicked
        LoadControl(New UC_settings())
    End Sub
End Class
