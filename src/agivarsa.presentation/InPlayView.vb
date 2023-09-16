Friend Module InPlayView
    Friend Function Run(model As IWorldModel) As Boolean
        Dim done As Boolean = False
        While Not done
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine("Yer playing the game!")
            Dim prompt As New SelectionPrompt(Of String) With {.Title = NowWhatPrompt}
            prompt.AddChoice(MainMenuText)
            Select Case AnsiConsole.Prompt(prompt)
                Case MainMenuText
                    done = True
            End Select
        End While
        Return False
    End Function
End Module
