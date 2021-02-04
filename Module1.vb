Imports System.IO
Module Module1

    Sub Main()
        Console.Write("                          校  排  班  排  計  算  器        <Professiona-v1.5>  ")
        Console.Write("================================================================================")
        Console.WriteLine("說明:本程式所計算之校排結果乃估計用,非完全準確(90%)。")
        Console.Write("使用方式:將學校發的成績單上的計算值照順序輸入即可,本程式將會自動計算校排及班排。")
        Console.WriteLine("班級校排模式的計算結果將會以文字及表格建立於""C:\校排班排計算結果\計算結果""中!")
        Console.WriteLine("注意:所有""回答""部分請用小寫!且任何地方亂打都可能發生錯誤!")
        Console.WriteLine("詳細使用說明請看附加使用說明檔,所有程序皆以按下""Enter""鍵來繼續執行。")
        Console.Write("--------------------------------------------------------------------------------")
        Dim st As New start
        st.ShowDialog()
        Dim cod As String
        Console.Write("")
        Console.Write(" 要開始使用了嗎?<YorN>")
        cod = Convert.ToString(Console.ReadLine())
        If cod = "y" Then
            GoTo star
        ElseIf cod = "Y" Then
            GoTo star
        Else
            GoTo sd
        End If
        Dim code As String
star:
        Console.Write("   請輸入應用程式啟動碼(網站上有寫):")
        code = Trim(Convert.ToString(Console.ReadLine()))
        If code = "oxwgla" Then
            Console.WriteLine("密碼已驗證")
        ElseIf code = "OXWGLA" Then
            Console.WriteLine("密碼已驗證")
        Else
            Console.WriteLine("密碼無法辨識,請至官網查詢!")
            Console.WriteLine("")
            GoTo star
        End If
stare:
        Console.WriteLine("--------------------------------------------------------------------------------")
        Dim a, b, c, d, e, f, ans As Single
        Dim y, n As String
        Console.Write("  ●功能選擇:     <班級校排""n""；單人校排:""e""；班級單科總分排名""f"">")
        n = Convert.ToString(Console.ReadLine())
        If n = "e" Then
            Console.WriteLine("-單人校排模式-")
            Call EA()
        ElseIf n = "n" Then
            Console.WriteLine("-班級校排模式-")
        ElseIf n = "f" Then
            Console.WriteLine("-班級單科總分排名模式-")
            Call qa()
        Else
            MsgBox("未知的項目!", 48, "注意")
            GoTo stare
        End If
        Console.Write("輸入這個班級的名稱:")
        y = Convert.ToString(Console.ReadLine())
1:
        Console.Write("輸入這次的組距差:")
        Try
            d = Convert.ToSingle(Console.ReadLine())
        Catch ex As Exception

            MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
            GoTo 1
        End Try
2:
        Console.Write("輸入班級人數:")
        Try
            a = Convert.ToSingle(Console.ReadLine())
            If a < 2 Or a > 48 Then
                MsgBox("班級人數應在2~48之間!", 48, "警告")
                GoTo 2
            End If
        Catch ex As Exception

            MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
            GoTo 2
        End Try
        Dim t(a - 1) As Single
        Dim r(a - 1) As Single
        Console.WriteLine("--------------------------------------------------------------------------------")
        For x As Integer = 1 To a
            Console.WriteLine("輸入{0}號的計算值:", x)
3:
            Console.Write("    總分:")
            Try
                e = Convert.ToSingle(Console.ReadLine())
            Catch ex As Exception

                MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
                GoTo 3
            End Try
4:
            Console.Write("    組距低:")
            Try
                f = Convert.ToSingle(Console.ReadLine())
            Catch ex As Exception

                MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
                GoTo 4
            End Try
5:
            Console.Write("    累積人數:")
            Try
                b = Convert.ToSingle(Console.ReadLine())
            Catch ex As Exception

                MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
                GoTo 5
            End Try
