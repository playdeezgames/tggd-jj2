Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter


    Public Sub New(data As WorldData, characterId As Integer)
        MyBase.New(data, characterId)
    End Sub

    Public Property Name As String Implements ICharacter.Name
        Get
            Return GetTrait(NameTrait)
        End Get
        Set(value As String)
            SetTrait(NameTrait, value)
        End Set
    End Property

    Public Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(WorldData, GetStatistic(LocationIdStatistic))
        End Get
        Set(value As ILocation)
            SetStatistic(LocationIdStatistic, value.Id)
        End Set
    End Property
End Class
