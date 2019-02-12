Partial Class Crop
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.pictureBox1 = New System.Windows.Forms.PictureBox
		Me.button1 = New System.Windows.Forms.Button
		Me.button2 = New System.Windows.Forms.Button
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'pictureBox1
		'
		Me.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pictureBox1.Location = New System.Drawing.Point(12, 12)
		Me.pictureBox1.Name = "pictureBox1"
		Me.pictureBox1.Size = New System.Drawing.Size(720, 668)
		Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.pictureBox1.TabIndex = 0
		Me.pictureBox1.TabStop = false
		'
		'button1
		'
		Me.button1.Location = New System.Drawing.Point(294, 686)
		Me.button1.Name = "button1"
		Me.button1.Size = New System.Drawing.Size(75, 23)
		Me.button1.TabIndex = 1
		Me.button1.Text = "Preview"
		Me.button1.UseVisualStyleBackColor = true
		'
		'button2
		'
		Me.button2.Location = New System.Drawing.Point(375, 686)
		Me.button2.Name = "button2"
		Me.button2.Size = New System.Drawing.Size(75, 23)
		Me.button2.TabIndex = 2
		Me.button2.Text = "Crop"
		Me.button2.UseVisualStyleBackColor = true
		'
		'Crop
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(744, 721)
		Me.Controls.Add(Me.button2)
		Me.Controls.Add(Me.button1)
		Me.Controls.Add(Me.pictureBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.Name = "Crop"
		Me.Text = "Crop"
		AddHandler Load, AddressOf Me.CropLoad
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private button2 As System.Windows.Forms.Button
	Private button1 As System.Windows.Forms.Button
	Private pictureBox1 As System.Windows.Forms.PictureBox
End Class
