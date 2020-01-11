Public Class clsAlerta
    Public Shared Sub subExibiNotificacao(ByRef parCampo As NotifyIcon, Optional ByVal parAlertaSonoro As Boolean = False)
        parCampo.ShowBalloonTip(500, "Água", "Lembre-se de beber água.", ToolTipIcon.Info)
        If parAlertaSonoro Then
            System.Threading.Thread.Sleep(1000)
            clsAlertaSonoro.subExecutaAlerta()
        End If
    End Sub

    Public Shared Sub subExibiNotificacao(ByRef parCampo As NotifyIcon, ByVal parTitulo As String, ByVal parDescricao As String)
        parCampo.ShowBalloonTip(500, parTitulo, parDescricao, ToolTipIcon.Info)
    End Sub

End Class
