Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Public Class Form4
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim test As Boolean = False
        Dim filePathPersonnel As String = "C:\Users\Khalil\Desktop\Project\bin\personnel.txt"

        Dim currentDate As Date = Date.Now
        Dim minDate As Date = currentDate.AddYears(-50)
        Dim maxDate As Date = currentDate.AddYears(-18)
        Dim enteredDate As Date = DateTimePicker1.Value


        If TextBox1.Text = "" OrElse TextBox2.Text = "" Then
            MsgBox("Veuillez remplir le nom et le prénom.")
        ElseIf enteredDate < minDate OrElse enteredDate > maxDate Then
            MsgBox("L'âge doit être entre 18 et 50 ans.")
        ElseIf TextBox3.Text.Length <> 8 OrElse Not IsNumeric(TextBox3.Text) Then
            MsgBox("Veuillez entrer un CIN valide de 8 chiffres.")
        ElseIf TextBox4.Text.Length <> 8 OrElse Not IsNumeric(TextBox4.Text) Then
            MsgBox("Numero de telephone non valide")
        ElseIf TextBox5.Text = "" Then
            MsgBox("Veuillez saisir un salaire")
        ElseIf ComboBox1.SelectedIndex = -1 Then
            MsgBox("Veuillez sélectionner un poste")

        Else
            Using sr As New StreamReader(filePathPersonnel)
            While sr.Peek > -1
                Dim line As String = sr.ReadLine()
                Dim t() As String = line.Split("#")

                If TextBox1.Text.ToUpper = t(0) AndAlso TextBox2.Text.ToUpper = t(1) AndAlso TextBox3.Text.ToUpper = t(2) AndAlso TextBox4.Text.ToUpper = t(3) Then
                    test = True
                    Exit While
                End If
            End While
        End Using

            If test Then
                MsgBox("Le compte existe déjà.")
                initializing()
                Exit Sub
            Else

                Using swPersonnel As New StreamWriter(filePathPersonnel, True)

                    swPersonnel.WriteLine($"{TextBox1.Text.ToUpper}#{TextBox2.Text.ToUpper}#{enteredDate.ToString("dd/MM/yyyy")}#{TextBox3.Text}#{TextBox4.Text}#{ComboBox1.SelectedItem.ToString()}#{TextBox5.Text}")
                End Using
                MsgBox("personnel avec succès")
                initializing()
            End If
        End If
    End Sub
    Private Sub initializing()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form7.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class