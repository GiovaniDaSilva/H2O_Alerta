Public Class frmNotificacao    
    Private Sub frmNotificacao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 5000
        Timer1.Start
        textBox.Clear()
        RichAddLineFmt(textBox, "<b>Lembre-se de beber água.</b>")
        

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub
End Class