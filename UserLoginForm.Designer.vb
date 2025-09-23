<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserLoginForm
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
        Me.panelUser = New System.Windows.Forms.Panel()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.btnUserLogin = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelUser
        '
        Me.panelUser.Controls.Add(Me.btnReturn)
        Me.panelUser.Controls.Add(Me.btnUserLogin)
        Me.panelUser.Controls.Add(Me.Label3)
        Me.panelUser.Controls.Add(Me.Label2)
        Me.panelUser.Controls.Add(Me.TxtPassword)
        Me.panelUser.Controls.Add(Me.TxtUser)
        Me.panelUser.Location = New System.Drawing.Point(46, 146)
        Me.panelUser.Name = "panelUser"
        Me.panelUser.Size = New System.Drawing.Size(701, 245)
        Me.panelUser.TabIndex = 5
        '
        'btnReturn
        '
        Me.btnReturn.Location = New System.Drawing.Point(6, 215)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(75, 23)
        Me.btnReturn.TabIndex = 5
        Me.btnReturn.Text = "Return"
        Me.btnReturn.UseVisualStyleBackColor = True
        '
        'btnUserLogin
        '
        Me.btnUserLogin.Location = New System.Drawing.Point(329, 140)
        Me.btnUserLogin.Name = "btnUserLogin"
        Me.btnUserLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnUserLogin.TabIndex = 4
        Me.btnUserLogin.Text = "Login"
        Me.btnUserLogin.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(223, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Password:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(223, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Username:"
        '
        'TxtPassword
        '
        Me.TxtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPassword.Location = New System.Drawing.Point(362, 77)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Size = New System.Drawing.Size(143, 31)
        Me.TxtPassword.TabIndex = 1
        '
        'TxtUser
        '
        Me.TxtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUser.Location = New System.Drawing.Point(362, 33)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.Size = New System.Drawing.Size(143, 31)
        Me.TxtUser.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(188, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(452, 86)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "📚 LibraryMS"
        '
        'UserLoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.panelUser)
        Me.Name = "UserLoginForm"
        Me.Text = "UserLoginForm"
        Me.panelUser.ResumeLayout(False)
        Me.panelUser.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelUser As Panel
    Friend WithEvents btnReturn As Button
    Friend WithEvents btnUserLogin As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents TxtUser As TextBox
    Friend WithEvents Label1 As Label
End Class
