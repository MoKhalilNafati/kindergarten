Imports System.Globalization
Imports System.IO
Imports System.Reflection.Emit

Public Class Form9
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fsParent As New FileStream("C:\Users\Khalil\Desktop\Project\bin\parent.txt", FileMode.Open, FileAccess.Read)
        Dim srParent As New StreamReader(fsParent)

        Dim isFound As Boolean = False

        While srParent.Peek > -1
            Dim parentLine As String = srParent.ReadLine()
            Dim parentData() As String = parentLine.Split("#")

            If parentData(0) = TextBox3.Text.ToUpper() AndAlso
                       parentData(1) = TextBox4.Text.ToUpper() AndAlso
                       parentData(2) = TextBox1.Text.ToUpper() AndAlso
                       parentData(3) = TextBox2.Text.ToUpper() AndAlso
                       parentData(5) = TextBox5.Text AndAlso
                       parentData(6) = TextBox6.Text.ToUpper Then

                Label1.Text = "Votre mot de passe: " & parentData(7)
                isFound = True
                Exit While ' Exit the inner loop if the match is found
            End If
        End While

            If Not isFound Then
                MsgBox("Coordonnées non valides")
            End If

            srParent.Close()
            fsParent.Close()
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class