<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login_Panel
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
        Me.lbl_login = New System.Windows.Forms.Label()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.lbl_password = New System.Windows.Forms.Label()
        Me.albl_link_to_signup = New System.Windows.Forms.LinkLabel()
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
        Me.btn_login.Text = "Login"
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
        'lbl_login
        '
        Me.lbl_login.AutoSize = True
        Me.lbl_login.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_login.Location = New System.Drawing.Point(97, 35)
        Me.lbl_login.Name = "lbl_login"
        Me.lbl_login.Size = New System.Drawing.Size(110, 42)
        Me.lbl_login.TabIndex = 4
        Me.lbl_login.Text = "Login"
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
        'albl_link_to_signup
        '
        Me.albl_link_to_signup.AutoSize = True
        Me.albl_link_to_signup.Location = New System.Drawing.Point(268, 245)
        Me.albl_link_to_signup.Name = "albl_link_to_signup"
        Me.albl_link_to_signup.Size = New System.Drawing.Size(45, 13)
        Me.albl_link_to_signup.TabIndex = 7
        Me.albl_link_to_signup.TabStop = True
        Me.albl_link_to_signup.Text = "Sign Up"
        '
        'Login_Panel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 450)
        Me.Controls.Add(Me.albl_link_to_signup)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.lbl_password)
        Me.Controls.Add(Me.lbl_login)
        Me.Controls.Add(Me.txt_username)
        Me.Controls.Add(Me.lbl_username)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.lbl_cancel)
        Me.Name = "Login_Panel"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_cancel As Button
    Friend WithEvents btn_login As Button
    Friend WithEvents lbl_username As Label
    Friend WithEvents txt_username As TextBox
    Friend WithEvents lbl_login As Label
    Friend WithEvents txt_password As TextBox
    Friend WithEvents lbl_password As Label
    Friend WithEvents albl_link_to_signup As LinkLabel
End Class
