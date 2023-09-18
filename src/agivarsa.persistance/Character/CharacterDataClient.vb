Friend MustInherit Class CharacterDataClient
    Inherits WorldDataClient
    Protected ReadOnly CharacterId As Integer
    Public Sub New(data As WorldData, characterId As Integer)
        MyBase.New(
            data,
            data.Characters(characterId).Traits,
            data.Characters(characterId).Statistics,
            data.Characters(characterId).Tags)
        Me.CharacterId = characterId
    End Sub
    Protected ReadOnly Property CharacterData As CharacterData
        Get
            Return WorldData.Characters(CharacterId)
        End Get
    End Property
End Class
