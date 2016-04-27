Imports System.Threading

Public Class Principal


    Dim PBSelected As PictureBox
    Dim Cards As New Dictionary(Of Integer, Banderas)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        LlenarCards()

        'Me.Panel2.Hide()
        Dim rand As New Random()
        Dim i As New Integer
        i = 0

        While i < 60

            Dim random = rand.Next(1, 32)
            Dim gettt As New Banderas
            gettt = Cards.Item(random)
            If gettt.col = 0 OrElse gettt.col = 1 Then
                Dim B As New PictureBox
                Panel1.Controls.Add(B)
                B.Height = 70
                B.Width = 100
                B.Left = (i Mod 8) * 118
                'B.BackColor = Color.Red

                B.Top = (i \ 8) * 75
                B.Name = random & ".png"
                B.Image = System.Drawing.Bitmap.FromFile(
                AppDomain.CurrentDomain.BaseDirectory & "\" & B.Name)
                B.Refresh()
                gettt.col = gettt.col + 1
                i = i + 1
                AddHandler B.Click, AddressOf Button_Click

            End If


        End While

    End Sub

    Private Sub LlenarCards()
        Cards = New Dictionary(Of Integer, Banderas)
        For i As Integer = 1 To 32

            Dim band As New Banderas
            band.id = i
            Cards.Add(i, band)
        Next

    End Sub


    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim B As PictureBox = sender

        B.Image = System.Drawing.Bitmap.FromFile(
                AppDomain.CurrentDomain.BaseDirectory & "\" & B.Name)

        B.Refresh()

        Thread.Sleep(500)

        If PBSelected IsNot Nothing Then

            If PBSelected.Name = B.Name Then

                B.Image = Nothing
                PBSelected.Image = Nothing

                B.BackColor = Color.DarkGreen
                PBSelected.BackColor = Color.DarkGreen

            Else

                PBSelected.Image = Nothing
                B.Image = Nothing
                B.BackColor = Color.Red
                PBSelected.BackColor = Color.Red

            End If

            PBSelected = Nothing


        Else
            PBSelected = B
            B.Image = System.Drawing.Bitmap.FromFile(
                AppDomain.CurrentDomain.BaseDirectory & "\" & B.Name)
        End If

    End Sub

End Class