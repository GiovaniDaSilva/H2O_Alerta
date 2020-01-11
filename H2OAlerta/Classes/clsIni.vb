Imports System.Security.Cryptography

Imports System.IO

Imports System.text

Public Class clsIni
    
    
Private Declare Auto Function GetPrivateProfileString Lib "Kernel32" ( ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer 
Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" ( ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer



    public function funCarregaIni() As clsParametrosIni 
        Dim nome_arquivo_ini As String = nomeArquivoINI()
        Dim locParametros As New clsParametrosIni 

        If Not File.Exists(nome_arquivo_ini) Then
            MsgBox("Será carregado os valores padrão do sistema.")
        End If

        locParametros.AlertaSonoro = LeArquivoINI(nome_arquivo_ini, "Geral", "AlertaSonoro", "true")
        locParametros.Timer = LeArquivoINI(nome_arquivo_ini, "Geral", "Timer", 15)
        locParametros.Animacao = LeArquivoINI(nome_arquivo_ini, "Geral", "Animacao", "true")
        Return locParametros 
    End function

    
' Usa a função GetPrivateProfileString para obter os valores

    Private Function LeArquivoINI(ByVal file_name As String, ByVal section_name As String, ByVal key_name As String, ByVal default_value As String) As String
        Const MAX_LENGTH As Integer = 500

        Dim string_builder As New StringBuilder(MAX_LENGTH)        
        GetPrivateProfileString(section_name, key_name, default_value, string_builder, MAX_LENGTH, file_name)        
        Return string_builder.ToString()        
    End Function

    public Sub gravaArquivoini(parParametros As clsParametrosIni ) 
        Dim nome_arquivo_ini As String = nomeArquivoINI()
        WritePrivateProfileString("Geral", "AlertaSonoro", parParametros.AlertaSonoro , nome_arquivo_ini)
        WritePrivateProfileString("Geral", "Timer", parParametros.Timer, nome_arquivo_ini)
        WritePrivateProfileString("Geral", "Animacao", parParametros.Animacao, nome_arquivo_ini)
    End Sub

    ' Retorna o nome do arquivo INI
    Private Function nomeArquivoINI() As String        
        Dim nome_arquivo_ini As String = Application.StartupPath 
        Return nome_arquivo_ini & "\H2O.ini"        
    End Function

End Class
