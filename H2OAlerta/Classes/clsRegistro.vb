Imports Microsoft.Win32

Public Class clsRegistro

    Public Shared Sub subRegistrarAplicacaoInicializacaoWindows()
       ' dim caminho As String = "C:\_vbn\Consulta_Cep\Consulta_Cep\bin\Debug\Consulta_Cep.exe"

        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            key.SetValue(Application.ExecutablePath, """" + Application.ExecutablePath + """")
        End Using

    End Sub


    Public Shared Sub subDesregistrarAplicacaoInicializacaoWindows()
       ' dim caminho As String = "C:\_vbn\Consulta_Cep\Consulta_Cep\bin\Debug\Consulta_Cep.exe"

       Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
	        key.DeleteValue(Application.ExecutablePath, False)
       End Using

    End Sub

    Public Shared function subExisteRegistroAplicacao() As Boolean
        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
	        dim registro = key.GetValue(Application.ExecutablePath)  
            Return not registro Is Nothing 
       End Using

        Return false
    End function

    'Abrir a pasta de inicializar automaticamente windows shell:startup

End Class
