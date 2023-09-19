Public Interface IAvatarLocationModel
    ReadOnly Property Name As String
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of String)
    Sub Move(routeName As String)
End Interface
