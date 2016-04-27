Imports System.Threading 'Necesario para utilizar el Sleep por un Thread

Public Class Principal

    Dim Jugador As String
    Dim points As Integer

    Dim PBSelected As PictureBox 'Contiene info del cuadro seleccionado
    Dim Cards As New Dictionary(Of Integer, Banderas) 'Lista con la cantidad de nombres de las banderas.


    'Boton de iniciar un juego
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Limpia el panel de PictureBox
        Panel1.Controls.Clear()


        Dim rand As New Random()
        Dim i As New Integer
        Dim random As Integer
        i = 0

        'Tratar de colocar 64 Cuadros
        While i < 64

            'Genera un random entre el 1 y el 33
            random = rand.Next(1, 33)

            'Guardamos la bandera de correspondiente al index random del diccionario
            Dim band As New Banderas
            band = Cards.Item(random)

            'Si la bandera esta colocada 0 o 1 vez
            If band.col = 0 OrElse band.col = 1 Then
                Dim B As New PictureBox
                Panel1.Controls.Add(B)
                B.Height = 47
                B.Width = 70
                B.Left = (i Mod 8) * 80
                'B.BackColor = Color.Red

                B.Top = (i \ 8) * 60
                B.Name = band.name & ".png"
                B.Image = System.Drawing.Bitmap.FromFile(
                AppDomain.CurrentDomain.BaseDirectory & "\question.png")
                B.Refresh()
                band.col = band.col + 1
                i = i + 1
                AddHandler B.Click, AddressOf Button_Click




            End If


        End While

    End Sub




    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim B As PictureBox = sender 'Boton donde se genera el click

        'Visualizamos la imagen cuando le damos click 
        B.Image = System.Drawing.Bitmap.FromFile(
                AppDomain.CurrentDomain.BaseDirectory & "\" & B.Name)

        B.Refresh()


        'Si ya existe un cuadro seleccionado
        If PBSelected IsNot Nothing Then

            'Dormimos el tiempo unos segundos mientras se muestra la imagen.
            Thread.Sleep(700)

            'Si el segundo cuadro seleccionado es igual al primero.
            If PBSelected.Name = B.Name Then


                B.Enabled = False
                PBSelected.Enabled = False

                points = points + 1
                TextBox2.Text = points & ""
                'Si no es igual   
            Else

                PBSelected.Image = System.Drawing.Bitmap.FromFile(
                AppDomain.CurrentDomain.BaseDirectory & "\question.png")
                B.Image = System.Drawing.Bitmap.FromFile(
                AppDomain.CurrentDomain.BaseDirectory & "\question.png")

                PBSelected.Enabled = True

            End If

            PBSelected = Nothing

            'Si no hay ningún cuadro seleccionado
        Else
            PBSelected = B 'variable global almacena temporalmente cuadro seleccionado

            'Visualizar imagen del cuadro seleccionado.
            B.Image = System.Drawing.Bitmap.FromFile(
                AppDomain.CurrentDomain.BaseDirectory & "\" & B.Name)
            PBSelected.Enabled = False
        End If

    End Sub

    '
    Private Sub LlenarCards()
        Cards = New Dictionary(Of Integer, Banderas)

        Dim Paises As New Dictionary(Of Integer, String)

        Paises.Add(1, "Costa-Rica")
        Paises.Add(2, "France")
        Paises.Add(3, "Brazil")
        Paises.Add(4, "Botswana")
        Paises.Add(5, "Colombia")
        Paises.Add(6, "China")
        Paises.Add(7, "Canada")
        Paises.Add(8, "Denmark")
        Paises.Add(9, "Dominica")
        Paises.Add(10, "Germany")
        Paises.Add(11, "Guatemala")
        Paises.Add(12, "Honduras")
        Paises.Add(13, "Hungary")
        Paises.Add(14, "India")
        Paises.Add(15, "Iran")
        Paises.Add(16, "Iraq")
        Paises.Add(17, "Italy")
        Paises.Add(18, "Jamaica")
        Paises.Add(19, "Japan")
        Paises.Add(20, "Korea-South")
        Paises.Add(21, "Laos")
        Paises.Add(22, "Liberia")
        Paises.Add(23, "Malawi")
        Paises.Add(24, "Nepal")
        Paises.Add(25, "Palau")
        Paises.Add(26, "Panama")
        Paises.Add(27, "Saint-Lucia")
        Paises.Add(28, "San-Marino")
        Paises.Add(29, "Solomon-Islands")
        Paises.Add(30, "Uruguay")
        Paises.Add(31, "United-Kingdom")
        Paises.Add(32, "Zimbabwe")


        For i As Integer = 1 To 32
            Dim band As New Banderas
            band.id = i
            band.name = Paises.Item(i)
            Cards.Add(i, band)
        Next



    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarCards()
    End Sub


End Class