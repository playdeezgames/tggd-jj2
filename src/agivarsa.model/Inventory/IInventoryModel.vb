Public Interface IInventoryModel
    ReadOnly Property Exists As Boolean
    ReadOnly Property All As IEnumerable(Of IItemStackModel)
    Function GetStack(itemName As String) As IEnumerable(Of IItemModel)
End Interface
