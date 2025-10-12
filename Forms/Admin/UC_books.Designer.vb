<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_books
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New Library_Management_App.RoundedPanel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnClearSelection = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDetails = New System.Windows.Forms.TextBox()
        Me.txtSeriesTitle = New System.Windows.Forms.TextBox()
        Me.txtISBN = New System.Windows.Forms.TextBox()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.btnAddBook = New System.Windows.Forms.Button()
        Me.btnEditBook = New System.Windows.Forms.Button()
        Me.dgvBooks = New System.Windows.Forms.DataGridView()
        Me.btnRemoveBook = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LibraryDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LibraryDataSet = New Library_Management_App.LibraryDataSet()
        Me.RoundedPanel1.SuspendLayout()
        CType(Me.dgvBooks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LibraryDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LibraryDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(29, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(253, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Manage your library's book collection"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(194, 24)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Books Management"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.White
        Me.RoundedPanel1.Controls.Add(Me.btnSearch)
        Me.RoundedPanel1.Controls.Add(Me.txtSearch)
        Me.RoundedPanel1.Controls.Add(Me.btnClearSelection)
        Me.RoundedPanel1.Controls.Add(Me.Label8)
        Me.RoundedPanel1.Controls.Add(Me.Label7)
        Me.RoundedPanel1.Controls.Add(Me.Label6)
        Me.RoundedPanel1.Controls.Add(Me.Label5)
        Me.RoundedPanel1.Controls.Add(Me.Label1)
        Me.RoundedPanel1.Controls.Add(Me.txtDetails)
        Me.RoundedPanel1.Controls.Add(Me.txtSeriesTitle)
        Me.RoundedPanel1.Controls.Add(Me.txtISBN)
        Me.RoundedPanel1.Controls.Add(Me.txtAuthor)
        Me.RoundedPanel1.Controls.Add(Me.txtTitle)
        Me.RoundedPanel1.Controls.Add(Me.btnAddBook)
        Me.RoundedPanel1.Controls.Add(Me.btnEditBook)
        Me.RoundedPanel1.Controls.Add(Me.dgvBooks)
        Me.RoundedPanel1.Controls.Add(Me.btnRemoveBook)
        Me.RoundedPanel1.Controls.Add(Me.Label4)
        Me.RoundedPanel1.Location = New System.Drawing.Point(32, 81)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1073, 600)
        Me.RoundedPanel1.TabIndex = 12
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Location = New System.Drawing.Point(222, 87)
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
        Me.txtSearch.Size = New System.Drawing.Size(183, 20)
        Me.txtSearch.TabIndex = 25
        '
        'btnClearSelection
        '
        Me.btnClearSelection.BackColor = System.Drawing.Color.Black
        Me.btnClearSelection.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClearSelection.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSelection.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnClearSelection.Location = New System.Drawing.Point(362, 18)
        Me.btnClearSelection.Name = "btnClearSelection"
        Me.btnClearSelection.Size = New System.Drawing.Size(170, 52)
        Me.btnClearSelection.TabIndex = 24
        Me.btnClearSelection.Text = "Clear Selection"
        Me.btnClearSelection.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(835, 529)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Details"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(634, 529)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Series Title"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(433, 529)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "ISBN"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(232, 529)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Author"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 529)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Title"
        '
        'txtDetails
        '
        Me.txtDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetails.Location = New System.Drawing.Point(838, 546)
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.Size = New System.Drawing.Size(195, 20)
        Me.txtDetails.TabIndex = 18
        '
        'txtSeriesTitle
        '
        Me.txtSeriesTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSeriesTitle.Location = New System.Drawing.Point(637, 546)
        Me.txtSeriesTitle.Name = "txtSeriesTitle"
        Me.txtSeriesTitle.Size = New System.Drawing.Size(195, 20)
        Me.txtSeriesTitle.TabIndex = 17
        '
        'txtISBN
        '
        Me.txtISBN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtISBN.Location = New System.Drawing.Point(436, 546)
        Me.txtISBN.Name = "txtISBN"
        Me.txtISBN.Size = New System.Drawing.Size(195, 20)
        Me.txtISBN.TabIndex = 16
        '
        'txtAuthor
        '
        Me.txtAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAuthor.Location = New System.Drawing.Point(235, 546)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(195, 20)
        Me.txtAuthor.TabIndex = 15
        '
        'txtTitle
        '
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTitle.Location = New System.Drawing.Point(34, 546)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(195, 20)
        Me.txtTitle.TabIndex = 14
        '
        'btnAddBook
        '
        Me.btnAddBook.BackColor = System.Drawing.Color.DarkGreen
        Me.btnAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddBook.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddBook.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAddBook.Location = New System.Drawing.Point(538, 18)
        Me.btnAddBook.Name = "btnAddBook"
        Me.btnAddBook.Size = New System.Drawing.Size(170, 52)
        Me.btnAddBook.TabIndex = 13
        Me.btnAddBook.Text = "Add New Book"
        Me.btnAddBook.UseVisualStyleBackColor = False
        '
        'btnEditBook
        '
        Me.btnEditBook.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnEditBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditBook.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditBook.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnEditBook.Location = New System.Drawing.Point(714, 18)
        Me.btnEditBook.Name = "btnEditBook"
        Me.btnEditBook.Size = New System.Drawing.Size(170, 52)
        Me.btnEditBook.TabIndex = 12
        Me.btnEditBook.Text = "Edit Book"
        Me.btnEditBook.UseVisualStyleBackColor = False
        '
        'dgvBooks
        '
        Me.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBooks.Location = New System.Drawing.Point(33, 166)
        Me.dgvBooks.Name = "dgvBooks"
        Me.dgvBooks.Size = New System.Drawing.Size(999, 347)
        Me.dgvBooks.TabIndex = 11
        '
        'btnRemoveBook
        '
        Me.btnRemoveBook.BackColor = System.Drawing.Color.DarkRed
        Me.btnRemoveBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemoveBook.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveBook.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnRemoveBook.Location = New System.Drawing.Point(890, 18)
        Me.btnRemoveBook.Name = "btnRemoveBook"
        Me.btnRemoveBook.Size = New System.Drawing.Size(170, 52)
        Me.btnRemoveBook.TabIndex = 10
        Me.btnRemoveBook.Text = "Remove Book"
        Me.btnRemoveBook.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(27, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(189, 31)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Book Catalog"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LibraryDataSetBindingSource
        '
        Me.LibraryDataSetBindingSource.DataSource = Me.LibraryDataSet
        Me.LibraryDataSetBindingSource.Position = 0
        '
        'LibraryDataSet
        '
        Me.LibraryDataSet.DataSetName = "LibraryDataSet"
        Me.LibraryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UC_books
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Name = "UC_books"
        Me.Size = New System.Drawing.Size(1130, 713)
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        CType(Me.dgvBooks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LibraryDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LibraryDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents btnRemoveBook As Button
    Friend WithEvents btnAddBook As Button
    Friend WithEvents btnEditBook As Button
    Friend WithEvents dgvBooks As DataGridView
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents txtISBN As TextBox
    Friend WithEvents txtSeriesTitle As TextBox
    Friend WithEvents txtDetails As TextBox
    Friend WithEvents LibraryDataSetBindingSource As BindingSource
    Friend WithEvents LibraryDataSet As LibraryDataSet
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnClearSelection As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
End Class
