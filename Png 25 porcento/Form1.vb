Imports System.Drawing.Imaging
Imports System.IO.Path

Public Class Form1
    Private Args() As String = System.Environment.GetCommandLineArgs()

    Public Sub ChangeResolution(ByVal InputPath As String, ByVal OutputPath As String, ByVal Fator As Decimal)

        Dim img As New Bitmap(InputPath)
        img.GetThumbnailImage(img.Width * Fator, img.Height * Fator, Nothing, IntPtr.Zero).Save(OutputPath, img.RawFormat)

    End Sub

    Sub AbrirArquivoProgramaPadrao(ByVal Arquivo As String)
        Dim p As New System.Diagnostics.Process
        Dim s As New System.Diagnostics.ProcessStartInfo(Arquivo)
        s.UseShellExecute = True
        s.WindowStyle = ProcessWindowStyle.Normal
        p.StartInfo = s
        p.Start()
    End Sub

    Private Sub btnReduzir_Click(sender As System.Object, e As System.EventArgs) Handles btnReduzir.Click
        Dim path As String = Me.TextBox1.Text

        If Not IO.File.Exists(path) Then
            MsgBox("Arquivo não existe", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim novoPath As String = path & "." & Me.NumericUpDown1.Value & "." & Microsoft.VisualBasic.Right(path, 3)

        ChangeResolution(path, novoPath, Me.NumericUpDown1.Value / 100)

        AbrirArquivoProgramaPadrao(novoPath)

    End Sub

End Class
