<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_transactions
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.RoundedPanel1 = New Library_Management_App.RoundedPanel()
        Me.btnClearSelection = New System.Windows.Forms.Button()
        Me.btnSendReminder = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbDateFilter = New System.Windows.Forms.ComboBox()
        Me.dgvRecentTransactions = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RoundedPanel1.SuspendLayout()
        CType(Me.dgvRecentTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.White
        Me.RoundedPanel1.Controls.Add(Me.btnClearSelection)
        Me.RoundedPanel1.Controls.Add(Me.btnSendReminder)
        Me.RoundedPanel1.Controls.Add(Me.Label5)
        Me.RoundedPanel1.Controls.Add(Me.btnSearch)
        Me.RoundedPanel1.Controls.Add(Me.txtSearch)
        Me.RoundedPanel1.Controls.Add(Me.Label1)
        Me.RoundedPanel1.Controls.Add(Me.cmbDateFilter)
        Me.RoundedPanel1.Controls.Add(Me.dgvRecentTransactions)
        Me.RoundedPanel1.Controls.Add(Me.Label4)
        Me.RoundedPanel1.Location = New System.Drawing.Point(32, 84)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1073, 600)
        Me.RoundedPanel1.TabIndex = 18
        '
        'btnClearSelection
        '
        Me.btnClearSelection.BackColor = System.Drawing.Color.Black
        Me.btnClearSelection.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClearSelection.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSelection.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnClearSelection.Location = New System.Drawing.Point(209, 530)
        Me.btnClearSelection.Name = "btnClearSelection"
        Me.btnClearSelection.Size = New System.Drawing.Size(170, 52)
        Me.btnClearSelection.TabIndex = 35
        Me.btnClearSelection.Text = "Clear Selection"
        Me.btnClearSelection.UseVisualStyleBackColor = False
        '
        'btnSendReminder
        '
        Me.btnSendReminder.BackColor = System.Drawing.Color.DarkRed
        Me.btnSendReminder.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSendReminder.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendReminder.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSendReminder.Location = New System.Drawing.Point(33, 530)
        Me.btnSendReminder.Name = "btnSendReminder"
        Me.btnSendReminder.Size = New System.Drawing.Size(170, 52)
        Me.btnSendReminder.TabIndex = 34
        Me.btnSendReminder.Text = "Send Reminders"
        Me.btnSendReminder.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(396, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Filter by date"
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Location = New System.Drawing.Point(222, 70)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 20)
        Me.btnSearch.TabIndex = 32
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(33, 70)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(183, 20)
        Me.txtSearch.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Search by Students / Book"
        '
        'cmbDateFilter
        '
        Me.cmbDateFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDateFilter.FormattingEnabled = True
        Me.cmbDateFilter.Items.AddRange(New Object() {"All", "Today", "Yesterday", "This Week"})
        Me.cmbDateFilter.Location = New System.Drawing.Point(399, 69)
        Me.cmbDateFilter.Name = "cmbDateFilter"
        Me.cmbDateFilter.Size = New System.Drawing.Size(278, 21)
        Me.cmbDateFilter.TabIndex = 29
        '
        'dgvRecentTransactions
        '
        Me.dgvRecentTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecentTransactions.Location = New System.Drawing.Point(33, 116)
        Me.dgvRecentTransactions.Name = "dgvRecentTransactions"
        Me.dgvRecentTransactions.Size = New System.Drawing.Size(884, 408)
        Me.dgvRecentTransactions.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(27, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(284, 31)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Recent Transactions"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(29, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(289, 18)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "View all book issue and return transactions"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(189, 24)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Transaction History"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'UC_transactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Name = "UC_transactions"
        Me.Size = New System.Drawing.Size(1130, 713)
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        CType(Me.dgvRecentTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvRecentTransactions As DataGridView
    Friend WithEvents cmbDateFilter As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnSendReminder As Button
    Friend WithEvents btnClearSelection As Button
End Class
