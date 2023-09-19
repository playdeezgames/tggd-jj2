Public Interface IAvatarOthersModel
    ReadOnly Property Exist As Boolean
    ReadOnly Property HasInteractables As Boolean
    ReadOnly Property All As IEnumerable(Of IOtherModel)
    ReadOnly Property Interactables As IEnumerable(Of IOtherModel)
    Sub LegacySetInteractionTarget(characterId As String)
    ReadOnly Property LegacyInteractionTarget As (name As String, id As String)
End Interface
