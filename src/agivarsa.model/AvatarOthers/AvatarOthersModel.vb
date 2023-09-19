Friend Class AvatarOthersModel
    Implements IAvatarOthersModel

    Private world As IWorld

    Public Sub New(world As IWorld)
        Me.world = world
    End Sub

    Public ReadOnly Property HasInteractables As Boolean Implements IAvatarOthersModel.HasInteractables
        Get
            Return world.Avatar.Others.Any(AddressOf CharacterExtensions.CanInteract)
        End Get
    End Property

    Public ReadOnly Property Exist As Boolean Implements IAvatarOthersModel.Exist
        Get
            Return world.Avatar.Others.Any
        End Get
    End Property
    Public ReadOnly Property LegacyInteractables As IEnumerable(Of (name As String, id As String)) Implements IAvatarOthersModel.LegacyInteractables
        Get
            Return world.
                Avatar.
                Others.
                Where(AddressOf CharacterExtensions.CanInteract).
                Select(Function(x) (x.Name, x.Id))
        End Get
    End Property

    Public ReadOnly Property LegacyInteractionTarget As (name As String, id As String) Implements IAvatarOthersModel.LegacyInteractionTarget
        Get
            Dim id = world.Avatar.GetTrait(InteractionCharacterIdTrait)
            Return (world.GetCharacter(id).Name, id)
        End Get
    End Property

    Public ReadOnly Property All As IEnumerable(Of IOtherModel) Implements IAvatarOthersModel.All
        Get
            Return world.Avatar.Others.Select(Function(x) New OtherModel(world, x.Id))
        End Get
    End Property

    Public Sub LegacySetInteractionTarget(characterId As String) Implements IAvatarOthersModel.LegacySetInteractionTarget
        world.Avatar.SetTrait(InteractionCharacterIdTrait, characterId)
    End Sub
End Class
