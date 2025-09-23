<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminLoginForm
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
        Me.panelAdmin = New System.Windows.Forms.Panel()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.btnAdminLogin = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAdminPassword = New System.Windows.Forms.TextBox()
        Me.txtAdminUsername = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelAdmin.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelAdmin
        '
        Me.panelAdmin.Controls.Add(Me.btnReturn)
        Me.panelAdmin.Controls.Add(Me.btnAdminLogin)
        Me.panelAdmin.Controls.Add(Me.Label4)
        Me.panelAdmin.Controls.Add(Me.Label5)
        Me.panelAdmin.Controls.Add(Me.txtAdminPassword)
        Me.panelAdmin.Controls.Add(Me.txtAdminUsername)
        Me.panelAdmin.Location = New System.Drawing.Point(52, 152)
        Me.panelAdmin.Name = "panelAdmin"
        Me.panelAdmin.Size = New System.Drawing.Size(701, 245)
        Me.panelAdmin.TabIndex = 7
        '
        'btnReturn
        '
        Me.btnReturn.Location = New System.Drawing.Point(6, 215)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(75, 23)
        Me.btnReturn.TabIndex = 7
        Me.btnReturn.Text = "Return"
        Me.btnReturn.UseVisualStyleBackColor = True
        '
        'btnAdminLogin
        '
        Me.btnAdminLogin.Location = New System.Drawing.Point(315, 164)
        Me.btnAdminLogin.Name = "btnAdminLogin"
        Me.btnAdminLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnAdminLogin.TabIndex = 9
        Me.btnAdminLogin.Text = "Login"
        Me.btnAdminLogin.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(209, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 25)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Password:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(209, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 25)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Username:"
        '
        'txtAdminPassword
        '
        Me.txtAdminPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdminPassword.Location = New System.Drawing.Point(348, 101)
        Me.txtAdminPassword.Name = "txtAdminPassword"
        Me.txtAdminPassword.Size = New System.Drawing.Size(143, 31)
        Me.txtAdminPassword.TabIndex = 6
        '
        'txtAdminUsername
        '
        Me.txtAdminUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdminUsername.Location = New System.Drawing.Point(348, 57)
        Me.txtAdminUsername.Name = "txtAdminUsername"
        Me.txtAdminUsername.Size = New System.Drawing.Size(143, 31)
        Me.txtAdminUsername.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(184, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(452, 86)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "📚 LibraryMS"
        '
        'AdminLoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.panelAdmin)
        Me.Name = "AdminLoginForm"
        Me.Text = "AdminLoginForm"
        Me.panelAdmin.ResumeLayout(False)
        Me.panelAdmin.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelAdmin As Panel
    Friend WithEvents btnReturn As Button
    Friend WithEvents btnAdminLogin As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAdminPassword As TextBox
    Friend WithEvents txtAdminUsername As TextBox
    Friend WithEvents Label1 As Label
End Class
