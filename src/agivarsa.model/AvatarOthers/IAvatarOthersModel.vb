Public Interface IAvatarOthersModel
    ReadOnly Property Exist As Boolean
    ReadOnly Property All As IEnumerable(Of (name As String, id As String))
    ReadOnly Property Interactable As IEnumerable(Of (name As String, id As String))
    ReadOnly Property HasInteractables As Boolean
    Sub SetInteractionTarget(characterId As String)
    ReadOnly Property InteractionTarget As (name As String, id As String)
End Interface
