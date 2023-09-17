Friend Class Route
    Inherits RouteDataClient
    Implements IRoute

    Public Sub New(data As WorldData, locationId As Integer, routeId As Integer)
        MyBase.New(data, locationId, routeId)
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

    Public Property Name As String Implements IRoute.Name
        Get
            If HasTrait(NameTrait) Then
                Return GetTrait(NameTrait)
            End If
            Return Nothing
        End Get
        Set(value As String)
            SetTrait(NameTrait, value)
        End Set
    End Property
End Class
