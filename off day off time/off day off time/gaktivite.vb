Public Class gaktivite
     Const gün As Double = 24.0
    Private this As Object

    Public Function hesapla(ByVal toplam As Integer) As Double
        Dim ksaat As Double = 0
        ksaat = gün - toplam
        ksaat = (ksaat * 1 / 3)
        ksaat = Math.Round(Convert.ToDouble(ksaat), 0)
        Return ksaat
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim uyuma As Double
        Dim is_okul As Double
        Dim kzaman As Double
        Dim sonuc As Double
        Try
            utxt.TextMaskFormat = MaskFormat.IncludeLiterals
            uyuma = Convert.ToDouble(utxt.Text.Replace(":", ","))

            itxt.TextMaskFormat = MaskFormat.IncludeLiterals
            is_okul = Convert.ToDouble(itxt.Text.Replace(":", ","))
            ktxt.TextMaskFormat = MaskFormat.IncludeLiterals
            kzaman = Convert.ToDouble(ktxt.Text.Replace(":", ","))
            sonuc = uyuma + is_okul + kzaman
            sonuc = hesapla(sonuc)
            If utxt.TextLength <= 0 Then
                ErrorProvider1.SetError(utxt, $"Uyuma süresi girmeniz gerekmektedir.")
            Else
                ErrorProvider1.SetError(utxt, vbNullString)
            End If

            If itxt.TextLength <= 0 Then
                ErrorProvider1.SetError(itxt, $"İşe veya okulunuza ayrılan sürenizi girmeniz gerekmektedir.")
            Else
                ErrorProvider1.SetError(itxt, vbNullString)
            End If

            If ktxt.TextLength <= 0 Then
                ErrorProvider1.SetError(ktxt, $"Kişisel işlerinize ayırdığınız zamanı girmeniz gerekmetedir.")
            Else
                ErrorProvider1.SetError(ktxt, vbNullString)
            End If
            MessageBox.Show($"Aktiviteleriniz için ayrılan zaman:" & sonuc)
            Dim gkalan As Double
            gkalan = gün - (sonuc + uyuma + is_okul + kzaman)
            Dim g As Graphics = CreateGraphics()
            Dim rect As Rectangle = New Rectangle(300, 50, 200, 200)
            uyuma = ((uyuma / 24) * 360)
            is_okul = ((is_okul / 24) * 360)
            kzaman = ((kzaman / 24) * 360)
            sonuc = ((sonuc / 24) * 360)
            gkalan = ((gkalan / 24) * 360)
            g.FillPie(Brushes.Green, rect, 0, uyuma)
            g.FillPie(Brushes.Red, rect, uyuma, is_okul)
            g.FillPie(Brushes.Blue, rect, is_okul + uyuma, kzaman)
            g.FillPie(Brushes.Orange, rect, is_okul + uyuma + kzaman, sonuc)
            g.FillPie(Brushes.Yellow, rect, is_okul + uyuma + kzaman + sonuc, gkalan)
            g.Dispose()
            GroupBox1.Visible = True
            For Each control As Control In Me.Controls
                If TypeOf control Is TextBox
                    control.Text=""
                End If
                Next
 Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

   

    Private Sub utxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles utxt.KeyPress
        If Not (Char.IsNumber(e.KeyChar) = True) And e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub itxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles itxt.KeyPress
        If Not (Char.IsNumber(e.KeyChar) = True) And e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ktxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ktxt.KeyPress
        If Not (Char.IsNumber(e.KeyChar) = True) And e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
End Class