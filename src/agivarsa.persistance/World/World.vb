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

    Public Function CreateLocation(name As String) As ILocation Implements IWorld.CreateLocation
        Dim locationId = WorldData.Locations.Count
        WorldData.Locations.Add(New LocationData)
        Dim result = New Location(WorldData, locationId) With {
            .Name = name
        }
        Return result
    End Function

    Public Function CreateCharacter(name As String, location As ILocation) As ICharacter Implements IWorld.CreateCharacter
        Dim characterId = WorldData.Characters.Count
        WorldData.Characters.Add(New CharacterData)
        Dim result = New Character(WorldData, characterId) With
            {
                .Name = name,
                .Location = location
            }
        Return result
    End Function
End Class
