Public Interface ICharacter
    Inherits IHolder
    Property Name As String
    Property Location As ILocation
    ReadOnly Property Id As String
    Property CharacterType As String
    ReadOnly Property Others As IEnumerable(Of ICharacter)
    Sub AddItem(item As IItem)
End Interface
