Public Interface IAvatarModel
    ReadOnly Property Name As String
    ReadOnly Property Location As IAvatarLocationModel
    ReadOnly Property Others As IAvatarOthersModel
    Sub SetInteractionTarget(characterId As String)
    ReadOnly Property InteractionTarget As (name As String, id As String)
End Interface
