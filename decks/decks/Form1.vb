Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

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
End Class
