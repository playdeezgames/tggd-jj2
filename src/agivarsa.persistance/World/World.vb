Public Class World
    Inherits WorldDataClient
    Implements IWorld


    Public Sub New(data As WorldData)
        MyBase.New(
            data,
            data.Traits,
            data.Statistics,
            data.Tags)
    End Sub

    Public Property Avatar As ICharacter Implements IWorld.Avatar
        Get
            Return New Character(WorldData, GetTrait(AvatarCharacterIdTrait))
        End Get
        Set(value As ICharacter)
            SetTrait(AvatarCharacterIdTrait, value.Id)
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

    Public Function CreateCharacter(id As String, name As String, characterType As String, location As ILocation) As ICharacter Implements IWorld.CreateCharacter
        If WorldData.Characters.ContainsKey(id) Then
            Throw New NotImplementedException
        End If
        WorldData.Characters(id) = New CharacterData
        Dim result = New Character(WorldData, id) With
            {
                .Name = name,
                .Location = location,
                .CharacterType = characterType
            }
        Return result
    End Function

    Public Function GetCharacter(id As String) As ICharacter Implements IWorld.GetCharacter
        If WorldData.Characters.ContainsKey(id) Then
            Return New Character(WorldData, id)
        End If
        Return Nothing
    End Function
End Class
