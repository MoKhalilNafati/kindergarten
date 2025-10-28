Public Class Form12
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim email As String = "admin@admin.com"
        Dim password As String = "Khalilo19"

        If TextBox1.Text.ToLower <> email Or TextBox2.Text <> password Then
            MsgBox("Email ou mot de passe non valide")
        Else
            TextBox1.Text = ""
            TextBox2.Text = ""
            Form8.Show()
            Me.Hide()
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class