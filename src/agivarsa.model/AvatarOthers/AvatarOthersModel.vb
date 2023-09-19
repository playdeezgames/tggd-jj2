Friend Class AvatarOthersModel
    Implements IAvatarOthersModel

    Private world As IWorld

    Public Sub New(world As IWorld)
        Me.world = world
    End Sub

    Public ReadOnly Property CanInteract As Boolean Implements IAvatarOthersModel.CanInteract
        Get
            Return world.Avatar.Others.Any(AddressOf CharacterExtensions.CanInteract)
        End Get
    End Property

    Public ReadOnly Property HasOthers As Boolean Implements IAvatarOthersModel.HasOthers
        Get
            Return world.Avatar.Others.Any
        End Get
    End Property

    Public ReadOnly Property OtherCharacterNames As IEnumerable(Of (name As String, id As String)) Implements IAvatarOthersModel.OtherCharacterNames
        Get
            Return world.Avatar.Others.Select(Function(x) (x.Name, x.Id))
        End Get
    End Property

    Public ReadOnly Property InteractableOthers As IEnumerable(Of (name As String, id As String)) Implements IAvatarOthersModel.InteractableOthers
        Get
            Return world.
                Avatar.
                Others.
                Where(AddressOf CharacterExtensions.CanInteract).
                Select(Function(x) (x.Name, x.Id))
        End Get
    End Property

    Public ReadOnly Property InteractionTarget As (name As String, id As String) Implements IAvatarOthersModel.InteractionTarget
        Get
            Dim id = world.Avatar.GetTrait(InteractionCharacterIdTrait)
            Return (world.GetCharacter(id).Name, id)
        End Get
    End Property

    Public Sub SetInteractionTarget(characterId As String) Implements IAvatarOthersModel.SetInteractionTarget
        world.Avatar.SetTrait(InteractionCharacterIdTrait, characterId)
    End Sub
End Class
