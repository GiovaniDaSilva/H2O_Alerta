Imports Tulpep.NotificationWindow
Imports System
Imports System.ComponentModel
imports Microsoft.VisualBasic.Devices

Public Class frmPrincipal
    Const INICIANDO = "H2O Alerta Iniciado.."
    Private glfParametros As clsParametrosIni
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExibiNotificacao.Click
        ExibeAlerta()
    End Sub

    Private Sub ExibeAlerta()

        If rbPersonalizado.Checked Then
            clsNotificacaoPersonalizada.subExecutaNotificacaoPersonalizada(glfParametros)
        Else
            clsAlerta.subExibiNotificacao(NotifyIcon1, chkAlertaSonoro.Checked)
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ExibeAlerta()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
           
        subCarregaParametros()

        subAtualizaTimer(Val(txtMinuto.Text))
        Timer1.Start()

        subExibiParametros(False)

        If glfParametros.Estilo = "W" Then
            clsAlerta.subExibiNotificacao(NotifyIcon1, "Água", INICIANDO)
        Else
            clsNotificacaoPersonalizada.subExecutaNotificacaoPersonalizada(glfParametros, INICIANDO)
        End If


    End Sub

    Private Sub subCarregaParametros()

        glfParametros = New clsIni().funCarregaIni
        chkAlertaSonoro.Checked = glfParametros.AlertaSonoro
        chkIniciarAuto.Checked = clsRegistro.subExisteRegistroAplicacao()
        txtMinuto.Text = IIf(glfParametros.Timer > 0, glfParametros.Timer, 15)
        chkAnimacao.Checked = glfParametros.Animacao
        rbPersonalizado.Checked = IIf(glfParametros.Estilo = "P", True, False)
        rbWindows.Checked = IIf(glfParametros.Estilo = "W", True, False)
        txtOpacidade.Text = glfParametros.Opacidade
        subHabiliaCampos(rbPersonalizado.Checked)
    End Sub

    Private Sub subExibiParametros(ByVal parValor As Boolean, Optional parGravaIni As Boolean = false)

        If parGravaIni Then
            If Not funGravar() Then Exit Sub
        End If


        If parValor Then
            Me.ShowIcon = True
            Me.ShowInTaskbar = True
            Me.WindowState = FormWindowState.Normal
            Me.Show()
        Else
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()                    
        End If


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


    Private Function funGravar() As Boolean
        Dim ini As New clsIni

        If Not funValidaOpacidade(Val(txtOpacidade.Text)) Then
            txtOpacidade.Focus()
            txtOpacidade.Text = glfParametros.Opacidade
            Return False
        End If


        glfParametros.AlertaSonoro = chkAlertaSonoro.Checked
        glfParametros.Timer = Val(txtMinuto.Text)
        glfParametros.Animacao = chkAnimacao.Checked
        glfParametros.Estilo = IIf(rbPersonalizado.Checked, "P", "W")
        glfParametros.Opacidade = Val(txtOpacidade.Text)
        ini.gravaArquivoini(glfParametros)
        Return True
    End Function



    Private Sub rbPersonalizado_CheckedChanged(sender As Object, e As EventArgs) Handles rbPersonalizado.CheckedChanged
        subHabiliaCampos(rbPersonalizado.Checked)
    End Sub

    Private Sub subHabiliaCampos(pAcao As Boolean)
        chkAnimacao.Enabled = pAcao
        txtOpacidade.Enabled = pAcao

        If pAcao = False Then
            chkAnimacao.Checked = False
            txtOpacidade.Text = ""
        End If

    End Sub

    Private Sub rbWindows_CheckedChanged(sender As Object, e As EventArgs) Handles rbWindows.CheckedChanged
        subHabiliaCampos(rbPersonalizado.Checked)
    End Sub

    Private Sub txtOpacidade_Leave(sender As Object, e As EventArgs) Handles txtOpacidade.Leave
        If Not funValidaOpacidade(Val(txtOpacidade.Text)) Then
            txtOpacidade.Focus()
            txtOpacidade.Text = glfParametros.Opacidade
        End If

        glfParametros.Opacidade = Val(txtOpacidade.Text)
    End Sub

    Private Function funValidaOpacidade(parValor As Integer) As Boolean
        Dim locValido As Boolean = True

        If rbWindows.Checked Then Return True

        If parValor < 1 Then
            locValido = False
        End If

        If parValor > 100 Then
            locValido = False
        End If

        If Not locValido Then
            MsgBox("Valor inválido. Digite um valor entre 1 e 100.")
        End If

        Return locValido
    End Function

    Private Sub chkAnimacao_Leave(sender As Object, e As EventArgs) Handles chkAnimacao.Leave
        glfParametros.Animacao = chkAnimacao.Checked
    End Sub

    Private Sub chkAlertaSonoro_Leave(sender As Object, e As EventArgs) Handles chkAlertaSonoro.Leave
        glfParametros.AlertaSonoro = chkAlertaSonoro.Checked
    End Sub
End Class

