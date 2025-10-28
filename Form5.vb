Imports System.IO

Public Class Form5

    ' Public properties to store user information
    Public Property FirstName As String
    Public Property LastName As String
    Public Property BirthDate As String
    Public Property SubscriptionCategory As String
    Public Property Transportation As String
    Public Property Meal As String
    Public Property Clubs As String
    Public Property link As String

    'Private ReadOnly selectedFirstName As String

    'Private ReadOnly selectedLastName As String

    ' Constructor (if needed)
    Public Sub New()
        ' This constructor can be left empty or modified as needed
        InitializeComponent()
    End Sub


    ' Create a method to retrieve checked items from the CheckedListBox
    Private Function GetCheckedItems() As String
        ' Create a list to store checked items
        Dim checkedItems As New List(Of String)()

        ' Loop through each item in the CheckedListBox
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            ' Check if the current item is checked
            If CheckedListBox1.GetItemChecked(i) Then
                ' Retrieve the checked item at index i and add it to the list
                checkedItems.Add(CheckedListBox1.Items(i).ToString())
            End If
        Next

        ' Do something with the list of checked items
        ' For example, join them into a string using "/"
        If checkedItems.Count > 0 Then
            Return String.Join("/", checkedItems)
        Else
            Return "" ' Return an empty string if no items are checked
        End If
    End Function





    ' Method to display user information when the form loads
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dataString As String = Clubs
        Dim ch As String = ""

        ' Split the string into an array based on the separator '/'
        Dim elements As String() = dataString.Split("/"c)


        ' Set the text of labels or text boxes to display user information
        LabelFirstName.Text = FirstName
        LabelLastName.Text = LastName
        LabelDOB.Text = BirthDate
        If SubscriptionCategory = "Journée-complète" Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If
        If Meal = "Avec-repas" Then
            RadioButton3.Checked = True
        Else
            RadioButton4.Checked = True
        End If
        If Transportation = "Avec-transport" Then
            RadioButton5.Checked = True
        Else
            RadioButton6.Checked = True
        End If

        Try
            If Not String.IsNullOrEmpty(link) AndAlso File.Exists(link) Then
                ' Load the image from the specified path
                Dim image As Image = Image.FromFile(link)

                ' Set the image to the PictureBox
                PictureBox1.Image = image
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading image: " & ex.Message)
        End Try


        ' Clear any existing items in the CheckedListBox
        For i As Integer = 0 To elements.Length - 1
            For j As Integer = 0 To CheckedListBox1.Items.Count - 1
                ' Check if the user input matches any item in the CheckedListBox
                If String.Equals(elements(i), CheckedListBox1.Items(j).ToString(), StringComparison.OrdinalIgnoreCase) Then
                    ' Set the item at index i to be checked
                    CheckedListBox1.SetItemChecked(j, True)
                    Exit For ' Exit loop after finding and checking the item
                End If
            Next
        Next


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim filePath As String = "C:\Users\Khalil\Desktop\Project\bin\enfant.txt"
        Dim fileLines As List(Of String) = File.ReadAllLines(filePath).ToList()

        For i As Integer = 0 To fileLines.Count - 1
            Dim userData As String() = fileLines(i).Split("#")

            If userData.Length > 0 AndAlso userData(0).ToUpper = LabelFirstName.Text.ToUpper AndAlso userData(1).ToUpper = LabelLastName.Text.ToUpper Then
                userData(0) = LabelFirstName.Text.ToUpper
                userData(1) = LabelLastName.Text.ToUpper
                userData(2) = LabelDOB.Text.ToUpper
                userData(3) = If(RadioButton1.Checked, "Journée-complète", "Demi-journée") ' Assuming a field for SubscriptionCategory
                userData(4) = If(RadioButton3.Checked, "Avec-repas", "Sans-repas") ' Assuming a field for Meal
                userData(5) = If(RadioButton5.Checked, "Avec-transport", "Sans-transport") ' Assuming a field for Transportation
                userData(6) = GetCheckedItems()

                fileLines(i) = String.Join("#", userData)
                Exit For
            End If
        Next

        File.WriteAllLines(filePath, fileLines)
        MsgBox("Modification avec succes")
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) 
        'Form8.Show()
        'Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form10.Show()
        Me.Hide()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub
End Class
