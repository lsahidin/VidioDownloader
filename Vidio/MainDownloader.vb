' This work is licensed under 
' a Creative Commons Attribution-NonCommercial 4.0 International License.
' https://creativecommons.org/licenses/by-nc/4.0/
' =======================================================================

Imports System.Net

Public Class Main

    Class ActiveCB
        Property VidRes As String
        Property UrlData As String
    End Class

    Public WithEvents downloader As WebClient
    Dim hundred As Boolean = False
    Dim downloadCounter As Integer
    'Dim DownloadedFiles As String = ""
    'Dim vidioSplitter As String

    Public Class MyUtilities
        Shared Sub RunCommandCom(command As String, permanent As Boolean)
            Dim p As Process = New Process()
            Dim pi As ProcessStartInfo = New ProcessStartInfo()
            pi.Arguments = " " + If(permanent = True, "/K", "/C") + " " + command
            pi.FileName = "CMD.EXE"
            p.StartInfo = pi
            p.Start()
        End Sub
    End Class

    Private Sub DownloaderTS(ByVal urlvid As String, ByVal destname As String)
        Dim client As WebClient = New WebClient
        AddHandler client.DownloadProgressChanged, AddressOf client_ProgressChanged
        AddHandler client.DownloadFileCompleted, AddressOf client_DownloadCompleted
        client.DownloadFileAsync(New Uri(urlvid), destname)
        'DownloadedFiles = DownloadedFiles + vidioSplitter + ControlChars.Quote + destname + ControlChars.Quote
        'vidioSplitter = "+"
    End Sub

    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100

        ProgressBar1.Value = Int32.Parse(Math.Truncate(percentage).ToString())
    End Sub

    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Dim strCombine, strffmpeg As String
        Dim mp4Name As String

        ListVidio.Items(downloadCounter).SubItems(2).Text = "OK"
        mp4Name = ListVidio.Items(0).SubItems(1).Text
        mp4Name = mp4Name.Substring(0, Len(ListVidio.Items(0).SubItems(1).Text) - Len("mp400000.ts")) + "mp4"
        If (downloadCounter = ListVidio.Items.Count - 1) Then
            strCombine = "COPY /b " + ControlChars.Quote + My.Computer.FileSystem.SpecialDirectories.Temp + "\*.ts" + ControlChars.Quote + " " + ControlChars.Quote + My.Computer.FileSystem.SpecialDirectories.Temp + "\" + ListVidio.Items(0).SubItems(1).Text + "combine.ts" + ControlChars.Quote
            strffmpeg = " -i " + My.Computer.FileSystem.SpecialDirectories.Temp + "\" + ListVidio.Items(0).SubItems(1).Text + "combine.ts -acodec copy -vcodec copy " + ControlChars.Quote + txtsave.Text + "\" + mp4Name + ControlChars.Quote
            MyUtilities.RunCommandCom(strCombine, False)
            Process.Start(Application.StartupPath + "\ffmpeg.exe", strffmpeg)
            ProgressBar1.Value = 0
            MessageBox.Show("Download Complete")
            MyUtilities.RunCommandCom("DEL " + ControlChars.Quote + My.Computer.FileSystem.SpecialDirectories.Temp + "\*.ts" + ControlChars.Quote, False) 'clean up folder from .ts file
            startButton.Text = "Start Download"
            startButton.Enabled = True
            browseButton.Enabled = True
            cmbRes.Enabled = True
        End If
        downloadCounter = downloadCounter + 1
    End Sub

    Public Function GetDownloadSize(ByVal URL As String) As Long
        Dim r As Net.WebRequest = Net.WebRequest.Create(URL)
        r.Method = Net.WebRequestMethods.Http.Head
        Using rsp = r.GetResponse()
            Return rsp.ContentLength
        End Using
    End Function

    Public Function GetLocalFileSize(ByVal PATH As String) As Long
        Dim fileDetail = My.Computer.FileSystem.GetFileInfo(PATH)
        Return fileDetail.Length
    End Function

    Private Sub browseButton_Click(sender As Object, e As EventArgs) Handles browseButton.Click
        Dim searchRES, searchURL As Boolean
        Dim dataVid() As String
        Dim urlVid() As String
        Dim cntr As Integer = 0

        openDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        openDialog.FileName = "vjs_playlist"
        openDialog.Title = "Open a vjs_playlist"
        openDialog.Filter = "m3u8 File|*.m3u8"

        If openDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            For Each lineRes As String In System.IO.File.ReadAllLines(openDialog.FileName)
                searchRES = lineRes.Contains("RESOLUTION")
                If searchRES Then
                    cntr = cntr + 1
                End If
            Next

            ReDim dataVid(cntr - 1)
            ReDim urlVid(cntr - 1)

            cntr = 0
            For Each lineRes As String In System.IO.File.ReadAllLines(openDialog.FileName)
                searchRES = lineRes.Contains("RESOLUTION")
                If searchRES Then
                    dataVid(cntr) = lineRes.Substring(lineRes.IndexOf("N="))
                    cntr = cntr + 1
                End If
            Next

            cntr = 0
            For Each lineUrl As String In System.IO.File.ReadAllLines(openDialog.FileName)
                searchURL = lineUrl.Contains("https://")
                If searchURL Then
                    urlVid(cntr) = lineUrl
                    cntr = cntr + 1
                End If
            Next

            cntr = 0

            Dim _Active As New List(Of ActiveCB)
            For Each element As String In dataVid
                _Active.Add(New ActiveCB With {.VidRes = element, .UrlData = urlVid(cntr)})
                cntr = cntr + 1
            Next
            cmbRes.DataSource = _Active
            cmbRes.DisplayMember = "VidRes"
            cmbRes.ValueMember = "UrlData"
            cmbRes.SelectedIndex = 0

        End If
    End Sub

    Private Sub ListVidio_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles ListVidio.ColumnWidthChanging
        e.Cancel = True
        e.NewWidth = ListVidio.Columns(e.ColumnIndex).Width
    End Sub

    Private Sub downloader_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles downloader.DownloadProgressChanged
        'ProgressBar1.Value = e.ProgressPercentage
        If (hundred = False) Then
            If (e.ProgressPercentage = 100) Then ' I dunno why it's appear twice
                hundred = True
                ProsesUrlFile()
            End If
        End If

    End Sub

    Private Sub ProsesUrlFile()
        Dim searchURL As String
        Dim cntr As Integer = 0
        For Each lineUrl As String In System.IO.File.ReadAllLines(My.Computer.FileSystem.SpecialDirectories.Temp + "vidio.feed")
            searchURL = lineUrl.Contains(".mp4")
            If searchURL Then
                ListVidio.Items.Add(cntr + 1)
                ListVidio.Items(cntr).SubItems.Add(lineUrl)
                ListVidio.Items(cntr).SubItems.Add("?")
                cntr = cntr + 1
            End If
        Next
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbRes_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbRes.SelectionChangeCommitted
        downloader = New WebClient
        Me.Cursor = Cursors.WaitCursor
        'My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp + "vidDown.url")
        downloader.DownloadFileAsync(New Uri(cmbRes.SelectedValue), My.Computer.FileSystem.SpecialDirectories.Temp + "vidio.feed")
        hundred = False
        ListVidio.Items.Clear()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtsave.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        Dim cntr As Integer
        Dim mp4file As String
        Dim tmpUrl As String

        tmpUrl = cmbRes.SelectedValue.ToString
        'vidioSplitter = ""
        Me.Cursor = Cursors.WaitCursor
        downloadCounter = 0
        cntr = ListVidio.Items.Count - 1
        For i As Integer = 0 To cntr
            mp4file = ListVidio.Items(i).SubItems(1).Text
            DownloaderTS(tmpUrl.Substring(0, tmpUrl.IndexOf(".m")) + mp4file.Substring(mp4file.IndexOf(".m")), My.Computer.FileSystem.SpecialDirectories.Temp + "\" + mp4file)
        Next
        startButton.Text = "Download in Progress"
        startButton.Enabled = False
        browseButton.Enabled = False
        cmbRes.Enabled = False
        Me.Cursor = Cursors.Default
    End Sub

End Class