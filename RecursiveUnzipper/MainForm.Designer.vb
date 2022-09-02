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
        Me.SuspendLayout
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(35, 18)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.ReadOnly = true
        Me.txtZip.Size = New System.Drawing.Size(268, 23)
        Me.txtZip.TabIndex = 0
        '
        'butSelectFile
        '
        Me.butSelectFile.Location = New System.Drawing.Point(310, 13)
        Me.butSelectFile.Name = "butSelectFile"
        Me.butSelectFile.Size = New System.Drawing.Size(119, 31)
        Me.butSelectFile.TabIndex = 1
        Me.butSelectFile.Text = "Select zip file"
        Me.butSelectFile.UseVisualStyleBackColor = true
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(35, 52)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = true
        Me.txtOutput.Size = New System.Drawing.Size(268, 23)
        Me.txtOutput.TabIndex = 2
        '
        'butSelectOutput
        '
        Me.butSelectOutput.Location = New System.Drawing.Point(310, 47)
        Me.butSelectOutput.Name = "butSelectOutput"
        Me.butSelectOutput.Size = New System.Drawing.Size(119, 31)
        Me.butSelectOutput.TabIndex = 3
        Me.butSelectOutput.Text = "Select output folder"
        Me.butSelectOutput.UseVisualStyleBackColor = True
        '
        'butUnzip
        '
        Me.butUnzip.Location = New System.Drawing.Point(435, 44)
        Me.butUnzip.Name = "butUnzip"
        Me.butUnzip.Size = New System.Drawing.Size(119, 31)
        Me.butUnzip.TabIndex = 4
        Me.butUnzip.Text = "Unzip"
        Me.butUnzip.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtLog.Location = New System.Drawing.Point(12, 84)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.Size = New System.Drawing.Size(542, 300)
        Me.txtLog.TabIndex = 5
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 396)
        Me.Controls.Add(Me.butUnzip)
        Me.Controls.Add(Me.butSelectOutput)
        Me.Controls.Add(Me.butSelectFile)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.txtZip)
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
End Class
