Public Class MotorRichFmt
    Private Rich As RichTextBox

    Public PureText As New Text.StringBuilder

    Public Sub New(xRich As RichTextBox)
        Me.Rich = xRich
    End Sub

    Class Token
        Public Lst As New List(Of Object)

        Public Tag As String
        Public ParRequired As Boolean
        Public AddMethod As Action(Of String)

        Public Sub DelLast()
            Lst.RemoveAt(Lst.Count - 1)
        End Sub

        Public ReadOnly Property Prop As Object
            Get
                Return Lst.Last
            End Get
        End Property

    End Class

    'Link
    Private LT_Link As Token =
        New Token With {.Tag = "A", .ParRequired = True, .AddMethod =
          Sub(par As String)
              .Lst.Add(par)
          End Sub}
    'Bold
    Private LT_Bold As Token =
        New Token With {.Tag = "B", .ParRequired = False, .AddMethod =
          Sub(par As String)
              .Lst.Add(True)
          End Sub}
    'Italic
    Private LT_Italic As Token =
        New Token With {.Tag = "I", .ParRequired = False, .AddMethod =
          Sub(par As String)
              .Lst.Add(True)
          End Sub}
    'Underline
    Private LT_Underline As Token =
        New Token With {.Tag = "U", .ParRequired = False, .AddMethod =
          Sub(par As String)
              .Lst.Add(True)
          End Sub}
    'Font Color
    Private LT_Color As Token =
        New Token With {.Tag = "FC", .ParRequired = True, .AddMethod =
          Sub(par As String)
              .Lst.Add(Color.FromName(par))
          End Sub}
    'Font Size
    Private LT_Size As Token =
        New Token With {.Tag = "FS", .ParRequired = True, .AddMethod =
          Sub(par As String)
              .Lst.Add(par)
          End Sub}
    'Font Name
    Private LT_Name As Token =
        New Token With {.Tag = "FN", .ParRequired = True, .AddMethod =
          Sub(par As String)
              .Lst.Add(par)
          End Sub}
    'Background Color
    Private LT_Backgound As Token =
        New Token With {.Tag = "BC", .ParRequired = True, .AddMethod =
          Sub(par As String)
              .Lst.Add(Color.FromName(par))
          End Sub}

    Private Tokens() As Token = {LT_Link, LT_Bold, LT_Italic, LT_Underline, LT_Color, LT_Size, LT_Name, LT_Backgound}

    Private Function GetStyleByValues(bBold As Boolean, bItalic As Boolean, bUnderline As Boolean) As FontStyle
        Dim fs As FontStyle = 0
        If bBold Then fs = fs Or FontStyle.Bold
        If bItalic Then fs = fs Or FontStyle.Italic
        If bUnderline Then fs = fs Or FontStyle.Underline
        Return fs
    End Function

    Private Sub InitListas()
        Dim f As Font = Rich.Font
        LT_Bold.Lst.Add(f.Bold)
        LT_Italic.Lst.Add(f.Italic)
        LT_Underline.Lst.Add(f.Underline)

        LT_Color.Lst.Add(Rich.ForeColor)
        LT_Size.Lst.Add(f.Size)
        LT_Name.Lst.Add(f.Name)

        LT_Backgound.Lst.Add(Rich.BackColor)
    End Sub

    Private Sub VerTag(tag As String)
        Dim cmd As String = Mid(tag, 2, tag.Length - 2)

        Dim Final As Boolean = cmd.StartsWith("/")
        If Final Then cmd = cmd.Remove(0, 1)

        Dim x As Integer = cmd.IndexOf(":") + 1
        Dim par As String = String.Empty

        If x > 0 Then 'Tag tem parâmetro
            par = Mid(cmd, x + 1)
            cmd = Mid(cmd, 1, x - 1)
        End If

        cmd = cmd.ToUpper
        Dim Tk = (From _tk In Tokens Where _tk.Tag = cmd).FirstOrDefault
        If Tk Is Nothing Then
            Throw New Exception("Token inválido")
        End If

        If Final Then
            Dim ult As Integer = 1
            If Tk Is LT_Link Then ult = 0
            If Tk.Lst.Count = ult Then Throw New Exception("Fechamento excedido")

            Tk.DelLast()
        Else
            If Tk.ParRequired And par = String.Empty Then
                Throw New Exception("Parâmetro requerido")
            End If

            Tk.AddMethod(par)
        End If

        If Tk Is LT_Link Then Exit Sub

        Rich.SelectionFont = New Font(
            CType(LT_Name.Prop, String),
            CType(LT_Size.Prop, Single),
            GetStyleByValues(LT_Bold.Prop, LT_Italic.Prop, LT_Underline.Prop))
        Rich.SelectionColor = LT_Color.Prop
        Rich.SelectionBackColor = LT_Backgound.Prop
    End Sub

    Public Sub DoFmt(Text As String)
        InitListas()

        While Text <> String.Empty
            Dim a As String
            Dim x As Integer

            If Text(0) = "<" Then
                'Tag
                x = Text.IndexOf(">") + 1
                If x = 0 Then Throw New Exception($"Finalizador da tag '{Text}' não encontrado")
                a = Mid(Text, 1, x)
                Text = Text.Remove(0, x)

                Try
                    VerTag(a)
                Catch ex As Exception
                    Throw New Exception($"Erro na tag {a}: {ex.Message}")
                End Try
            Else
                'Texto
                x = Text.IndexOf("<") + 1 'Localizar próxima tag
                If x = 0 Then x = Text.Length + 1
                a = Mid(Text, 1, x - 1)
                Text = Text.Remove(0, x - 1)

                a = a.Replace("&lt;", "<")
                a = a.Replace("&gt;", ">")
                                
                Rich.SelectedText = a
                
                PureText.Append(a)
            End If
        End While
    End Sub

