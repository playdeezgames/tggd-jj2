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
        Dim table = itemStack.ToDictionary(Function(x) x.UniqueName, Function(x) x)
        Return False
    End Function
End Module
