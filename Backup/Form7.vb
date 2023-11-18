Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports System.Windows.Forms

Public Class Form7
    Dim vv As New Printer

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x As Printer
        For Each x In Printers
            ComboBox1.Items.Add(x.DeviceName)
            ComboBox2.Items.Add(x.DeviceName)
            ComboBox3.Items.Add(x.DeviceName)

        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        gPrinter1 = ComboBox1.Text
        gPrinter2 = ComboBox2.Text
        gPrinter3 = ComboBox3.Text

    End Sub
End Class