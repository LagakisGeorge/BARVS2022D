﻿Public Class PROTYPO

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub



    Private Sub Form3_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frUpdate = False
        Me.Dispose()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo err




        Exit Sub
err:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim proc As New System.Diagnostics.Process()
    End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B7.Click
    '    TYPOSE("7")
    'End Sub

    'Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B6.Click
    '    TYPOSE("6")
    'End Sub

    'Sub TYPOSE(ByVal D As String)

    '    Dim F As String
    '    F = ""





    '    If D = "<" Then
    '        If Len(F) > 1 Then
    '            F = Mid(F, 1, Len(F) - 1)
    '        Else
    '            F = ""
    '        End If

    '    Else

    '        If D = "." Then
    '            If InStr(F, ".") > 0 Then D = ""
    '        End If

    '        F = F + D


    '    End If




    'End Sub




    'Private Sub B9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B9.Click
    '    TYPOSE("9")
    'End Sub

    'Private Sub B4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B4.Click
    '    TYPOSE("4")
    'End Sub

    'Private Sub B5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B5.Click
    '    TYPOSE("5")
    'End Sub

    'Private Sub B8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B8.Click
    '    TYPOSE("8")
    'End Sub

    'Private Sub B1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B1.Click
    '    TYPOSE("1")
    'End Sub

    'Private Sub B2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B2.Click
    '    TYPOSE("2")
    'End Sub

    'Private Sub B3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B3.Click
    '    TYPOSE("3")
    'End Sub

    'Private Sub B0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B0.Click
    '    TYPOSE("0")
    'End Sub


    'Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ' TIMH.BackColor = Color.White
    'End Sub


    'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    TYPOSE("<")
    'End Sub

    'Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    TYPOSE(".")
    'End Sub


   

    Private Sub ClickButton(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles B1.Click, _
  B2.Click, B3.Click, B4.Click, B5.Click, B6.Click, _
          B7.Click, B8.Click, B9.Click, B0.Click, Button1.Click, Button2.Click

        Dim btn As Button
        btn = CType(sender, Button)


        Dim D As String = btn.Text
        Dim F As String
        F = ""





        If D = "<" Then
            If Len(F) > 1 Then
                F = Mid(F, 1, Len(F) - 1)
            Else
                F = ""
            End If

        Else

            If D = "." Then
                If InStr(F, ".") > 0 Then D = ""
            End If

            F = F + D


        End If








        'Dim i As Integer = Val(Mid(btn.Name, InStr(btn.Name, "_") + 1, 2))
        'Dim pos As Single = 1

    End Sub



End Class