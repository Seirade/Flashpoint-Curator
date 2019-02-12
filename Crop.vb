Public Partial Class Crop
	Public Sub New()
		Me.InitializeComponent()
	End Sub
	
	Sub CropLoad(sender As Object, e As EventArgs)
		PictureBox1.Image = MainForm.logo
		MessageBox.Show("Width: " + PictureBox1.Image.Width.ToString + vbCrLf + "Height: " + PictureBox1.Image.Height.ToString)
	End Sub
End Class
