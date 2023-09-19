Friend Class AvatarLocationModel
    Implements IAvatarLocationModel

    Private world As IWorld

    Public Sub New(world As IWorld)
        Me.world = world
    End Sub

    Public ReadOnly Property Name As String Implements IAvatarLocationModel.Name
        Get
            Return world.Avatar.Location.Name
        End Get
    End Property

    Public ReadOnly Property HasRoutes As Boolean Implements IAvatarLocationModel.HasRoutes
        Get
            Return world.Avatar.Location.HasRoutes
        End Get
    End Property

    Public ReadOnly Property RouteNames As IEnumerable(Of String) Implements IAvatarLocationModel.RouteNames
        Get
            Return world.Avatar.Location.Routes.Select(Function(x) x.Name)
        End Get
    End Property

    Public Sub Move(routeName As String) Implements IAvatarLocationModel.Move
        Dim route = world.Avatar.Location.Routes.Single(Function(x) x.Name = routeName)
        world.Avatar.Location = route.Destination
    End Sub
End Class
