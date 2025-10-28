Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class Form6
    Public Property FirstName As String
    Public Property LastName As String
    Public Property BirthDate As String
    Public Property cin As String
    Public Property phone As String
    Public Property post As String
    Public Property salary As String
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LabelFirstName.Text = FirstName
        LabelLastName.Text = LastName
        LabelDOB.Text = BirthDate
        LabelCin.Text = cin
        TextBox1.Text = phone
        LabelPost.Text = post
        TextBox2.Text = salary


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim filePath As String = "C:\Users\Khalil\Desktop\Project\bin\personnel.txt"
        Dim fileLines As List(Of String) = File.ReadAllLines(filePath).ToList()

        For i As Integer = 0 To fileLines.Count - 1
            Dim userData As String() = fileLines(i).Split("#")

            If userData.Length > 0 AndAlso userData(0).ToUpper = LabelFirstName.Text.ToUpper AndAlso userData(1).ToUpper = LabelLastName.Text.ToUpper Then
                userData(4) = TextBox1.Text.ToString
                userData(6) = TextBox2.Text.ToString
                fileLines(i) = String.Join("#", userData)
                Exit For
            End If
        Next

        File.WriteAllLines(filePath, fileLines)
        MsgBox("Modification avec succes")
    End Sub
End Class