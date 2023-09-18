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
            If HasStatistic(LocationIdStatistic) Then
                Return New Location(WorldData, GetStatistic(LocationIdStatistic))
            End If
            Return Nothing
        End Get
        Set(value As ILocation)
            If Location IsNot Nothing Then
                Location.RemoveCharacter(Me)
            End If
            SetStatistic(LocationIdStatistic, value.Id)
            If Location IsNot Nothing Then
                Location.AddCharacter(Me)
            End If
        End Set
    End Property

    Public ReadOnly Property Id As Integer Implements ICharacter.Id
        Get
            Return CharacterId
        End Get
    End Property

    Public Property CharacterType As String Implements ICharacter.CharacterType
        Get
            Return GetTrait(CharacterTypeTrait)
        End Get
        Set(value As String)
            SetTrait(CharacterTypeTrait, value)
        End Set
    End Property
End Class
