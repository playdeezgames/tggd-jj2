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
                'do nothing
            Case Else
                MessageBox(target.Interact(answer))
        End Select
        model.Avatar.Others.CurrentInteractee = Nothing
        Return False
    End Function
End Module
