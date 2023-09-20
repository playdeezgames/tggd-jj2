Friend Module DropAction
    Friend Function Run(model As IWorldModel, ParamArray items() As IItemModel) As Boolean
        MessageBox($"{model.Avatar.Name} drops {items.Count} {items.First.Name}.")
        For Each item In items
            item.Drop()
        Next
        Return False
    End Function
End Module
