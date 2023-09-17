Public Interface IWorld
    Inherits IHolder
    Function CreateLocation(name As String) As ILocation
    Function CreateCharacter(name As String, location As ILocation) As ICharacter
    Property Avatar As ICharacter
End Interface
