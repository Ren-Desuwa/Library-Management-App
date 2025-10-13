Imports Guna.UI2.WinForms

Public Class Login_Panel

    Private Sub Login_Panel(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set transparency to 30%
        SetImageTransparency(Guna2PictureBox1, 0.3F)
        ' Make the label transparent and sit on top of the image
        Guna2HtmlLabel1.Parent = Guna2PictureBox1
        Guna2HtmlLabel1.BackColor = Color.Transparent
        Guna2HtmlLabel2.Parent = Guna2PictureBox1
        Guna2HtmlLabel2.BackColor = Color.Transparent

        ' Optional: center label or adjust position
        Guna2HtmlLabel1.BringToFront()
        Guna2HtmlLabel2.BringToFront()

    End Sub

    Private Sub SetImageTransparency(pictureBox As Guna.UI2.WinForms.Guna2PictureBox, transparency As Single)
        ' transparency = 0 (fully transparent) to 1 (fully opaque)
        If pictureBox.Image Is Nothing Then Exit Sub

        Dim bmp As New Bitmap(pictureBox.Image.Width, pictureBox.Image.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            Dim cm As New Imaging.ColorMatrix()
            cm.Matrix33 = transparency ' alpha (transparency)
            Dim ia As New Imaging.ImageAttributes()
            ia.SetColorMatrix(cm, Imaging.ColorMatrixFlag.Default, Imaging.ColorAdjustType.Bitmap)
            g.DrawImage(pictureBox.Image, New Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, ia)
        End Using

        pictureBox.Image = bmp
    End Sub

    Private Sub Guna2HtmlLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click

    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub
End Class
