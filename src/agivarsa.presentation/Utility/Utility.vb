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
    Friend Function PromptUser(title As String, model As IWorldModel, promptConditions As IReadOnlyList(Of (text As String, condition As Func(Of IWorldModel, Boolean)))) As String
        Dim command As String
        Dim prompt As New SelectionPrompt(Of String) With
                        {
                            .Title = title
                        }
        For Each promptCondition In promptConditions
            If promptCondition.condition(model) Then
                prompt.AddChoice(promptCondition.text)
            End If
        Next
        command = AnsiConsole.Prompt(prompt)
        Return command
    End Function
    Friend Sub MessageBox(ParamArray lines() As String)
        For Each line In lines
            AnsiConsole.MarkupLine(line)
        Next
        OkPrompt()
    End Sub
End Module
