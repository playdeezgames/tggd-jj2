Friend Module InventoryView
    Friend Function Run(model As IWorldModel) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{model.Avatar.Name}'s Inventory:[/]"}
        prompt.AddChoice(NeverMindText)
        Dim table = model.Avatar.Inventory.All.ToDictionary(Function(x) $"{x.Name}(x{x.Count})", Function(x) x.Name)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return False
            Case Else
                Return InventoryStackView.Run(model, table(answer))
        End Select
    End Function
End Module
