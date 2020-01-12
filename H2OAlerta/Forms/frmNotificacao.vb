Imports System.Drawing.Drawing2D


Public Class frmNotificacao

    Private Declare Function CreateRoundRectRgn Lib "gdi32" (ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer, ByVal X3 As Integer, ByVal Y3 As Integer) As Integer

    Public Sub ChamaForulario(ByVal parMensagem As String)
        Me.Show()

        RichAddLineFmt(textBox, "<b>" & parMensagem & "</b>")

    End Sub

    Private Sub frmNotificacao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 5000
        Timer1.Start()
        textBox.Clear()

        ArredondaCantosdoForm()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub


    ''' <summary>
    ''' Arredonda os cantos do Formulario
    ''' </summary>
    Private Sub ArredondaCantosdoForm()

        'Dim PastaGrafica As New GraphicsPath

        'Dim rect As New Rectangle(1, 1, Me.Size.Width, Me.Size.Height)
        'PastaGrafica.AddRectangle(rect)


        'Dim rES As New Rectangle(1, 1, 10, 10)
        'PastaGrafica.AddRectangle(rES)
        'PastaGrafica.AddPie(1, 1, 20, 20, 180, 90)


        'Dim rDS As New Rectangle(Me.Width - 12, 1, 12, 13)
        'PastaGrafica.AddRectangle(rDS)
        'PastaGrafica.AddPie(Me.Width - 24, 1, 24, 26, 270, 90)


        'Dim rIE As New Rectangle(1, Me.Height - 10, 10, 10)
        'PastaGrafica.AddRectangle(rIE)
        'PastaGrafica.AddPie(1, Me.Height - 20, 20, 20, 90, 90)


        'Dim rID As New Rectangle(Me.Width - 12, Me.Height - 13, 13, 13)
        'PastaGrafica.AddRectangle(rID)
        'PastaGrafica.AddPie(Me.Width - 24, Me.Height - 26, 24, 26, 0, 90)

        'PastaGrafica.SetMarkers()
        'Me.Region = New Region(PastaGrafica)


        Dim regionHandle As IntPtr = New IntPtr(CreateRoundRectRgn(0, 0, Me.Width, Me.Height, 50, 50))
        Me.Region = Region.FromHrgn(regionHandle)
    End Sub

End Class