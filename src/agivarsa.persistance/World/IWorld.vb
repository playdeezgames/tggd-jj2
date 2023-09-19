Public Interface IWorld
    Inherits IHolder
    Function CreateLocation(name As String) As ILocation
    Function CreateCharacter(id As String, name As String, characterType As String, location As ILocation) As ICharacter
    Property Avatar As ICharacter
    Function GetCharacter(id As String) As ICharacter
End Interface
