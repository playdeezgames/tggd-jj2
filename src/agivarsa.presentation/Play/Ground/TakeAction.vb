Friend Module TakeAction
    Friend Function Run(model As IWorldModel, items As IEnumerable(Of IItemModel)) As Boolean
        MessageBox($"{model.Avatar.Name} takes {items.Count} {items.First.Name}.")
        For Each item In items
            item.Take()
        Next
        Return False
    End Function
End Module