End Class

Public Module RichHTMLFormatting

    Public Sub RichGoToEnd(Rich As RichTextBox)
        Rich.SelectionStart = Rich.TextLength
    End Sub

    Public Sub RichAddFmt(Rich As RichTextBox, Text As String, Optional AtEnd As Boolean = True)
        If AtEnd Then RichGoToEnd(Rich)

        Dim motor As New MotorRichFmt(Rich)
        motor.DoFmt(Text)
    End Sub

    Public Sub RichAddLineFmt(Rich As RichTextBox, Text As String, Optional AtEnd As Boolean = True)
        RichAddFmt(Rich, Text & Environment.NewLine, AtEnd)
    End Sub


    Public Class clsRichHTMLFmtVar
        Public StartPos As Integer
        Public Length As Integer
    End Class

    Public Function RichAddFmtVar(Rich As RichTextBox, Text As String, Optional AtEnd As Boolean = True) As clsRichHTMLFmtVar
        If AtEnd Then RichGoToEnd(Rich)

        Dim v As New clsRichHTMLFmtVar
        v.StartPos = Rich.SelectionStart
        RichAddFmt(Rich, Text, False)
        v.Length = Rich.TextLength - v.StartPos
        Return v
    End Function

    Public Sub RichSetVar(Rich As RichTextBox, Text As String, Var As clsRichHTMLFmtVar)
        Dim old_pos = Rich.SelectionStart

        Rich.SelectionStart = Var.StartPos
        Rich.SelectionLength = Var.Length

        Dim old_length = Rich.TextLength

        RichAddFmt(Rich, Text, False)

        Dim len_dif = Rich.TextLength - old_length

        Var.Length += len_dif 'Atualizar tamanho da variável

        Rich.SelectionStart = old_pos + len_dif
    End Sub

    Public Function StringToRtf(a As String) As String
        a = a.Replace("\", "\\")
        Return a
    End Function

End Module
