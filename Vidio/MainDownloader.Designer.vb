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
        Me.browseButton = New System.Windows.Forms.Button()
        Me.openDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ListVidio = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmbRes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtsave = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'startButton
        '
        Me.startButton.Location = New System.Drawing.Point(146, 266)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(126, 23)
        Me.startButton.TabIndex = 0
        Me.startButton.Text = "Start Download"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 241)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(260, 19)
        Me.ProgressBar1.TabIndex = 1
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(3, 12)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(104, 23)
        Me.browseButton.TabIndex = 2
        Me.browseButton.Text = "Browse vjs_playlist"
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'openDialog
        '
        Me.openDialog.FileName = "OpenFileDialog1"
        '
        'ListVidio
        '
        Me.ListVidio.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListVidio.FullRowSelect = True
        Me.ListVidio.GridLines = True
        Me.ListVidio.Location = New System.Drawing.Point(3, 41)
        Me.ListVidio.Name = "ListVidio"
        Me.ListVidio.ShowItemToolTips = True
        Me.ListVidio.Size = New System.Drawing.Size(275, 155)
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
        Me.cmbRes.Location = New System.Drawing.Point(111, 14)
        Me.cmbRes.Name = "cmbRes"
        Me.cmbRes.Size = New System.Drawing.Size(168, 21)
        Me.cmbRes.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 199)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Save to:"
        '
        'txtsave
        '
        Me.txtsave.Location = New System.Drawing.Point(12, 215)
        Me.txtsave.Name = "txtsave"
        Me.txtsave.Size = New System.Drawing.Size(260, 20)
        Me.txtsave.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Indigo
        Me.Label2.Location = New System.Drawing.Point(11, 271)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Written by lsahidin"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Vidio.My.Resources.Resources.github
        Me.PictureBox1.Location = New System.Drawing.Point(102, 266)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 23)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 296)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtsave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbRes)
        Me.Controls.Add(Me.ListVidio)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.startButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vidio Downloader"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents startButton As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents browseButton As System.Windows.Forms.Button
    Friend WithEvents openDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListVidio As System.Windows.Forms.ListView
    Friend WithEvents cmbRes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtsave As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
