Friend Module MainMenu
    Friend Sub Run()
        Dim done As Boolean = False
        While Not done
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With
                {
                    .Title = MainMenuTitle
                }
            prompt.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(prompt)
                Case QuitText
                    done = Confirm(ConfirmQuitPrompt)
            End Select
        End While
    End Sub
End Module
