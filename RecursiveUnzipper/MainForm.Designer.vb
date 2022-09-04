<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.butSelectFile = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.butSelectOutput = New System.Windows.Forms.Button()
        Me.butUnzip = New System.Windows.Forms.Button()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.txtFilters = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstZipfiles = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkOverwrite = New System.Windows.Forms.CheckBox()
        Me.chkRemoveparent = New System.Windows.Forms.CheckBox()
        Me.chkIgnoreifFilesPresent = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txtZip
        '
        Me.txtZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZip.Location = New System.Drawing.Point(12, 26)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.ReadOnly = True
        Me.txtZip.Size = New System.Drawing.Size(243, 23)
        Me.txtZip.TabIndex = 1
        '
        'butSelectFile
        '
        Me.butSelectFile.Location = New System.Drawing.Point(261, 21)
        Me.butSelectFile.Name = "butSelectFile"
        Me.butSelectFile.Size = New System.Drawing.Size(30, 31)
        Me.butSelectFile.TabIndex = 2
        Me.butSelectFile.Text = "..."
        Me.butSelectFile.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutput.Location = New System.Drawing.Point(12, 422)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.Size = New System.Drawing.Size(243, 23)
        Me.txtOutput.TabIndex = 5
        '
        'butSelectOutput
        '
        Me.butSelectOutput.Location = New System.Drawing.Point(261, 417)
        Me.butSelectOutput.Name = "butSelectOutput"
        Me.butSelectOutput.Size = New System.Drawing.Size(30, 31)
        Me.butSelectOutput.TabIndex = 6
        Me.butSelectOutput.Text = "..."
        Me.butSelectOutput.UseVisualStyleBackColor = True
        '
        'butUnzip
        '
        Me.butUnzip.Enabled = False
        Me.butUnzip.Location = New System.Drawing.Point(536, 21)
        Me.butUnzip.Name = "butUnzip"
        Me.butUnzip.Size = New System.Drawing.Size(119, 31)
        Me.butUnzip.TabIndex = 12
        Me.butUnzip.Text = "Unzip"
        Me.butUnzip.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLog.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtLog.Location = New System.Drawing.Point(297, 73)
        Me.txtLog.MaxLength = 6576700
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.Size = New System.Drawing.Size(479, 431)
        Me.txtLog.TabIndex = 14
        '
        'butCancel
        '
        Me.butCancel.Enabled = False
        Me.butCancel.Location = New System.Drawing.Point(657, 21)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(119, 31)
        Me.butCancel.TabIndex = 13
        Me.butCancel.Text = "Cancel operation"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'txtFilters
        '
        Me.txtFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilters.Location = New System.Drawing.Point(12, 470)
        Me.txtFilters.Name = "txtFilters"
        Me.txtFilters.Size = New System.Drawing.Size(278, 23)
        Me.txtFilters.TabIndex = 8
        Me.txtFilters.Text = "*.*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folder with zip/rar files"
        '
        'lstZipfiles
        '
        Me.lstZipfiles.FormattingEnabled = True
        Me.lstZipfiles.ItemHeight = 15
        Me.lstZipfiles.Location = New System.Drawing.Point(12, 55)
        Me.lstZipfiles.Name = "lstZipfiles"
        Me.lstZipfiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstZipfiles.Size = New System.Drawing.Size(278, 334)
        Me.lstZipfiles.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 404)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Output folder"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 452)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fille patterns"
        '
        'chkOverwrite
        '
        Me.chkOverwrite.AutoSize = True
        Me.chkOverwrite.Location = New System.Drawing.Point(297, 7)
        Me.chkOverwrite.Name = "chkOverwrite"
        Me.chkOverwrite.Size = New System.Drawing.Size(227, 19)
        Me.chkOverwrite.TabIndex = 9
        Me.chkOverwrite.Text = "Overwrite, if files are present in output"
        Me.chkOverwrite.UseVisualStyleBackColor = True
        '
        'chkRemoveparent
        '
        Me.chkRemoveparent.AutoSize = True
        Me.chkRemoveparent.Location = New System.Drawing.Point(297, 26)
        Me.chkRemoveparent.Name = "chkRemoveparent"
        Me.chkRemoveparent.Size = New System.Drawing.Size(219, 19)
        Me.chkRemoveparent.TabIndex = 10
        Me.chkRemoveparent.Text = "Ignore first level if one folder present"
        Me.chkRemoveparent.UseVisualStyleBackColor = True
        '
        'chkIgnoreifFilesPresent
        '
        Me.chkIgnoreifFilesPresent.AutoSize = True
        Me.chkIgnoreifFilesPresent.Enabled = False
        Me.chkIgnoreifFilesPresent.Location = New System.Drawing.Point(297, 48)
        Me.chkIgnoreifFilesPresent.Name = "chkIgnoreifFilesPresent"
        Me.chkIgnoreifFilesPresent.Size = New System.Drawing.Size(202, 19)
        Me.chkIgnoreifFilesPresent.TabIndex = 11
        Me.chkIgnoreifFilesPresent.Text = "Ignore first level, even if files exist"
        Me.chkIgnoreifFilesPresent.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 516)
        Me.Controls.Add(Me.chkIgnoreifFilesPresent)
        Me.Controls.Add(Me.chkRemoveparent)
        Me.Controls.Add(Me.chkOverwrite)
        Me.Controls.Add(Me.lstZipfiles)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butUnzip)
        Me.Controls.Add(Me.butSelectOutput)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butSelectFile)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.txtFilters)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.txtZip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recursize Unzipper"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents txtZip As TextBox
    Friend WithEvents butSelectFile As Button
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents butSelectOutput As Button
    Friend WithEvents butUnzip As Button
    Friend WithEvents txtLog As TextBox
    Friend WithEvents butCancel As Button
    Friend WithEvents txtFilters As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lstZipfiles As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents chkOverwrite As CheckBox
    Friend WithEvents chkRemoveparent As CheckBox
    Friend WithEvents chkIgnoreifFilesPresent As CheckBox
End Class
