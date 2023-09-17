Imports System.Diagnostics.CodeAnalysis

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
            Return Enumerable.
                Range(0, LocationData.Routes.Count).
                Select(Function(x) New Route(WorldData, LocationId, x))
        End Get
    End Property

    Public Sub AddCharacter(character As ICharacter) Implements ILocation.AddCharacter
        LocationData.CharacterIds.Add(character.Id)
    End Sub

    Public Sub RemoveCharacter(character As ICharacter) Implements ILocation.RemoveCharacter
        LocationData.CharacterIds.Remove(character.Id)
    End Sub

    Public Function CreateRoute() As IRoute Implements ILocation.CreateRoute
        Dim routeId = LocationData.Routes.Count
        LocationData.Routes.Add(New RouteData)
        Return New Route(WorldData, LocationId, routeId)
    End Function
End Class
