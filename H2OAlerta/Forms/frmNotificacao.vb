Imports System.Drawing.Drawing2D


Public Class frmNotificacao

    Private Declare Function CreateRoundRectRgn Lib "gdi32" (ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer, ByVal X3 As Integer, ByVal Y3 As Integer) As Integer

    Private glfTopMax As Double
    Private glfTopMin As Double
    Private glfTop As Double

    Public Sub ChamaForulario(ByVal parMensagem As String, Optional ByVal parAnimacao As Boolean = False)

        'Variaveis de Controle da Animação
        glfTopMax = Screen.GetWorkingArea(Me).Height
        glfTopMin = Screen.GetWorkingArea(Me).Height - Me.Height - 25
        glfTop = glfTopMax

        'left fixo
        Me.Left = (Screen.GetWorkingArea(Me).Width - Me.Width) - 25
        
        Me.Top = IIf(parAnimacao, glfTopMax, glfTopMin)
        
        Me.Show()
        Me.Activate()
        RichAddLineFmt(textBox, "<b>" & parMensagem & "</b>")

        If parAnimacao Then
            Timer2.Interval = 5
            Timer2.Start()
        End If
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
        Dim regionHandle As IntPtr = New IntPtr(CreateRoundRectRgn(0, 0, Me.Width, Me.Height, 50, 50))
        Me.Region = Region.FromHrgn(regionHandle)
    End Sub


    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Me.Top > glfTopMin Then
            glfTop = glfTop - 0.7
            Me.Top = CInt(glfTop)
        End If
    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click        
        Me.Close()
    End Sub

    Private Sub textBox_Click(sender As Object, e As EventArgs) Handles textBox.Click
        Me.Close()
    End Sub
End Class