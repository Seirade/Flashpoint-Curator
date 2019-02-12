Partial Class MainForm
	Inherits System.Windows.Forms.Form
	Private components As System.ComponentModel.IContainer
	
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	Private Sub InitializeComponent()
		Me.groupBox1 = New System.Windows.Forms.GroupBox
		Me.pictureBox1 = New System.Windows.Forms.PictureBox
		Me.groupBox2 = New System.Windows.Forms.GroupBox
		Me.pictureBox2 = New System.Windows.Forms.PictureBox
		Me.button1 = New System.Windows.Forms.Button
		Me.button2 = New System.Windows.Forms.Button
		Me.button3 = New System.Windows.Forms.Button
		Me.label1 = New System.Windows.Forms.Label
		Me.textBox1 = New System.Windows.Forms.TextBox
		Me.textBox2 = New System.Windows.Forms.TextBox
		Me.label2 = New System.Windows.Forms.Label
		Me.label3 = New System.Windows.Forms.Label
		Me.label4 = New System.Windows.Forms.Label
		Me.label5 = New System.Windows.Forms.Label
		Me.label6 = New System.Windows.Forms.Label
		Me.label10 = New System.Windows.Forms.Label
		Me.label11 = New System.Windows.Forms.Label
		Me.checkBox1 = New System.Windows.Forms.CheckBox
		Me.comboBox1 = New System.Windows.Forms.ComboBox
		Me.comboBox2 = New System.Windows.Forms.ComboBox
		Me.comboBox3 = New System.Windows.Forms.ComboBox
		Me.textBox4 = New System.Windows.Forms.TextBox
		Me.textBox5 = New System.Windows.Forms.TextBox
		Me.textBox6 = New System.Windows.Forms.TextBox
		Me.textBox7 = New System.Windows.Forms.TextBox
		Me.textBox8 = New System.Windows.Forms.TextBox
		Me.comboBox4 = New System.Windows.Forms.ComboBox
		Me.button4 = New System.Windows.Forms.Button
		Me.textBox3 = New System.Windows.Forms.TextBox
		Me.label7 = New System.Windows.Forms.Label
		Me.button5 = New System.Windows.Forms.Button
		Me.button6 = New System.Windows.Forms.Button
		Me.groupBox1.SuspendLayout
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.groupBox2.SuspendLayout
		CType(Me.pictureBox2,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'groupBox1
		'
		Me.groupBox1.Controls.Add(Me.pictureBox1)
		Me.groupBox1.Location = New System.Drawing.Point(12, 12)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(200, 162)
		Me.groupBox1.TabIndex = 0
		Me.groupBox1.TabStop = false
		Me.groupBox1.Text = "Logo Preview"
		'
		'pictureBox1
		'
		Me.pictureBox1.Location = New System.Drawing.Point(6, 19)
		Me.pictureBox1.Name = "pictureBox1"
		Me.pictureBox1.Size = New System.Drawing.Size(188, 137)
		Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.pictureBox1.TabIndex = 0
		Me.pictureBox1.TabStop = false
		AddHandler Me.pictureBox1.DragDrop, AddressOf Me.PictureBox1DragDrop
		AddHandler Me.pictureBox1.DragEnter, AddressOf Me.PictureBox1DragEnter
		'
		'groupBox2
		'
		Me.groupBox2.Controls.Add(Me.pictureBox2)
		Me.groupBox2.Location = New System.Drawing.Point(218, 12)
		Me.groupBox2.Name = "groupBox2"
		Me.groupBox2.Size = New System.Drawing.Size(200, 162)
		Me.groupBox2.TabIndex = 1
		Me.groupBox2.TabStop = false
		Me.groupBox2.Text = "Screenshot Preview"
		'
		'pictureBox2
		'
		Me.pictureBox2.Location = New System.Drawing.Point(6, 19)
		Me.pictureBox2.Name = "pictureBox2"
		Me.pictureBox2.Size = New System.Drawing.Size(188, 137)
		Me.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.pictureBox2.TabIndex = 0
		Me.pictureBox2.TabStop = false
		AddHandler Me.pictureBox2.DragDrop, AddressOf Me.PictureBox2DragDrop
		AddHandler Me.pictureBox2.DragEnter, AddressOf Me.PictureBox2DragEnter
		'
		'button1
		'
		Me.button1.Location = New System.Drawing.Point(137, 180)
		Me.button1.Name = "button1"
		Me.button1.Size = New System.Drawing.Size(75, 23)
		Me.button1.TabIndex = 17
		Me.button1.Text = "Capture"
		Me.button1.UseVisualStyleBackColor = true
		AddHandler Me.button1.Click, AddressOf Me.Button1Click
		'
		'button2
		'
		Me.button2.Location = New System.Drawing.Point(343, 180)
		Me.button2.Name = "button2"
		Me.button2.Size = New System.Drawing.Size(75, 23)
		Me.button2.TabIndex = 19
		Me.button2.Text = "Capture"
		Me.button2.UseVisualStyleBackColor = true
		AddHandler Me.button2.Click, AddressOf Me.Button2Click
		'
		'button3
		'
		Me.button3.Enabled = false
		Me.button3.Location = New System.Drawing.Point(56, 180)
		Me.button3.Name = "button3"
		Me.button3.Size = New System.Drawing.Size(75, 23)
		Me.button3.TabIndex = 18
		Me.button3.Text = "Crop"
		Me.button3.UseVisualStyleBackColor = true
		AddHandler Me.button3.Click, AddressOf Me.Button3Click
		'
		'label1
		'
		Me.label1.Location = New System.Drawing.Point(12, 221)
		Me.label1.Name = "label1"
		Me.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.label1.Size = New System.Drawing.Size(64, 23)
		Me.label1.TabIndex = 5
		Me.label1.Text = "Title"
		'
		'textBox1
		'
		Me.textBox1.Location = New System.Drawing.Point(82, 218)
		Me.textBox1.Name = "textBox1"
		Me.textBox1.Size = New System.Drawing.Size(336, 20)
		Me.textBox1.TabIndex = 1
		'
		'textBox2
		'
		Me.textBox2.Location = New System.Drawing.Point(82, 244)
		Me.textBox2.Name = "textBox2"
		Me.textBox2.Size = New System.Drawing.Size(336, 20)
		Me.textBox2.TabIndex = 2
		'
		'label2
		'
		Me.label2.Location = New System.Drawing.Point(12, 247)
		Me.label2.Name = "label2"
		Me.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.label2.Size = New System.Drawing.Size(64, 23)
		Me.label2.TabIndex = 7
		Me.label2.Text = "Series"
		'
		'label3
		'
		Me.label3.Location = New System.Drawing.Point(12, 299)
		Me.label3.Name = "label3"
		Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.label3.Size = New System.Drawing.Size(64, 23)
		Me.label3.TabIndex = 9
		Me.label3.Text = "Command"
		'
		'label4
		'
		Me.label4.Location = New System.Drawing.Point(12, 273)
		Me.label4.Name = "label4"
		Me.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.label4.Size = New System.Drawing.Size(64, 23)
		Me.label4.TabIndex = 11
		Me.label4.Text = "Application"
		'
		'label5
		'
		Me.label5.Location = New System.Drawing.Point(12, 325)
		Me.label5.Name = "label5"
		Me.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.label5.Size = New System.Drawing.Size(64, 23)
		Me.label5.TabIndex = 12
		Me.label5.Text = "Developer"
		'
		'label6
		'
		Me.label6.Location = New System.Drawing.Point(12, 351)
		Me.label6.Name = "label6"
		Me.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.label6.Size = New System.Drawing.Size(64, 23)
		Me.label6.TabIndex = 13
		Me.label6.Text = "Publisher"
		'
		'label10
		'
		Me.label10.Location = New System.Drawing.Point(12, 377)
		Me.label10.Name = "label10"
		Me.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.label10.Size = New System.Drawing.Size(64, 23)
		Me.label10.TabIndex = 17
		Me.label10.Text = "Source"
		'
		'label11
		'
		Me.label11.Location = New System.Drawing.Point(6, 511)
		Me.label11.Name = "label11"
		Me.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.label11.Size = New System.Drawing.Size(70, 23)
		Me.label11.TabIndex = 18
		Me.label11.Text = "Author Notes"
		'
		'checkBox1
		'
		Me.checkBox1.Location = New System.Drawing.Point(292, 425)
		Me.checkBox1.Name = "checkBox1"
		Me.checkBox1.Size = New System.Drawing.Size(104, 24)
		Me.checkBox1.TabIndex = 11
		Me.checkBox1.Text = "Extreme Content"
		Me.checkBox1.UseVisualStyleBackColor = true
		'
		'comboBox1
		'
		Me.comboBox1.DropDownHeight = 159
		Me.comboBox1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.comboBox1.FormattingEnabled = true
		Me.comboBox1.IntegralHeight = false
		Me.comboBox1.Location = New System.Drawing.Point(82, 400)
		Me.comboBox1.Name = "comboBox1"
		Me.comboBox1.Size = New System.Drawing.Size(204, 21)
		Me.comboBox1.TabIndex = 8
		Me.comboBox1.Text = "Genre"
		'
		'comboBox2
		'
		Me.comboBox2.FormattingEnabled = true
		Me.comboBox2.Items.AddRange(New Object() {"Playable", "Playable (Partial)", "Playable (Hacked)", "Playable (Web Browser)", "Playable (Web Browser) (Hacked)", "Not Working"})
		Me.comboBox2.Location = New System.Drawing.Point(82, 427)
		Me.comboBox2.Name = "comboBox2"
		Me.comboBox2.Size = New System.Drawing.Size(204, 21)
		Me.comboBox2.TabIndex = 10
		Me.comboBox2.Text = "Status"
		'
		'comboBox3
		'
		Me.comboBox3.FormattingEnabled = true
		Me.comboBox3.Items.AddRange(New Object() {"Single Player", "Multiplayer", "Cooperative"})
		Me.comboBox3.Location = New System.Drawing.Point(292, 400)
		Me.comboBox3.Name = "comboBox3"
		Me.comboBox3.Size = New System.Drawing.Size(126, 21)
		Me.comboBox3.TabIndex = 9
		Me.comboBox3.Text = "Playmode"
		'
		'textBox4
		'
		Me.textBox4.Location = New System.Drawing.Point(82, 296)
		Me.textBox4.Name = "textBox4"
		Me.textBox4.Size = New System.Drawing.Size(336, 20)
		Me.textBox4.TabIndex = 4
		'
		'textBox5
		'
		Me.textBox5.Location = New System.Drawing.Point(82, 322)
		Me.textBox5.Name = "textBox5"
		Me.textBox5.Size = New System.Drawing.Size(336, 20)
		Me.textBox5.TabIndex = 5
		'
		'textBox6
		'
		Me.textBox6.Location = New System.Drawing.Point(82, 348)
		Me.textBox6.Name = "textBox6"
		Me.textBox6.Size = New System.Drawing.Size(336, 20)
		Me.textBox6.TabIndex = 6
		'
		'textBox7
		'
		Me.textBox7.Location = New System.Drawing.Point(82, 374)
		Me.textBox7.Name = "textBox7"
		Me.textBox7.Size = New System.Drawing.Size(336, 20)
		Me.textBox7.TabIndex = 7
		'
		'textBox8
		'
		Me.textBox8.Location = New System.Drawing.Point(82, 508)
		Me.textBox8.Multiline = true
		Me.textBox8.Name = "textBox8"
		Me.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.textBox8.Size = New System.Drawing.Size(336, 47)
		Me.textBox8.TabIndex = 13
		'
		'comboBox4
		'
		Me.comboBox4.FormattingEnabled = true
		Me.comboBox4.Items.AddRange(New Object() {"Flash Player", "Shockwave", "Unity", "Java", "HTML5"})
		Me.comboBox4.Location = New System.Drawing.Point(82, 270)
		Me.comboBox4.Name = "comboBox4"
		Me.comboBox4.Size = New System.Drawing.Size(336, 21)
		Me.comboBox4.TabIndex = 3
		Me.comboBox4.Text = "Flash"
		'
		'button4
		'
		Me.button4.Location = New System.Drawing.Point(308, 567)
		Me.button4.Name = "button4"
		Me.button4.Size = New System.Drawing.Size(110, 23)
		Me.button4.TabIndex = 14
		Me.button4.Text = "Curate"
		Me.button4.UseVisualStyleBackColor = true
		AddHandler Me.button4.Click, AddressOf Me.Button4Click
		'
		'textBox3
		'
		Me.textBox3.Location = New System.Drawing.Point(82, 455)
		Me.textBox3.Multiline = true
		Me.textBox3.Name = "textBox3"
		Me.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.textBox3.Size = New System.Drawing.Size(336, 47)
		Me.textBox3.TabIndex = 12
		AddHandler Me.textBox3.KeyDown, AddressOf Me.TextBox3KeyDown
		'
		'label7
		'
		Me.label7.Location = New System.Drawing.Point(32, 455)
		Me.label7.Name = "label7"
		Me.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.label7.Size = New System.Drawing.Size(44, 23)
		Me.label7.TabIndex = 31
		Me.label7.Text = "Notes"
		'
		'button5
		'
		Me.button5.Location = New System.Drawing.Point(193, 567)
		Me.button5.Name = "button5"
		Me.button5.Size = New System.Drawing.Size(109, 23)
		Me.button5.TabIndex = 15
		Me.button5.Text = "Reset All"
		Me.button5.UseVisualStyleBackColor = true
		AddHandler Me.button5.Click, AddressOf Me.Button5Click
		'
		'button6
		'
		Me.button6.Location = New System.Drawing.Point(82, 567)
		Me.button6.Name = "button6"
		Me.button6.Size = New System.Drawing.Size(105, 23)
		Me.button6.TabIndex = 16
		Me.button6.Text = "Copy Title"
		Me.button6.UseVisualStyleBackColor = true
		AddHandler Me.button6.Click, AddressOf Me.Button6Click
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(427, 602)
		Me.Controls.Add(Me.button6)
		Me.Controls.Add(Me.button5)
		Me.Controls.Add(Me.label7)
		Me.Controls.Add(Me.textBox3)
		Me.Controls.Add(Me.button4)
		Me.Controls.Add(Me.comboBox4)
		Me.Controls.Add(Me.textBox8)
		Me.Controls.Add(Me.textBox7)
		Me.Controls.Add(Me.textBox6)
		Me.Controls.Add(Me.textBox5)
		Me.Controls.Add(Me.textBox4)
		Me.Controls.Add(Me.comboBox3)
		Me.Controls.Add(Me.comboBox2)
		Me.Controls.Add(Me.comboBox1)
		Me.Controls.Add(Me.checkBox1)
		Me.Controls.Add(Me.label11)
		Me.Controls.Add(Me.label10)
		Me.Controls.Add(Me.label6)
		Me.Controls.Add(Me.label5)
		Me.Controls.Add(Me.label4)
		Me.Controls.Add(Me.label3)
		Me.Controls.Add(Me.textBox2)
		Me.Controls.Add(Me.label2)
		Me.Controls.Add(Me.textBox1)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.button3)
		Me.Controls.Add(Me.button2)
		Me.Controls.Add(Me.button1)
		Me.Controls.Add(Me.groupBox2)
		Me.Controls.Add(Me.groupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.Name = "MainForm"
		Me.Text = "Flashpoint Curator"
		AddHandler Load, AddressOf Me.MainFormLoad
		Me.groupBox1.ResumeLayout(false)
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).EndInit
		Me.groupBox2.ResumeLayout(false)
		CType(Me.pictureBox2,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private button6 As System.Windows.Forms.Button
	Private button5 As System.Windows.Forms.Button
	Private label7 As System.Windows.Forms.Label
	Private textBox3 As System.Windows.Forms.TextBox
	Private button4 As System.Windows.Forms.Button
	Private comboBox4 As System.Windows.Forms.ComboBox
	Private textBox8 As System.Windows.Forms.TextBox
	Private textBox7 As System.Windows.Forms.TextBox
	Private textBox6 As System.Windows.Forms.TextBox
	Private textBox5 As System.Windows.Forms.TextBox
	Private textBox4 As System.Windows.Forms.TextBox
	Private comboBox3 As System.Windows.Forms.ComboBox
	Private comboBox2 As System.Windows.Forms.ComboBox
	Private comboBox1 As System.Windows.Forms.ComboBox
	Private checkBox1 As System.Windows.Forms.CheckBox
	Private label11 As System.Windows.Forms.Label
	Private label10 As System.Windows.Forms.Label
	Private label6 As System.Windows.Forms.Label
	Private label5 As System.Windows.Forms.Label
	Private label4 As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private textBox2 As System.Windows.Forms.TextBox
	Private textBox1 As System.Windows.Forms.TextBox
	Private label1 As System.Windows.Forms.Label
	Private button3 As System.Windows.Forms.Button
	Private button2 As System.Windows.Forms.Button
	Private button1 As System.Windows.Forms.Button
	Private pictureBox2 As System.Windows.Forms.PictureBox
	Private pictureBox1 As System.Windows.Forms.PictureBox
	Private groupBox2 As System.Windows.Forms.GroupBox
	Private groupBox1 As System.Windows.Forms.GroupBox
End Class
