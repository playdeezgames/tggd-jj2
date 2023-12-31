﻿Public Interface ILocation
    Inherits IHolder
    Property Name As String
    ReadOnly Property Id As Integer
    Sub AddCharacter(character As ICharacter)
    Sub RemoveCharacter(character As ICharacter)
    Function CreateRoute(name As String, destination As ILocation) As IRoute
    Sub AddItem(item As IItem)
    Sub RemoveItem(item As IItem)
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRoute)
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
    ReadOnly Property HasItems As Boolean
    ReadOnly Property Items As IEnumerable(Of IItem)
End Interface
