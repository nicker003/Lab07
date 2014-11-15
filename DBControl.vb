Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class DBControl
    Private conn As New SqlConnection("Server=.\SQLExpress;Database=BookMgr;Trusted_Connection=True;")
    Private sqlcmd As New SqlCommand

    Public Function Connection() As Boolean
        Try
            conn.Open()
            conn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function
    Public Sub Execute(ByVal query As String)
        Try
            conn.Open()
            sqlcmd = New SqlCommand(query, conn)
            sqlcmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub ExecuteQuery(ByVal cmd As SqlCommand)
        Try
            conn.Open()
            cmd.Connection = conn
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function GetData(sql As String) As DataTable
        Dim da As SqlDataAdapter
        Dim dt As New DataTable()
        da = New SqlDataAdapter(sql, conn)
        da.Fill(dt)
        Return dt
    End Function

    'Public Function SingleQuery(sql As String) As String
    '    Dim r As SqlDataReader
    '    Dim result As String = ""
    '    Try
    '        conn.Open()
    '        sqlcmd = New SqlCommand(sql, conn)
    '        r = sqlcmd.ExecuteReader
    '        r.Read()
    '        result = r.GetValue(0)
    '        r.Close()
    '        conn.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    '    Return result
    'End Function

    Public Sub ClearTextBox(ByVal root As Control)
        For Each cntrl As Control In root.Controls
            ClearTextBox(cntrl)
            If TypeOf cntrl Is TextBox Then
                CType(cntrl, TextBox).Text = String.Empty
            End If
        Next cntrl
    End Sub
End Class
