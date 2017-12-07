Imports System.Data.SqlClient
Public Class giris_sayfası
    Private Sub giris_sayfası_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim kayitsayisi As Integer
        kayitsayisi = -1
        Dim con As SqlConnection = New SqlConnection("Data Source=DESKTOP-OB6MC9Q;Initial Catalog=off_day_off_time;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand("select count (*)from kullanici", con)
        Dim rdr As SqlDataReader
        con.Open()

        kayitsayisi = Convert.ToInt32(cmd.ExecuteScalar())
        con.Close()
        Dim cd As SqlCommand = New SqlCommand("select resim_yolu from kullanici", con)

        Dim j As Integer = 0

        Dim resimler(kayitsayisi) As PictureBox
        For i = 0 To kayitsayisi

            j = j + 100
            resimler(i) = New PictureBox()


            resimler(i).Location = New Point(j, 100)

            resimler(i).Visible = True
            resimler(i).BackColor = Color.Blue
            resimler(i).SizeMode = PictureBoxSizeMode.AutoSize

            Me.Controls.Add(resimler(i))

        Next
        con.Open()
        rdr = cd.ExecuteReader()

        'resimler = rdr.


        rdr.Close()
        con.Close()
        'For Each 
        '    j = j + 100
        '    resimler(i) = New PictureBox()


        '    resimler(i).Location = New Point(j, 100)

        '    resimler(i).Visible = True
        '    resimler(i).BackColor = Color.Transparent
        '    resimler(i).SizeMode = PictureBoxSizeMode.AutoSize

        '    Me.Controls.Add(resimler(i))


        'Next



        'Dim cd As SqlCommand = New SqlCommand("select resim_yolu from kullanici ")
        'cd.Connection = con
        'con.Open()
        'Dim oku As SqlDataReader
        'oku = cd.ExecuteReader()

        'While (oku.Read())

        '    pb = Convert.toku
        'End While

        'oku.Close()
        'con.Close()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Bilgiler.Show()

    End Sub

End Class