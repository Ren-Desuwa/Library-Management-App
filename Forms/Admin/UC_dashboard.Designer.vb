<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_dashboard
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
        Me.components = New System.ComponentModel.Container()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RoundedPanel5 = New Library_Management_App.RoundedPanel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.RoundedPanel4 = New Library_Management_App.RoundedPanel()
        Me.lblAttention = New System.Windows.Forms.Label()
        Me.lblOverdue = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.RoundedPanel3 = New Library_Management_App.RoundedPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblBooksIssued = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.RoundedPanel2 = New Library_Management_App.RoundedPanel()
        Me.lblTotalStudents = New System.Windows.Forms.Label()
        Me.lblUpdateTotalStudents = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New Library_Management_App.RoundedPanel()
        Me.lblUpdateTotalBooks = New System.Windows.Forms.Label()
        Me.lblTotalBooks = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RoundedPanel5.SuspendLayout()
        Me.RoundedPanel4.SuspendLayout()
        Me.RoundedPanel3.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(217, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Good morning, Name!"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(29, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(295, 18)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Here's what's happening at the library today."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'RoundedPanel5
        '
        Me.RoundedPanel5.BackColor = System.Drawing.Color.White
        Me.RoundedPanel5.Controls.Add(Me.Label15)
        Me.RoundedPanel5.Location = New System.Drawing.Point(32, 296)
        Me.RoundedPanel5.Name = "RoundedPanel5"
        Me.RoundedPanel5.Size = New System.Drawing.Size(1025, 385)
        Me.RoundedPanel5.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(19, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(301, 31)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Make Announcements"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'RoundedPanel4
        '
        Me.RoundedPanel4.BackColor = System.Drawing.Color.White
        Me.RoundedPanel4.Controls.Add(Me.lblAttention)
        Me.RoundedPanel4.Controls.Add(Me.lblOverdue)
        Me.RoundedPanel4.Controls.Add(Me.Label13)
        Me.RoundedPanel4.Location = New System.Drawing.Point(825, 119)
        Me.RoundedPanel4.Name = "RoundedPanel4"
        Me.RoundedPanel4.Size = New System.Drawing.Size(232, 143)
        Me.RoundedPanel4.TabIndex = 8
        '
        'lblAttention
        '
        Me.lblAttention.AutoSize = True
        Me.lblAttention.BackColor = System.Drawing.Color.White
        Me.lblAttention.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttention.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblAttention.Location = New System.Drawing.Point(29, 100)
        Me.lblAttention.Name = "lblAttention"
        Me.lblAttention.Size = New System.Drawing.Size(98, 14)
        Me.lblAttention.TabIndex = 15
        Me.lblAttention.Text = "Needs Attention"
        Me.lblAttention.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblOverdue
        '
        Me.lblOverdue.AutoSize = True
        Me.lblOverdue.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverdue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblOverdue.Location = New System.Drawing.Point(26, 53)
        Me.lblOverdue.Name = "lblOverdue"
        Me.lblOverdue.Size = New System.Drawing.Size(30, 31)
        Me.lblOverdue.TabIndex = 14
        Me.lblOverdue.Text = "2"
        Me.lblOverdue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(30, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 18)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Overdue"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.BackColor = System.Drawing.Color.White
        Me.RoundedPanel3.Controls.Add(Me.Label11)
        Me.RoundedPanel3.Controls.Add(Me.lblBooksIssued)
        Me.RoundedPanel3.Controls.Add(Me.Label10)
        Me.RoundedPanel3.Location = New System.Drawing.Point(565, 119)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(232, 143)
        Me.RoundedPanel3.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(24, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 14)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Today"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblBooksIssued
        '
        Me.lblBooksIssued.AutoSize = True
        Me.lblBooksIssued.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBooksIssued.ForeColor = System.Drawing.Color.Black
        Me.lblBooksIssued.Location = New System.Drawing.Point(20, 53)
        Me.lblBooksIssued.Name = "lblBooksIssued"
        Me.lblBooksIssued.Size = New System.Drawing.Size(30, 31)
        Me.lblBooksIssued.TabIndex = 12
        Me.lblBooksIssued.Text = "7"
        Me.lblBooksIssued.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(24, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 18)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Books Issued"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.White
        Me.RoundedPanel2.Controls.Add(Me.lblTotalStudents)
        Me.RoundedPanel2.Controls.Add(Me.lblUpdateTotalStudents)
        Me.RoundedPanel2.Controls.Add(Me.Label5)
        Me.RoundedPanel2.Controls.Add(Me.Label6)
        Me.RoundedPanel2.Location = New System.Drawing.Point(295, 119)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(232, 143)
        Me.RoundedPanel2.TabIndex = 8
        '
        'lblTotalStudents
        '
        Me.lblTotalStudents.AutoSize = True
        Me.lblTotalStudents.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalStudents.ForeColor = System.Drawing.Color.Black
        Me.lblTotalStudents.Location = New System.Drawing.Point(23, 53)
        Me.lblTotalStudents.Name = "lblTotalStudents"
        Me.lblTotalStudents.Size = New System.Drawing.Size(30, 31)
        Me.lblTotalStudents.TabIndex = 13
        Me.lblTotalStudents.Text = "7"
        Me.lblTotalStudents.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblUpdateTotalStudents
        '
        Me.lblUpdateTotalStudents.AutoSize = True
        Me.lblUpdateTotalStudents.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateTotalStudents.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblUpdateTotalStudents.Location = New System.Drawing.Point(21, 100)
        Me.lblUpdateTotalStudents.Name = "lblUpdateTotalStudents"
        Me.lblUpdateTotalStudents.Size = New System.Drawing.Size(79, 14)
        Me.lblUpdateTotalStudents.TabIndex = 10
        Me.lblUpdateTotalStudents.Text = "+5 this week"
        Me.lblUpdateTotalStudents.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(17, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 31)
        Me.Label5.TabIndex = 10
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(21, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 18)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Students"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.White
        Me.RoundedPanel1.Controls.Add(Me.lblUpdateTotalBooks)
        Me.RoundedPanel1.Controls.Add(Me.lblTotalBooks)
        Me.RoundedPanel1.Controls.Add(Me.Label1)
        Me.RoundedPanel1.Location = New System.Drawing.Point(32, 119)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(232, 143)
        Me.RoundedPanel1.TabIndex = 7
        '
        'lblUpdateTotalBooks
        '
        Me.lblUpdateTotalBooks.AutoSize = True
        Me.lblUpdateTotalBooks.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateTotalBooks.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblUpdateTotalBooks.Location = New System.Drawing.Point(25, 100)
        Me.lblUpdateTotalBooks.Name = "lblUpdateTotalBooks"
        Me.lblUpdateTotalBooks.Size = New System.Drawing.Size(86, 14)
        Me.lblUpdateTotalBooks.TabIndex = 9
        Me.lblUpdateTotalBooks.Text = "+14 this week"
        Me.lblUpdateTotalBooks.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblTotalBooks
        '
        Me.lblTotalBooks.AutoSize = True
        Me.lblTotalBooks.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBooks.ForeColor = System.Drawing.Color.Black
        Me.lblTotalBooks.Location = New System.Drawing.Point(19, 53)
        Me.lblTotalBooks.Name = "lblTotalBooks"
        Me.lblTotalBooks.Size = New System.Drawing.Size(0, 31)
        Me.lblTotalBooks.TabIndex = 8
        Me.lblTotalBooks.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(25, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 18)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Total Books"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'UC_dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.RoundedPanel5)
        Me.Controls.Add(Me.RoundedPanel4)
        Me.Controls.Add(Me.RoundedPanel3)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Name = "UC_dashboard"
        Me.Size = New System.Drawing.Size(1130, 713)
        Me.RoundedPanel5.ResumeLayout(False)
        Me.RoundedPanel5.PerformLayout()
        Me.RoundedPanel4.ResumeLayout(False)
        Me.RoundedPanel4.PerformLayout()
        Me.RoundedPanel3.ResumeLayout(False)
        Me.RoundedPanel3.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents RoundedPanel2 As RoundedPanel
    Friend WithEvents RoundedPanel3 As RoundedPanel
    Friend WithEvents RoundedPanel4 As RoundedPanel
    Friend WithEvents lblTotalBooks As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblUpdateTotalStudents As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblUpdateTotalBooks As Label
    Friend WithEvents lblOverdue As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblBooksIssued As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblAttention As Label
    Friend WithEvents RoundedPanel5 As RoundedPanel
    Friend WithEvents Label15 As Label
    Friend WithEvents lblTotalStudents As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
End Class
