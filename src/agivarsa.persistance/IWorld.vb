Public Interface IWorld
    Inherits IHolder
    Function CreateLocation() As ILocation
    Function CreateCharacter() As ICharacter
    Property Avatar As ICharacter
End Interface
