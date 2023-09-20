Public Interface ICharacter
    Inherits IHolder
    Property Name As String
    Property Location As ILocation
    ReadOnly Property Id As String
    Property CharacterType As String
    ReadOnly Property Others As IEnumerable(Of ICharacter)
    ReadOnly Property HasItems As Boolean
    Sub AddItem(item As IItem)
    Sub RemoveItem(item As IItem)
    ReadOnly Property Items As IEnumerable(Of IItem)
End Interface
