Friend Class LocationItemModel
    Implements IItemModel
    Private ReadOnly location As ILocation
    Private ReadOnly character As ICharacter
    Private ReadOnly item As IItem

    Public Sub New(location As ILocation, character As ICharacter, item As IItem)
        Me.location = location
        Me.character = character
        Me.item = item
    End Sub

    Public ReadOnly Property Name As String Implements IItemModel.Name
        Get
            Return item.Name
        End Get
    End Property

    Public ReadOnly Property UniqueName As String Implements IItemModel.UniqueName
        Get
            Return item.Name + item.Id.ToString() + String.Join("", Enumerable.Range(0, item.Id.ToString().Length).Select(Function(x) ChrW(8)))
        End Get
    End Property

    Public Sub Drop() Implements IItemModel.Drop
        Throw New NotImplementedException("Cannot drop that which is already on the ground!")
    End Sub

    Public Sub Take() Implements IItemModel.Take
        character.AddItem(item)
        location.RemoveItem(item)
    End Sub
End Class
