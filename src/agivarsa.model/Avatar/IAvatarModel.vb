Public Interface IAvatarModel
    ReadOnly Property CharacterName As String
    ReadOnly Property LocationName As String
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property RouteNames As IEnumerable(Of String)
End Interface
