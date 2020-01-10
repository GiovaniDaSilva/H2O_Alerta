Public Class clsAlerta
    Public Sub subExibiNotificacao(ByRef parCampo As NotifyIcon, optional byval parAlertaSonoro As Boolean = false)          
        parCampo.ShowBalloonTip(500, "Água", "Lembre-se de beber água.", ToolTipIcon.Info)
        If parAlertaSonoro  then
            System.Threading.Thread.Sleep(1000)
            clsAlertaSonoro.subExecutaAlerta()
        End If
    End Sub

    Public Sub subExibiNotificacao(ByRef parCampo As NotifyIcon, ByVal parTitulo As String, ByVal parDescricao As String)
        parCampo.ShowBalloonTip(500, parTitulo, parDescricao, ToolTipIcon.Info)
    End Sub

End Class
