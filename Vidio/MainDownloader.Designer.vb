<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.startButton = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ListVidio = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmbRes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtsave = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txturl = New System.Windows.Forms.TextBox()
        Me.btnGetUrl = New System.Windows.Forms.Button()
        Me.rbvidio = New System.Windows.Forms.RadioButton()
        Me.rbterafile = New System.Windows.Forms.RadioButton()
        Me.lbprogress = New System.Windows.Forms.Label()
        Me.lbsource = New System.Windows.Forms.Label()
        Me.btnFolder = New System.Windows.Forms.Button()
        Me.FolderSave = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'startButton
        '
        Me.startButton.Enabled = False
        Me.startButton.Location = New System.Drawing.Point(154, 102)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(126, 23)
        Me.startButton.TabIndex = 3
        Me.startButton.Text = "Start Download"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 315)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(260, 19)
        Me.ProgressBar1.TabIndex = 1
        '
        'ListVidio
        '
        Me.ListVidio.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListVidio.FullRowSelect = True
        Me.ListVidio.GridLines = True
        Me.ListVidio.Location = New System.Drawing.Point(4, 132)
        Me.ListVidio.Name = "ListVidio"
        Me.ListVidio.ShowItemToolTips = True
        Me.ListVidio.Size = New System.Drawing.Size(275, 164)
        Me.ListVidio.TabIndex = 3
        Me.ListVidio.UseCompatibleStateImageBehavior = False
        Me.ListVidio.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "#"
        Me.ColumnHeader1.Width = 35
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "File to download"
        Me.ColumnHeader2.Width = 163
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Status"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 55
        '
        'cmbRes
        '
        Me.cmbRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRes.FormattingEnabled = True
        Me.cmbRes.Location = New System.Drawing.Point(4, 103)
        Me.cmbRes.Name = "cmbRes"
        Me.cmbRes.Size = New System.Drawing.Size(147, 21)
        Me.cmbRes.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Save to:"
        '
        'txtsave
        '
        Me.txtsave.Location = New System.Drawing.Point(52, 76)
        Me.txtsave.Name = "txtsave"
        Me.txtsave.Size = New System.Drawing.Size(183, 20)
        Me.txtsave.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Indigo
        Me.Label2.Location = New System.Drawing.Point(106, 343)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Written by lsahidin on github"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Vidio.My.Resources.Resources.github
        Me.PictureBox1.Location = New System.Drawing.Point(249, 337)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 23)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(32, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(222, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Vidio.com and Terafile.net Movie Downloader"
        '
        'txturl
        '
        Me.txturl.Location = New System.Drawing.Point(35, 49)
        Me.txturl.Name = "txturl"
        Me.txturl.Size = New System.Drawing.Size(200, 20)
        Me.txturl.TabIndex = 0
        '
        'btnGetUrl
        '
        Me.btnGetUrl.Location = New System.Drawing.Point(241, 47)
        Me.btnGetUrl.Name = "btnGetUrl"
        Me.btnGetUrl.Size = New System.Drawing.Size(39, 23)
        Me.btnGetUrl.TabIndex = 2
        Me.btnGetUrl.Text = "Get"
        Me.btnGetUrl.UseVisualStyleBackColor = True
        '
        'rbvidio
        '
        Me.rbvidio.AutoSize = True
        Me.rbvidio.Checked = True
        Me.rbvidio.Location = New System.Drawing.Point(62, 27)
        Me.rbvidio.Name = "rbvidio"
        Me.rbvidio.Size = New System.Drawing.Size(71, 17)
        Me.rbvidio.TabIndex = 13
        Me.rbvidio.TabStop = True
        Me.rbvidio.Text = "Vidio.com"
        Me.rbvidio.UseVisualStyleBackColor = True
        '
        'rbterafile
        '
        Me.rbterafile.AutoSize = True
        Me.rbterafile.Location = New System.Drawing.Point(148, 27)
        Me.rbterafile.Name = "rbterafile"
        Me.rbterafile.Size = New System.Drawing.Size(78, 17)
        Me.rbterafile.TabIndex = 14
        Me.rbterafile.Text = "Terafile.net"
        Me.rbterafile.UseVisualStyleBackColor = True
        '
        'lbprogress
        '
        Me.lbprogress.AutoSize = True
        Me.lbprogress.Location = New System.Drawing.Point(7, 300)
        Me.lbprogress.Name = "lbprogress"
        Me.lbprogress.Size = New System.Drawing.Size(115, 13)
        Me.lbprogress.TabIndex = 15
        Me.lbprogress.Text = "Download progress 0%"
        '
        'lbsource
        '
        Me.lbsource.AutoSize = True
        Me.lbsource.Location = New System.Drawing.Point(4, 52)
        Me.lbsource.Name = "lbsource"
        Me.lbsource.Size = New System.Drawing.Size(24, 13)
        Me.lbsource.TabIndex = 16
        Me.lbsource.Text = "ID :"
        '
        'btnFolder
        '
        Me.btnFolder.Location = New System.Drawing.Point(241, 74)
        Me.btnFolder.Name = "btnFolder"
        Me.btnFolder.Size = New System.Drawing.Size(39, 23)
        Me.btnFolder.TabIndex = 1
        Me.btnFolder.Text = ". . />"
        Me.btnFolder.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 362)
        Me.Controls.Add(Me.btnFolder)
        Me.Controls.Add(Me.lbsource)
        Me.Controls.Add(Me.lbprogress)
        Me.Controls.Add(Me.rbterafile)
        Me.Controls.Add(Me.rbvidio)
        Me.Controls.Add(Me.btnGetUrl)
        Me.Controls.Add(Me.txturl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtsave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbRes)
        Me.Controls.Add(Me.ListVidio)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.startButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movie Downloader"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents startButton As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListVidio As System.Windows.Forms.ListView
    Friend WithEvents cmbRes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtsave As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txturl As System.Windows.Forms.TextBox
    Friend WithEvents btnGetUrl As System.Windows.Forms.Button
    Friend WithEvents rbvidio As System.Windows.Forms.RadioButton
    Friend WithEvents rbterafile As System.Windows.Forms.RadioButton
    Friend WithEvents lbprogress As System.Windows.Forms.Label
    Friend WithEvents lbsource As System.Windows.Forms.Label
    Friend WithEvents btnFolder As System.Windows.Forms.Button
    Friend WithEvents FolderSave As System.Windows.Forms.FolderBrowserDialog

End Class
