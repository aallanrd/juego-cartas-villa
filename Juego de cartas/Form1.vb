Public Class Form1

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True And CheckBox2.Checked = True Then
            MsgBox("Modo de juego no permitido, seguir")
        Else
            Me.Visible = False
            Form2.ShowDialog()
        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Visible = False
        Principal.ShowDialog()
    End Sub
End Class
