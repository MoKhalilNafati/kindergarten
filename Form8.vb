Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form8

    Public Property SelectedFirstName As String
    Public Property SelectedLastName As String
    Dim t() As String
    Dim ch As String

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim filePath As String = "C:\Users\Khalil\Desktop\Project\bin\enfant.txt"

        If File.Exists(filePath) Then
            Dim lines As String() = File.ReadAllLines(filePath)

            For Each line As String In lines
                Dim parts As String() = line.Split("#"c)
                If parts.Length >= 2 Then
                    Dim combinedParts As String = $"{parts(0).Trim()} {parts(1).Trim()}"
                    ListBox1.Items.Add(combinedParts)
                Else
                    ListBox1.Items.Add(line)
                End If
            Next
        Else
            MessageBox.Show("File not found!")
        End If
    End Sub


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form7.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form11.Show()
        Me.Hide()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Check if an item is selected in the ListBox
        If ListBox1.SelectedIndex <> -1 Then
            ' Get the selected item's text
            Dim selectedItemText As String = ListBox1.SelectedItem.ToString()

            ' Split the selected item's text to extract FirstName and LastName
            Dim parts As String() = selectedItemText.Split(" "c)
            If parts.Length >= 2 Then
                Dim selectedFirstName As String = parts(0).Trim()
                Dim selectedLastName As String = parts(1).Trim()

                ' Open the file for writing
                Dim filePath As String = "C:\Users\Khalil\Desktop\Project\bin\enfant.txt"
                Dim lines As New List(Of String)(File.ReadAllLines(filePath))

                ' Find the line containing the selected user's information and remove it
                Dim lineToRemove As String = lines.FirstOrDefault(Function(line) line.StartsWith($"{selectedFirstName}#{selectedLastName}"))
                If lineToRemove IsNot Nothing Then
                    lines.Remove(lineToRemove)
                    File.WriteAllLines(filePath, lines.ToArray())

                    ' Remove the selected item from the ListBox
                    ListBox1.Items.Remove(selectedItemText)
                End If
            End If
        Else
            MessageBox.Show("Please select a user to delete.")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fs As New FileStream("C:\Users\Khalil\Desktop\Project\bin\enfant.txt", FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(fs)

        ' Check if an item is selected
        If ListBox1.SelectedIndex <> -1 Then
            ' Get the selected item's text (assuming it's in the format "FirstName LastName")
            Dim selectedItemText As String = ListBox1.SelectedItem.ToString()

            ' Split the selected item's text to extract FirstName and LastName
            Dim parts As String() = selectedItemText.Split(" "c)
            If parts.Length >= 2 Then
                SelectedFirstName = parts(0).Trim()
                SelectedLastName = parts(1).Trim()
                While sr.Peek > -1
                    ch = sr.ReadLine()
                    t = ch.Split("#")
                    If SelectedFirstName = t(0) AndAlso SelectedLastName = t(1) Then
                        ' Store user information in variables accessible to other forms
                        Dim firstName As String = t(0)
                        Dim lastName As String = t(1)
                        Dim birthDate As String = t(2)
                        Dim subscriptionCategory As String = t(3)
                        Dim meal As String = t(4)
                        Dim transportation As String = t(5)
                        Dim clubs As String = t(6)
                        Dim link As String = t(8)

                        ' Open Form5 and pass the user information
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

                sr.Close()
                fs.Close()
            End If
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class