Friend Class ItemModel
    Implements IItemModel
    Private ReadOnly character As ICharacter
    Private ReadOnly item As IItem

    Public Sub New(character As ICharacter, item As IItem)
        Me.character = character
        Me.item = item
    End Sub

    Public ReadOnly Property Name As String Implements IItemModel.Name
        Get
            Return Item.Name
        End Get
    End Property

    Public ReadOnly Property UniqueName As String Implements IItemModel.UniqueName
        Get
            Return item.Name + item.Id.ToString() + String.Join("", Enumerable.Range(0, item.Id.ToString().Length).Select(Function(x) ChrW(8)))
        End Get
    End Property
End Class
