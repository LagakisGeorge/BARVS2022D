Imports System.Security.Policy
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FSERVITOROI
    Private Sub FSERVITOROI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CType(Me.Controls.Find(NameToFind, False)(0), TextBox).Text = "Hello"

        Dim dt As New DataTable
        ExecuteSQLQuery("select * from BARDIA WHERE ISOPEN=1 AND IDERGAZ<=8", dt)
        On Error Resume Next
        Dim k, n As Integer, c As String
        For k = 0 To dt.Rows.Count - 1
            n = k + 1 : c = LTrim(dt.Rows(k)("IDERGAZ").ToString)


            Dim Obj As Object = Me.Controls.Find("Button" + c, True).FirstOrDefault()
            Obj.Backcolor = Color.Yellow


            Dim Obj2 As Object = Me.Controls.Find("h" + c, True).FirstOrDefault()
            Obj2.text = dt.Rows(k)("hme").ToString

            'βρισκω τις αξιες για καθε βαρδια
            Dim objID As Object = Me.Controls.Find("h" + c, True).FirstOrDefault()



            Dim cID = dt.Rows(k)("ID").ToString

            Dim objkl As Object = Me.Controls.Find("kl" + c, True).FirstOrDefault()
            objkl.text = "ΚΛΕΙΣΙΜΟ;                       " + cID
            objkl.enabled = True


            Dim dt2 As New DataTable
            ExecuteSQLQuery("select sum(isnull(CASH,0)) AS METR, sum(isnull(PIS1, 0)) As PIS1, sum(isnull(PIS2, 0)) As PIS2 ,sum(isnull(KERA,0)) AS KERA FROM PARAGGMASTER WHERE IDBARDIA=" + cID, dt2)

            Dim ObjM As Object = Me.Controls.Find("M" + c, True).FirstOrDefault()
            ObjM.text = dt2.Rows(0)("METR").ToString

            ' CType(Me.Controls.Find("Button" + c, False)(0), Button).BackColor = Color.Green

            ' CType(Me.Controls.Find("h" + c, False)(0), Label).Text = dt.Rows(k)("hme").ToString
            Dim Objk1 As Object = Me.Controls.Find("k" + c, True).FirstOrDefault()
            Objk1.text = dt2.Rows(0)("PIS1").ToString

            Dim dt3 As New DataTable
            ExecuteSQLQuery("select COUNT(*) as an FROM PARAGGMASTER WHERE TROPOS IS NULL AND  IDBARDIA=" + cID, dt2)

            Dim Obja As Object = Me.Controls.Find("an" + c, True).FirstOrDefault()
            Obja.text = dt2.Rows(0)(0).ToString


        Next




    End Sub

    Private Sub kl1_Click(sender As Object, e As EventArgs) Handles kl1.Click
        CLOSEBARDIA(LTrim(kl1.Text.Split(";")(1)))
    End Sub

    Private Sub kl2_Click(sender As Object, e As EventArgs) Handles kl2.Click
        CLOSEBARDIA(LTrim(kl2.Text.Split(";")(1)))
    End Sub

    Private Sub kl3_Click(sender As Object, e As EventArgs) Handles kl3.Click
        CLOSEBARDIA(LTrim(kl3.Text.Split(";")(1)))
    End Sub

    Private Sub kl4_Click(sender As Object, e As EventArgs) Handles kl4.Click
        CLOSEBARDIA(LTrim(kl4.Text.Split(";")(1)))
    End Sub

    Private Sub CLOSEBARDIA(MBARDIA As String)

        Dim DT As New DataTable

        ExecuteSQLQuery("SELECT Sum(isnull(CASH,0)) AS CASH ,  Sum(isnull(PIS1,0)) AS PIS1 , Sum(isnull(PIS2,0)) AS PIS2 ,  Sum(isnull(KERA,0)) AS KERA  FROM PARAGGMASTER WHERE  IDBARDIA=" + MBARDIA, DT)  ' Str(gBardia), DT)
        Dim MM As String = ""
        Dim CASH(5) As String
        Dim CASHTOT As Single = 0
        MsgBox("Μετρ: " + DT(0)("CASH").ToString + Chr(13) + "Πιστ: " + DT(0)("pis1").ToString + Chr(13) + "Εκπτ: " + DT(0)("PIS2").ToString + Chr(13) + "Κερασμ: " + DT(0)("KERA").ToString)



        Dim dt1 As New DataTable
        ExecuteSQLQuery("select count(*) FROM PARAGGMASTER WHERE IDBARDIA=" + MBARDIA + "  AND TROPOS IS NULL ", dt1)
        If dt1(0)(0) > 0 Then
            MsgBox("ΥΠΑΡΧΟΥΝ " + Str(dt1(0)(0)) + " TRAPEZIA ANOIXTA. ΚΛΕΙΣΤΕ ΤΑ.")
            Exit Sub
        End If


        'ΕΛΕΓΧΩ ΑΝ ΕΧΕΙ ΑΝΟΙΧΤΑ ΤΡΑΠΕΖΙΑ




        Dim DT2 As New DataTable

        Dim ANS As Integer = MsgBox(MM, MsgBoxStyle.YesNo, "ΚΛΕΙΣΙΜΟ ΒΑΡΔΙΑΣ")
        '
        If ANS = MsgBoxResult.Yes Then
            paragkentr.TYPONO_BARDIA(gBardia)
            ExecuteSQLQuery("UPDATE BARDIA SET CASHTOT=" + Replace(Format(CASHTOT, "####.00"), ",", ".") + ", CLOSEH='" + Format(Now, "hh:mm") + "', ISOPEN=0 WHERE ID=" + Str(MBARDIA), DT2)
            For K = 1 To 5
                If CASH(K) = Nothing Then
                Else
                    If Val(CASH(K)) > 0 Then
                        ExecuteSQLQuery("UPDATE BARDIA SET CASH" + Format(K, "0") + "=" + CASH(K) + " WHERE ID=" + MBARDIA, DT2)
                    End If

                End If
            Next
        End If
    End Sub

    Private Sub kl5_Click(sender As Object, e As EventArgs) Handles kl5.Click
        CLOSEBARDIA(LTrim(kl5.Text.Split(";")(1)))
    End Sub

    Private Sub kl6_Click(sender As Object, e As EventArgs) Handles kl6.Click
        CLOSEBARDIA(LTrim(kl6.Text.Split(";")(1)))
    End Sub

    Private Sub kl7_Click(sender As Object, e As EventArgs) Handles kl7.Click
        CLOSEBARDIA(LTrim(kl7.Text.Split(";")(1)))
    End Sub

    Private Sub kl8_Click(sender As Object, e As EventArgs) Handles kl8.Click
        CLOSEBARDIA(LTrim(kl8.Text.Split(";")(1)))
    End Sub

    Private Sub ANBARD1_Click(sender As Object, e As EventArgs) Handles ANBARD1.Click
        Open_Bardia(1)
    End Sub

    Private Sub ANBARD2_Click(sender As Object, e As EventArgs) Handles ANBARD2.Click
        Open_Bardia(2)
    End Sub

    Private Sub ANBARD3_Click(sender As Object, e As EventArgs) Handles ANBARD3.Click
        Open_Bardia(3)
    End Sub

    Private Sub ANBARD4_Click(sender As Object, e As EventArgs) Handles ANBARD4.Click
        Open_Bardia(4)
    End Sub

    Private Sub ANBARD5_Click(sender As Object, e As EventArgs) Handles ANBARD5.Click
        Open_Bardia(5)
    End Sub

    Private Sub ANBARD6_Click(sender As Object, e As EventArgs) Handles ANBARD6.Click
        Open_Bardia(6)
    End Sub

    Private Sub ANBARD7_Click(sender As Object, e As EventArgs) Handles ANBARD7.Click
        Open_Bardia(7)
    End Sub

    Private Sub ANBARD8_Click(sender As Object, e As EventArgs) Handles ANBARD8.Click
        Open_Bardia(8)
    End Sub
    Private Sub Open_Bardia(M_USER As Integer)

        Dim mUser As String = Str(M_USER)

        ' On Error GoTo err
        Dim DT As New DataTable

        Dim MDATE As String
        If InStr(gCONNECT, "MDB") > 0 Then
            MDATE = "#" + Format(Now, "dd/MM/yyyy") + "#"
        Else
            MDATE = "'" + Format(Now, "MM/dd/yyyy") + "'"
        End If





        Try
            ExecuteSQLQuery("INSERT INTO BARDIA (OPENH,ISOPEN,HME,IDERGAZ,NUM1) VALUES ('" + Format(Now, "hh:mm") + "',1," + MDATE + "," + mUser + "," + mUser + ")", DT)
            '   ExecuteSQLQuery("SELECT MAX(ID) FROM BARDIA WHERE NUM1=" + Str(gUser), DT)

        Catch ex As Exception
            gBardia = 0
            MsgBox("ΔΕΝ ΕΓΙΝΕ ΑΝΟΙΓΜΑ ΒΑΡΔΙΑΣ")
        End Try

        'gBardia = DT(0)(0)
        ' GeRGAZ = CKATHG.Text


        Me.Close()

    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub
End Class