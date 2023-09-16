Public Class World
    Inherits WorldDataClient
    Implements IWorld


    Public Sub New(data As WorldData)
        MyBase.New(
            data,
            data.Traits,
            data.Statistics)
    End Sub

    Public Property Avatar As ICharacter Implements IWorld.Avatar
        Get
            Return New Character(WorldData, GetStatistic(AvatarCharacterIdStatistic))
        End Get
        Set(value As ICharacter)
            SetStatistic(AvatarCharacterIdStatistic, value.Id)
        End Set
    End Property

    Public Function CreateLocation() As ILocation Implements IWorld.CreateLocation
        Dim locationId = WorldData.Locations.Count
        WorldData.Locations.Add(New LocationData)
        Return New Location(WorldData, locationId)
    End Function

    Public Function CreateCharacter() As ICharacter Implements IWorld.CreateCharacter
        Dim characterId = WorldData.Characters.Count
        WorldData.Characters.Add(New CharacterData)
        Return New Character(WorldData, characterId)
    End Function
End Class
