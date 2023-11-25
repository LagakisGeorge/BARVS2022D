Public Class param
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles UpdateMem.Click

        Dim q As String
        q = "UPDATE MEM
   SET
      SHOWOLATRAP = " + IIf(SHOWOLATRAP.Checked, "1", "0") + "
      ,LOGPRINPLIR =" + IIf(LOGPRINPLIR.Checked, "1", "0") + "
      ,EKTPRINPLIR = " + IIf(EKTPRINPLIR.Checked, "1", "0") + "
      ,RESERVEDBYONE =" + IIf(RESERVEDBYONE.Checked, "1", "0") + "
      ,CANOPENBARDIA =" + IIf(CANOPENBARDIA.Checked, "1", "0") + " "
        ' WHERE <Search Conditions,,>"
        Dim dt2 As New DataTable

        ExecuteSQLQuery(q, dt2)


    End Sub

    Private Sub param_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt2 As New DataTable

        ExecuteSQLQuery("select isnull(SHOWOLATRAP,0) as SHOWOLATRAP
      ,isnull(LOGPRINPLIR,0) as LOGPRINPLIR
      ,isnull(EKTPRINPLIR,0) as EKTPRINPLIR
      ,isnull(RESERVEDBYONE,0) as RESERVEDBYONE
      ,isnull(CANOPENBARDIA,0) as CANOPENBARDIA from MEM", dt2)
        If dt2.Rows.Count > 0 Then
            If dt2(0)("SHOWOLATRAP") = 1 Then
                SHOWOLATRAP.Checked = True
            Else
                SHOWOLATRAP.Checked = False
            End If



            If dt2(0)("LOGPRINPLIR") = 1 Then
                LOGPRINPLIR.Checked = True
            Else
                LOGPRINPLIR.Checked = False
            End If

            If dt2(0)("EKTPRINPLIR") = 1 Then
                EKTPRINPLIR.Checked = True
            Else
                EKTPRINPLIR.Checked = False
            End If


            If dt2(0)("RESERVEDBYONE") = 1 Then
                RESERVEDBYONE.Checked = True
            Else
                RESERVEDBYONE.Checked = False
            End If


            If dt2(0)("CANOPENBARDIA") = 1 Then
                CANOPENBARDIA.Checked = True
            Else
                CANOPENBARDIA.Checked = False
            End If

        End If














    End Sub

    Private Sub allaghKodikoy_Click(sender As Object, e As EventArgs) Handles allaghKodikoy.Click
        Dim U As String
        U = InputBox("ΔΩΣΕ ΑΡΙΘΜΟ ΧΡΗΣΤΗ", "")





        Dim dt As New DataTable
        Dim PW, pw2 As String
        PW = InputBox("ΔΩΣΕ ΝΕΟ ΚΩΔΙΚΟ", "")
        pw2 = InputBox("ΕΠΑΝΑΛΑΒΕΤΕ ΤΟΝ ΝΕΟ ΚΩΔΙΚΟ", "")


        If PW = pw2 Then
            ExecuteSQLQuery("UPDATE LOGGING SET QUERY='" + PW + "' WHERE ID=" + U, dt)
            If U = "24" Then
                G_ADMIN_PW = PW
            End If
            MsgBox("OK")
        Else
            MsgBox("ΛΑΘΟΣ ΕΠΑΝΑΛΗΨΗ.Ο Κωδικός δεν άλλαξε")
        End If
    End Sub
End Class