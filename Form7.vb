Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form7

    Public Property SelectedFirstName As String
    Public Property SelectedLastName As String
    Dim t() As String
    Dim ch As String
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim filePath As String = "C:\Users\Khalil\Desktop\Project\bin\personnel.txt"

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

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        ' Update 'personnel' information in the file
        UpdatePersonnelInformation()
    End Sub

    Private Sub UpdatePersonnelInformation()
        Dim filePath As String = "C:\Users\Khalil\Desktop\Project\bin\personnel.txt"

        ' Read all lines from the file
        Dim fileLines As List(Of String) = File.ReadAllLines(filePath).ToList()


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Form8.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Form11.Show()
        Me.Hide()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fs As New FileStream("C:\Users\Khalil\Desktop\Project\bin\personnel.txt", FileMode.Open, FileAccess.Read)
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
                        Dim cin As String = t(3)
                        Dim phone As String = t(4)
                        Dim post As String = t(5)
                        Dim salary As String = t(6)

                        ' Open Form5 and pass the user information
                        Dim form6Instance As New Form6()
                        form6Instance.FirstName = firstName
                        form6Instance.LastName = lastName
                        form6Instance.BirthDate = birthDate
                        form6Instance.cin = cin
                        form6Instance.phone = phone
                        form6Instance.post = post
                        form6Instance.salary = salary

                        form6Instance.Show()
                        'Me.Hide()
                        Exit While
                    End If
                End While

                sr.Close()
                fs.Close()
            End If
        End If
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Form8.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Form11.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
                Else
                    MessageBox.Show("User not found in file.")
                End If
            End If
        Else
            MessageBox.Show("Please select a user to delete.")
        End If
    End Sub
End Class