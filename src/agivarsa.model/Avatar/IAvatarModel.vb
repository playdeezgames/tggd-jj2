Public Interface IAvatarModel
    ReadOnly Property CharacterName As String
    ReadOnly Property Location As IAvatarLocationModel
    ReadOnly Property LocationName As String
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property RouteNames As IEnumerable(Of String)
    Sub Move(routeName As String)

    ReadOnly Property HasOthers As Boolean
    ReadOnly Property OtherCharacterNames As IEnumerable(Of (name As String, id As String))
    ReadOnly Property InteractableOthers As IEnumerable(Of (name As String, id As String))
    ReadOnly Property CanInteract As Boolean
    Sub SetInteractionTarget(characterId As String)
    ReadOnly Property InteractionTarget As (name As String, id As String)
End Interface
