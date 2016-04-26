Public Class Form2

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.CheckBox1.Checked = True And Form1.CheckBox2.Checked = False Then
            Label3.Visible = False
            TextBox2.Visible = False
            CheckBox1.Visible = False
            CheckBox2.Visible = False
        ElseIf Form1.CheckBox1.Checked = False And Form1.CheckBox2.Checked = True Then
            Label3.Visible = True
            TextBox2.Visible = True
            CheckBox1.Visible = True
            CheckBox2.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Visible = True
        Form1.CheckBox1.Checked = False
        Form1.CheckBox2.Checked = False



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Form1.CheckBox1.Checked = True And Form1.CheckBox2.Checked = False And Trim(TextBox1.Text) = "" Then
            MsgBox("Información incompleta")
        ElseIf Form1.CheckBox2.Checked = True And Trim(TextBox1.Text) = "" Then
            MsgBox("Información incompleta")

        ElseIf Form1.CheckBox2.Checked = True And Trim(TextBox2.Text) = "" Then
            MsgBox("Información incompleta")



        Else
            Me.Hide()
            Form3.ShowDialog()
        End If



    End Sub
End Class