6:
            Console.Write("    組間人數:")
            Try
                c = Convert.ToSingle(Console.ReadLine())
            Catch ex As Exception

                MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
                GoTo 6
            End Try

            ans = Math.Ceiling(Math.Abs(((e - f) * c / d) - b))
            t(x - 1) = e
            Console.WriteLine("-----校排第_{0}_名-----", ans)
            r(x - 1) = ans
            Console.WriteLine("--------------------------------------------------------------------------------")
        Next
        Dim h(a - 1) As Integer
        Dim q(a - 1) As Integer
        Dim u(a - 1) As Integer
        For k As Integer = 0 To a - 1
            h(k) = (k + 1)
        Next
        For k As Integer = 0 To a - 1
            q(k) = (k + 1)
        Next
        For k As Integer = 0 To a - 1
            u(k) = (k + 1)
        Next
        For z As Single = 0 To t.Length - 1
            For j = z + 1 To t.Length - 1
                If t(z) < t(j) Then
                    Dim tmp As Single
                    tmp = t(z)
                    t(z) = t(j)
                    t(j) = tmp
                    Dim tmp2 As Single
                    tmp2 = h(z)
                    h(z) = h(j)
                    h(j) = tmp2
                    Dim tmp3 As Single
                    tmp3 = q(z)
                    q(z) = q(j)
                    q(j) = tmp3
                End If
            Next
        Next
        For mm As Integer = 0 To a - 1
            u(q(mm) - 1) = mm + 1
        Next
        Dim dir As DirectoryInfo = New DirectoryInfo("c:\校排班排結果")
        If dir.Exists Then
        Else
            dir.Create()
            dir.Refresh()
        End If
        Dim ssw As FileStream = New FileStream("c:\校排班排結果\計算結果(表格).html", FileMode.Create)
        Dim sw As StreamWriter = New StreamWriter(ssw, System.Text.Encoding.UTF8)
        Dim ssw2 As FileStream = New FileStream("c:\校排班排結果\計算結果(文字).txt", FileMode.Create)
        Dim sw2 As StreamWriter = New StreamWriter(ssw2, System.Text.Encoding.UTF8)
        Console.WriteLine("                      校  排  班  排  計  算  結  果  :(Class_{0})            ", y)
        sw2.Write("-------------------校  排  班  排  計  算  結  果  :(Class_{0})-------------------", y)
        sw.Write("<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"">")
        sw.Write("<html>")
        sw.Write("<body>")
        sw.Write("<font align=""center"" color=""#000000"" face=""Microsoft JhengHei""size=""5"">")
        sw.Write("<h1 align=""center"">")
        sw.Write("<font align=""center"" color=""#000000"" face=""Microsoft JhengHei""size=""6.5"">")
        sw.Write("<p><b>校班排計算結果(Class_{0})</b></p>", y)
        sw.Write("</font>")
        sw.Write("</h1>")
        sw.Write("<table align=""center"" border=""5"">")
        sw2.Write(vbNewLine)
        sw2.Write(vbNewLine)
        sw2.Write(" 班排如下:(在{0}人的情況下)", a)
        sw2.Write(vbNewLine)
        Console.WriteLine(" 班排如下:(在{0}人的情況下)", a)
        Dim w As Integer = 1
        For g = 1 To a
            Console.WriteLine("  第{0}名是{1}號；", w, h(g - 1))
            sw2.Write(vbNewLine)
            sw2.Write("  第{0}名是{1}號；", w, h(g - 1))
            w += 1
        Next
        sw2.Write(vbNewLine)
        sw2.Write(vbNewLine)
        sw2.Write("  校排如下:")
        sw2.Write(vbNewLine)
        Console.WriteLine(" 校排如下:")
        For i As Integer = 1 To a
            Console.WriteLine("  {0}號的校排是第{1}名;", i, r(i - 1))
            sw2.Write(vbNewLine)
            sw2.Write("  {0}號的校排是第{1}名;", i, r(i - 1))
        Next
        Dim ckck As Integer = a Mod 12
        If ckck = 0 Then
            ckck = (a / 12)
        Else
            ckck = (Math.Ceiling(a / 12))
        End If
        Dim tamp As Integer
        If ckck = 4 Then
            tamp = 47
        ElseIf ckck = 3 Then
            tamp = 35
        ElseIf ckck = 2 Then
            tamp = 23
        ElseIf ckck = 1 Then
            tamp = 11
        End If
        Dim ii(tamp), rr(tamp), uu(tamp) As String
        If ckck = 4 Then
            For j As Integer = 0 To a - 1
                ii(j) = Convert.ToString(j + 1)
                rr(j) = Convert.ToString(r(j))
                uu(j) = Convert.ToString(u(j))
            Next
        ElseIf ckck = 3 Then
            For j As Integer = 0 To a - 1
                ii(j) = Convert.ToString(j + 1)
                rr(j) = Convert.ToString(r(j))
                uu(j) = Convert.ToString(u(j))
            Next
        ElseIf ckck = 2 Then
            For j As Integer = 0 To a - 1
                ii(j) = Convert.ToString(j + 1)
                rr(j) = Convert.ToString(r(j))
                uu(j) = Convert.ToString(u(j))
            Next
        ElseIf ckck = 1 Then
            For j As Integer = 0 To a - 1
                ii(j) = Convert.ToString(j + 1)
                rr(j) = Convert.ToString(r(j))
                uu(j) = Convert.ToString(u(j))
            Next
        End If

        If ckck = 4 Then
            sw.Write("<tr><th><u>座號</u></th><td>校排</td><td>班排</td><th><u>座號</u></th><td>校排</td><td>班排</td><th><u>座號</u></th><td>校排</td><td>班排</td><th><u>座號</u></th><td>校排</td><td>班排</td></tr>")
            For i As Integer = 1 To 12 'ckck=4
                sw.Write("<tr><th><u>{0}</u></th><td>{1}</td><td>{2}</td><th><u>{3}</u></th><td>{4}</td><td>{5}</td><th><u>{6}</u></th><td>{7}</td><td>{8}</td><th><u>{9}</u></th><td>{10}</td><td>{11}</td></tr>", ii(i - 1), rr(i - 1), uu(i - 1), ii(i + 11), rr(i + 11), uu(i + 11), ii(i + 23), rr(i + 23), uu(i + 23), ii(i + 35), rr(i + 35), uu(i + 35))
            Next
        ElseIf ckck = 3 Then
            sw.Write("<tr><th><u>座號</u></th><td>校排</td><td>班排</td><th><u>座號</u></th><td>校排</td><td>班排</td><th><u>座號</u></th><td>校排</td><td>班排</td></tr>")
            For i As Integer = 1 To 12 'ckck=3
                sw.Write("<tr><th><u>{0}</u></th><td>{1}</td><td>{2}</td><th><u>{3}</u></th><td>{4}</td><td>{5}</td><th><u>{6}</u></th><td>{7}</td><td>{8}</td></tr>", ii(i - 1), rr(i - 1), uu(i - 1), ii(i + 11), rr(i + 11), uu(i + 11), ii(i + 23), rr(i + 23), uu(i + 23))
            Next
        ElseIf ckck = 2 Then
            sw.Write("<tr><th><u>座號</u></th><td>校排</td><td>班排</td><th><u>座號</u></th><td>校排</td><td>班排</td></tr>")
            For i As Integer = 1 To 12 'ckck=2
                sw.Write("<tr><th><u>{0}</u></th><td>{1}</td><td>{2}</td><th><u>{3}</u></th><td>{4}</td><td>{5}</td></tr>", ii(i - 1), rr(i - 1), uu(i - 1), ii(i + 11), rr(i + 11), uu(i + 11))
            Next
        ElseIf ckck = 1 Then
            sw.Write("<tr><th><u>座號</u></th><td>校排</td><td>班排</td></tr>")
            For i As Integer = 1 To 12 'ckck=1
                sw.Write("<tr><th><u>{0}</u></th><td>{1}</td><td>{2}</td></tr>", ii(i - 1), rr(i - 1), uu(i - 1))
            Next
        End If
        sw.Write("</table>")
        sw.Write("</font>")
        sw.Write("</body>")
        sw.Write("</html>")
        Console.WriteLine("")
        Console.WriteLine("~已將此結果以文字檔和表格檔格式存入電腦中!~")
        Console.WriteLine("--------------------------------------------------------------------------------")
        sw2.Write(vbNewLine)
        sw2.Write("---------------------------------------------------------------------------------")
        sw2.Close()
        sw.Close()
        Dim l As String
        Console.Write("這個計算已完成，還要再計算嗎?<Y or N>")
        l = Convert.ToString(Console.ReadLine())
        If l = "y" Then
            Console.WriteLine("                                                                            ")
            GoTo stare
        ElseIf l = "Y" Then
            Console.WriteLine("                                                                            ")
            GoTo stare
        Else
