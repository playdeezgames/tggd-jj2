Public Interface IAvatarLocationModel
    ReadOnly Property LocationName As String
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property RouteNames As IEnumerable(Of String)
    Sub Move(routeName As String)
End Interface
