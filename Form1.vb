Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Show dashboard when app starts
        ShowSection("Dashboard")
    End Sub

    Private Sub ShowSection(section As String)
        ' Hide all panels first
        pnlBooks.Visible = False
        pnlMembers.Visible = False
        pnlTransactions.Visible = False
        pnlReports.Visible = False
        pnlSettings.Visible = False

        ' Show the right one + update title + overview text
        Select Case section
            Case "Dashboard"
                pnlDashboard.Visible = True
                lblPageTitle.Text = "Dashboard"
                lblOverview.Text = "Dashboard Overview" & vbCrLf &
                                   "Welcome to the Library Management System Admin Dashboard."
            Case "Books"
                pnlBooks.Visible = True
                lblPageTitle.Text = "Books Management"
                lblOverview.Text = "Here you can manage the library's book records."
            Case "Members"
                pnlMembers.Visible = True
                lblPageTitle.Text = "Members"
                lblOverview.Text = "Here you can manage registered library members."
            Case "Transactions"
                pnlTransactions.Visible = True
                lblPageTitle.Text = "Transactions"
                lblOverview.Text = "Here you can track book borrowing and returning."
            Case "Reports"
                pnlReports.Visible = True
                lblPageTitle.Text = "Reports"
                lblOverview.Text = "Here you can view reports like overdue books or popular titles."
            Case "Settings"
                pnlSettings.Visible = True
                lblPageTitle.Text = "Settings"
                lblOverview.Text = "Here you can configure system settings."
        End Select
    End Sub

    ' ========== SIDEBAR BUTTONS ==========
    Private Sub btnDashboards_Click(sender As Object, e As EventArgs) Handles btnDashboards.Click
        ShowSection("Dashboard")
    End Sub

    Private Sub btnBooks_Click(sender As Object, e As EventArgs) Handles btnBooks.Click
        ShowSection("Books")
    End Sub

    Private Sub btnMembers_Click(sender As Object, e As EventArgs) Handles btnMembers.Click
        ShowSection("Members")
    End Sub

    Private Sub btnTransactions_Click(sender As Object, e As EventArgs) Handles btnTransactions.Click
        ShowSection("Transactions")
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        ShowSection("Reports")
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ShowSection("Settings")
    End Sub

End Class