sd:
            Console.WriteLine("================================================================================")
            Console.WriteLine("按""Enter""結束程式")
            Console.Read()
        End If
        Console.Read()
    End Sub
    Sub EA()
        Dim b, c, d, e, f, ans As Single
7:
        Console.Write("輸入這次的組距差:")
        Try
            d = Convert.ToSingle(Console.ReadLine())
        Catch ex As Exception

            MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
            GoTo 7
        End Try
8:
        Console.Write("    總分:")
        Try
            e = Convert.ToSingle(Console.ReadLine())
        Catch ex As Exception

            MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
            GoTo 8
        End Try
9:
        Console.Write("    組距低:")
        Try
            f = Convert.ToSingle(Console.ReadLine())
        Catch ex As Exception

            MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
            GoTo 9
        End Try
10:
        Console.Write("    累積人數:")
        Try
            b = Convert.ToSingle(Console.ReadLine())
        Catch ex As Exception

            MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
            GoTo 10
        End Try
11:
        Console.Write("    組間人數:")
        Try
            c = Convert.ToSingle(Console.ReadLine())
        Catch ex As Exception

            MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
            GoTo 11
        End Try

        ans = Math.Round(Math.Abs(((e - f) * c / d) - b))
        Console.WriteLine("-----校排是第_{0}_名-----", ans)
        Console.WriteLine("================================================================================")
        Console.WriteLine("按""Enter""結束程式")
        Console.Read()
        End
    End Sub
    Sub qa()
        Dim a As Integer '人數
