Imports System.IO.Compression
Imports SevenZipExtractor
'***********************************************************************
'Copyright 2022 Vijay Sridhara

'Licensed under the Apache License, Version 2.0 (the "License");
'you may not use this file except in compliance with the License.
'You may obtain a copy of the License at

'http://www.apache.org/licenses/LICENSE-2.0

'Unless required by applicable law or agreed to in writing, software
'distributed under the License is distributed on an "AS IS" BASIS,
'WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'See the License for the specific language governing permissions and
'limitations under the License.
'***********************************************************************
Public Class MainForm
    Private unzipFolder As String
    Dim selfile As String
    Dim cancelRequested As Boolean = False
    Dim filters As New List(Of String)
    Private Sub butUnzip_Click(sender As Object, e As EventArgs) Handles butUnzip.Click
        unzipFolder = My.Computer.FileSystem.SpecialDirectories.Temp & "\temp00000recurunzip"
        If IO.Directory.Exists(txtZip.Text) = False Then
            LogMessage("The input directory doesn't exist: " & txtZip.Text)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtZip.Text) Then
            LogMessage("First select a folder that contains to unzip(zip, or rar)")
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtOutput.Text) Then
            LogMessage("Output directory must be selected, for extracting...")
            Exit Sub
        End If
        If Not IO.Directory.Exists(txtOutput.Text) Then
            LogMessage("The selected output directory doesn't exist " & txtOutput.Text)
            Exit Sub

        End If
        If String.IsNullOrEmpty(txtFilters.Text) Then
            LogMessage("You should specify one or more filters like *.jpg, *.png. Or for all files *.*")
            Exit Sub
        End If
        If lstZipfiles.SelectedItems.Count = 0 Then
            LogMessage("You must select at least one zip/rar file to process, from the list on left. Hold control to select multiple")
            Exit Sub
        End If
        filters.Clear()
        filters.AddRange(txtFilters.Text.Split(","))
        If Not IO.Directory.Exists(unzipFolder) Then
            IO.Directory.CreateDirectory(unzipFolder)

        End If
        cancelRequested = False
        butCancel.Enabled = True
        butUnzip.Enabled = False
        Application.DoEvents()
        LogMessage("Started **************")
        LogMessage("Processing " & lstZipfiles.SelectedItems.Count & " items")
        System.IO.Directory.Delete(unzipFolder, True)
        Dim zippath As String = txtZip.Text
        For Each f As String In lstZipfiles.SelectedItems
            zippath = txtZip.Text & "\" & f
            IO.Directory.CreateDirectory(unzipFolder)
            Dim extrPath As String = txtOutput.Text
            selfile = IIf(IO.Path.GetExtension(zippath) = ".zip", "zip", "rar")
            Try
                If cancelRequested Then
                    LogMessage("Cancel requested...")
                    LogMessage("Stopped *************")
                    Exit Sub
                End If
                If selfile = "zip" Then
                    ZipFile.ExtractToDirectory(zippath, unzipFolder)
                Else
                    Dim unra As New SevenZipExtractor.ArchiveFile(zippath)
                    unra.Extract(unzipFolder, True)
                    unra.Dispose()
                End If
            Catch ex As Exception
                LogMessage(ex.Message)
            End Try
            Dim passpath As String = unzipFolder
            If chkRemoveparent.Checked Then
                Dim dirs() As String = IO.Directory.GetDirectories(unzipFolder)
                If dirs.Length = 1 Then
                    Dim fls() As String = IO.Directory.GetFiles(unzipFolder, "*.*")
                    If fls.Length = 0 Or chkIgnoreifFilesPresent.Checked Then
                        passpath = dirs(0)
                    End If
                End If
            End If
            CopyToFolder(passpath, extrPath)
            System.IO.Directory.Delete(unzipFolder, True)
        Next
        LogMessage("Completed successfully **************")
        butCancel.Enabled = False
        butUnzip.Enabled = True
    End Sub
    Private Sub LogMessage(msg As String)
        Application.DoEvents()
        txtLog.Text += msg & vbCrLf
        txtLog.SelectionStart = txtLog.TextLength
        txtLog.ScrollToCaret()
        txtLog.Refresh()
    End Sub
    Private Sub CopyToFolder(tempFolder As String, outputFolder As String)
        If cancelRequested Then Exit Sub
        LogMessage("Checking " & tempFolder)

        Try
            Dim fls() As String = IO.Directory.GetFiles(tempFolder, "*.zip")

            For Each f As String In fls
                If cancelRequested Then Exit Sub
                LogMessage("Found zip file " & f)

                Try
                    ZipFile.ExtractToDirectory(f, tempFolder)
                Catch ex As Exception
                    LogMessage("[Error in zip file " & f & "]")
                    LogMessage(ex.Message)
                End Try


            Next
            fls = IO.Directory.GetFiles(tempFolder, "*.rar")
            For Each f As String In fls
                If cancelRequested Then Exit Sub
                LogMessage("Found rar file " & f)
                Try
                    Dim unra As New SevenZipExtractor.ArchiveFile(f)

                    unra.Extract(outputFolder, True)
                    unra.Dispose()
                Catch ex As Exception
                    LogMessage("[Error in rar file " & f & "]")
                    LogMessage(ex.Message)
                End Try

            Next
            For Each fil As String In filters
                fls = IO.Directory.GetFiles(tempFolder, fil)
                LogMessage("Found " & fls.Length & fil & " files in " & tempFolder)
                Try
                    If Not IO.Directory.Exists(outputFolder) Then
                        IO.Directory.CreateDirectory(outputFolder)
                    End If
                Catch ex As Exception
                    LogMessage(ex.Message)
                End Try
                For Each f As String In fls
                    If cancelRequested Then Exit Sub
                    Try
                        IO.File.Copy(f, outputFolder & "\" & IO.Path.GetFileName(f), chkOverwrite.Checked)
                    Catch ex As Exception
                        LogMessage(ex.Message)
                    End Try

                Next
            Next
            Dim dis() As String = IO.Directory.GetDirectories(tempFolder)
            LogMessage("Found " & dis.Length & " directories in " & tempFolder)
            For Each di As String In dis
                If cancelRequested Then Exit Sub
                If IO.Directory.Exists(outputFolder & "\" & IO.Path.GetFileName(di)) = False Then
                    IO.Directory.CreateDirectory(outputFolder & "\" & IO.Path.GetFileName(di))
                End If
                CopyToFolder(di, outputFolder & "\" & IO.Path.GetFileName(di))
            Next

        Catch ex As Exception
            LogMessage(ex.Message)
        End Try


    End Sub

    Private Sub butSelectFile_Click(sender As Object, e As EventArgs) Handles butSelectFile.Click
        Dim selfdg As New FolderBrowserDialog
        With selfdg
            .InitialDirectory = My.Settings.ZipLocation

            If .ShowDialog = DialogResult.OK Then
                txtZip.Text = .SelectedPath
                My.Settings.ZipLocation = .SelectedPath
                My.Settings.Save()
            End If
            lstZipfiles.Items.Clear()
            Dim zipfiles() As String = IO.Directory.GetFiles(selfdg.SelectedPath, "*.zip")
            For Each z As String In zipfiles
                lstZipfiles.Items.Add(IO.Path.GetFileName(z))
            Next
            Dim rarFiles() As String = IO.Directory.GetFiles(selfdg.SelectedPath, "*.rar")
            For Each r As String In rarFiles
                lstZipfiles.Items.Add(IO.Path.GetFileName(r))
            Next
            If lstZipfiles.Items.Count > 0 And IO.Directory.Exists(txtOutput.Text) Then
                butUnzip.Enabled = True
            Else
                butUnzip.Enabled = False
            End If
        End With
    End Sub

    Private Sub butSelectOutput_Click(sender As Object, e As EventArgs) Handles butSelectOutput.Click
        Dim ofd As New FolderBrowserDialog
        With ofd
            .InitialDirectory = My.Settings.OutputLocation
            If .ShowDialog = DialogResult.OK Then
                txtOutput.Text = .SelectedPath
                My.Settings.OutputLocation = .SelectedPath
                My.Settings.Save()
                If lstZipfiles.Items.Count > 0 And IO.Directory.Exists(txtOutput.Text) Then
                    butUnzip.Enabled = True
                Else
                    butUnzip.Enabled = False
                End If
            End If
        End With

    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        cancelRequested = True
        LogMessage("Cancel requested...")
        butCancel.Enabled = False

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub chkOverwrite_CheckedChanged(sender As Object, e As EventArgs) Handles chkOverwrite.CheckedChanged

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkOverwrite.Checked = My.Settings.Overwrite
        txtFilters.Text = My.Settings.Filters
        chkRemoveparent.Checked = My.Settings.IgnoreFolderZips

    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Overwrite = chkOverwrite.Checked
        My.Settings.Filters = txtFilters.Text
        My.Settings.IgnoreFolderZips = chkRemoveparent.Checked
        My.Settings.Save()
    End Sub

    Private Sub chkRemoveparent_CheckedChanged(sender As Object, e As EventArgs) Handles chkRemoveparent.CheckedChanged
        If chkRemoveparent.Checked Then
            chkIgnoreifFilesPresent.Enabled = True
        Else
            chkIgnoreifFilesPresent.Enabled = False

        End If
    End Sub
End Class
