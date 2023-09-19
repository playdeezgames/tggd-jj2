Friend Class Item
    Inherits ItemDataClient
    Implements IItem
    Public Sub New(data As WorldData, itemId As Integer)
        MyBase.New(
            data,
            itemId,
            data.Items(itemId).Traits,
            data.Items(itemId).Statistics,
            data.Items(itemId).Tags)
    End Sub

    Public Property Name As String Implements IItem.Name
        Get
            Return GetTrait(NameTrait)
        End Get
        Set(value As String)
            SetTrait(NameTrait, value)
        End Set
    End Property

    Public Property ItemType As String Implements IItem.ItemType
        Get
            Return GetTrait(ItemTypeTrait)
        End Get
        Set(value As String)
            SetTrait(ItemTypeTrait, value)
        End Set
    End Property

    Public ReadOnly Property Id As Integer Implements IItem.Id
        Get
            Return ItemId
        End Get
    End Property
End Class
