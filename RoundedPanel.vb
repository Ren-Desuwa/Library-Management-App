Imports System.Drawing.Drawing2D

Public Class RoundedPanel
    Inherits Panel

    Public Sub New()
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.BackColor = Color.White ' panel background
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim radius As Integer = 20 ' corner radius
        Dim path As New GraphicsPath()

        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        Me.Region = New Region(path) ' apply rounded corners

        Using brush As New SolidBrush(Me.BackColor)
            e.Graphics.FillPath(brush, path)
        End Using

        ' Optional border
        Using pen As New Pen(Color.LightGray, 1)
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub
End Class