12:
        Console.Write("輸入班級人數:")
        Try
            a = Convert.ToSingle(Console.ReadLine())
        Catch ex As Exception
            MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
            GoTo 12
        End Try
        Dim t(a - 1) As Single '總分陣列
        Dim h(a - 1) As Integer '座號
        Dim toal As Integer '總分

        Console.WriteLine("--------------------------------------------------------------------------------")
        For i = 0 To a - 1
13:
            Console.Write("輸入{0}號的總分:", i + 1)
            Try
                t(i) = Convert.ToSingle(Console.ReadLine())
            Catch ex As Exception
                MsgBox("輸入錯誤!請確認這個項目所對應的字串類型!", 16, "錯誤")
                GoTo 13
            End Try
        Next
        For i = 0 To t.Length - 1
            For j = i + 1 To t.Length - 1
                If t(i) < t(j) Then
                    Dim tem As Single
                    tem = t(i)
                    t(i) = t(j)
                    t(j) = tem
                    Dim tem2 As Integer
                    tem2 = h(i)
                    h(i) = h(j)
                    h(j) = tem2  '座號跟著分數一起換
                End If
            Next
        Next
        For k = 0 To a - 1
            h(k) = k + 1
        Next
        Console.WriteLine("--------------------------------------------------------------------------------")
        For l = 0 To t.Length - 1
            Console.WriteLine("第{0}高分是{1}號，{2}分", l + 1, h(l), t(l))
        Next
        For i = 0 To a - 1
            toal += t(i)
        Next
        Console.WriteLine("◎共{0}分", toal)
        Console.WriteLine("◎平均{0}分", Math.Round(Math.Abs(toal / a)))
        Console.WriteLine("================================================================================")
        Console.WriteLine("按""Enter""結束程式")
        Console.Read()
        End
    End Sub

End Module
