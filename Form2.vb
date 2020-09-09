Imports System.Drawing
Imports System.Drawing.Printing
Public Class Form2
    Public file As String
    Public path As String = "c:/"
    Public ToPrintReader As System.IO.StreamReader
    Public ToPrint As String
    Public PageSetup As PageSettings

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub OuvrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirToolStripMenuItem.Click
        OpenFileDialog1.InitialDirectory = path
        OpenFileDialog1.Filter = "Text Files|*.txt"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            file = OpenFileDialog1.FileName
            MsgBox("Fichier " + file + " selectionné",, "Fichier")
        End If
    End Sub

    Private Sub OuvrirdansblocnoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirdansblocnoteToolStripMenuItem.Click
        System.Diagnostics.Process.Start("notepad.exe", file)
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click
        End
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            path = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        OuvrirToolStripMenuItem_Click(sender, e)
        ToPrintReader = New System.IO.StreamReader(file)
        ToPrint = ToPrintReader.ReadToEnd
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            Dim PageSetup As PageSettings
            PageSetup = New PageSettings()
            PageSetup.Margins.Left = 50
            PageSetup.Margins.Top = 50
            PageSetup.Margins.Right = 50
            PageSetup.Margins.Bottom = 50
            PageSetup.Landscape = False
            PrintDocument1.DefaultPageSettings = PageSetup
        End If
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage_1(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(ToPrint, New Font("Arial", 11), Brushes.Black, New Point(100, 100))
    End Sub
End Class