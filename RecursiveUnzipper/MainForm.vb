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
    Private Sub butUnzip_Click(sender As Object, e As EventArgs) Handles butUnzip.Click
        unzipFolder = My.Computer.FileSystem.SpecialDirectories.Temp & "\temp00000unzip"
        If IO.File.Exists(txtZip.Text) = False Then
            LogMessage("The file doesn't exist: " & txtZip.Text)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtZip.Text) Then
            LogMessage("First select a file to unzip(zip, or rar)")
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
        If Not IO.Directory.Exists(unzipFolder) Then
            IO.Directory.CreateDirectory(unzipFolder)

        End If
        cancelRequested = False
        butCancel.Enabled = True
        Application.DoEvents()
        LogMessage("Started **************")
        System.IO.Directory.Delete(unzipFolder, True)
        Dim zippath As String = txtZip.Text
        IO.Directory.CreateDirectory(unzipFolder)
        Dim extrPath As String = txtOutput.Text
        Try
            If selfile = "zip" Then
                ZipFile.ExtractToDirectory(zippath, unzipFolder)
            Else
                Dim unra As New SevenZipExtractor.ArchiveFile(zippath)
                unra.Extract(unzipFolder, True)
                unra.Dispose()
            End If
        Catch ex As Exception
            LogMessage(ex.Message)
            LogMessage("Stopped **************")
            butCancel.Enabled = False
            Exit Sub
        End Try
        CopyToFolder(unzipFolder, extrPath)
        System.IO.Directory.Delete(unzipFolder, True)
        LogMessage("Completed successfully **************")
        butCancel.Enabled = False
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
            fls = IO.Directory.GetFiles(tempFolder, "*.jpg")
            LogMessage("Found " & fls.Length & " jpg files in " & tempFolder)

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

                    IO.File.Copy(f, outputFolder & "\" & IO.Path.GetFileName(f))
                Catch ex As Exception
                    LogMessage(ex.Message)
                End Try

            Next
            fls = IO.Directory.GetFiles(tempFolder, "*.png")
            LogMessage("Found " & fls.Length & " png files in " & tempFolder)
            For Each f As String In fls
                If cancelRequested Then Exit Sub
                Try

                    If Not IO.File.Exists(outputFolder & "\" & IO.Path.GetFileName(f)) Then IO.File.Copy(f, outputFolder & "\" & IO.Path.GetFileName(f))
                Catch ex As Exception
                    LogMessage(ex.Message)
                End Try
            Next
            fls = IO.Directory.GetFiles(tempFolder, "*.bmp")
            LogMessage("Found " & fls.Length & " bmp files in " & tempFolder)
            For Each f As String In fls
                If cancelRequested Then Exit Sub
                If Not IO.Directory.Exists(outputFolder) Then
                    IO.Directory.CreateDirectory(outputFolder)

                End If
                If Not IO.File.Exists(outputFolder & "\" & IO.Path.GetFileName(f)) Then IO.File.Copy(f, outputFolder & "\" & IO.Path.GetFileName(f))
            Next
            fls = IO.Directory.GetFiles(tempFolder, "*.ico")
            LogMessage("Found " & fls.Length & " ico files in " & tempFolder)
            For Each f As String In fls
                If cancelRequested Then Exit Sub
                If Not IO.Directory.Exists(outputFolder) Then
                    IO.Directory.CreateDirectory(outputFolder)

                End If
                If Not IO.File.Exists(outputFolder & "\" & IO.Path.GetFileName(f)) Then IO.File.Copy(f, outputFolder & "\" & IO.Path.GetFileName(f))
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
        Dim selfdg As New OpenFileDialog
        With selfdg
            .InitialDirectory = My.Settings.ZipLocation
            .Filter = "Zip files|*.zip|Rar files|*.rar"
            If .ShowDialog = DialogResult.OK Then
                txtZip.Text = .FileName
                My.Settings.ZipLocation = IO.Path.GetDirectoryName(.FileName)
                My.Settings.Save()
            End If
            If .FilterIndex = 0 Then
                selfile = "zip"
            Else
                selfile = "rar"
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
            End If
        End With

    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        cancelRequested = True
        LogMessage("Cancel requested...")
        butCancel.Enabled = False

    End Sub
End Class
