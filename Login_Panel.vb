<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        tblMain = New TableLayoutPanel()
        Panel1 = New Panel()
        Label5 = New Label()
        Label4 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Label3 = New Label()
        TableLayoutPanel1 = New TableLayoutPanel()
        panelLoginCard = New RoundedPanel()
        tblLoginForm = New TableLayoutPanel()
        txtPassword = New TextBox()
        Label9 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        ComboBox1 = New ComboBox()
        Label8 = New Label()
        TextBox1 = New TextBox()
        CheckBox1 = New CheckBox()
        Button1 = New Button()
        TableLayoutPanel6 = New TableLayoutPanel()
        LinkLabel2 = New LinkLabel()
        LinkLabel1 = New LinkLabel()
        TableLayoutPanel2 = New TableLayoutPanel()
        RoundedPanel3 = New RoundedPanel()
        TableLayoutPanel5 = New TableLayoutPanel()
        Label13 = New Label()
        Label15 = New Label()
        RoundedPanel1 = New RoundedPanel()
        TableLayoutPanel3 = New TableLayoutPanel()
        Label11 = New Label()
        Label14 = New Label()
        RoundedPanel2 = New RoundedPanel()
        TableLayoutPanel4 = New TableLayoutPanel()
        Label10 = New Label()
        Label12 = New Label()
        tblMain.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        panelLoginCard.SuspendLayout()
        tblLoginForm.SuspendLayout()
        TableLayoutPanel6.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        RoundedPanel3.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        RoundedPanel1.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        RoundedPanel2.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' tblMain
        ' 
        tblMain.BackColor = SystemColors.ButtonFace
        tblMain.ColumnCount = 2
        tblMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60.0F))
        tblMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40.0F))
        tblMain.Controls.Add(Panel1, 0, 0)
        tblMain.Controls.Add(TableLayoutPanel1, 1, 0)
        tblMain.Dock = DockStyle.Fill
        tblMain.Location = New Point(0, 0)
        tblMain.Margin = New Padding(0)
        tblMain.Name = "tblMain"
        tblMain.Padding = New Padding(20)
        tblMain.RowCount = 1
        tblMain.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tblMain.Size = New Size(1384, 801)
        tblMain.TabIndex = 2
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label3)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(23, 23)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(800, 755)
        Panel1.TabIndex = 0
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ForeColor = SystemColors.ActiveCaptionText
        Label5.Location = New Point(57, 540)
        Label5.Name = "Label5"
        Label5.Size = New Size(401, 15)
        Label5.TabIndex = 5
        Label5.Text = "✔ Book Catalog Management     ✔ Member Tracking     ✔ Due Date Alerts"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.ControlDarkDark
        Label4.Location = New Point(58, 462)
        Label4.Name = "Label4"
        Label4.Size = New Size(401, 63)
        Label4.TabIndex = 4
        Label4.Text = "Manage books, track members, and streamline your" & vbCrLf & "library operations with our comprehensive management" & vbCrLf & "system."
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 45.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(50, 252)
        Label2.Name = "Label2"
        Label2.Size = New Size(517, 81)
        Label2.TabIndex = 2
        Label2.Text = "Welcome to Your"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(47, 170)
        Label1.Name = "Label1"
        Label1.Size = New Size(250, 47)
        Label1.TabIndex = 1
        Label1.Text = "📚 LibraryMS"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 45.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ControlDarkDark
        Label3.Location = New Point(50, 314)
        Label3.Name = "Label3"
        Label3.Size = New Size(452, 81)
        Label3.TabIndex = 3
        Label3.Text = "Library System"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 10.8581438F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 76.88266F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.0840626F))
        TableLayoutPanel1.Controls.Add(panelLoginCard, 1, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 1, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(829, 23)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 77.8656158F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 22.134388F))
        TableLayoutPanel1.Size = New Size(532, 755)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' panelLoginCard
        ' 
        panelLoginCard.BackColor = Color.White
        panelLoginCard.Controls.Add(tblLoginForm)
        panelLoginCard.Dock = DockStyle.Fill
        panelLoginCard.Location = New Point(63, 6)
        panelLoginCard.Margin = New Padding(6)
        panelLoginCard.MinimumSize = New Size(320, 420)
        panelLoginCard.Name = "panelLoginCard"
        panelLoginCard.Padding = New Padding(18)
        panelLoginCard.Size = New Size(397, 575)
        panelLoginCard.TabIndex = 0
        ' 
        ' tblLoginForm
        ' 
        tblLoginForm.ColumnCount = 1
        tblLoginForm.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        tblLoginForm.Controls.Add(txtPassword, 0, 6)
        tblLoginForm.Controls.Add(Label9, 0, 5)
        tblLoginForm.Controls.Add(Label6, 0, 0)
        tblLoginForm.Controls.Add(Label7, 0, 1)
        tblLoginForm.Controls.Add(ComboBox1, 0, 2)
        tblLoginForm.Controls.Add(Label8, 0, 3)
        tblLoginForm.Controls.Add(TextBox1, 0, 4)
        tblLoginForm.Controls.Add(CheckBox1, 0, 7)
        tblLoginForm.Controls.Add(Button1, 0, 8)
        tblLoginForm.Controls.Add(TableLayoutPanel6, 0, 9)
        tblLoginForm.Dock = DockStyle.Fill
        tblLoginForm.Location = New Point(18, 18)
        tblLoginForm.Name = "tblLoginForm"
        tblLoginForm.RowCount = 10
        tblLoginForm.RowStyles.Add(New RowStyle(SizeType.Percent, 27.8350525F))
        tblLoginForm.RowStyles.Add(New RowStyle(SizeType.Percent, 10.6557379F))
        tblLoginForm.RowStyles.Add(New RowStyle(SizeType.Percent, 61.47541F))
        tblLoginForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 17.0F))
        tblLoginForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0F))
        tblLoginForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 16.0F))
        tblLoginForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 32.0F))
        tblLoginForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 29.0F))
        tblLoginForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 227.0F))
        tblLoginForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 26.0F))
        tblLoginForm.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0F))
        tblLoginForm.Size = New Size(361, 539)
        tblLoginForm.TabIndex = 0
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Dock = DockStyle.Fill
        txtPassword.Location = New Point(3, 227)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(355, 23)
        txtPassword.TabIndex = 6
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Dock = DockStyle.Fill
        Label9.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = SystemColors.ActiveCaptionText
        Label9.Location = New Point(3, 208)
        Label9.Name = "Label9"
        Label9.Size = New Size(355, 16)
        Label9.TabIndex = 5
        Label9.Text = "Password"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Dock = DockStyle.Fill
        Label6.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(3, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(355, 45)
        Label6.TabIndex = 0
        Label6.Text = "Sign In"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Dock = DockStyle.Fill
        Label7.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = SystemColors.ActiveCaptionText
        Label7.Location = New Point(3, 45)
        Label7.Name = "Label7"
        Label7.Size = New Size(355, 17)
        Label7.TabIndex = 1
        Label7.Text = "Login As"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Dock = DockStyle.Fill
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Librarian", "Student"})
        ComboBox1.Location = New Point(3, 65)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(355, 23)
        ComboBox1.TabIndex = 2
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Dock = DockStyle.Fill
        Label8.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = SystemColors.ActiveCaptionText
        Label8.Location = New Point(3, 161)
        Label8.Name = "Label8"
        Label8.Size = New Size(355, 17)
        Label8.TabIndex = 3
        Label8.Text = "User ID"
        ' 
        ' TextBox1
        ' 
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Dock = DockStyle.Fill
        TextBox1.ForeColor = Color.Gray
        TextBox1.Location = New Point(3, 181)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(355, 23)
        TextBox1.TabIndex = 4
        TextBox1.Text = "Enter User ID"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Dock = DockStyle.Right
        CheckBox1.Location = New Point(250, 259)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(108, 23)
        CheckBox1.TabIndex = 7
        CheckBox1.Text = "Show Password"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.AutoSize = True
        Button1.BackColor = Color.Black
        Button1.Dock = DockStyle.Bottom
        Button1.ForeColor = SystemColors.ButtonFace
        Button1.Location = New Point(3, 484)
        Button1.Name = "Button1"
        Button1.Size = New Size(355, 25)
        Button1.TabIndex = 8
        Button1.Text = "Sign In"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TableLayoutPanel6
        ' 
        TableLayoutPanel6.ColumnCount = 2
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel6.Controls.Add(LinkLabel2, 1, 0)
        TableLayoutPanel6.Controls.Add(LinkLabel1, 0, 0)
        TableLayoutPanel6.Dock = DockStyle.Fill
        TableLayoutPanel6.Location = New Point(3, 515)
        TableLayoutPanel6.Name = "TableLayoutPanel6"
        TableLayoutPanel6.RowCount = 1
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel6.Size = New Size(355, 21)
        TableLayoutPanel6.TabIndex = 9
        ' 
        ' LinkLabel2
        ' 
        LinkLabel2.ActiveLinkColor = Color.Transparent
        LinkLabel2.AutoSize = True
        LinkLabel2.BackColor = Color.Silver
        LinkLabel2.Dock = DockStyle.Fill
        LinkLabel2.LinkBehavior = LinkBehavior.NeverUnderline
        LinkLabel2.LinkColor = Color.Black
        LinkLabel2.Location = New Point(180, 0)
        LinkLabel2.Name = "LinkLabel2"
        LinkLabel2.Size = New Size(172, 21)
        LinkLabel2.TabIndex = 1
        LinkLabel2.TabStop = True
        LinkLabel2.Text = "Forgot Password?"
        LinkLabel2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.ActiveLinkColor = Color.Transparent
        LinkLabel1.AutoSize = True
        LinkLabel1.BackColor = Color.Silver
        LinkLabel1.Dock = DockStyle.Fill
        LinkLabel1.LinkBehavior = LinkBehavior.NeverUnderline
        LinkLabel1.LinkColor = Color.Black
        LinkLabel1.Location = New Point(3, 0)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(171, 21)
        LinkLabel1.TabIndex = 0
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Create Account"
        LinkLabel1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.AutoSize = True
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.Controls.Add(RoundedPanel3, 2, 0)
        TableLayoutPanel2.Controls.Add(RoundedPanel1, 0, 0)
        TableLayoutPanel2.Controls.Add(RoundedPanel2, 1, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(60, 590)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel2.Size = New Size(403, 162)
        TableLayoutPanel2.TabIndex = 1
        ' 
        ' RoundedPanel3
        ' 
        RoundedPanel3.BackColor = Color.White
        RoundedPanel3.Controls.Add(TableLayoutPanel5)
        RoundedPanel3.Dock = DockStyle.Fill
        RoundedPanel3.Location = New Point(271, 3)
        RoundedPanel3.Name = "RoundedPanel3"
        RoundedPanel3.Size = New Size(129, 156)
        RoundedPanel3.TabIndex = 2
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.ColumnCount = 1
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel5.Controls.Add(Label13, 0, 0)
        TableLayoutPanel5.Controls.Add(Label15, 0, 1)
        TableLayoutPanel5.Dock = DockStyle.Fill
        TableLayoutPanel5.Location = New Point(0, 0)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 2
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel5.Size = New Size(129, 156)
        TableLayoutPanel5.TabIndex = 1
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Dock = DockStyle.Bottom
        Label13.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(3, 58)
        Label13.Name = "Label13"
        Label13.Size = New Size(123, 20)
        Label13.TabIndex = 1
        Label13.Text = "12"
        Label13.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Dock = DockStyle.Top
        Label15.ForeColor = SystemColors.ControlDarkDark
        Label15.Location = New Point(3, 78)
        Label15.Name = "Label15"
        Label15.Size = New Size(123, 15)
        Label15.TabIndex = 2
        Label15.Text = "Due Today"
        Label15.TextAlign = ContentAlignment.TopCenter
        ' 
        ' RoundedPanel1
        ' 
        RoundedPanel1.BackColor = Color.White
        RoundedPanel1.Controls.Add(TableLayoutPanel3)
        RoundedPanel1.Dock = DockStyle.Fill
        RoundedPanel1.Location = New Point(3, 3)
        RoundedPanel1.Name = "RoundedPanel1"
        RoundedPanel1.Size = New Size(128, 156)
        RoundedPanel1.TabIndex = 0
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel3.Controls.Add(Label11, 0, 0)
        TableLayoutPanel3.Controls.Add(Label14, 0, 1)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(0, 0)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 2
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel3.Size = New Size(128, 156)
        TableLayoutPanel3.TabIndex = 2
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Dock = DockStyle.Bottom
        Label11.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(3, 58)
        Label11.Name = "Label11"
        Label11.Size = New Size(122, 20)
        Label11.TabIndex = 1
        Label11.Text = "1,184"
        Label11.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Dock = DockStyle.Top
        Label14.ForeColor = SystemColors.ControlDarkDark
        Label14.Location = New Point(3, 78)
        Label14.Name = "Label14"
        Label14.Size = New Size(122, 15)
        Label14.TabIndex = 2
        Label14.Text = "Total Books"
        Label14.TextAlign = ContentAlignment.TopCenter
        ' 
        ' RoundedPanel2
        ' 
        RoundedPanel2.BackColor = Color.White
        RoundedPanel2.Controls.Add(TableLayoutPanel4)
        RoundedPanel2.Dock = DockStyle.Fill
        RoundedPanel2.Location = New Point(137, 3)
        RoundedPanel2.Name = "RoundedPanel2"
        RoundedPanel2.Size = New Size(128, 156)
        RoundedPanel2.TabIndex = 1
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 1
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel4.Controls.Add(Label10, 0, 0)
        TableLayoutPanel4.Controls.Add(Label12, 0, 1)
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(0, 0)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 2
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        TableLayoutPanel4.Size = New Size(128, 156)
        TableLayoutPanel4.TabIndex = 1
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Dock = DockStyle.Bottom
        Label10.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(3, 58)
        Label10.Name = "Label10"
        Label10.Size = New Size(122, 20)
        Label10.TabIndex = 1
        Label10.Text = "342"
        Label10.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Dock = DockStyle.Top
        Label12.ForeColor = SystemColors.ControlDarkDark
        Label12.Location = New Point(3, 78)
        Label12.Name = "Label12"
        Label12.Size = New Size(122, 15)
        Label12.TabIndex = 2
        Label12.Text = "Members"
        Label12.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1384, 801)
        Controls.Add(tblMain)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Main"
        tblMain.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        panelLoginCard.ResumeLayout(False)
        tblLoginForm.ResumeLayout(False)
        tblLoginForm.PerformLayout()
        TableLayoutPanel6.ResumeLayout(False)
        TableLayoutPanel6.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        RoundedPanel3.ResumeLayout(False)
        TableLayoutPanel5.ResumeLayout(False)
        TableLayoutPanel5.PerformLayout()
        RoundedPanel1.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        RoundedPanel2.ResumeLayout(False)
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel4.PerformLayout()
        ResumeLayout(False)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)
        ' Enable smooth edges
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Panel rectangle
        Dim rect As New Rectangle(0, 0, Panel1.Width - 1, Panel1.Height - 1)

        ' Draw shadow
        Using shadowBrush As New SolidBrush(Color.FromArgb(50, Color.Black))
            e.Graphics.FillRectangle(shadowBrush, rect.X + 5, rect.Y + 5, rect.Width, rect.Height)
        End Using

        ' Draw rounded rectangle
        Dim path As New Drawing2D.GraphicsPath
        Dim radius = 20
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        ' Fill background
        Using brush As New SolidBrush(Color.White)
            e.Graphics.FillPath(brush, path)
        End Using

        ' Border
        Using pen As New Pen(Color.LightGray, 2)
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        If CheckBox1.Checked Then
            txtPassword.UseSystemPasswordChar = False  ' show password
        Else
            txtPassword.UseSystemPasswordChar = True   ' hide password
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs)
        If TextBox1.Text = "Enter User ID" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs)
        If TextBox1.Text = "" Then
            TextBox1.Text = "Enter User ID"
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim frm As New Form2
        frm.Show()
        Hide() ' hides current form (optional)
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Friend WithEvents tblMain As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents panelLoginCard As RoundedPanel
    Friend WithEvents tblLoginForm As TableLayoutPanel
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents RoundedPanel3 As RoundedPanel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents RoundedPanel2 As RoundedPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim frm As New Form2()
        frm.Show()
        Me.Hide() ' hides current form (optional)
    End Sub
End Class