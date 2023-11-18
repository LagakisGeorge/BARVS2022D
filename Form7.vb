Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports System.Windows.Forms

Public Class Form7
    Dim vv As New Printer

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x As Printer
        Dim n = Printers.Count
        Dim i As Integer = 1
        For Each x In Printers

            ComboBox1.Items.Add(x.DeviceName)
            ComboBox2.Items.Add(x.DeviceName)
            ComboBox3.Items.Add(x.DeviceName)
            ComboBox1.Text = gPrinter1
            ComboBox2.Text = gPrinter2
            ComboBox3.Text = gPrinter3

            If i = n Then
                Exit For
            End If
            i = i + 1
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        gPrinter1 = ComboBox1.Text
        gPrinter2 = ComboBox2.Text
        gPrinter3 = ComboBox3.Text
        Dim DT As New DataTable

        ExecuteSQLQuery("UPDATE MEM SET PR01='" + gPrinter1 + "'", DT)
        ExecuteSQLQuery("UPDATE MEM SET PR02='" + gPrinter2 + "'", DT)
        ExecuteSQLQuery("UPDATE MEM SET PR03='" + gPrinter3 + "'", DT)


    End Sub
End Class