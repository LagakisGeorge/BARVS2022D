Public Class myPrinter
    Friend TextToBePrinted As String

    Private mSTHLH As String


    Public Property ektypvths() As String
        Get
            Return mSTHLH
        End Get
        Set(ByVal Value As String)
            ' If Value < 1 Or Value > 12 Then
            ' Error processing for invalid value. 
            'Else
            mSTHLH = Value
            'End If
        End Set
    End Property




    Public Sub prt(ByVal text As String)
        TextToBePrinted = text
        Dim prn As New Printing.PrintDocument
        Using (prn)
            prn.PrinterSettings.PrinterName = ektypvths ' "PrinterName"
            AddHandler prn.PrintPage, _
               AddressOf Me.PrintPageHandler
            prn.Print()
            RemoveHandler prn.PrintPage, _
               AddressOf Me.PrintPageHandler
        End Using
    End Sub
    Private Sub PrintPageHandler(ByVal sender As Object, _
       ByVal args As Printing.PrintPageEventArgs)
        Dim myFont As New Font("Microsoft San Serif", 10)


        args.Graphics.DrawString(TextToBePrinted, _
           New Font(myFont, FontStyle.Regular), _
           Brushes.Black, 50, 50)
    End Sub
End Class