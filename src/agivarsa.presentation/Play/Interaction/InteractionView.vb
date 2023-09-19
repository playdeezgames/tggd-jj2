Friend Module InteractionView
    Friend Function Run(model As IWorldModel) As Boolean
        Dim target = model.Avatar.Others.CurrentInteractee
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]Interact with {target.name}[/]"}
        prompt.AddChoice(NeverMindText)
        Dim interactions = target.Interactions
        prompt.AddChoices(interactions)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                model.Avatar.Others.CurrentInteractee = Nothing
                Return False
            Case Else
                Return False
        End Select
    End Function
End Module
