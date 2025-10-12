<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_Members
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.RoundedPanel1 = New Library_Management_App.RoundedPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbDateFilterJoined = New System.Windows.Forms.ComboBox()
        Me.txtSearchStudents = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvMembers = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RoundedPanel1.SuspendLayout()
        CType(Me.dgvMembers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.White
        Me.RoundedPanel1.Controls.Add(Me.Label5)
        Me.RoundedPanel1.Controls.Add(Me.btnSearch)
        Me.RoundedPanel1.Controls.Add(Me.cmbDateFilterJoined)
        Me.RoundedPanel1.Controls.Add(Me.txtSearchStudents)
        Me.RoundedPanel1.Controls.Add(Me.Label1)
        Me.RoundedPanel1.Controls.Add(Me.dgvMembers)
        Me.RoundedPanel1.Controls.Add(Me.Label4)
        Me.RoundedPanel1.Location = New System.Drawing.Point(32, 84)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1073, 600)
        Me.RoundedPanel1.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(398, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Filter by Date Registered"
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Location = New System.Drawing.Point(222, 76)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 20)
        Me.btnSearch.TabIndex = 35
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbDateFilterJoined
        '
        Me.cmbDateFilterJoined.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDateFilterJoined.FormattingEnabled = True
        Me.cmbDateFilterJoined.Items.AddRange(New Object() {"All", "Today", "Yesterday", "This Week"})
        Me.cmbDateFilterJoined.Location = New System.Drawing.Point(401, 75)
        Me.cmbDateFilterJoined.Name = "cmbDateFilterJoined"
        Me.cmbDateFilterJoined.Size = New System.Drawing.Size(278, 21)
        Me.cmbDateFilterJoined.TabIndex = 34
        '
        'txtSearchStudents
        '
        Me.txtSearchStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchStudents.Location = New System.Drawing.Point(33, 76)
        Me.txtSearchStudents.Name = "txtSearchStudents"
        Me.txtSearchStudents.Size = New System.Drawing.Size(183, 20)
        Me.txtSearchStudents.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Search by Student ID / Students"
        '
        'dgvMembers
        '
        Me.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMembers.Location = New System.Drawing.Point(33, 126)
        Me.dgvMembers.Name = "dgvMembers"
        Me.dgvMembers.Size = New System.Drawing.Size(999, 347)
        Me.dgvMembers.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(27, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 31)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Students"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(29, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(296, 18)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Manage library members and their accounts"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(208, 24)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Student Management"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'UC_Members
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Name = "UC_Members"
        Me.Size = New System.Drawing.Size(1130, 713)
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        CType(Me.dgvMembers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvMembers As DataGridView
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearchStudents As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbDateFilterJoined As ComboBox
End Class
