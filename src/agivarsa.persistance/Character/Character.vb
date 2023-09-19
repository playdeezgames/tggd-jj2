Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter
    Public Sub New(data As WorldData, characterId As String)
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

    Public ReadOnly Property Id As String Implements ICharacter.Id
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

    Public ReadOnly Property Others As IEnumerable(Of ICharacter) Implements ICharacter.Others
        Get
            Return Location.Characters.Where(Function(other) other.Id <> Id)
        End Get
    End Property

    Public Sub AddItem(item As IItem) Implements ICharacter.AddItem
        CharacterData.ItemIds.Add(item.Id)
    End Sub
End Class
