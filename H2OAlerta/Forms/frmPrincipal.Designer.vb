<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ParâmetrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExibiNotificacao = New System.Windows.Forms.Button()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMinuto = New System.Windows.Forms.MaskedTextBox()
        Me.btnSobre = New System.Windows.Forms.Button()
        Me.chkIniciarAuto = New System.Windows.Forms.CheckBox()
        Me.chkAlertaSonoro = New System.Windows.Forms.CheckBox()
        Me.btnNotificacaoPropria = New System.Windows.Forms.Button()
        Me.chkAnimacao = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbWindows = New System.Windows.Forms.RadioButton()
        Me.rbPersonalizado = New System.Windows.Forms.RadioButton()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "H2O Alerta"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParâmetrosToolStripMenuItem, Me.ToolStripMenuItem1, Me.SairToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(135, 54)
        '
        'ParâmetrosToolStripMenuItem
        '
        Me.ParâmetrosToolStripMenuItem.Name = "ParâmetrosToolStripMenuItem"
        Me.ParâmetrosToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.ParâmetrosToolStripMenuItem.Text = "Parâmetros"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(131, 6)
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'btnExibiNotificacao
        '
        Me.btnExibiNotificacao.Location = New System.Drawing.Point(6, 208)
        Me.btnExibiNotificacao.Name = "btnExibiNotificacao"
        Me.btnExibiNotificacao.Size = New System.Drawing.Size(101, 23)
        Me.btnExibiNotificacao.TabIndex = 1
        Me.btnExibiNotificacao.Text = "Exibi Notificação"
        Me.btnExibiNotificacao.UseVisualStyleBackColor = True
        '
        'btnSair
        '
        Me.btnSair.Location = New System.Drawing.Point(385, 208)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(75, 23)
        Me.btnSair.TabIndex = 2
        Me.btnSair.Text = "Sair"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tempo entre as notificações:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "minutos"
        '
        'txtMinuto
        '
        Me.txtMinuto.Location = New System.Drawing.Point(162, 18)
        Me.txtMinuto.Mask = "999"
        Me.txtMinuto.Name = "txtMinuto"
        Me.txtMinuto.Size = New System.Drawing.Size(27, 20)
        Me.txtMinuto.TabIndex = 6
        '
        'btnSobre
        '
        Me.btnSobre.Location = New System.Drawing.Point(385, 12)
        Me.btnSobre.Name = "btnSobre"
        Me.btnSobre.Size = New System.Drawing.Size(75, 23)
        Me.btnSobre.TabIndex = 7
        Me.btnSobre.Text = "Sobre"
        Me.btnSobre.UseVisualStyleBackColor = True
        '
        'chkIniciarAuto
        '
        Me.chkIniciarAuto.AutoSize = True
        Me.chkIniciarAuto.Location = New System.Drawing.Point(15, 147)
        Me.chkIniciarAuto.Name = "chkIniciarAuto"
        Me.chkIniciarAuto.Size = New System.Drawing.Size(214, 17)
        Me.chkIniciarAuto.TabIndex = 8
        Me.chkIniciarAuto.Text = "Iniciar automaticamente com o windows"
        Me.chkIniciarAuto.UseVisualStyleBackColor = True
        '
        'chkAlertaSonoro
        '
        Me.chkAlertaSonoro.AutoSize = True
        Me.chkAlertaSonoro.Location = New System.Drawing.Point(15, 101)
        Me.chkAlertaSonoro.Name = "chkAlertaSonoro"
        Me.chkAlertaSonoro.Size = New System.Drawing.Size(261, 17)
        Me.chkAlertaSonoro.TabIndex = 9
        Me.chkAlertaSonoro.Text = "Executar alerta sonoro (Água derramada no copo)"
        Me.chkAlertaSonoro.UseVisualStyleBackColor = True
        '
        'btnNotificacaoPropria
        '
        Me.btnNotificacaoPropria.Location = New System.Drawing.Point(113, 208)
        Me.btnNotificacaoPropria.Name = "btnNotificacaoPropria"
        Me.btnNotificacaoPropria.Size = New System.Drawing.Size(142, 23)
        Me.btnNotificacaoPropria.TabIndex = 10
        Me.btnNotificacaoPropria.Text = "Notificação Personalizada"
        Me.btnNotificacaoPropria.UseVisualStyleBackColor = True
        '
        'chkAnimacao
        '
        Me.chkAnimacao.AutoSize = True
        Me.chkAnimacao.Location = New System.Drawing.Point(15, 124)
        Me.chkAnimacao.Name = "chkAnimacao"
        Me.chkAnimacao.Size = New System.Drawing.Size(117, 17)
        Me.chkAnimacao.TabIndex = 11
        Me.chkAnimacao.Text = "Executar animação"
        Me.chkAnimacao.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbPersonalizado)
        Me.GroupBox1.Controls.Add(Me.rbWindows)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(261, 51)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estilo"
        '
        'rbWindows
        '
        Me.rbWindows.AutoSize = True
        Me.rbWindows.Location = New System.Drawing.Point(27, 19)
        Me.rbWindows.Name = "rbWindows"
        Me.rbWindows.Size = New System.Drawing.Size(69, 17)
        Me.rbWindows.TabIndex = 14
        Me.rbWindows.Text = "Windows"
        Me.rbWindows.UseVisualStyleBackColor = True
        '
        'rbPersonalizado
        '
        Me.rbPersonalizado.AutoSize = True
        Me.rbPersonalizado.Checked = True
        Me.rbPersonalizado.Location = New System.Drawing.Point(124, 19)
        Me.rbPersonalizado.Name = "rbPersonalizado"
        Me.rbPersonalizado.Size = New System.Drawing.Size(91, 17)
        Me.rbPersonalizado.TabIndex = 15
        Me.rbPersonalizado.TabStop = True
        Me.rbPersonalizado.Text = "Personalizado"
        Me.rbPersonalizado.UseVisualStyleBackColor = True
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(472, 243)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkAnimacao)
        Me.Controls.Add(Me.btnNotificacaoPropria)
        Me.Controls.Add(Me.chkAlertaSonoro)
        Me.Controls.Add(Me.chkIniciarAuto)
        Me.Controls.Add(Me.btnSobre)
        Me.Controls.Add(Me.txtMinuto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.btnExibiNotificacao)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrincipal"
        Me.Text = "H2O Alerta"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ParâmetrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents SairToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnExibiNotificacao As Button
    Friend WithEvents btnSair As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMinuto As MaskedTextBox
    Friend WithEvents btnSobre As Button
    Friend WithEvents chkIniciarAuto As CheckBox
    Friend WithEvents chkAlertaSonoro As CheckBox
    Friend WithEvents btnNotificacaoPropria As Button
    Friend WithEvents chkAnimacao As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbPersonalizado As RadioButton
    Friend WithEvents rbWindows As RadioButton
End Class
