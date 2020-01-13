Public Class clsAlertaSonoro

    Public Shared sub subExecutaAlerta()
        My.Computer.Audio.Play(My.Resources.Agua , AudioPlayMode.Background)             
    End sub

End Class
