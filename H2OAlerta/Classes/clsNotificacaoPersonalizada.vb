Imports System.Threading

Public Class clsNotificacaoPersonalizada
    Public Shared Sub subExecutaNotificacaoPersonalizada(Optional ByVal parAlertaSonoro As Boolean = False)

        Dim locForm As New frmNotificacao

        If parAlertaSonoro Then                   
            clsAlertaSonoro.subExecutaAlerta
        End If


        '25 para deixar uma pequena distancia        
        locForm.Left = (Screen.GetWorkingArea(locForm).Width - locForm.Width) - 25
        locForm.Top = Screen.GetWorkingArea(locForm).Height - locForm.Height - 25
        locForm.Show
    End Sub
End Class
