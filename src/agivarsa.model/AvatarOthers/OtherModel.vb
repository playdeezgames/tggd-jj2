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

    Private ReadOnly Property Id As String Implements IOtherModel.Id
        Get
            Return characterId
        End Get
    End Property
End Class
