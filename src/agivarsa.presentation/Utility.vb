Friend Module Utility
    Friend Sub OkPrompt()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = String.Empty}
        prompt.AddChoice(Constants.OkText)
        AnsiConsole.Prompt(prompt)
    End Sub
    Friend Function Confirm(text As String) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = text}
        prompt.AddChoices(Constants.NoText, Constants.YesText)
        Return AnsiConsole.Prompt(prompt) = YesText
    End Function
End Module
