Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form3

    Private selectedFilePath As String = "" ' Declare at class level to access it in other methods

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        ' Regular expression pattern for validating email addresses
        Dim emailRegex As String = "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        Dim regex As New Regex(emailRegex)
        Return regex.IsMatch(email)
    End Function
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Dim test As Boolean = False
        Dim inputEmail As String = TextBox6.Text.Trim()
        Dim filePathEnfant As String = "C:\Users\Khalil\Desktop\Project\bin\enfant.txt"
        Dim filePathParent As String = "C:\Users\Khalil\Desktop\Project\bin\parent.txt"

        Dim currentDate As Date = Date.Now
        Dim minDate As Date = currentDate.AddYears(-5)
        Dim maxDate As Date = currentDate.AddYears(-3)
        Dim enteredDate As Date = DateTimePicker1.Value


        If TextBox1.Text = "" OrElse TextBox2.Text = "" OrElse TextBox3.Text = "" OrElse TextBox4.Text = "" Then
            MsgBox("Veuillez remplir le nom et le prénom.")
        ElseIf TextBox5.Text.Length <> 8 OrElse Not IsNumeric(TextBox5.Text) Then
            MsgBox("Veuillez entrer un CIN valide de 8 chiffres.")
        ElseIf Not IsValidEmail(inputEmail) Then
            MsgBox("Email non valide")
        ElseIf enteredDate < minDate OrElse enteredDate > maxDate Then
            MsgBox("L'âge doit être entre 3 et 5 ans.")
        ElseIf TextBox7.Text.Length > 12 OrElse TextBox7.Text.Length < 6 OrElse TextBox7.Text = "" Then
            MsgBox("Le mot de passe doit être entre 6 et 12 caractères.")
        Else
            ' Check if the account already exists
            Using sr As New StreamReader(filePathParent)
                While sr.Peek > -1
                    Dim line As String = sr.ReadLine()
                    Dim t() As String = line.Split("#")

                    If TextBox3.Text.ToUpper = t(0) AndAlso TextBox4.Text.ToUpper = t(1) AndAlso TextBox1.Text.ToUpper = t(2) AndAlso TextBox2.Text.ToUpper = t(3) Then
                        test = True
                        Exit While
                    End If
                End While
            End Using

            If test Then
                MsgBox("Le compte existe déjà.")
                initializing()
                Exit Sub


                ' Calculate date ranges


                ' Calculate base price
            Else
                Dim basePrice As Integer = If(RadioButton1.Checked, 500, 300)
                Dim mealPrice As Integer = If(CheckBox1.Checked, 100, 0)
                Dim transportPrice As Integer = If(CheckBox2.Checked, 100, 0)
                Dim clubPrice As Integer = CheckedListBox1.CheckedItems.Count * 50
                Dim totalPrice As Integer = basePrice + mealPrice + transportPrice + clubPrice

                TextBox8.Text = totalPrice & "DT"

                Using swEnfant As New StreamWriter(filePathEnfant, True),
                      swParent As New StreamWriter(filePathParent, True)
                    swEnfant.WriteLine($"{TextBox1.Text.ToUpper}#{TextBox2.Text.ToUpper}#{enteredDate.ToString("dd/MM/yyyy")}#{If(RadioButton1.Checked, "Journée-complète", "Demi-journée")}#{If(CheckBox1.Checked, "Avec-repas", "Sans-repas")}#{If(CheckBox2.Checked, "Avec-transport", "Sans-transport")}#{String.Join("/", CheckedListBox1.CheckedItems.Cast(Of String)().ToArray())}#{totalPrice}#{selectedFilePath}")
                    swParent.WriteLine($"{TextBox3.Text.ToUpper}#{TextBox4.Text.ToUpper}#{TextBox1.Text.ToUpper}#{TextBox2.Text.ToUpper}#{totalPrice}#{TextBox5.Text}#{TextBox6.Text.ToUpper}#{TextBox7.Text}")
                End Using

                MsgBox("Élève enregistré avec succès")
                initializing()

            End If
        End If
    End Sub
    Private Sub initializing()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, False)
        Next
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
    End Sub





    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub LoadImageIntoFlowLayoutPanel(imagePath As String)
        ' Create a PictureBox
        Dim pictureBox As New PictureBox()

        ' Set PictureBox properties
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom ' Adjust the size mode as needed
        pictureBox.Image = Image.FromFile(imagePath)

        ' Add the PictureBox to the FlowLayoutPanel
        FlowLayoutPanel1.Controls.Add(pictureBox)
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim openFileDialog1 As New OpenFileDialog()

        ' Set OpenFileDialog properties
        openFileDialog1.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp"
        openFileDialog1.Title = "Select an Image File"

        ' Show the dialog and check if the user selected a file
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Get the selected file's path and display the image in PictureBox
            PictureBox1.Image = Image.FromFile(openFileDialog1.FileName)
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom

            ' Save the file path to the class-level variable
            selectedFilePath = openFileDialog1.FileName
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class