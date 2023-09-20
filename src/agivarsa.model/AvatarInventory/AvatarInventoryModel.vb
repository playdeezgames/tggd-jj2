Friend Class AvatarInventoryModel
    Implements IAvatarInventoryModel

    Private world As IWorld

    Public Sub New(world As IWorld)
        Me.world = world
    End Sub

    Public ReadOnly Property Exists As Boolean Implements IAvatarInventoryModel.Exists
        Get
            Return world.Avatar.HasItems
        End Get
    End Property

    Public ReadOnly Property All As IEnumerable(Of IItemStackModel) Implements IAvatarInventoryModel.All
        Get
            Return world.Avatar.Items.GroupBy(Function(x) x.Name).Select(Function(x) New ItemStackModel(world.Avatar, x.Key))
        End Get
    End Property

    Public Function GetStack(itemName As String) As IEnumerable(Of IItemModel) Implements IAvatarInventoryModel.GetStack
        Return world.Avatar.Items.Where(Function(x) x.Name = itemName).Select(Function(x) New ItemModel(world.Avatar, x))
    End Function
End Class
