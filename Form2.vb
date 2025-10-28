Imports System.IO
Imports System.Net.Security

Public Class Form2
    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userExists As Boolean = False
        Dim fs As New FileStream("C:\Users\Khalil\Desktop\Project\bin\parent.txt", FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(fs)
        Dim t() As String
        Dim ch As String
        Dim fs2 As New FileStream("C:\Users\Khalil\Desktop\Project\bin\enfant.txt", FileMode.Open, FileAccess.Read)
        Dim sr2 As New StreamReader(fs2)
        Dim t2() As String
        Dim ch2 As String

        While sr.Peek > -1
            ch = sr.ReadLine()
            t = ch.Split("#")

            If TextBox1.Text.ToUpper() = t(6) AndAlso TextBox2.Text = t(7) Then
                userExists = True

                ' Reset the stream position for enfant.txt
                fs2.Position = 0
                sr2.DiscardBufferedData()

                While sr2.Peek > -1
                    ch2 = sr2.ReadLine()
                    t2 = ch2.Split("#")
                    If t(2) = t2(0) AndAlso t(3) = t2(1) Then

                        Dim firstName As String = t2(0)
                        Dim lastName As String = t2(1)
                        Dim birthDate As String = t2(2)
                        Dim subscriptionCategory As String = t2(3)
                        Dim meal As String = t2(4)
                        Dim transportation As String = t2(5)
                        Dim clubs As String = t2(6)
                        Dim link As String = t2(8)

                        Dim form5Instance As New Form5()
                        form5Instance.FirstName = firstName
                        form5Instance.LastName = lastName
                        form5Instance.BirthDate = birthDate
                        form5Instance.SubscriptionCategory = subscriptionCategory
                        form5Instance.Transportation = transportation
                        form5Instance.Meal = meal
                        form5Instance.Clubs = clubs
                        form5Instance.link = link

                        form5Instance.Show()
                        'Me.Hide()
                        Exit While
                    End If
                End While
                Exit While
            End If
        End While

        sr.Close()
        fs.Close()

        sr2.Close()
        fs2.Close()

        If Not userExists Then
            MsgBox("Le compte n'existe pas")
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        Form1.Show()
        Me.Hide()
    End Sub
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        Form9.Show()
        Me.Hide()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class