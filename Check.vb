Imports System.IO
Public Class Check

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim a, b, c, d As String
        Dim dir As DirectoryInfo = New DirectoryInfo("c:\windows\system32\cs-CZ\gbh4832\")
        Dim f As FileInfo = New FileInfo("c:\windows\system32\cs-CZ\gbh4832\b$c$0$1$aak.dll")
        a = TextBox1.Text
        b = TextBox2.Text
        c = TextBox3.Text
        d = a + b + c
        Select Case d
            Case "458GHM4895MHD8H"
                dir.Create()
                Dim fl As FileStream = f.Create
                fl.Close()
                Dim sr As StreamWriter = New StreamWriter("c:\windows\system32\cs-CZ\gbh4832\b$c$0$1$aak.dll")
                sr.Write("458GHM4895MHD8H")
                sr.Close()
                MsgBox("軟體已驗證", 64, "")
                Me.Close()
            Case "MCH875GMHUH4FHV"
                dir.Create()
                Dim fl As FileStream = f.Create
                fl.Close()
                Dim sr As StreamWriter = New StreamWriter("c:\windows\system32\cs-CZ\gbh4832\b$c$0$1$aak.dll")
                sr.Write("MCH875GMHUH4FHV")
                sr.Close()
                MsgBox("軟體已驗證", 64, "")
                Me.Close()
            Case "IUCEI5FMBC5H4GF"
                dir.Create()
                Dim fl As FileStream = f.Create
                fl.Close()
                Dim sr As StreamWriter = New StreamWriter("c:\windows\system32\cs-CZ\gbh4832\b$c$0$1$aak.dll")
                sr.Write("IUCEI5FMBC5H4GF")
                sr.Close()
                MsgBox("軟體已驗證", 64, "")
                Me.Close()
            Case "CNUBIF48GHUR5XH"
                dir.Create()
                Dim fl As FileStream = f.Create
                fl.Close()
                Dim sr As StreamWriter = New StreamWriter("c:\windows\system32\cs-CZ\gbh4832\b$c$0$1$aak.dll")
                sr.Write("CNUBIF48GHUR5XH")
                sr.Close()
                MsgBox("軟體已驗證", 64, "")
                Me.Close()
            Case Else
                MsgBox("這個驗證碼是無效的,請重新輸入。", 16, "")
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
        End Select
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        End
    End Sub
End Class