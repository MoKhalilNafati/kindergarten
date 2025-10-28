Imports System.IO

Public Class Form11
    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim filePath As String = "C:\Users\Khalil\Desktop\Project\bin\enfant.txt"
        Dim fileLines As List(Of String) = File.ReadAllLines(filePath).ToList()


        Dim nbr_complete As Integer = 0
        Dim nbr_demi As Integer = 0
        Dim nbr_with_r As Integer = 0
        Dim nbr_without_r As Integer = 0
        Dim nbr_with_t As Integer = 0
        Dim nbr_without_t As Integer = 0
        Dim tot_income As Integer = 0



        For i As Integer = 0 To fileLines.Count - 1
            Dim t As String() = fileLines(i).Split("#")

            If t(3) = "Journée-complète" Then
                nbr_complete += 1
            Else
                nbr_demi += 1
            End If
            If t(5) = "Avec-transport" Then
                nbr_with_t += 1
            Else
                nbr_without_t += 1
            End If
            If t(4) = "Avec-repas" Then
                nbr_with_r += 1
            Else
                nbr_without_r += 1
            End If
            tot_income += t(7)
        Next
        Label10.Text = nbr_complete.ToString
        Label11.Text = nbr_demi.ToString
        Label12.Text = nbr_with_t.ToString
        Label13.Text = nbr_without_t.ToString
        Label14.Text = nbr_with_r.ToString
        Label15.Text = nbr_without_r.ToString
        Label17.Text = fileLines.Count.ToString
        Label19.Text = tot_income.ToString

        Dim filePath2 As String = "C:\Users\Khalil\Desktop\Project\bin\personnel.txt"
        Dim fileLines2 As List(Of String) = File.ReadAllLines(filePath2).ToList()

        Dim tot_outcome As Integer = 0

        For j As Integer = 0 To fileLines2.Count - 1
            Dim t2 As String() = fileLines2(j).Split("#")
            tot_outcome += t2(6)
        Next
        Label21.Text = fileLines2.Count.ToString
        Label23.Text = tot_outcome.ToString
        Label25.Text = tot_income - tot_outcome

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Form8.Show()
        Me.Show()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Form7.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        Form7.Show()
        Me.Hide()
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Form8.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class