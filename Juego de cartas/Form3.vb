Public Class Form3
    Dim s As Integer
    Dim n As Integer
    Dim banderas() As Integer
    Dim cont As Integer = 0

    


    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        

        s = 0
        TextBox1.Text = s
        Timer1.Interval = 1000
        Timer1.Enabled = True
        Timer1.Start()


        Dim l As Integer = 0
        Dim i As Integer
        For i = 1 To 64
            n = Rnd() * 31 + 1

            For Each item In banderas
                If item = n And cont = 2 Then
                    i = i - 1
                ElseIf item = n And cont = 1 Then

                    ReDim banderas(l + 1)
                    banderas(l) = n
                    l = l + 1
                    cont = 2
                Else
                    ReDim banderas(l + 1)
                    banderas(l) = n
                    l = l + 1
                    cont = 1
                End If
            Next
        Next










        If Form1.CheckBox1.Checked = True Then
            Label10.Text = Form2.TextBox1.Text
            Label3.Visible = False
            Label7.Visible = False
            Label9.Visible = False




        ElseIf Form1.CheckBox2.Checked = True Then
            Label10.Text = Form2.TextBox1.Text
            Label11.Text = Form2.TextBox2.Text
        End If


    End Sub





    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        s = s + 1
        TextBox1.Text = s
        If s Mod 10 = 1 Or s Mod 10 = 2 Or s Mod 10 = 3 Or s Mod 10 = 4 Or s Mod 10 = 5 Then
            CheckBox1.Checked = True
            CheckBox2.Checked = False

        ElseIf s Mod 10 = 6 Or s Mod 10 = 7 Or s Mod 10 = 8 Or s Mod 10 = 9 Or s Mod 10 = 0 Then
            CheckBox1.Checked = False
            CheckBox2.Checked = True


        End If


    End Sub
End Class