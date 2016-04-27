Imports System.Threading 'Necesario para utilizar el Sleep por un Thread
Imports System.Threading.Tasks

Public Class Principal

    Dim Jugador1 As String
    Dim Jugador2 As String


    Dim PBSelected As PictureBox 'Contiene info del cuadro seleccionado
    Dim Cards As New Dictionary(Of Integer, Banderas) 'Lista con la cantidad de nombres de las banderas.
    Dim Paises As New Dictionary(Of Integer, String)
    Dim Partidas As New Dictionary(Of Integer, Partidas)


    Dim modo As New Integer
    Dim time As New Integer
    Dim turno As New Integer
    Dim points1 As Integer
    Dim points2 As Integer
    Dim points As Integer

    Sub start()

    End Sub

    'Boton de iniciar un juego
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        modo = 1
        Panel2.Show()
        Panel3.Hide()
        Panel5.Show()
        Panel6.Hide()
        Button3.Show()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        modo = 2
        Panel2.Show()
        Panel3.Show()
        Panel5.Show()
        Panel6.Show()
        Button3.Show()



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

                'Subir puntos al jugador en turno
                If modo = 1 Then
                    points1 = points1 + 1
                    TextBox2.Text = points1 & ""
                Else
                    If turno = 1 Then
                        points1 = points1 + 1
                        points = points + 1
                        TextBox2.Text = points1 & ""
                    Else
                        points = points + 1
                        points2 = points2 + 1
                        TextBox4.Text = points2 & ""
                    End If

                End If


                If points = 32 Then
                    MsgBox("Felicidades lo haz logrado!")

                End If
                'Si no es igual   
            Else

                PBSelected.Image = System.Drawing.Bitmap.FromFile(
                AppDomain.CurrentDomain.BaseDirectory & "\question.png")
                B.Image = System.Drawing.Bitmap.FromFile(
                AppDomain.CurrentDomain.BaseDirectory & "\question.png")
                PBSelected.Enabled = True
                If turno = 0 Then
                    turno = 1
                    CheckBox1.Checked = True
                    CheckBox2.Checked = False

                Else
                    turno = 0
                    CheckBox1.Checked = False
                    CheckBox2.Checked = True
                End If
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

        'Limpia el panel de PictureBox
        Panel1.Controls.Clear()
        turno = 1
        points1 = 0
        points2 = 0
        points = 0
        TextBox2.Text = 0 & ""
        TextBox4.Text = 0 & ""

        Cards = New Dictionary(Of Integer, Banderas)
        Paises = New Dictionary(Of Integer, String)

        Paises.Add(1, "Costa-Rica")
        Paises.Add(2, "France")
        Paises.Add(3, "Brazil")
        Paises.Add(4, "Botswana")
        Paises.Add(5, "Colombia")
        Paises.Add(6, "Comoros")
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

        'Crea una bandera por cada Pais en la lista Paises
        For i As Integer = 1 To 32
            Dim band As New Banderas
            band.id = i
            band.name = Paises.Item(i)
            Cards.Add(i, band)
        Next

        Dim rand As New Random() 'espacio memoria pra randomizar
        Dim y As New Integer 'contador de cartas
        Dim random As Integer 'aloja el numero random generado

        y = 0

        'Tratar de colocar 64 Cuadros
        While y < 64

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
                B.Left = (y Mod 8) * 80
                B.Top = (y \ 8) * 60
                B.Name = band.name & ".png"
                B.Image = System.Drawing.Bitmap.FromFile(
                AppDomain.CurrentDomain.BaseDirectory & "\question.png")
                B.Refresh()
                band.col = band.col + 1 'Aumenta el contador de colocados en la bandera.
                y = y + 1 'Aumenta el contador de colocados en el tablero.

                AddHandler B.Click, AddressOf Button_Click 'Evento del Picture Box creado.

            End If


        End While


    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel3.Hide()
        Panel2.Hide()
        Panel6.Hide()
        Panel5.Hide()
        Button3.Hide()

        time = 0
        AddHandler Timer1.Tick, AddressOf OnLayouttimerTick

    End Sub

    Private Sub OnLayouttimerTick(sender As Object, e As EventArgs)
        time = time + 1
        Thread.Sleep(1000)
        Label7.Text = time & ""

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        LlenarCards()
        Label3.Text = TextBox1.Text
        Label5.Text = TextBox3.Text
        Panel2.Hide()
        Panel3.Hide()
        Button3.Hide()

        Timer1.Enabled = True


    End Sub


End Class