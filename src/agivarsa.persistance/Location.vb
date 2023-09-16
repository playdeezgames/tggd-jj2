Friend Class Location
    Inherits LocationDataClient
    Implements ILocation

    Public Sub New(worldData As WorldData, locationId As Integer)
        MyBase.New(worldData, locationId)
    End Sub

    Public Property Name As String Implements ILocation.Name
        Get
            Return GetTrait("Name")
        End Get
        Set(value As String)
            SetTrait("Name", value)
        End Set
    End Property
End Class
