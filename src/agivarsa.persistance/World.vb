Public Class World
    Inherits WorldDataClient
    Implements IWorld
    Public Sub New(data As WorldData)
        MyBase.New(data, data.Traits)
    End Sub

    Public Property Avatar As ICharacter Implements IWorld.Avatar
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As ICharacter)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Function CreateLocation() As ILocation Implements IWorld.CreateLocation
        Dim locationId = WorldData.Locations.Count
        WorldData.Locations.Add(New LocationData)
        Return New Location(WorldData, locationId)
    End Function

    Public Function CreateCharacter() As ICharacter Implements IWorld.CreateCharacter
        Throw New NotImplementedException()
    End Function
End Class
