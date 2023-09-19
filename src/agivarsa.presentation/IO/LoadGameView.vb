Friend Module LoadGameView
    Friend Function Run(model As IWorldModel) As Boolean
        Dim filename = AnsiConsole.Ask(Of String)(FilenamePrompt, String.Empty)
        If Not String.IsNullOrEmpty(filename) Then
            If model.Load(filename) Then
                MessageBox(GameLoadedMessage)
                Return ContinueGameView.Run(model)
            Else
                MessageBox(FailedLoadMessage)
            End If
        Else
            MessageBox(CancelLoadMessage)
        End If
        Return False
    End Function
End Module
