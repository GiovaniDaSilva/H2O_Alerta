Public Class clsAlertaSonoro

    Public Shared sub subExecutaAlerta()
        My.Computer.Audio.Play(Application.StartupPath  & "\Agua.wav", AudioPlayMode.Background )
    End sub

End Class
