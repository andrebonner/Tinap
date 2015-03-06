Public Class main
    Private filename As String = "Untitled"
    Private changed As Boolean
    Private _Previous As System.Nullable(Of Point) = Nothing
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler Application.Idle, AddressOf UpdateButtons
    End Sub

    Private Sub UpdateButtons(ByVal sender As Object, ByVal e As EventArgs)
        Dim box = TryCast(Me.mainPaintBox, PictureBox)

        If filename <> "" Then Me.Text = System.IO.Path.GetFileName(filename) & " - " & Application.ProductName

        ' update buttons as required
        UndoToolStripMenuItem.Enabled = False
        RedoToolStripMenuItem.Enabled = False
        CopyToolStripMenuItem.Enabled = False
        CopyToolStripButton.Enabled = CopyToolStripMenuItem.Enabled
        CutToolStripMenuItem.Enabled = CopyToolStripMenuItem.Enabled
        CutToolStripButton.Enabled = CutToolStripMenuItem.Enabled
        PasteToolStripMenuItem.Enabled = Clipboard.ContainsImage
        PasteToolStripButton.Enabled = PasteToolStripMenuItem.Enabled
    End Sub


    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = filename & " - " & Application.ProductName
        Me.StatusLabelPresent.Text = "Ready ..."
        mainPaintBox.SizeMode = PictureBoxSizeMode.Zoom
        'mainPaintBox.BackgroundImage = mainPaintBox.Image
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        ' new image document setup
        newImage()
    End Sub

    Private Sub NewToolStripButton_Click(sender As Object, e As EventArgs) Handles NewToolStripButton.Click
        ' new image document setup
        newImage()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        ' open image document
        openImage()
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        ' open image document
        openImage()
    End Sub


    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        ' save image document
        saveImage()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ' save image document
        saveImage()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        ' save as Image document
        saveAsImage()
    End Sub


    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        ' print Image document
        printImage()
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        ' print Image document
        printImage()
    End Sub
    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        ' the preview of the Image document
        previewImage()
    End Sub

    Private Function newImage()
        ' is image document saved
        If changed And filename = "Untitled" Then
            saveAsImage()
        End If

        filename = "Untitled"
        mainPaintBox.Image = Nothing
        mainPaintBox.BackColor = Color.Empty
        ' update title
        Return Nothing
    End Function
    Private Function openImage()
        mainOpenFileDialog.Title = "Open Image"
        If mainOpenFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Me.mainPaintBox.Image = Image.FromFile(mainOpenFileDialog.FileName)
            filename = mainOpenFileDialog.FileName
            ' update title
        End If
        Return Nothing
    End Function

    Private Function saveImage()
        ' is the image untitled
        If filename = "Untitled" Then
            saveAsImage()
        Else
            ' save image to file
            mainPaintBox.Image.Save(filename)
        End If
        ' update title
        Return Nothing
    End Function


    Private Function saveAsImage()
        mainSaveFileDialog.Title = "Save As Image"
        If mainSaveFileDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            If mainSaveFileDialog.FileName <> "" Then
                Dim fs As System.IO.FileStream = CType(mainSaveFileDialog.OpenFile(), System.IO.FileStream)
                Select Case mainSaveFileDialog.FilterIndex
                    Case 1
                        Me.mainPaintBox.Image.Save(fs, Drawing.Imaging.ImageFormat.Png)
                    Case 2
                        Me.mainPaintBox.Image.Save(fs, Drawing.Imaging.ImageFormat.Jpeg)
                    Case 3
                        Me.mainPaintBox.Image.Save(fs, Drawing.Imaging.ImageFormat.Bmp)
                    Case Else
                        Me.mainPaintBox.Image.Save(fs, Drawing.Imaging.ImageFormat.Bmp)
                End Select
                fs.Close()
                filename = mainSaveFileDialog.FileName
            End If
        End If
        ' update title
        Return Nothing
    End Function

    Private Function printImage()
        mainPrintDialog.Document = ImageDocument
        mainPrintDialog.PrinterSettings = ImageDocument.PrinterSettings
        mainPrintDialog.AllowSomePages = True
        If mainPrintDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            ImageDocument.PrinterSettings = mainPrintDialog.PrinterSettings
            ImageDocument.Print()
        End If
        Return Nothing
    End Function

    Private Function previewImage()
        mainPrintPreviewDialog.ShowDialog()
        Return Nothing
    End Function

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        ' undo image 
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        ' redo image
    End Sub

    Private Sub ImageDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles ImageDocument.PrintPage
        Dim prev As Image = Image.FromFile(filename)
        e.Graphics.DrawImage(prev, 10, 10)
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        ' cut graphic object
    End Sub
    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        ' cut graphic object
    End Sub
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' copy graphic object
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        ' copy graphic object
    End Sub
    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        ' paste graphic object
    End Sub

    Private Sub PasteToolStripButton_Click(sender As Object, e As EventArgs) Handles PasteToolStripButton.Click
        ' paste graphic object
    End Sub

    Private Sub BrushToolStripButton_Click(sender As Object, e As EventArgs) Handles BrushToolStripButton.Click
        ' brush graphic object
    End Sub

    Private Sub PenToolStripButton_Click(sender As Object, e As EventArgs) Handles PenToolStripButton.Click
        ' pen graphic object
    End Sub

    Private Sub TextToolStripButton_Click(sender As Object, e As EventArgs) Handles TextToolStripButton.Click
        ' text graphic object
    End Sub

    Private Sub RecToolStripButton_Click(sender As Object, e As EventArgs) Handles RecToolStripButton.Click
        ' rectangle graphic object
    End Sub

    Private Sub CircleToolStripButton_Click(sender As Object, e As EventArgs) Handles CircleToolStripButton.Click
        ' circle graphic object
    End Sub

    Private Sub ColorToolStripButton_Click(sender As Object, e As EventArgs) Handles ColorToolStripButton.Click
        ' color changing
        mainColorDialog.Color = mainPaintBox.BackColor
        If mainColorDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            mainPaintBox.BackColor = mainColorDialog.Color
        End If
    End Sub

    Private Sub mainPaintBox_MouseDown(sender As Object, e As MouseEventArgs) Handles mainPaintBox.MouseDown
        _Previous = e.Location
        mainPaintBox_MouseMove(sender, e)
    End Sub

    Private Sub mainPaintBox_MouseMove(sender As Object, e As MouseEventArgs) Handles mainPaintBox.MouseMove
        If _Previous IsNot Nothing Then
            If mainPaintBox.Image Is Nothing Then
                Dim bmp As New Bitmap(mainPaintBox.Width, mainPaintBox.Height)
                Using g As Graphics = Graphics.FromImage(bmp)
                    g.Clear(Color.White)
                End Using
                mainPaintBox.Image = bmp
                Using g As Graphics = Graphics.FromImage(mainPaintBox.Image)
                    g.DrawLine(Pens.Black, _Previous.Value, e.Location)
                End Using
                _Previous = e.Location
            End If
        End If
    End Sub

    Private Sub mainPaintBox_MouseUp(sender As Object, e As MouseEventArgs) Handles mainPaintBox.MouseUp
        '_Previous = Nothing
    End Sub

    Private Sub mainPaintBox_Paint(sender As Object, e As PaintEventArgs) Handles mainPaintBox.Paint

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.ShowDialog()
    End Sub
End Class
