Friend Module MainMenu
    Friend Sub Run()
        Dim done As Boolean = False
        Dim model As IWorldModel = New WorldModel
        While Not done
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With
                {
                    .Title = MainMenuTitle
                }
            If model.IsInPlay Then
                prompt.AddChoice(ContinueGameText)
                prompt.AddChoice(AbandonGameText)
            Else
                prompt.AddChoice(EmbarkText)
                prompt.AddChoice(QuitText)
            End If
            Select Case AnsiConsole.Prompt(prompt)
                Case ContinueGameText
                    InPlayView.Run(model)
                Case AbandonGameText
                    If Confirm(ConfirmAbandonGamePrompt) Then
                        model.Abandon()
                    End If
                Case EmbarkText
                    EmbarkView.Run(model)
                Case QuitText
                    done = Confirm(ConfirmQuitPrompt)
            End Select
        End While
    End Sub
End Module
