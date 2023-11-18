'Created by Junnajir j. Giminsil
Imports System.Data.OleDb
Imports System.Data.SqlClient
Module Module1
    Public myConn As New OleDbConnection
    Public myCmd As New OleDbCommand
    Public myDR As OleDbDataReader
    Public frUpdate As Boolean 'Holding for Updating entry
    Public gCONNECT As String
    Public gAtim As String
    Public gID_NUM As String


    Public Function IsConnected(ByVal strQry As String, ByVal ver As Boolean)
        Try

            If myConn.State = ConnectionState.Open Then myConn.Close()
            myConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb;"
            myConn.Open()

            myCmd.CommandText = strQry
            myCmd.Connection = myConn

            If ver = False Then
                myDR = myCmd.ExecuteReader() 'For reading query
            Else
                myCmd.ExecuteNonQuery() 'For updating query
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function




    Public Function openWifiSQL(ByVal sql As String, ByRef FDS As System.Data.DataSet) As Long

        Dim fobjcon As SqlConnection, fobjcmd As New SqlCommand
        Dim c As String = gCONNECT ' "Server=HPPC\SQL12;Database=MERCURY;UID=sa;pwd=12345678;"
        'Dim FDS As New System.Data.DataSet
        Dim FDA As New SqlDataAdapter

        Try
            fobjcon = New SqlConnection(c)


            fobjcmd = New SqlCommand(sql, fobjcon)
            fobjcmd.Connection.Open()
            FDA.SelectCommand = fobjcmd
            FDS.Clear()
            FDA.Fill(FDS)
            openWifiSQL = FDS.Tables.Count
            fobjcon.Close()
        Catch ex As Exception
            MsgBox("Can't load Web page" & vbCrLf & ex.Message)
            openWifiSQL = -1
        End Try



    End Function

End Module