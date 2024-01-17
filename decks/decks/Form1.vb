Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates

Public Class Form1
    Dim records(50) As String
    Dim COUNT As Integer
    Dim CURRENT As Integer
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        field1.Text = ""
        field2.Text = ""
        field3.Text = ""
        field4.Text = ""
        field5.Text = ""
        PictureBox1.Image = Nothing
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim outfile As New IO.StreamWriter("data.txt")
        outfile.Write(field1.Text)
        outfile.Write("|")
        outfile.Write(field2.Text)
        outfile.Write("|")
        outfile.Write(field3.Text)
        outfile.Write("|")
        outfile.Write(field4.Text)
        outfile.Write("|")
        outfile.Write(field5.Text)
        outfile.Write("|")
        outfile.WriteLine(PictureBox1.ImageLocation)
        outfile.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox1.Load(OpenFileDialog1.FileName)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists("data.txt") Then
            Dim infile As New StreamReader("data.txt")
            While Not infile.EndOfStream
                records(COUNT) = infile.ReadLine
                COUNT = COUNT + 1
            End While
            infile.Close()
            showrecord(0)
        End If

    End Sub
    Public Sub showrecord(index As Integer)
        Dim feilds() As String
        If records(index) <> Nothing Then

            feilds = records(index).Split("|")
        field1.Text = feilds(0)
        field2.Text = feilds(1)
        field3.Text = feilds(2)
        field4.Text = feilds(3)
        field5.Text = feilds(4)
        If File.Exists(feilds(5)) Then
            PictureBox1.Load(feilds(5))
        End If
        End If
    End Sub

    Private Sub first_Click(sender As Object, e As EventArgs) Handles first.Click
        CURRENT = 0
        showrecord(CURRENT)
    End Sub

    Private Sub last_Click(sender As Object, e As EventArgs) Handles last.Click
        CURRENT = COUNT - 1
        showrecord(CURRENT)
    End Sub

    Private Sub previous_Click(sender As Object, e As EventArgs) Handles previous.Click
        If CURRENT > 0 Then
            CURRENT = CURRENT - 1
            showrecord(CURRENT)

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CURRENT < COUNT - 1 Then
            CURRENT = CURRENT + 1
            showrecord(CURRENT)
        End If
    End Sub
End Class
