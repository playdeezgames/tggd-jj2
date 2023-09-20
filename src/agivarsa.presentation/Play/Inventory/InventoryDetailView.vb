Friend Module InventoryDetailView
    Friend Function Run(model As IWorldModel, itemModel As IItemModel) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{itemModel.Name}[/]"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoice(DropText)
        Select Case AnsiConsole.Prompt(prompt)
            Case NeverMindText
                Return False
            Case DropText
                DropAction.Run(model, itemModel)
        End Select
        Return False
    End Function
End Module
