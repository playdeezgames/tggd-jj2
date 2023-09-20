Friend Module InventoryDetailView
    Friend Function Run(model As IWorldModel, itemModel As IItemModel) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{itemModel.Name}[/]"}
        prompt.AddChoice(NeverMindText)
        Select Case AnsiConsole.Prompt(prompt)
            Case NeverMindText
                Return False
        End Select
        Return False
    End Function
End Module
