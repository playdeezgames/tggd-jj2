Public Interface IAvatarOthersModel
    ReadOnly Property Exist As Boolean
    ReadOnly Property HasInteractables As Boolean
    ReadOnly Property All As IEnumerable(Of IOtherModel)
    ReadOnly Property Interactables As IEnumerable(Of IOtherModel)
    Property InteractionTarget As IOtherModel
End Interface
