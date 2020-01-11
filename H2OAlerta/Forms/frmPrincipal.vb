Imports Tulpep.NotificationWindow
Imports System
Imports System.ComponentModel
imports Microsoft.VisualBasic.Devices

Public Class frmPrincipal

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExibiNotificacao.Click
        ExibeAlerta()
    End Sub

    Private Sub ExibeAlerta()
        Dim locAlerta As New clsAlerta
        locAlerta.subExibiNotificacao(NotifyIcon1, chkAlertaSonoro.Checked )
        locAlerta = Nothing
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ExibeAlerta()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
           
        subCarregaParametros()

        subAtualizaTimer(Val(txtMinuto.Text))
        Timer1.Start()

        subExibiParametros(False)

        Dim locAlerta As New clsAlerta
        Try
            locAlerta.subExibiNotificacao(NotifyIcon1, "Água", "Água Alerta Iniciado..")
        Finally 
            locAlerta = Nothing
        End Try
                   
    End Sub

    Private Sub subCarregaParametros()
        Dim locParametros As clsParametrosIni = New clsIni().funCarregaIni
        chkAlertaSonoro.Checked = locParametros.AlertaSonoro
        chkIniciarAuto.Checked = clsRegistro.subExisteRegistroAplicacao()
        txtMinuto.Text = IIf(locParametros.Timer > 0, locParametros.Timer, 15)
        chkAnimacao.Checked = locParametros.Animacao
        rbPersonalizado.Checked = IIf(locParametros.Estilo = "P", True, False)
        rbWindows.Checked = IIf(locParametros.Estilo = "W", True, False)

        subHabiliaCampos(rbPersonalizado.Checked)
    End Sub

    Private Sub subExibiParametros(ByVal parValor As Boolean, Optional parGravaIni As Boolean = false)
        If parValor Then
            Me.ShowIcon = True
            Me.ShowInTaskbar = True
            Me.Show()
            Me.WindowState = FormWindowState.Normal
        Else
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()                    
        End If

        If parGravaIni Then subGravar 
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        subExibiParametros(False, True )
        subAtualizaTimer(Val(txtMinuto.Text))
    End Sub

    Private Sub SairToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        End
    End Sub

    Private Sub ParâmetrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParâmetrosToolStripMenuItem.Click
        subExibiParametros(True)
    End Sub

    Private Sub subAtualizaTimer(ByVal parValor As Short)
        Timer1.Interval = parValor * 60000
    End Sub

    ''' <summary>
    ''' Versão 1.1 - Adicionado menu de Inicializar com windows
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSobre_Click(sender As Object, e As EventArgs) Handles btnSobre.Click
        MsgBox("H2O Alerta v.1.3" + vbNewLine + "Criado por: Giovani da Silva" + vbNewLine + "E-mail: giovani-vani@hotmail.com")
    End Sub

    Private Sub chkIniciarAuto_Click(sender As Object, e As EventArgs) Handles chkIniciarAuto.Click
        If chkIniciarAuto.Checked Then
            clsRegistro.subRegistrarAplicacaoInicializacaoWindows 
        Else
            clsRegistro.subDesregistrarAplicacaoInicializacaoWindows 
        End If 
    End Sub

    
    Private sub subGravar()
        dim ini As new clsIni
        Dim parametros As New clsParametrosIni 

        parametros.AlertaSonoro = chkAlertaSonoro.Checked
        parametros.Timer = Val(txtMinuto.Text)
        parametros.Animacao = chkAnimacao.Checked
        parametros.Estilo = IIf(rbPersonalizado.Checked, "P", "W")
        ini.gravaArquivoini(parametros)
    End sub

    Private Sub btnNotificacaoPropria_Click(sender As Object, e As EventArgs) Handles btnNotificacaoPropria.Click
        clsNotificacaoPersonalizada.subExecutaNotificacaoPersonalizada(chkAlertaSonoro.Checked, chkAnimacao.Checked)
    End Sub

    Private Sub rbPersonalizado_CheckedChanged(sender As Object, e As EventArgs) Handles rbPersonalizado.CheckedChanged
        subHabiliaCampos(rbPersonalizado.Checked)
    End Sub

    Private Sub subHabiliaCampos(pAcao As Boolean)
        chkAnimacao.Enabled = pAcao

        If pAcao = False Then
            chkAnimacao.Checked = False
        End If

    End Sub

    Private Sub rbWindows_CheckedChanged(sender As Object, e As EventArgs) Handles rbWindows.CheckedChanged
        subHabiliaCampos(rbPersonalizado.Checked)
    End Sub
End Class

