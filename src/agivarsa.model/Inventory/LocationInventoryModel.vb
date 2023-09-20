Friend Class LocationInventoryModel
    Implements IInventoryModel

    Private ReadOnly location As ILocation
    Private ReadOnly character As ICharacter

    Public Sub New(location As ILocation, character As ICharacter)
        Me.location = location
        Me.character = character
    End Sub

    Public ReadOnly Property Exists As Boolean Implements IInventoryModel.Exists
        Get
            Return location.HasItems
        End Get
    End Property

    Public ReadOnly Property All As IEnumerable(Of IItemStackModel) Implements IInventoryModel.All
        Get
            Return location.Items.GroupBy(Function(x) x.Name).Select(Function(x) New LocationItemStackModel(location, x.Key))
        End Get
    End Property

    Public Function GetStack(itemName As String) As IEnumerable(Of IItemModel) Implements IInventoryModel.GetStack
        Return location.Items.Where(Function(x) x.Name = itemName).Select(Function(x) New LocationItemModel(location, character, x))
    End Function
End Class
