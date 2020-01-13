Imports System.Threading

Public Class clsNotificacaoPersonalizada

    Const BEBER_AGUA = "Lembre-se de beber água."
    Private Shared glfMensagem As String

    Public Shared Sub subExecutaNotificacaoPersonalizada(parParametros As clsParametrosIni, Optional ByVal parMensagem As String = BEBER_AGUA)

        Dim locForm As New frmNotificacao

        If parParametros.AlertaSonoro Then
            clsAlertaSonoro.subExecutaAlerta()
        End If

        locForm.Opacity = (parParametros.Opacidade / 100)
        glfMensagem = parMensagem

        subChamaFormulario(locForm, parParametros.Animacao)

    End Sub

    Private Shared Sub subChamaFormulario(ByRef pForm As frmNotificacao, ByVal Optional pAnimacao As Boolean = True)
        pForm.ChamaForulario(glfMensagem, pAnimacao )
    End Sub
    

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
