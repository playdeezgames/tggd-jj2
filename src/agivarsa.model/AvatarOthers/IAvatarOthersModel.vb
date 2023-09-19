Public Interface IAvatarOthersModel
    ReadOnly Property Exist As Boolean
    ReadOnly Property HasInteractables As Boolean

    ReadOnly Property LegacyAll As IEnumerable(Of (name As String, id As String))
    ReadOnly Property LegacyInteractables As IEnumerable(Of (name As String, id As String))
    Sub LegacySetInteractionTarget(characterId As String)
    ReadOnly Property LegacyInteractionTarget As (name As String, id As String)
End Interface
