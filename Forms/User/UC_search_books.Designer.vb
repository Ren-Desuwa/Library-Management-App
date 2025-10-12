<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_search_books
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New Library_Management_App.RoundedPanel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnClearSelection = New System.Windows.Forms.Button()
        Me.btnBorrowBook = New System.Windows.Forms.Button()
        Me.dgvBooks = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RoundedPanel1.SuspendLayout()
        CType(Me.dgvBooks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(31, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(344, 18)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Search by title, author, or category to locate books."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 24)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Browse Books"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.White
        Me.RoundedPanel1.Controls.Add(Me.btnSearch)
        Me.RoundedPanel1.Controls.Add(Me.txtSearch)
        Me.RoundedPanel1.Controls.Add(Me.btnClearSelection)
        Me.RoundedPanel1.Controls.Add(Me.btnBorrowBook)
        Me.RoundedPanel1.Controls.Add(Me.dgvBooks)
        Me.RoundedPanel1.Controls.Add(Me.Label4)
        Me.RoundedPanel1.Location = New System.Drawing.Point(32, 70)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1073, 600)
        Me.RoundedPanel1.TabIndex = 19
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Location = New System.Drawing.Point(349, 87)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 20)
        Me.btnSearch.TabIndex = 26
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(33, 87)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(310, 20)
        Me.txtSearch.TabIndex = 25
        '
        'btnClearSelection
        '
        Me.btnClearSelection.BackColor = System.Drawing.Color.Black
        Me.btnClearSelection.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClearSelection.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSelection.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnClearSelection.Location = New System.Drawing.Point(714, 13)
        Me.btnClearSelection.Name = "btnClearSelection"
        Me.btnClearSelection.Size = New System.Drawing.Size(170, 52)
        Me.btnClearSelection.TabIndex = 24
        Me.btnClearSelection.Text = "Clear Selection"
        Me.btnClearSelection.UseVisualStyleBackColor = False
        '
        'btnBorrowBook
        '
        Me.btnBorrowBook.BackColor = System.Drawing.Color.DarkGreen
        Me.btnBorrowBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBorrowBook.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrowBook.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnBorrowBook.Location = New System.Drawing.Point(890, 13)
        Me.btnBorrowBook.Name = "btnBorrowBook"
        Me.btnBorrowBook.Size = New System.Drawing.Size(170, 52)
        Me.btnBorrowBook.TabIndex = 13
        Me.btnBorrowBook.Text = "Borrow Book"
        Me.btnBorrowBook.UseVisualStyleBackColor = False
        '
        'dgvBooks
        '
        Me.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBooks.Location = New System.Drawing.Point(33, 166)
        Me.dgvBooks.Name = "dgvBooks"
        Me.dgvBooks.Size = New System.Drawing.Size(851, 412)
        Me.dgvBooks.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(27, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(189, 31)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Book Catalog"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'UC_search_books
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Name = "UC_search_books"
        Me.Size = New System.Drawing.Size(1130, 713)
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        CType(Me.dgvBooks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnClearSelection As Button
    Friend WithEvents btnBorrowBook As Button
    Friend WithEvents dgvBooks As DataGridView
    Friend WithEvents Label4 As Label
End Class
