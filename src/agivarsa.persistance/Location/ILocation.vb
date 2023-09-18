Public Interface ILocation
    Inherits IHolder
    Property Name As String
    ReadOnly Property Id As Integer
    Sub AddCharacter(character As ICharacter)
    Sub RemoveCharacter(character As ICharacter)
    Function CreateRoute(name As String, destination As ILocation) As IRoute
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRoute)
End Interface
