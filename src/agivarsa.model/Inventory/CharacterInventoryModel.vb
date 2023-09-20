Friend Class CharacterInventoryModel
    Implements IInventoryModel

    Private ReadOnly character As ICharacter

    Public Sub New(character As ICharacter)
        Me.character = character
    End Sub

    Public ReadOnly Property Exists As Boolean Implements IInventoryModel.Exists
        Get
            Return character.HasItems
        End Get
    End Property

    Public ReadOnly Property All As IEnumerable(Of IItemStackModel) Implements IInventoryModel.All
        Get
            Return character.Items.GroupBy(Function(x) x.Name).Select(Function(x) New CharacterItemStackModel(character, x.Key))
        End Get
    End Property

    Public Function GetStack(itemName As String) As IEnumerable(Of IItemModel) Implements IInventoryModel.GetStack
        Return character.Items.Where(Function(x) x.Name = itemName).Select(Function(x) New CharacterItemModel(character, x))
    End Function
End Class
