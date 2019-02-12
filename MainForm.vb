Imports System.Runtime.InteropServices
Imports System.Drawing.Graphics
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports ICSharpCode.SharpZipLib.Zip

Public Partial Class MainForm
	<DllImport("user32.dll", CharSet:=CharSet.Auto)> _
	Private Shared Function GetClientRect(ByVal hWnd As System.IntPtr, ByRef lpRECT As Rectangle) As Integer
	End Function
	
	Private Declare Auto Function IsIconic Lib "user32.dll" (ByVal hwnd As IntPtr) As Boolean
	
	<DllImport("user32.dll", SetLastError:=True)> _
	Private Shared Function IsWindowVisible(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
	End Function
	
	Declare Function SetForegroundWindow Lib "user32.dll" (ByVal hwnd As Integer) As Integer
	
	Public Shared logo As Bitmap
	Public Shared gamescreen As Bitmap
	
	Public Sub New()
		Me.InitializeComponent()
		Me.AllowDrop = True
		PictureBox1.AllowDrop = True
		PictureBox2.AllowDrop = True
	End Sub
	
	Sub Button1Click(sender As Object, e As EventArgs)
		Dim players As Process() = Process.GetProcessesByName("flashplayer")
		
		If(players.Length = 0) Then
			MessageBox.Show("No Flash Players detected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		
		Dim player = players(0).MainWindowHandle
		
		Dim pic As New Rectangle
		GetClientRect(player, pic)
		
		Dim screenshot As New ScreenShot.ScreenCapture
		Dim image As Bitmap = screenshot.CaptureWindow(player)
		
		Dim border As Integer = (image.Width - pic.Width) / 2
		Dim top As Integer = image.Height - pic.Height - border
		
		Dim crop As Rectangle = New Rectangle(border, top, pic.Width, pic.Height)
		
		If(IsIconic(player) Or crop.IsEmpty Or crop.Width = 0 Or crop.Height = 0) Then
			MessageBox.Show("Please make sure the Flash Player is not minimized", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			SetForegroundWindow(player)
			SendKeys.SendWait("~")
		Else
			logo = image.Clone(crop, image.PixelFormat)
			PictureBox1.Image = logo
		End If
	End Sub
	
	Sub Button2Click(sender As Object, e As EventArgs)
'		Dim players As Process() = Process.GetProcessesByName("flashplayer_31_sa")
		Dim players As Process() = Process.GetProcessesByName("flashplayer")
		
		If(players.Length = 0) Then
			MessageBox.Show("No Flash Players detected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If
		
		Dim player = players(0).MainWindowHandle
		
		Dim pic As New Rectangle
		GetClientRect(player, pic)
		
		Dim screenshot As New ScreenShot.ScreenCapture
		Dim image As Bitmap = screenshot.CaptureWindow(player)
		
		Dim border As Integer = (image.Width - pic.Width) / 2
		Dim top As Integer = image.Height - pic.Height - border
		
		Dim crop As Rectangle = New Rectangle(border, top, pic.Width, pic.Height)
		
		If(IsIconic(player) Or crop.IsEmpty Or crop.Width = 0 Or crop.Height = 0) Then
			MessageBox.Show("Please make sure the Flash Player is not minimized", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			SetForegroundWindow(player)
			SendKeys.SendWait("~")
		Else
			gamescreen = image.Clone(crop, image.PixelFormat)
			PictureBox2.Image = gamescreen
		End If
	End Sub
	
	Sub Button3Click(sender As Object, e As EventArgs)
		Dim crop As Crop = New Crop
		If(logo Is Nothing) Then
			MessageBox.Show("No image to crop", "Crop", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Else
			crop.Show()
		End If
	End Sub
	
	Public Function CheckMeta() As Boolean
		Dim title = TextBox1.Text.Trim()
		Dim status = ComboBox2.Text.Trim()
		Dim genre = ComboBox1.Text.Trim()
		Dim playmode = ComboBox3.Text.Trim()
		Dim source = TextBox7.Text.Trim()
		Dim launchcommand = TextBox4.Text.Trim()
		
		If(logo Is Nothing) Then
			MessageBox.Show("Logo is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return False
		End If
		
		If(gamescreen Is Nothing) Then
			MessageBox.Show("Screenshot is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return False
		End If
		
		If(title.Length = 0) Then
			MessageBox.Show("Title cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return False
		End If
		
		If(launchcommand.Length = 0) Then
			MessageBox.Show("Command cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return False
		End If
		
		If(launchcommand.StartsWith("https://")) Then
			MessageBox.Show("Do not use HTTPS for the launch command", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return False
		End If
		
		If(source.Length = 0) Then
			MessageBox.Show("Source cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return False
		End If
		
		If(genre.Length = 0 Or genre = "Genre") Then
			MessageBox.Show("Please specify a genre", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return False
		End If
		
		If(playmode.Length = 0 Or playmode = "Playmode") Then
			MessageBox.Show("Please specify a playmode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return False
		End If
		
		If(status.Length = 0 Or status = "Status") Then
			MessageBox.Show("Please specify a status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return False
		End If
		
		Return True
	End Function

	Public Function CreateMeta() As String
		Dim title = TextBox1.Text.Trim()
		Dim series = TextBox2.Text.Trim()
		Dim developer = TextBox5.Text.Trim()
		Dim publisher = TextBox6.Text.Trim()
		Dim status = ComboBox2.Text.Trim()
		Dim extreme = "No"
		Dim genre = ComboBox1.Text.Trim()
		Dim playmode = ComboBox3.Text.Trim()
		Dim source = TextBox7.Text.Trim()
		Dim launchcommand = TextBox4.Text.Trim()
		Dim notes = TextBox3.Text.Trim().Replace(vbCrLf, "&#xD;&#xA;")
		Dim authornotes = TextBox8.Text.Trim().Replace(vbCrLf, "&#xD;&#xA;")
		
		If(CheckBox1.Checked) Then
			extreme = "Yes"
		End If
		
		Dim meta = _
		"Title: " + title + vbCrLf + _
		"Series: " + series + vbCrLf + _
		"Developer: " + developer + vbCrLf + _
		"Publisher: " + publisher + vbCrLf + _
		"Status: " + status + vbCrLf + _
		"Extreme: " + extreme + vbCrLf + _
		"Genre: " + genre + vbCrLf + _
		"Source: " + source + vbCrLf + _
		"Launch Command: " + launchcommand + vbCrLf + _
		"Notes: " + notes + vbCrLf + _
		"Author Notes: " + authornotes
		
		'MessageBox.Show(meta)
		
		Return meta
	End Function
	
	Sub Button4Click(sender As Object, e As EventArgs)
		If(CheckMeta()) Then
			Dim title = TextBox1.Text.Trim()
			
			'Create curation files
			Dim logostream = New MemoryStream()
			logo.Save(logostream, ImageFormat.Png)
			Dim screenshotstream = New MemoryStream()
			gamescreen.Save(screenshotstream, ImageFormat.Png)
			Dim meta = Encoding.UTF8.GetBytes(CreateMeta())
			
			'Get folder where all of the game contents are
			Dim folder As New FolderBrowserDialog
			folder.Description = "Please choose the content folder"
			folder.ShowNewFolderButton = False
			
			If(folder.ShowDialog() = DialogResult.Cancel) Then
				Exit Sub
			End If
			
			If(Directory.Exists(folder.SelectedPath) = False) Then
				MessageBox.Show("Could not find directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			
			Dim content = Directory.GetParent(folder.SelectedPath).ToString()
			
			'Grab a list of all files to be added. Warn if there are too many
			Dim files As New List(Of String)
			CompressFolder(folder.SelectedPath, content, files)
			
			If(files.Count >= 100) Then
				Dim action = MessageBox.Show("There are more than 100 files in the selected folder (" + files.Count.ToString() + " files). Is this a multi-asset game?" + vbCrLf + vbCrLf + "Click Yes to proceed", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
				If(action = DialogResult.No) Then
					Exit Sub
				End If
			End If
			
			'Get zip file name
			Dim SaveAs As New SaveFileDialog
			SaveAs.DefaultExt = ".zip"
			SaveAs.OverwritePrompt = True
			SaveAs.Title = "Save curated ZIP file"
			SaveAs.Filter = "ZIP file|*.zip"
			SaveAs.FileName = TextBox1.Text
			SaveAs.ShowDialog()
			
			'Create zip file
			Dim output As New MemoryStream
			Dim zipstream As New ZipOutputStream(output)
			zipstream.SetLevel(9)
			
			AddFile(title + "\logo.png", logostream.ToArray(), zipstream)
			AddFile(title + "\ss.png", screenshotstream.ToArray(), zipstream)
			AddFile(title + "\meta.txt", meta, zipstream)
			
			For Each newfile In files
				Dim addtozip = File.ReadAllBytes(content + "\" + newfile)
				AddFile(title + "\content\" + newfile, addtozip, zipstream)
			Next
			
			zipstream.Close()
			File.WriteAllBytes(SaveAs.FileName, output.ToArray())
		End If
	End Sub
	
	Sub MainFormLoad(sender As Object, e As EventArgs)
		Dim genres As String() = _
		{"""Quiz""", _
		"Action", _
		"Adult", _
		"Adventure", _
		"Animation", _
		"Arcade", _
		"Artillery", _
		"Brawler", _
		"Card", _
		"Choose Your Own Adventure", _
		"Dating Sim", _
		"Dress Up", _
		"Driving", _
		"Escape the Room", _
		"Fighting", _
		"Find", _
		"Gambling", _
		"Horror", _
		"Motocross", _
		"Pinball", _
		"Platformer", _
		"Pong", _
		"Puzzle", _
		"Quiz", _
		"Racing", _
		"Rhythm", _
		"Rock Paper Scissors", _
		"RPG", _
		"Runner", _
		"Seizure-Inducing", _
		"Shooter", _
		"Simulation", _
		"Sports", _
		"Strategy", _
		"Tower Defense", _
		"Toy", _
		"Tutorial", _
		"Typing", _
		"Variety", _
		"Visual Novel", _
		"Walkright", _
		"WTF"}
		
		ComboBox1.Items.AddRange(genres)
	End Sub
	
	Sub Button5Click(sender As Object, e As EventArgs)
		If(MessageBox.Show("Are you sure you wish to reset all fields?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes) Then
			PictureBox1.Image = Nothing
			PictureBox2.Image = Nothing
			logo = Nothing
			gamescreen = Nothing
			TextBox1.Text = ""
			TextBox2.Text = ""
			TextBox5.Text = ""
			TextBox6.Text = ""
			ComboBox2.Text = "Status"
			CheckBox1.Checked = False
			ComboBox1.Text = "Genre"
			ComboBox3.Text = "Playmode"
			TextBox7.Text = ""
			TextBox4.Text = ""
			TextBox3.Text = ""
			TextBox8.Text = ""
		End If
	End Sub
	
	Sub Button6Click(sender As Object, e As EventArgs)
		Clipboard.SetText(TextBox1.Text)
	End Sub
	
	Public Sub AddFile(filename As String, content As Byte(), zipfile As ZipOutputStream)
		Dim newentry As New ZipEntry(filename)
		newentry.DateTime = DateTime.Now
		zipfile.PutNextEntry(newentry)
		zipfile.Write(content, 0, content.Length)
		zipfile.CloseEntry()
	End Sub
	
	Public Sub CompressFolder(path As String, ByRef root As String, ByRef output As List(Of String))
		Dim files = Directory.GetFiles(path)
		
		For Each filename In files
			Dim fi = New FileInfo(filename)
			Dim entryname = filename.Substring(0)
			'entryname = ZipEntry.CleanName(entryname)
			output.Add(entryname.Substring(root.Length + 1))
		Next
		
		Dim folders = Directory.GetDirectories(path)
		For Each folder In folders
			CompressFolder(folder, root, output)
		Next
	End Sub
	
	Sub TextBox3KeyDown(sender As Object, e As KeyEventArgs)
		If(e.Control And e.KeyCode = Keys.A) Then
			TextBox3.SelectAll()
		End If
	End Sub
	
	Sub PictureBox1DragEnter(sender As Object, e As DragEventArgs)
		If(e.Data.GetDataPresent(DataFormats.FileDrop)) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub
	
	Sub PictureBox1DragDrop(sender As Object, e As DragEventArgs)
		Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
		logo = Image.FromFile(files(0))
		PictureBox1.Image = logo
	End Sub
	
	Sub PictureBox2DragEnter(sender As Object, e As DragEventArgs)
		If(e.Data.GetDataPresent(DataFormats.FileDrop)) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub
	
	Sub PictureBox2DragDrop(sender As Object, e As DragEventArgs)
		Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
		gamescreen = Image.FromFile(files(0))
		PictureBox2.Image = gamescreen
	End Sub
End Class
