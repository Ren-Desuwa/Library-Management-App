<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Main_Panel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.pnlDashboard = New System.Windows.Forms.Panel()
        Me.lblOverview = New System.Windows.Forms.Label()
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.pnlReports = New System.Windows.Forms.Panel()
        Me.pnlTransactions = New System.Windows.Forms.Panel()
        Me.pnlMembers = New System.Windows.Forms.Panel()
        Me.pnlBooks = New System.Windows.Forms.Panel()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.lblPageTitle = New System.Windows.Forms.Label()
        Me.panelSidebar = New System.Windows.Forms.Panel()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.btnTransactions = New System.Windows.Forms.Button()
        Me.btnMembers = New System.Windows.Forms.Button()
        Me.btnBooks = New System.Windows.Forms.Button()
        Me.btnDashboards = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panelMain.SuspendLayout()
        Me.pnlDashboard.SuspendLayout()
        Me.panelSidebar.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelMain
        '
        Me.panelMain.Controls.Add(Me.pnlDashboard)
        Me.panelMain.Controls.Add(Me.pnlSettings)
        Me.panelMain.Controls.Add(Me.pnlReports)
        Me.panelMain.Controls.Add(Me.pnlTransactions)
        Me.panelMain.Controls.Add(Me.pnlMembers)
        Me.panelMain.Controls.Add(Me.pnlBooks)
        Me.panelMain.Controls.Add(Me.pnlContent)
        Me.panelMain.Controls.Add(Me.lblPageTitle)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(200, 0)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(792, 616)
        Me.panelMain.TabIndex = 6
        '
        'pnlDashboard
        '
        Me.pnlDashboard.Controls.Add(Me.lblOverview)
        Me.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDashboard.Location = New System.Drawing.Point(0, 31)
        Me.pnlDashboard.Name = "pnlDashboard"
        Me.pnlDashboard.Size = New System.Drawing.Size(792, 585)
        Me.pnlDashboard.TabIndex = 7
        '
        'lblOverview
        '
        Me.lblOverview.AutoSize = True
        Me.lblOverview.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverview.Location = New System.Drawing.Point(6, 4)
        Me.lblOverview.Name = "lblOverview"
        Me.lblOverview.Size = New System.Drawing.Size(57, 18)
        Me.lblOverview.TabIndex = 0
        Me.lblOverview.Text = "Label3"
        '
        'pnlSettings
        '
        Me.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettings.Location = New System.Drawing.Point(0, 31)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(792, 585)
        Me.pnlSettings.TabIndex = 6
        '
        'pnlReports
        '
        Me.pnlReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlReports.Location = New System.Drawing.Point(0, 31)
        Me.pnlReports.Name = "pnlReports"
        Me.pnlReports.Size = New System.Drawing.Size(792, 585)
        Me.pnlReports.TabIndex = 5
        '
        'pnlTransactions
        '
        Me.pnlTransactions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTransactions.Location = New System.Drawing.Point(0, 31)
        Me.pnlTransactions.Name = "pnlTransactions"
        Me.pnlTransactions.Size = New System.Drawing.Size(792, 585)
        Me.pnlTransactions.TabIndex = 4
        '
        'pnlMembers
        '
        Me.pnlMembers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMembers.Location = New System.Drawing.Point(0, 31)
        Me.pnlMembers.Name = "pnlMembers"
        Me.pnlMembers.Size = New System.Drawing.Size(792, 585)
        Me.pnlMembers.TabIndex = 3
        '
        'pnlBooks
        '
        Me.pnlBooks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBooks.Location = New System.Drawing.Point(0, 31)
        Me.pnlBooks.Name = "pnlBooks"
        Me.pnlBooks.Size = New System.Drawing.Size(792, 585)
        Me.pnlBooks.TabIndex = 2
        '
        'pnlContent
        '
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 31)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(792, 585)
        Me.pnlContent.TabIndex = 1
        '
        'lblPageTitle
        '
        Me.lblPageTitle.AutoSize = True
        Me.lblPageTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPageTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPageTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblPageTitle.Name = "lblPageTitle"
        Me.lblPageTitle.Size = New System.Drawing.Size(156, 31)
        Me.lblPageTitle.TabIndex = 0
        Me.lblPageTitle.Text = "Dashboard"
        '
        'panelSidebar
        '
        Me.panelSidebar.Controls.Add(Me.btnSettings)
        Me.panelSidebar.Controls.Add(Me.btnReports)
        Me.panelSidebar.Controls.Add(Me.btnTransactions)
        Me.panelSidebar.Controls.Add(Me.btnMembers)
        Me.panelSidebar.Controls.Add(Me.btnBooks)
        Me.panelSidebar.Controls.Add(Me.btnDashboards)
        Me.panelSidebar.Controls.Add(Me.Label1)
        Me.panelSidebar.Controls.Add(Me.Label2)
        Me.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelSidebar.Location = New System.Drawing.Point(0, 0)
        Me.panelSidebar.Name = "panelSidebar"
        Me.panelSidebar.Size = New System.Drawing.Size(200, 616)
        Me.panelSidebar.TabIndex = 5
        '
        'btnSettings
        '
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Location = New System.Drawing.Point(19, 416)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(166, 57)
        Me.btnSettings.TabIndex = 8
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnReports
        '
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Location = New System.Drawing.Point(19, 353)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(166, 57)
        Me.btnReports.TabIndex = 7
        Me.btnReports.Text = "Reports"
        Me.btnReports.UseVisualStyleBackColor = False
        '
        'btnTransactions
        '
        Me.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransactions.Location = New System.Drawing.Point(19, 290)
        Me.btnTransactions.Name = "btnTransactions"
        Me.btnTransactions.Size = New System.Drawing.Size(166, 57)
        Me.btnTransactions.TabIndex = 6
        Me.btnTransactions.Text = "Transaction"
        Me.btnTransactions.UseVisualStyleBackColor = False
        '
        'btnMembers
        '
        Me.btnMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMembers.Location = New System.Drawing.Point(19, 227)
        Me.btnMembers.Name = "btnMembers"
        Me.btnMembers.Size = New System.Drawing.Size(166, 57)
        Me.btnMembers.TabIndex = 5
        Me.btnMembers.Text = "Members"
        Me.btnMembers.UseVisualStyleBackColor = False
        '
        'btnBooks
        '
        Me.btnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBooks.Location = New System.Drawing.Point(19, 164)
        Me.btnBooks.Name = "btnBooks"
        Me.btnBooks.Size = New System.Drawing.Size(166, 57)
        Me.btnBooks.TabIndex = 4
        Me.btnBooks.Text = "Books Management"
        Me.btnBooks.UseVisualStyleBackColor = False
        '
        'btnDashboards
        '
        Me.btnDashboards.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashboards.Location = New System.Drawing.Point(19, 101)
        Me.btnDashboards.Name = "btnDashboards"
        Me.btnDashboards.Size = New System.Drawing.Size(166, 57)
        Me.btnDashboards.TabIndex = 3
        Me.btnDashboards.Text = "Dashboard"
        Me.btnDashboards.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "📚 LibraryMS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label2.Location = New System.Drawing.Point(47, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Admin Dashboard"
        '
        'Admin_Main_Panel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.panelMain)
        Me.Controls.Add(Me.panelSidebar)
        Me.Name = "Admin_Main_Panel"
        Me.Text = "Form1"
        Me.panelMain.ResumeLayout(False)
        Me.panelMain.PerformLayout()
        Me.pnlDashboard.ResumeLayout(False)
        Me.pnlDashboard.PerformLayout()
        Me.panelSidebar.ResumeLayout(False)
        Me.panelSidebar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelMain As Panel
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents lblOverview As Label
    Friend WithEvents pnlSettings As Panel
    Friend WithEvents pnlReports As Panel
    Friend WithEvents pnlTransactions As Panel
    Friend WithEvents pnlMembers As Panel
    Friend WithEvents pnlBooks As Panel
    Friend WithEvents pnlContent As Panel
    Friend WithEvents lblPageTitle As Label
    Friend WithEvents panelSidebar As Panel
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnTransactions As Button
    Friend WithEvents btnMembers As Button
    Friend WithEvents btnBooks As Button
    Friend WithEvents btnDashboards As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
