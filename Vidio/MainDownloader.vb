' This work is licensed under 
' a Creative Commons Attribution-NonCommercial 4.0 International License.
' https://creativecommons.org/licenses/by-nc/4.0/
' Author : Luqman Sahidin
' Github : https://github.com/lsahidin
' e-mail : lsahidin@yahoo.com
' =======================================================================

Imports System.Net

Public Class Main

    Class ActiveCB
        Property VidRes As String
        Property UrlData As String
    End Class

    Public WithEvents downloader As WebClient
    Dim hundred As Boolean = False
    Dim itStart As Boolean = False
    Dim videofeed As Boolean = False
    Dim downloadCounter As Integer
    Dim ResUrl, indexvidname As String

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

    'Private Sub browseButton_Click(sender As Object, e As EventArgs) Handles browseButton.Click
    '    openDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
    '    openDialog.FileName = "vjs_playlist"
    '    openDialog.Title = "Open a vjs_playlist"
    '    openDialog.Filter = "m3u8 File|*.m3u8|m3u8 PHP|*.php"

    '    If openDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

    '        Call getClipInfo(openDialog.FileName)

    '    End If
    'End Sub

    Private Sub getClipInfo(getFrom As String)
        Dim searchRES, searchURL As Boolean
        Dim dataVid(), urlVid() As String
        Dim cntr As Integer = 0

        Try
            For Each lineRes As String In System.IO.File.ReadAllLines(getFrom)
                searchRES = lineRes.Contains("NAME")
                If searchRES Then
                    cntr = cntr + 1
                End If
            Next

            ReDim dataVid(cntr - 1)
            ReDim urlVid(cntr - 1)

            cntr = 0
            For Each lineRes As String In System.IO.File.ReadAllLines(getFrom)
                searchRES = lineRes.Contains("NAME")
                If searchRES Then
                    dataVid(cntr) = lineRes.Substring(lineRes.IndexOf("NAME="))
                    cntr = cntr + 1
                End If
            Next

            cntr = 0
            For Each lineUrl As String In System.IO.File.ReadAllLines(getFrom)
                searchURL = lineUrl.Contains("http")
                If searchURL Then
                    urlVid(cntr) = lineUrl
                    cntr = cntr + 1
                End If
            Next

            If cntr <> 0 Then

                cntr = 0 ' Reset Counter to be use in the next loop

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

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub ListVidio_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles ListVidio.ColumnWidthChanging
        e.Cancel = True
        e.NewWidth = ListVidio.Columns(e.ColumnIndex).Width
    End Sub

    Private Sub downloader_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles downloader.DownloadProgressChanged

    End Sub

    Private Sub ProsesUrlFile()
        Dim searchURL As String
        Dim cntr As Integer = 0
        For Each lineUrl As String In System.IO.File.ReadAllLines(My.Computer.FileSystem.SpecialDirectories.Temp + "\vidio.feed")
            searchURL = lineUrl.Contains(".ts")
            If searchURL Then
                ListVidio.Items.Add(cntr + 1)
                ListVidio.Items(cntr).SubItems.Add(lineUrl)
                ListVidio.Items(cntr).SubItems.Add("?")
                cntr = cntr + 1
            End If
        Next

        If ListVidio.Items.Count > 0 Then
            indexvidname = ListVidio.Items(0).SubItems(1).Text.Substring(0, 3)
        End If
        ResUrl = cmbRes.SelectedValue.ToString.Substring(0, cmbRes.SelectedValue.ToString.IndexOf(indexvidname))
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ClipList()
        ListVidio.Items.Clear()
        ProsesUrlFile()
        startButton.Enabled = True
    End Sub

    Private Sub cmbRes_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbRes.SelectionChangeCommitted
        Me.Cursor = Cursors.WaitCursor
        videofeed = True
        DownloaderTS(cmbRes.SelectedValue, My.Computer.FileSystem.SpecialDirectories.Temp + "\vidio.feed")
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtsave.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    End Sub

    Private Sub DownloaderTS(ByVal urlvid As String, ByVal destname As String)
        Dim client As WebClient = New WebClient
        AddHandler client.DownloadProgressChanged, AddressOf client_ProgressChanged
        AddHandler client.DownloadFileCompleted, AddressOf client_DownloadCompleted
        client.DownloadFileAsync(New Uri(urlvid), destname)
    End Sub

    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        'Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        'Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim totalVideo As Double = ListVidio.Items.Count - 1
        Dim downloadedVideo As Double = downloadCounter
        Dim percentage As Double = Double.Parse(downloadedVideo) / Double.Parse(totalVideo) * 100

        If (itStart) Then
            lbprogress.Text = "Download progress " + Math.Round(percentage).ToString + "%"
            ProgressBar1.Value = Int32.Parse(Math.Truncate(percentage).ToString())
        End If

    End Sub

    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Dim strCombine, strffmpeg, mp4Name As String

        If Not (itStart) Then
            If (videofeed) Then
                Call ClipList()
                videofeed = False
            Else
                Call getClipInfo(My.Computer.FileSystem.SpecialDirectories.Temp + "\movieList.lst")
                videofeed = True
                DownloaderTS(cmbRes.SelectedValue, My.Computer.FileSystem.SpecialDirectories.Temp + "\vidio.feed")
            End If
        Else
            ListVidio.Items(downloadCounter).SubItems(2).Text = "OK"
            mp4Name = ListVidio.Items(0).SubItems(1).Text.Substring(0, ListVidio.Items(0).SubItems(1).Text.IndexOf(".ts")) + ".mp4"
            If (downloadCounter = ListVidio.Items.Count - 1) Then
                strCombine = "COPY /b " + ControlChars.Quote + My.Computer.FileSystem.SpecialDirectories.Temp + "\*.ts" + ControlChars.Quote + " " + ControlChars.Quote + My.Computer.FileSystem.SpecialDirectories.Temp + "\" + ListVidio.Items(0).SubItems(1).Text + "combine.ts" + ControlChars.Quote
                strffmpeg = " -i " + My.Computer.FileSystem.SpecialDirectories.Temp + "\" + ListVidio.Items(0).SubItems(1).Text + "combine.ts -acodec copy -vcodec copy " + ControlChars.Quote + txtsave.Text + "\" + mp4Name + ControlChars.Quote
                MyUtilities.RunCommandCom(strCombine, False)
                Process.Start(Application.StartupPath + "\ffmpeg.exe", strffmpeg)
                MessageBox.Show("Download Complete")
                MyUtilities.RunCommandCom("DEL " + ControlChars.Quote + My.Computer.FileSystem.SpecialDirectories.Temp + "\*.ts" + ControlChars.Quote, False) 'clean up folder from .ts file
                startButton.Text = "Start Download"
                startButton.Enabled = True
                cmbRes.Enabled = True
                itStart = False
            End If
            downloadCounter += 1
        End If

    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        Me.Cursor = Cursors.WaitCursor
        itStart = True
        downloadCounter = 0
        For i As Integer = 0 To ListVidio.Items.Count - 1
            DownloaderTS(ResUrl + ListVidio.Items(i).SubItems(1).Text, My.Computer.FileSystem.SpecialDirectories.Temp + "\" + ListVidio.Items(i).SubItems(1).Text)
        Next
        startButton.Text = "Downloading"
        startButton.Enabled = False
        cmbRes.Enabled = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnGetUrl_Click(sender As Object, e As EventArgs) Handles btnGetUrl.Click
        Dim fromtxtUrl As String = txturl.Text
        Dim terafileID As String

        If fromtxtUrl <> "" Then
            Me.Cursor = Cursors.WaitCursor
            itStart = False
            ProgressBar1.Value = 0
            lbprogress.Text = "Download progress 0%"
            If rbvidio.Checked = True Then
                ' vidio.com
                If fromtxtUrl.Contains("http") Then
                    MsgBox("please enter vidio ID for vidio.com")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                DownloaderTS("https://www.vidio.com/videos/" + fromtxtUrl + "/vjs_playlist.m3u8", My.Computer.FileSystem.SpecialDirectories.Temp + "\movieList.lst")
            Else
                ' terafile.net
                If Not fromtxtUrl.Contains("http") Then
                    MsgBox("please enter correct url for terafile")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                terafileID = fromtxtUrl.Substring(fromtxtUrl.IndexOf("?slug="), Len(fromtxtUrl) - fromtxtUrl.IndexOf("?slug="))
                DownloaderTS("https://hls.faststream.me/m3u8.php" + terafileID, My.Computer.FileSystem.SpecialDirectories.Temp + "\movieList.lst")
            End If
        End If
    End Sub

    Private Sub rbvidio_Click(sender As Object, e As EventArgs) Handles rbvidio.Click
        lbsource.Text = "ID :"
        cmbRes.DataSource = Nothing
        cmbRes.Items.Clear()
        startButton.Enabled = False
    End Sub

    Private Sub rbterafile_Click(sender As Object, e As EventArgs) Handles rbterafile.Click
        lbsource.Text = "URL"
        cmbRes.DataSource = Nothing
        cmbRes.Items.Clear()
        startButton.Enabled = False
    End Sub

    Private Sub btnFolder_Click(sender As Object, e As EventArgs) Handles btnFolder.Click
        If FolderSave.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtsave.Text = FolderSave.SelectedPath
        End If
    End Sub
End Class