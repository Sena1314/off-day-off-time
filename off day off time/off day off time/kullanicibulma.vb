
Imports System.Data.SqlClient

Module Kullanicibulma
  Function Getir(ByVal tablom As Hashtable) As String
        Try
            
            Dim degerSayisi As Integer
            degerSayisi=tablom.Values.Count
            Dim array1(degerSayisi) As String
            For i As Integer = 0 To degerSayisi
                array1(i)=Convert.ToString( tablom.Values(i)) 
            Next i
            Dim con As SqlConnection = New SqlConnection("Data Source=MERT;Initial Catalog=off_day_off_time;Integrated Security=True")
            Dim cmd As SqlCommand = New SqlCommand()
            Dim dr As SqlDataReader
            cmd.Parameters.Clear()
            cmd.Connection = con
            cmd.CommandText ="SELECT isim FROM kullanici"
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            dr = cmd.ExecuteReader()
             While( dr.Read())
                Dim bulunan As String=""
                 For i As Integer = 0 To degerSayisi-1
                     If dr.GetString(0)=array1(i) Then
                        bulunan=array1(i)
                        Return bulunan
                     End If
                 Next i
             End While
  dr.Close()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

   End Function
  
End Module
