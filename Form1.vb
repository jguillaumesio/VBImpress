Public Class Form1
    Public pass As String = "test"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = pass Then
            If MsgBox("Accèder à l'écran suivant ?", vbOKCancel, "Authentification") = vbOK Then
                TextBox1.Text = ""
                Form2.Show()
            Else
                TextBox1.Text = ""
            End If
        End If
    End Sub
End Class
