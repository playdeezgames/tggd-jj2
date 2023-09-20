Friend Class Location
    Inherits LocationDataClient
    Implements ILocation
    Public Sub New(worldData As WorldData, locationId As Integer)
        MyBase.New(worldData, locationId)
    End Sub

    Public Property Name As String Implements ILocation.Name
        Get
            Return GetTrait(NameTrait)
        End Get
        Set(value As String)
            SetTrait(NameTrait, value)
        End Set
    End Property

    Public ReadOnly Property Id As Integer Implements ILocation.Id
        Get
            Return LocationId
        End Get
    End Property

    Public ReadOnly Property HasRoutes As Boolean Implements ILocation.HasRoutes
        Get
            Return LocationData.Routes.Any
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of IRoute) Implements ILocation.Routes
        Get
            Return LocationData.
                Routes.
                Keys.
                Select(Function(x) New Route(WorldData, LocationId, x))
        End Get
    End Property

    Public ReadOnly Property Characters As IEnumerable(Of ICharacter) Implements ILocation.Characters
        Get
            Return LocationData.CharacterIds.Select(Function(x) New Character(WorldData, x))
        End Get
    End Property

    Public Sub AddCharacter(character As ICharacter) Implements ILocation.AddCharacter
        LocationData.CharacterIds.Add(character.Id)
    End Sub

    Public Sub RemoveCharacter(character As ICharacter) Implements ILocation.RemoveCharacter
        LocationData.CharacterIds.Remove(character.Id)
    End Sub

    Public Sub AddItem(item As IItem) Implements ILocation.AddItem
        LocationData.ItemIds.Add(item.Id)
    End Sub

    Public Function CreateRoute(name As String, destination As ILocation) As IRoute Implements ILocation.CreateRoute
        LocationData.Routes(name) = New RouteData
        Dim result = New Route(WorldData, LocationId, name) With
            {
                .Destination = destination
            }
        Return result
    End Function
End Class
