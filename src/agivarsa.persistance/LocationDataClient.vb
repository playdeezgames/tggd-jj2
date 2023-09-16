Friend MustInherit Class LocationDataClient
    Inherits WorldDataClient
    Protected ReadOnly LocationId As Integer
    Public Sub New(data As WorldData, locationId As Integer)
        MyBase.New(data, data.Locations(locationId).Traits)
        Me.LocationId = locationId
    End Sub
    Protected ReadOnly Property LocationData As LocationData
        Get
            Return WorldData.Locations(LocationId)
        End Get
    End Property
End Class
