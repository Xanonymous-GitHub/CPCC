Imports System.IO
Public Class start

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PictureBox1.Visible = False
        Label1.Visible = False
        Button1.Visible = False
        Button2.Visible = True
        Label2.Visible = True
        RadioButton1.Visible = True
        RadioButton3.Visible = True
        RadioButton2.Visible = True
        RadioButton4.Visible = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Button2.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If RadioButton1.Checked = True Then
            Me.Close()
        End If
        If RadioButton3.Checked = True Then
            End
        End If
        If RadioButton2.Checked = True Then
            Dim i As New ihh
            i.ShowDialog()
        End If
        If RadioButton4.Checked Then
            Try
                Dim p As New Process()
                Dim psi As New ProcessStartInfo("校排班排計算器使用說明.chm")
                psi.Verb = "open"
                p.StartInfo = psi
                p.Start()
            Catch ex As Exception
                MsgBox("找不到說明檔。", 16, "錯誤")
            End Try
            
        End If

    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Button2.Enabled = True
    End Sub

    Private Sub start_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dir As DirectoryInfo = New DirectoryInfo("c:\windows\system32\cs-CZ\gbh4832\")
        If dir.Exists = False Then
            Dim c As Check = New Check
            c.ShowDialog()
            Me.Hide()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Button2.Enabled = True
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Button2.Enabled = True
    End Sub

    

End Class