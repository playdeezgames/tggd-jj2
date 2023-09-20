Friend Module GroundView
    Friend Function Run(model As IWorldModel) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]On the ground:[/]"}
        prompt.AddChoice(NeverMindText)
        Dim table = model.Avatar.Location.Inventory.All.ToDictionary(Function(x) $"{x.Name}(x{x.Count})", Function(x) x.Name)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return False
            Case Else
                Return GroundStackView.Run(model, table(answer))
        End Select
    End Function
End Module
