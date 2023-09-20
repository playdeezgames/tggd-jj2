Friend Module InventoryStackView

    Friend Function Run(model As IWorldModel, itemName As String) As Boolean
        Dim itemStack = model.Avatar.Inventory.GetStack(itemName)
        Select Case itemStack.Count
            Case 0
                MessageBox($"{model.Avatar.Name} doesn't have any {itemName}.")
                Return False
            Case 1
                Return InventoryDetailView.Run(model, itemStack.Single)
            Case Else
                Return ShowStackMenu(model, itemStack)
        End Select
    End Function

    Private Function ShowStackMenu(model As IWorldModel, itemStack As IEnumerable(Of IItemModel)) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{itemStack.First.Name}(x{itemStack.Count})[/]"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoice(DropAllText)
        If itemStack.Count > 2 Then
            prompt.AddChoice(DropHalfText)
        End If
        Dim table = itemStack.ToDictionary(Function(x) x.UniqueName, Function(x) x)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return False
            Case DropAllText
                Return Drop(model, itemStack)
            Case DropHalfText
                Return Drop(model, itemStack.Take(itemStack.Count \ 2))
            Case Else
                Return InventoryDetailView.Run(model, table(answer))
        End Select
    End Function

    Private Function Drop(model As IWorldModel, itemStack As IEnumerable(Of IItemModel)) As Boolean
        MessageBox($"{model.Avatar.Name} drops {itemStack.Count} {itemStack.First.Name}.")
        For Each item In itemStack
            item.Drop()
        Next
        Return False
    End Function
End Module
