Friend Class Route
    Inherits RouteDataClient
    Implements IRoute

    Public Sub New(data As WorldData, locationId As Integer, routeName As String)
        MyBase.New(data, locationId, routeName)
    End Sub

    Public Property Destination As ILocation Implements IRoute.Destination
        Get
            If HasStatistic(DestinationLocationIdStatistic) Then
                Return New Location(WorldData, GetStatistic(DestinationLocationIdStatistic))
            End If
            Return Nothing
        End Get
        Set(value As ILocation)
            If value Is Nothing Then
                RemoveStatistic(DestinationLocationIdStatistic)
                Return
            End If
            SetStatistic(DestinationLocationIdStatistic, value.Id)
        End Set
    End Property

    Public ReadOnly Property Name As String Implements IRoute.Name
        Get
            Return RouteName
        End Get
    End Property
End Class
