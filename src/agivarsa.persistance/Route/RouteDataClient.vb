Friend Class RouteDataClient
    Inherits LocationDataClient
    Protected RouteName As String
    Public Sub New(
                  data As WorldData,
                  locationId As Integer,
                  routeName As String)
        MyBase.New(
            data,
            locationId,
            data.Locations(locationId).Routes(routeName).Traits,
            data.Locations(locationId).Routes(routeName).Statistics)
        Me.RouteName = routeName
    End Sub
End Class
