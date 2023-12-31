﻿Public Interface IWorld
    Inherits IHolder
    Function CreateLocation(name As String) As ILocation
    Function CreateCharacter(id As String, name As String, characterType As String, location As ILocation) As ICharacter
    Function CreateItem(name As String, itemType As String) As IItem
    Property Avatar As ICharacter
    Function GetCharacter(id As String) As ICharacter
End Interface
