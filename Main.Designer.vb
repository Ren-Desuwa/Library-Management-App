<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelChoose = New System.Windows.Forms.Panel()
        Me.btnUser = New System.Windows.Forms.Button()
        Me.btnAdmin = New System.Windows.Forms.Button()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.panelChoose.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(163, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(430, 86)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "📚 LibraryMS"
        '
        'panelChoose
        '
        Me.panelChoose.Controls.Add(Me.btnAdmin)
        Me.panelChoose.Controls.Add(Me.btnUser)
        Me.panelChoose.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelChoose.Location = New System.Drawing.Point(0, 139)
        Me.panelChoose.Name = "panelChoose"
        Me.panelChoose.Size = New System.Drawing.Size(800, 311)
        Me.panelChoose.TabIndex = 3
        '
        'btnUser
        '
        Me.btnUser.Location = New System.Drawing.Point(312, 59)
        Me.btnUser.Name = "btnUser"
        Me.btnUser.Size = New System.Drawing.Size(190, 54)
        Me.btnUser.TabIndex = 0
        Me.btnUser.Text = "User"
        Me.btnUser.UseVisualStyleBackColor = True
        '
        'btnAdmin
        '
        Me.btnAdmin.Location = New System.Drawing.Point(312, 119)
        Me.btnAdmin.Name = "btnAdmin"
        Me.btnAdmin.Size = New System.Drawing.Size(190, 54)
        Me.btnAdmin.TabIndex = 1
        Me.btnAdmin.Text = "Admin"
        Me.btnAdmin.UseVisualStyleBackColor = True
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.panelChoose)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(800, 450)
        Me.PanelMain.TabIndex = 0
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "Main"
        Me.Text = "Main"
        Me.panelChoose.ResumeLayout(False)
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents panelChoose As Panel
    Friend WithEvents btnAdmin As Button
    Friend WithEvents btnUser As Button
    Friend WithEvents PanelMain As Panel
End Class
