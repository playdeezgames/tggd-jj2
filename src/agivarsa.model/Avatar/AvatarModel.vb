Friend Class AvatarModel
    Implements IAvatarModel

    Private ReadOnly world As IWorld
    Sub New(world As IWorld)
        Me.world = world
    End Sub
    Public ReadOnly Property Name As String Implements IAvatarModel.Name
        Get
            Return world.Avatar.Name
        End Get
    End Property
    Public ReadOnly Property Location As IAvatarLocationModel Implements IAvatarModel.Location
        Get
            Return New AvatarLocationModel(world)
        End Get
    End Property

    Public ReadOnly Property Others As IAvatarOthersModel Implements IAvatarModel.Others
        Get
            Return New AvatarOthersModel(world)
        End Get
    End Property

    Public ReadOnly Property Inventory As IAvatarInventoryModel Implements IAvatarModel.Inventory
        Get
            Return New AvatarInventoryModel(world)
        End Get
    End Property
End Class
