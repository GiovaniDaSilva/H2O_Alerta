Imports System.Threading

Public Class clsNotificacaoPersonalizada
    Public Shared Sub subExecutaNotificacaoPersonalizada(parParametros As clsParametrosIni)

        Dim locForm As New frmNotificacao

        If parParametros.AlertaSonoro Then
            clsAlertaSonoro.subExecutaAlerta()
        End If

        locForm.Opacity = (parParametros.Opacidade / 100)

        subChamaFormulario(locForm, parParametros.Animacao)

    End Sub

    Private Shared Sub subChamaFormulario(ByRef pForm As frmNotificacao, ByVal Optional pAnimacao As Boolean = True)
        If pAnimacao Then
            subChamaFormularioComANimacao(pForm)
        Else
            subChamaFormularioSemANimacao(pForm)
        End If


    End Sub

    Private Shared Sub subChamaFormularioSemANimacao(ByRef pForm As frmNotificacao)
        '25 para deixar uma pequena distancia        
        pForm.Left = (Screen.GetWorkingArea(pForm).Width - pForm.Width) - 25
        pForm.Top = Screen.GetWorkingArea(pForm).Height - pForm.Height - 25
        pForm.Show()
    End Sub

    Private Shared Sub subChamaFormularioComANimacao(ByRef pForm As frmNotificacao)
        '25 para deixar uma pequena distancia        
        Dim locTopMax = Screen.GetWorkingArea(pForm).Height
        Dim locTopMin = Screen.GetWorkingArea(pForm).Height - pForm.Height - 25

        pForm.Left = (Screen.GetWorkingArea(pForm).Width - pForm.Width) - 25
        pForm.Top = locTopMax
        pForm.Show()

        Dim locTop As Double = locTopMax
        Do While pForm.Top > locTopMin
            locTop = locTop - 0.05
            pForm.Top = CInt(locTop)
            pForm.Refresh()
        Loop

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
