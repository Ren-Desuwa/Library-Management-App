<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SignUp_Panel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.lbl_cancel = New System.Windows.Forms.Button()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.lbl_username = New System.Windows.Forms.Label()
        Me.txt_username = New System.Windows.Forms.TextBox()
        Me.lbl_SignUp = New System.Windows.Forms.Label()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.lbl_password = New System.Windows.Forms.Label()
        Me.albl_link_to_login = New System.Windows.Forms.LinkLabel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lbl_confirm_password = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_cancel
        '
        Me.lbl_cancel.Location = New System.Drawing.Point(13, 390)
        Me.lbl_cancel.Name = "lbl_cancel"
        Me.lbl_cancel.Size = New System.Drawing.Size(128, 48)
        Me.lbl_cancel.TabIndex = 0
        Me.lbl_cancel.Text = "Cancel"
        Me.lbl_cancel.UseVisualStyleBackColor = True
        '
        'btn_login
        '
        Me.btn_login.Location = New System.Drawing.Point(201, 390)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(128, 48)
        Me.btn_login.TabIndex = 1
        Me.btn_login.Text = "Sign Up"
        Me.btn_login.UseVisualStyleBackColor = True
        '
        'lbl_username
        '
        Me.lbl_username.AutoSize = True
        Me.lbl_username.Location = New System.Drawing.Point(11, 135)
        Me.lbl_username.Name = "lbl_username"
        Me.lbl_username.Size = New System.Drawing.Size(55, 13)
        Me.lbl_username.TabIndex = 2
        Me.lbl_username.Text = "Username"
        '
        'txt_username
        '
        Me.txt_username.Location = New System.Drawing.Point(12, 151)
        Me.txt_username.Name = "txt_username"
        Me.txt_username.Size = New System.Drawing.Size(316, 20)
        Me.txt_username.TabIndex = 3
        '
        'lbl_SignUp
        '
        Me.lbl_SignUp.AutoSize = True
        Me.lbl_SignUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SignUp.Location = New System.Drawing.Point(97, 35)
        Me.lbl_SignUp.Name = "lbl_SignUp"
        Me.lbl_SignUp.Size = New System.Drawing.Size(151, 42)
        Me.lbl_SignUp.TabIndex = 4
        Me.lbl_SignUp.Text = "Sign Up"
        '
        'txt_password
        '
        Me.txt_password.Location = New System.Drawing.Point(11, 213)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.Size = New System.Drawing.Size(316, 20)
        Me.txt_password.TabIndex = 6
        '
        'lbl_password
        '
        Me.lbl_password.AutoSize = True
        Me.lbl_password.Location = New System.Drawing.Point(10, 197)
        Me.lbl_password.Name = "lbl_password"
        Me.lbl_password.Size = New System.Drawing.Size(53, 13)
        Me.lbl_password.TabIndex = 5
        Me.lbl_password.Text = "Password"
        '
        'albl_link_to_login
        '
        Me.albl_link_to_login.AutoSize = True
        Me.albl_link_to_login.Location = New System.Drawing.Point(194, 289)
        Me.albl_link_to_login.Name = "albl_link_to_login"
        Me.albl_link_to_login.Size = New System.Drawing.Size(133, 13)
        Me.albl_link_to_login.TabIndex = 7
        Me.albl_link_to_login.TabStop = True
        Me.albl_link_to_login.Text = "Already have an Account?"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(11, 257)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(316, 20)
        Me.TextBox1.TabIndex = 9
        '
        'lbl_confirm_password
        '
        Me.lbl_confirm_password.AutoSize = True
        Me.lbl_confirm_password.Location = New System.Drawing.Point(10, 241)
        Me.lbl_confirm_password.Name = "lbl_confirm_password"
        Me.lbl_confirm_password.Size = New System.Drawing.Size(91, 13)
        Me.lbl_confirm_password.TabIndex = 8
        Me.lbl_confirm_password.Text = "Confirm Password"
        '
        'SignUp_Panel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 450)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lbl_confirm_password)
        Me.Controls.Add(Me.albl_link_to_login)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.lbl_password)
        Me.Controls.Add(Me.lbl_SignUp)
        Me.Controls.Add(Me.txt_username)
        Me.Controls.Add(Me.lbl_username)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.lbl_cancel)
        Me.Name = "SignUp_Panel"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_cancel As Button
    Friend WithEvents btn_login As Button
    Friend WithEvents lbl_username As Label
    Friend WithEvents txt_username As TextBox
    Friend WithEvents lbl_SignUp As Label
    Friend WithEvents txt_password As TextBox
    Friend WithEvents lbl_password As Label
    Friend WithEvents albl_link_to_login As LinkLabel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lbl_confirm_password As Label
End Class
