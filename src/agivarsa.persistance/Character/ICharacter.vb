Public Interface ICharacter
    Inherits IHolder
    Property Name As String
    Property Location As ILocation
    ReadOnly Property Id As Integer
    Property CharacterType As String
End Interface
