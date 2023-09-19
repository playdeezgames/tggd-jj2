Public Interface IAvatarOthersModel
    ReadOnly Property Exist As Boolean
    ReadOnly Property HasInteractees As Boolean
    ReadOnly Property All As IEnumerable(Of IOtherModel)
    ReadOnly Property Interactees As IEnumerable(Of IOtherModel)
    Property CurrentInteractee As IOtherModel
End Interface
