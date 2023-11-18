Imports System.Data.SqlClient

Imports System
Imports System.IO


Public Class Form2

    'Visual Basic 
    Dim sortColumn As Integer = -1


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim line As String
        Using sr As StreamReader = New StreamReader("config.ini", System.Text.Encoding.Default)
            line = sr.ReadLine()

        End Using

        'ConString = "Server=HPPC\SQL12;Database=MERCURY;UID=sa;pwd=12345678;"
        gconnect = "Server=" + Split(line, ";")(0) + ";Database=" + Split(line, ";")(1) + ";uid=" + Split(line, ";")(2) + ";pwd=" + Split(line, ";")(3) + ";"

        LV2.Items.Clear()

        LV2.Columns(0).Text = "Α/Α"
        LV2.Columns(1).Text = "ΚΩΔΙΚΟΣ"
        LV2.Columns(2).Text = "ONOMA"
        LV2.Columns(3).Text = "ΠΟΣΟΤΗΤΑ"
        LV2.Columns(4).Text = "TIMH"
        LV2.Columns(5).Text = "ΑΞΙΑ"
        'LV.Columns(4).Text = "ΤΗΛΕΦΩΝΟ"




        Me.TextBox1.Text = "Αναζήτηση"
        Me.TextBox1.ForeColor = Color.SlateGray


        Call Loader()

        Me.Show()
       

    End Sub
    Private Sub Loader()
        ' PELATES
        IsConnected("Select ID,KOD,EPO,DIE,EPA,THL from PEL", False)


        LV.Items.Clear()
        LV.Columns(0).Text = "Α/Α"
        LV.Columns(1).Text = "ΕΠΩΝΥΜΙΑ"
        LV.Columns(2).Text = "ΕΠΑΓΓΕΛΜΑ"
        LV.Columns(3).Text = "ΔΙΕΥΘΥΝΣΗ"
        LV.Columns(4).Text = "ΤΗΛΕΦΩΝΟ"
        LV.Columns(5).Text = "ΚΩΔΙΚΟΣ"

        While (myDR.Read())

            With LV.Items.Add(myDR(0))
                .SubItems.Add(myDR("EPO"))
                .SubItems.Add(IIf(IsDBNull(myDR("EPA")), "", myDR("EPA")))
                .SubItems.Add(IIf(IsDBNull(myDR("DIE")), "", myDR("DIE")))
                .SubItems.Add(IIf(IsDBNull(myDR("THL")), "", myDR("THL")))
                .SubItems.Add(IIf(IsDBNull(myDR("KOD")), "", myDR("KOD")))
            End With


        End While

        'LV.Items.Clear()
        'While (myDR.Read())

        '    With LV.Items.Add(myDR(0))
        '        .SubItems.Add(myDR("EPO"))
        '        .SubItems.Add(IIf(IsDBNull(myDR(1)), "", myDR(1)))
        '        .SubItems.Add(IIf(IsDBNull(myDR(2)), "", myDR(2)))
        '        .SubItems.Add(IIf(IsDBNull(myDR(3)), "", myDR(3)))

        '    End With


        'End While
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEOEIDOS.Click
        'Call login()

        ' IsConnected("DELETE FROM EGGTIM ", True)

        If LV.SelectedItems.Count = 0 Then
            MsgBox("ΔΙΑΛΕΞΤΕ ΕΊΔΟΣ")
            Exit Sub
        Else
            ' GroupBox1.Text = LV.SelectedItems(0).SubItems(1).Text
        End If





        Form3.Text = "Νέα Εγγραφή"
        frUpdate = True
        Form3.ShowDialog()
        Form3.TextBox4.Focus()




    End Sub
    Private Sub login()
        Dim rep As Integer

        If NEOEIDOS.Text = "Login" Then
            Form1.ShowDialog()
        Else

            rep = MsgBox("Are you sure you want to logout and switch user?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmation")
            If rep = vbOK Then

                NEOEIDOS.Text = "Login"
                Form1.Text = "Click close to quit"
                Form1.ShowDialog()

            End If
        End If
    End Sub
    Private Sub ButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click
        'Call addNew()
        If ButtonAdd.Text = "Νέα Παραγγελία" Then


            LV2.Items.Clear()
            LV2.Columns(0).Text = "ΚΩΔΙΚΟΣ"
            LV2.Columns(1).Text = "ΠΕΡΙΓΡΑΦΗ"
            LV2.Columns(2).Text = "ΠΟΣΟΤΗΤΑ"
            LV2.Columns(3).Text = "ΤΙΜΗ"
            'LV.Columns(4).Text = "ΤΗΛΕΦΩΝΟ"



            'Form3.TextID.Text = LV.SelectedItems(0).SubItems(0).Text
            If LV.SelectedItems.Count = 0 Then
                MsgBox("Διαλέξτε Πελάτη")
                Exit Sub
            Else
                GroupBox1.Text = LV.SelectedItems(0).SubItems(1).Text
            End If
            '
            IsConnected("SELECT * FROM ARITMISI WHERE ID=1 ", False)
            myDR.Read()

            'If myDR.RecordsAffected = 0 Then
            '    MsgBox("ΔΕΝ ΚΑΤΑΧΩΡΗΘΗΚΕ")
            '    gID_NUM = 0
            '    Exit Sub

            'End If
            gAtim = "a" + Format(IIf(IsDBNull(myDR("ARITMISI")), 1, myDR("ARITMISI") + 1), "000000")
            IsConnected("update ARITMISI set ARITMISI=ARITMISI+1 WHERE ID=1", True)

            IsConnected("Insert into TIM (KPE,ATIM,HME) values('" & _
                            LV.SelectedItems(0).SubItems(5).Text & "','" & _
                            gAtim & "','" & _
                           Format(Now, "dd/MM/yyyy") & "')", True)


            IsConnected("SELECT * FROM TIM WHERE ATIM='" + gAtim + "'", False)
            myDR.Read()
            gID_NUM = myDR("ID_NUM")

            LOAD_EIDH()
            NEOEIDOS.Enabled = True

            ButtonAdd.Text = "Κλείσιμο Παραγγελίας"

        Else

            NEOEIDOS.Enabled = False
            Loader()











            ButtonAdd.Text = "Νέα Παραγγελία"

        End If













    End Sub
    Private Sub addNew()
        frUpdate = False
        Form3.ShowDialog()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Refresh()
    End Sub
    Private Sub Refresh()
        ' PELATES
        IsConnected("Select ID,KOD,EPO,DIE,EPA,THL from PEL", False)


        LV.Items.Clear()
        LV.Columns(0).Text = "Α/Α"
        LV.Columns(1).Text = "ΕΠΩΝΥΜΙΑ"
        LV.Columns(2).Text = "ΕΠΑΓΓΕΛΜΑ"
        LV.Columns(3).Text = "ΔΙΕΥΘΥΝΣΗ"
        LV.Columns(4).Text = "ΤΗΛΕΦΩΝΟ"

        While (myDR.Read())

            With LV.Items.Add(myDR(0))
                .SubItems.Add(myDR("EPO"))
                .SubItems.Add(IIf(IsDBNull(myDR("EPA")), "", myDR("EPA")))
                .SubItems.Add(IIf(IsDBNull(myDR("DIE")), "", myDR("DIE")))
                .SubItems.Add(IIf(IsDBNull(myDR("THL")), "", myDR("THL")))

            End With


        End While





        ' IsConnected("Select * from PEL", False)
        ' Call Loader()
    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        Me.TextBox1.Text = ""
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        IsConnected("Select * from tblPersonal Where ID like '" & Me.TextBox1.Text & _
                    "%' or firstname like '" & Me.TextBox1.Text & "%' or lastname like '" & Me.TextBox1.Text & "%';", False)
        Call Loader()
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Call Editable()
    End Sub
    Private Sub Editable()
        If frUpdate = True Then
            Form3.Text = "Edit entry"
            frUpdate = True
            Form3.ShowDialog()
        Else
            MsgBox("Please select item to edit!", MsgBoxStyle.Exclamation, "Information")
        End If
    End Sub
    Private Sub Delete()
        On Error GoTo err

        If LV.SelectedItems.Count > 0 Then

            Dim rep As Integer
            rep = MsgBox("Να Διαγραφεί ο κωδικός " & LV2.SelectedItems(0).SubItems(1).Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
            If rep = vbYes Then
                IsConnected("Delete from EGGTIM Where ID=" & LV2.SelectedItems(0).SubItems(0).Text & " ", True)
                ' IsConnected("Select * from tblPersonal", False)
                LOAD_EGGTIM()
            Else
                frUpdate = False
            End If
        Else
            MsgBox("Διαλέξτε την σειρά που θέλετε να διαγράψετε.", MsgBoxStyle.Exclamation, "Information")
        End If
        Exit Sub
err:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
    End Sub
    Private Sub LV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LV.Click
        frUpdate = True
        Form3.TextID.Text = LV.SelectedItems(0).SubItems(0).Text
        Form3.TextBox1.Text = LV.SelectedItems(0).SubItems(1).Text
        Form3.TextBox2.Text = LV.SelectedItems(0).SubItems(2).Text
        Form3.TextBox3.Text = LV.SelectedItems(0).SubItems(3).Text
        'Form3.DateTimePicker1.Value = LV.SelectedItems(0).SubItems(4).Text
        'Form3.TextBox5.Text = LV.SelectedItems(0).SubItems(5).Text

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Call Delete()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call Editable()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Call Refresh()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call Delete()
    End Sub
    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        Call addNew()
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Call login()
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        Call Editable()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        Call Delete()
    End Sub

    Private Sub LV_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles LV.ColumnClick
        'Me.LV.ListViewItemSorter = New ListViewItemComparer(e.Column)
        ' Call the sort method to manually sort.
        'LV.Sort()


        ' Determine whether the column is the same as the last column clicked.
        If e.Column <> sortColumn Then
            ' Set the sort column to the new column.
            sortColumn = e.Column
            ' Set the sort order to ascending by default.
            LV.Sorting = SortOrder.Ascending
        Else
            ' Determine what the last sort order was and change it.
            If LV.Sorting = SortOrder.Ascending Then
                LV.Sorting = SortOrder.Descending
            Else
                LV.Sorting = SortOrder.Ascending
            End If
        End If
        ' Call the sort method to manually sort.
        LV.Sort()
        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.
        LV.ListViewItemSorter = New ListViewItemComparer(e.Column, _
                                                         LV.Sorting)



    End Sub

    Private Sub LV_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LV.MouseClick

    End Sub

    Private Sub LV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LV.SelectedIndexChanged

    End Sub

    Private Sub mnuAboutme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAboutme.Click
        Form4.ShowDialog()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim k As Long, KL As Long
        Dim FDS As New System.Data.DataSet
        Dim FDS2 As New System.Data.DataSet

        k = openWifiSQL("select  * from EID order by KOD", FDS)
        If k < 0 Then
            MsgBox("ΑΔΥΝΑΤΗ Η ΣΥΝΔΕΣΗ. ΔΟΚΙΜΑΣΤΕ ΜΕ ΚΑΛΩΔΙΟ")
            Exit Sub
        End If
        'Button5.Text = FDS.Tables(0).Rows(k).Item("ONO").ToString
        Dim mKod As String
        Dim mepo As String
        Dim mLti5 As String


        If k > 0 Then
            KL = IsConnected("DELETE from EID", True)

            For k = 0 To FDS.Tables(0).Rows.Count - 1
                mKod = Trim(FDS.Tables(0).Rows(k).Item("KOD").ToString)
                mepo = Replace(Trim(FDS.Tables(0).Rows(k).Item("ONO").ToString), "'", "''")
                mLti5 = Replace(Trim(FDS.Tables(0).Rows(k).Item("lti").ToString), ",", ".")

                'SEIRA = Space(100)
                KL = IsConnected("INSERT INTO EID (KOD,ONO,LTI) VALUES ('" + mKod + "','" + mepo + "'," + mLti5 + ")", True)
                If k Mod 10 = 0 Then
                    Application.DoEvents()
                    Me.Text = Format(k, "#####")
                End If
                'ListBox1.Items.Add(FDS.Tables(0).Rows(k).Item("EPO").ToString)

            Next k
            MsgBox("OK " + Str(k) + " ΕΙΔΗ")
        End If


        '======================================================================
        k = openWifiSQL("select  * from PEL order by KOD", FDS)
        If k < 0 Then
            MsgBox("ΑΔΥΝΑΤΗ Η ΣΥΝΔΕΣΗ. ΔΟΚΙΜΑΣΤΕ ΜΕ ΚΑΛΩΔΙΟ")
            Exit Sub
        End If
        'Button5.Text = FDS.Tables(0).Rows(k).Item("ONO").ToString

        Dim mEPA As String
        Dim mDIE As String

        If k > 0 Then
            KL = IsConnected("DELETE from PEL", True)

            For k = 0 To FDS.Tables(0).Rows.Count - 1
                mKod = Trim(FDS.Tables(0).Rows(k).Item("KOD").ToString)
                mepo = Replace(Trim(FDS.Tables(0).Rows(k).Item("EPO").ToString), "'", "''")
                mDIE = Replace(Trim(FDS.Tables(0).Rows(k).Item("DIE").ToString), ",", ".")
                mEPA = Replace(Trim(FDS.Tables(0).Rows(k).Item("EPA").ToString), ",", ".")
                'SEIRA = Space(100)
                KL = IsConnected("INSERT INTO PEL (KOD,EPO,DIE,EPA) VALUES ('" + mKod + "','" + mepo + "','" + mDIE + "','" + mEPA + "')", True)
                If k Mod 10 = 0 Then
                    Application.DoEvents()
                    Me.Text = Format(k, "#####")
                End If
                'ListBox1.Items.Add(FDS.Tables(0).Rows(k).Item("EPO").ToString)

            Next k
            MsgBox("OK " + Str(k) + " πελατες")
        End If










    End Sub


    'Public Function openWifiSQL(ByVal sql As String, ByRef FDS As System.Data.DataSet) As Long

    '    Dim fobjcon As SqlConnection, fobjcmd As New SqlCommand
    '    Dim c As String = "Server=HPPC\SQL12;Database=MERCURY;UID=sa;pwd=12345678;"
    '    'Dim FDS As New System.Data.DataSet
    '    Dim FDA As New SqlDataAdapter

    '    Try
    '        fobjcon = New SqlConnection(c)


    '        fobjcmd = New SqlCommand(sql, fobjcon)
    '        fobjcmd.Connection.Open()
    '        FDA.SelectCommand = fobjcmd
    '        FDS.Clear()
    '        FDA.Fill(FDS)
    '        openWifiSQL = FDS.Tables.Count
    '        fobjcon.Close()
    '    Catch ex As Exception
    '        MsgBox("Can't load Web page" & vbCrLf & ex.Message)
    '        openWifiSQL = -1
    '    End Try



    'End Function





    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LOAD_EIDH()



    End Sub
    Sub LOAD_EGGTIM()

        IsConnected("Select ID,KODE,ONOMA,POSO,TIMM,KAU_AJIA  from EGGTIM WHERE ID_NUM=" + Str(gID_NUM), False)  ' WHERE ATIM='22'
        ' Call Loader()
        LV2.Items.Clear()

        While (myDR.Read())

            With LV2.Items.Add(myDR(0))
                .SubItems.Add(myDR("KODE"))
                .SubItems.Add(IIf(IsDBNull(myDR("ONOMA")), "", myDR("ONOMA")))
                .SubItems.Add(IIf(IsDBNull(myDR("TIMM")), "", myDR("TIMM")))
                .SubItems.Add(IIf(IsDBNull(myDR("POSO")), "", myDR("POSO")))
                .SubItems.Add(IIf(IsDBNull(myDR("KAU_AJIA")), "", myDR("KAU_AJIA")))

            End With


        End While
        LV2.Refresh()

    End Sub


    Sub LOAD_EIDH()
        IsConnected("Select ID,KOD,ONO,LTI,LTI5  from EID", False)
        ' Call Loader()
        LV.Items.Clear()

        LV.Columns(0).Text = "Α/Α"
        LV.Columns(1).Text = "ΚΩΔΙΚΟΣ"
        LV.Columns(2).Text = "ONOMA"
        LV.Columns(3).Text = "XONDR.TIMH"
        LV.Columns(4).Text = "LIANIKH TIMH"
        'LV.Columns(4).Text = "ΤΗΛΕΦΩΝΟ"






        While (myDR.Read())

            With LV.Items.Add(myDR(0))
                .SubItems.Add(myDR("KOD"))
                .SubItems.Add(IIf(IsDBNull(myDR("ONO")), "", myDR("ONO")))
                .SubItems.Add(IIf(IsDBNull(myDR("LTI")), "", myDR("LTI")))
                .SubItems.Add(IIf(IsDBNull(myDR("LTI5")), "", myDR("LTI5")))

            End With


        End While

    End Sub


    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LOAD_EGGTIM()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOPC.Click
        ' ================   TO PC ------------------------------------------------
        Dim k As Long, KL As Long
        Dim FDS As New System.Data.DataSet
        Dim FDS2 As New System.Data.DataSet

        k = openWifiSQL("select TOP 1  * from EID order by KOD", FDS)
        If k < 0 Then
            MsgBox("ΑΔΥΝΑΤΗ Η ΣΥΝΔΕΣΗ. ΔΟΚΙΜΑΣΤΕ ΜΕ ΚΑΛΩΔΙΟ")
            Exit Sub
        End If
        'Button5.Text = FDS.Tables(0).Rows(k).Item("ONO").ToString
        Dim mKod As String
        Dim mepo As String
        Dim mLti5 As String




        Dim SQL As String

        IsConnected("Select *  from TIM ", False)
        Dim Synt As String

        While (myDR.Read())
            SQL = "INSERT INTO TIM (EIDOS,ATIM,KPE,HME) VALUES ('e','"
            SQL = SQL + myDR("ATIM") + "','" + myDR("KPE") + "','" + Format(myDR("HME"), "MM/dd/yyyy") + "')"
            k = openWifiSQL(SQL, FDS)
            Synt = " ATIM='" + myDR("ATIM") + "' AND HME='" + Format(myDR("HME"), "MM/dd/yyyy") + "'"
            k = openWifiSQL("select * from TIM WHERE " + SYNT, FDS)
            If FDS.Tables(0).Rows.Count > 0 Then
                IsConnected("UPDATE EGGTIM SET HME='" + Format(FDS.Tables(0)(0)("HME"), "dd/MM/yyyy") + "',ID_NUM=" + FDS.Tables(0)(0)("ID_NUM").ToString + " WHERE  ATIM='" + myDR("ATIM") + "'", False)
            End If


        End While

        'Gdb.Execute("UPDATE  TIM SET AJ2=" + Replace(Str(Round(NNUL(R6!fpa2), 2)), ",", ".") + " WHERE ID_NUM=" + Str(ID_NUM(KN)))
        'Gdb.Execute("UPDATE  TIM SET AJ3=" + Replace(Str(Round(NNUL(R6!fpa3), 2)), ",", ".") + " WHERE ID_NUM=" + Str(ID_NUM(KN)))
        'Gdb.Execute("UPDATE  TIM SET AJ4=" + Replace(Str(Round(NNUL(R6!fpa4), 2)), ",", ".") + " WHERE ID_NUM=" + Str(ID_NUM(KN)))
        'Gdb.Execute("UPDATE  TIM SET AJ5=" + Replace(Str(Round(NNUL(R6!FPA5), 2)), ",", ".") + " WHERE ID_NUM=" + Str(ID_NUM(KN)))
        'Gdb.Execute("UPDATE  TIM SET AJ1=AJ1-AJ2-AJ3-AJ4-AJ5 WHERE ID_NUM=" + Str(ID_NUM(KN)))


        IsConnected("Select *  from EGGTIM ", False)

        While (myDR.Read())
            SQL = "INSERT INTO EGGTIM (HME,KODE,ID_NUM,EIDOS,APOT,FPA,ONOMA,ATIM,POSO,TIMM) VALUES ('" + Format(myDR("HME"), "MM/dd/yyyy") + "','" + myDR("KODE") + "'," + Str(myDR("ID_NUM")) + ",'e',1,2,'" + myDR("ONOMA") + "','"
            SQL = SQL + myDR("ATIM") + "'," + Replace(Str(myDR("POSO")), ",", ".") + "," + Replace(Format(myDR("TIMM"), "##0.00"), ",", ".") + ")"
            k = openWifiSQL(SQL, FDS)
        End While






        MsgBox("ok")







    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        IsConnected("DELETE FROM TIM ", True)
        IsConnected("DELETE FROM EGGTIM ", True)

    End Sub
End Class
'Visual Basic 
' Implements the manual sorting of items by columns.
Class ListViewItemComparer
    Implements IComparer
    Private col As Integer
    Private order As SortOrder

    Public Sub New()
        col = 0
        order = SortOrder.Ascending
    End Sub

    Public Sub New(ByVal column As Integer, ByVal order As SortOrder)
        col = column
        Me.order = order
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
                        Implements System.Collections.IComparer.Compare
        Dim returnVal As Integer = -1
        Try
            returnVal = [String].Compare(CType(x,  _
                            ListViewItem).SubItems(col).Text, _
                            CType(y, ListViewItem).SubItems(col).Text)
            ' Determine whether the sort order is descending.
            If order = SortOrder.Descending Then
                ' Invert the value returned by String.Compare.
                returnVal *= -1
            End If

            Return returnVal
        Catch


        End Try

    End Function
End Class
