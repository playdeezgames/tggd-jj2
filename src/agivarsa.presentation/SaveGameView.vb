Friend Module SaveGameView
    Friend Function Run(model As IWorldModel) As Boolean
        Dim filename = AnsiConsole.Ask(Of String)(FilenamePrompt, String.Empty)
        If Not String.IsNullOrEmpty(filename) Then
            If model.Save(filename) Then
                MessageBox(GameSavedMessage)
            Else
                MessageBox(FailedSaveMessage)
            End If
        Else
            MessageBox(CancelSaveMessage)
        End If
        Return False
    End Function
End Module
