Friend Class OtherModel
    Implements IOtherModel

    Private ReadOnly world As IWorld
    Private ReadOnly characterId As String

    Public Sub New(world As IWorld, characterId As String)
        Me.world = world
        Me.characterId = characterId
    End Sub

    Public ReadOnly Property Name As String Implements IOtherModel.Name
        Get
            Return world.GetCharacter(characterId).Name
        End Get
    End Property

    Public ReadOnly Property Interactions As IEnumerable(Of String) Implements IOtherModel.Interactions
        Get
            Dim result As New List(Of String)
            Dim character = world.GetCharacter(characterId)
            If character.HasTag(CanShaveTag) Then
                result.Add(ShaveInteraction)
            End If
            Return result
        End Get
    End Property

    Private ReadOnly Property Id As String Implements IOtherModel.Id
        Get
            Return characterId
        End Get
    End Property

    Public Function Interact(interaction As String) As String() Implements IOtherModel.Interact
        Select Case interaction
            Case ShaveInteraction
                Return Shave().ToArray
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Private Function Shave() As IEnumerable(Of String)
        Dim character = world.GetCharacter(characterId)
        If Not character.HasTag(CanShaveTag) Then
            Return New List(Of String) From
                {
                    $"{world.Avatar.Name} cannot shave {character.Name}."
                }
        End If
        character.RemoveTag(CanShaveTag)
        Dim item = world.CreateItem(YakHairName, YakHairItemType)
        world.Avatar.AddItem(item)
        Dim result = New List(Of String) From
            {
                    $"{world.Avatar.Name} shaves {character.Name}.",
                    $"{world.Avatar.Name} acquires {item.Name}."
            }
        character.Name = $"Shorn {character.Name}"
        Return result
    End Function
End Class
