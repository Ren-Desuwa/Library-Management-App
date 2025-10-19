Imports Transitions
Public Class Admin_Main_Panel2
    Private isCollapsed As Boolean = True ' Start collapsed
    Private collapseTimer As New Timer()
    Private animationTimer As Timer
    Private isAnimating As Boolean = False
    Private labelPanel As Panel ' Panel that slides behind icons

    Private Sub Admin_Main_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup the sliding label panel
        SetupLabelPanel()

        ' Setup collapse timer (5 seconds)
        collapseTimer.Interval = 5000
        AddHandler collapseTimer.Tick, AddressOf AutoCollapsePanel

        ' Setup hover events on Panel1 (the icon panel)
        AddHandler Panel1.MouseEnter, AddressOf Panel_MouseEnter
        AddHandler Panel1.MouseLeave, AddressOf Panel_MouseLeave
        AddHandler TableLayoutPanel3.MouseEnter, AddressOf Panel_MouseEnter
        AddHandler TableLayoutPanel3.MouseLeave, AddressOf Panel_MouseLeave

        ' Also add hover events to the label panel
        AddHandler labelPanel.MouseEnter, AddressOf Panel_MouseEnter
        AddHandler labelPanel.MouseLeave, AddressOf Panel_MouseLeave

        ' Start with labels hidden
        labelPanel.Left = 60
        labelPanel.Visible = False

        ' Load dashboard
        LoadControl(New UC_dashboard())
    End Sub

    Private Sub SetupLabelPanel()
        ' Create a separate panel for the link labels that slides out
        labelPanel = New Panel()
        labelPanel.Size = New Size(176, Me.ClientSize.Height) ' 236 - 60 = 176
        labelPanel.BackColor = Color.Brown
        labelPanel.Left = 60 ' Position right next to icon panel
        labelPanel.Top = 0
        labelPanel.Visible = False
        labelPanel.BringToFront()

        ' Create TableLayoutPanel for labels
        Dim labelLayout As New TableLayoutPanel()
        labelLayout.Dock = DockStyle.Fill
        labelLayout.BackColor = Color.Brown
        labelLayout.ColumnCount = 1
        labelLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
        labelLayout.RowCount = 9
        labelLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 11.0!))
        labelLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 7.0!))
        labelLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 7.0!))
        labelLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 7.0!))
        labelLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 7.0!))
        labelLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 7.0!))
        labelLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 7.0!))
        labelLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 40.0!))
        labelLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 7.0!))

        ' Move link labels from TableLayoutPanel3 to labelLayout
        Dim labelsToMove As New List(Of LinkLabel)
        For Each ctrl As Control In TableLayoutPanel3.Controls
            If TypeOf ctrl Is LinkLabel Then
                labelsToMove.Add(CType(ctrl, LinkLabel))
            End If
        Next

        For Each lbl As LinkLabel In labelsToMove
            Dim row As Integer = TableLayoutPanel3.GetRow(lbl)
            TableLayoutPanel3.Controls.Remove(lbl)
            lbl.Margin = New Padding(10, 0, 3, 0)
            lbl.Dock = DockStyle.Fill
            labelLayout.Controls.Add(lbl, 0, row)
        Next

        labelPanel.Controls.Add(labelLayout)
        Me.Controls.Add(labelPanel)
        labelPanel.BringToFront()

        ' Add hover events to all link labels
        For Each lbl As LinkLabel In labelsToMove
            AddHandler lbl.MouseEnter, AddressOf Panel_MouseEnter
            AddHandler lbl.MouseLeave, AddressOf Panel_MouseLeave
        Next
    End Sub

    Private Sub Panel_MouseEnter(sender As Object, e As EventArgs)
        collapseTimer.Stop()
        ExpandPanel()
    End Sub

    Private Sub Panel_MouseLeave(sender As Object, e As EventArgs)
        collapseTimer.Stop()
        collapseTimer.Start()
    End Sub

    Private Sub AutoCollapsePanel(sender As Object, e As EventArgs)
        collapseTimer.Stop()
        CollapsePanel()
    End Sub

    Private Sub ExpandPanel()
        If isCollapsed AndAlso Not isAnimating Then
            isAnimating = True
            labelPanel.Visible = True
            labelPanel.BringToFront()
            AnimateLabelPanel(60) ' Slide to position 60
            isCollapsed = False
        End If
    End Sub

    Private Sub CollapsePanel()
        If Not isCollapsed AndAlso Not isAnimating Then
            isAnimating = True
            AnimateLabelPanel(0) ' Slide to position 0 (hidden behind icons)
            isCollapsed = True
        End If
    End Sub

    Private Sub AnimateLabelPanel(targetLeft As Integer)
        ' Stop any active animations on this control
        Transition.run(labelPanel, "Left", targetLeft, New TransitionType_EaseInEaseOut(500))

        ' Handle visibility at start/end
        If targetLeft > 0 Then
            labelPanel.Visible = True
            labelPanel.BringToFront()
        Else
            ' Fade-out effect after slide completes
            Dim hideTimer As New Timer() With {.Interval = 520}
            AddHandler hideTimer.Tick, Sub()
                                           hideTimer.Stop()
                                           hideTimer.Dispose()
                                           labelPanel.Visible = False
                                       End Sub
            hideTimer.Start()
        End If

        ' Update state flags
        isAnimating = False
    End Sub


    Private Sub LoadControl(ctrl As UserControl)
        ' Find or create content panel
        Dim contentPanel As Panel = Nothing

        For Each c As Control In Me.Controls
            If TypeOf c Is Panel AndAlso c IsNot Panel1 AndAlso c IsNot labelPanel Then
                contentPanel = CType(c, Panel)
                Exit For
            End If
        Next

        If contentPanel Is Nothing Then
            contentPanel = New Panel()
            contentPanel.Location = New Point(60, 0)
            contentPanel.Size = New Size(Me.ClientSize.Width - 60, Me.ClientSize.Height)
            contentPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
            Me.Controls.Add(contentPanel)
            contentPanel.SendToBack()
        End If

        contentPanel.Controls.Clear()
        ctrl.Dock = DockStyle.Fill
        contentPanel.Controls.Add(ctrl)
    End Sub

    Private Sub HighlightLink(clickedLink As LinkLabel)
        ' Reset all links
        For Each ctrl As Control In labelPanel.Controls(0).Controls
            If TypeOf ctrl Is LinkLabel Then
                Dim lnk As LinkLabel = CType(ctrl, LinkLabel)
                lnk.LinkColor = Color.White
                lnk.BackColor = Color.Brown
            End If
        Next

        ' Highlight clicked link
        clickedLink.LinkColor = Color.White
        clickedLink.BackColor = Color.FromArgb(139, 0, 0) ' Darker brown
    End Sub

    Private Sub lnkDashboard_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDashboard.LinkClicked
        HighlightLink(lnkDashboard)
        LoadControl(New UC_dashboard())
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkBooks.LinkClicked
        HighlightLink(lnkBooks)
        LoadControl(New UC_books())
    End Sub

    Private Sub lnkMember_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMember.LinkClicked
        HighlightLink(lnkMember)
        LoadControl(New UC_Members())
    End Sub

    Private Sub lnkTransactions_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTransactions.LinkClicked
        HighlightLink(lnkTransactions)
        LoadControl(New UC_transactions())
    End Sub

    Private Sub lnkReports_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkReports.LinkClicked
        HighlightLink(lnkReports)
        LoadControl(New UC_reports())
    End Sub

    Private Sub lnkSettings_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSettings.LinkClicked
        HighlightLink(lnkSettings)
        LoadControl(New UC_settings())
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Dim loginForm As New Login_Panel()
                loginForm.StartPosition = FormStartPosition.CenterScreen
                loginForm.Show()
                Me.Hide()
                AddHandler loginForm.FormClosed, Sub(s, ev) Me.Close()
            Catch ex As Exception
                MessageBox.Show("Failed to open login: " & ex.Message)
            End Try
        End If
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If collapseTimer IsNot Nothing Then
            collapseTimer.Stop()
            collapseTimer.Dispose()
        End If
        If animationTimer IsNot Nothing Then
            animationTimer.Stop()
            animationTimer.Dispose()
        End If
        MyBase.OnFormClosing(e)
    End Sub
End Class