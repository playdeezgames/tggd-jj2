﻿Friend MustInherit Class LocationDataClient
    Inherits WorldDataClient
    Protected ReadOnly LocationId As Integer
    Public Sub New(
                  data As WorldData,
                  locationId As Integer,
                  Optional traits As Dictionary(Of String, String) = Nothing,
                  Optional statistics As Dictionary(Of String, Integer) = Nothing)
        MyBase.New(
            data,
            If(traits, data.Locations(locationId).Traits),
            If(statistics, data.Locations(locationId).Statistics))
        Me.LocationId = locationId
    End Sub
    Protected ReadOnly Property LocationData As LocationData
        Get
            Return WorldData.Locations(LocationId)
        End Get
    End Property
End Class
