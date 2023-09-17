Public Interface IAvatarModel
    ReadOnly Property CharacterName As String
    ReadOnly Property LocationName As String
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property RouteNames As IEnumerable(Of String)
    Sub Move(routeName As String)
End Interface
