Friend Class RouteDataClient
    Inherits LocationDataClient
    Protected RouteId As Integer
    Public Sub New(
                  data As WorldData,
                  locationId As Integer,
                  routeId As Integer)
        MyBase.New(
            data,
            locationId,
            data.Locations(locationId).Routes(routeId).Traits,
            data.Locations(locationId).Routes(routeId).Statistics)
        Me.RouteId = routeId
    End Sub
End Class
