Friend Class AvatarModel
    Implements IAvatarModel
    Private ReadOnly world As IWorld
    Sub New(world As IWorld)
        Me.world = world
    End Sub
    Public ReadOnly Property CharacterName As String Implements IAvatarModel.CharacterName
        Get
            Return world.Avatar.Name
        End Get
    End Property

    Public ReadOnly Property LocationName As String Implements IAvatarModel.LocationName
        Get
            Return world.Avatar.Location.Name
        End Get
    End Property

    Public ReadOnly Property HasRoutes As Boolean Implements IAvatarModel.HasRoutes
        Get
            Return world.Avatar.Location.HasRoutes
        End Get
    End Property

    Public ReadOnly Property RouteNames As IEnumerable(Of String) Implements IAvatarModel.RouteNames
        Get
            Return world.Avatar.Location.Routes.Select(Function(x) x.Name)
        End Get
    End Property
End Class
