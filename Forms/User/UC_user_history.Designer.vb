<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_user_history
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New Library_Management_App.RoundedPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbDateFilter = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnClearSelection = New System.Windows.Forms.Button()
        Me.btnReturnBook = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvBorrowedBooks = New System.Windows.Forms.DataGridView()
        Me.RoundedPanel1.SuspendLayout()
        CType(Me.dgvBorrowedBooks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(29, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(315, 18)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Track all your past transactions with the library."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(189, 24)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Transaction History"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.White
        Me.RoundedPanel1.Controls.Add(Me.dgvBorrowedBooks)
        Me.RoundedPanel1.Controls.Add(Me.Label5)
        Me.RoundedPanel1.Controls.Add(Me.cmbDateFilter)
        Me.RoundedPanel1.Controls.Add(Me.btnSearch)
        Me.RoundedPanel1.Controls.Add(Me.txtSearch)
        Me.RoundedPanel1.Controls.Add(Me.btnClearSelection)
        Me.RoundedPanel1.Controls.Add(Me.btnReturnBook)
        Me.RoundedPanel1.Controls.Add(Me.Label1)
        Me.RoundedPanel1.Location = New System.Drawing.Point(32, 84)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1073, 600)
        Me.RoundedPanel1.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(292, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Filter by date"
        '
        'cmbDateFilter
        '
        Me.cmbDateFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDateFilter.FormattingEnabled = True
        Me.cmbDateFilter.Items.AddRange(New Object() {"All", "Today", "Yesterday", "This Week"})
        Me.cmbDateFilter.Location = New System.Drawing.Point(295, 66)
        Me.cmbDateFilter.Name = "cmbDateFilter"
        Me.cmbDateFilter.Size = New System.Drawing.Size(278, 21)
        Me.cmbDateFilter.TabIndex = 34
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Location = New System.Drawing.Point(237, 66)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(52, 20)
        Me.btnSearch.TabIndex = 33
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(25, 66)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(206, 20)
        Me.txtSearch.TabIndex = 32
        '
        'btnClearSelection
        '
        Me.btnClearSelection.BackColor = System.Drawing.Color.Black
        Me.btnClearSelection.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClearSelection.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSelection.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnClearSelection.Location = New System.Drawing.Point(595, 34)
        Me.btnClearSelection.Name = "btnClearSelection"
        Me.btnClearSelection.Size = New System.Drawing.Size(170, 52)
        Me.btnClearSelection.TabIndex = 25
        Me.btnClearSelection.Text = "Clear Selection"
        Me.btnClearSelection.UseVisualStyleBackColor = False
        '
        'btnReturnBook
        '
        Me.btnReturnBook.BackColor = System.Drawing.Color.DarkRed
        Me.btnReturnBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReturnBook.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturnBook.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnReturnBook.Location = New System.Drawing.Point(771, 34)
        Me.btnReturnBook.Name = "btnReturnBook"
        Me.btnReturnBook.Size = New System.Drawing.Size(170, 52)
        Me.btnReturnBook.TabIndex = 31
        Me.btnReturnBook.Text = "Return Book"
        Me.btnReturnBook.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(227, 31)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Borrowed Books"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'dgvBorrowedBooks
        '
        Me.dgvBorrowedBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBorrowedBooks.Location = New System.Drawing.Point(25, 124)
        Me.dgvBorrowedBooks.Name = "dgvBorrowedBooks"
        Me.dgvBorrowedBooks.Size = New System.Drawing.Size(694, 455)
        Me.dgvBorrowedBooks.TabIndex = 29
        '
        'UC_user_history
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Name = "UC_user_history"
        Me.Size = New System.Drawing.Size(1130, 713)
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        CType(Me.dgvBorrowedBooks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnReturnBook As Button
    Friend WithEvents btnClearSelection As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbDateFilter As ComboBox
    Friend WithEvents dgvBorrowedBooks As DataGridView
End Class
