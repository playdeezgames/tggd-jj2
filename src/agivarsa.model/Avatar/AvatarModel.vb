Friend Class AvatarModel
    Implements IAvatarModel

    Private ReadOnly world As IWorld
    Sub New(world As IWorld)
        Me.world = world
    End Sub
    Public ReadOnly Property Name As String Implements IAvatarModel.Name
        Get
            Return world.Avatar.Name
        End Get
    End Property

    Public ReadOnly Property CanInteract As Boolean Implements IAvatarModel.CanInteract
        Get
            Return world.Avatar.Others.Any(AddressOf CharacterExtensions.CanInteract)
        End Get
    End Property
    Public ReadOnly Property InteractableOthers As IEnumerable(Of (name As String, id As String)) Implements IAvatarModel.InteractableOthers
        Get
            Return world.
                Avatar.
                Others.
                Where(AddressOf CharacterExtensions.CanInteract).
                Select(Function(x) (x.Name, x.Id))
        End Get
    End Property

    Public ReadOnly Property InteractionTarget As (name As String, id As String) Implements IAvatarModel.InteractionTarget
        Get
            Dim id = world.Avatar.GetTrait(InteractionCharacterIdTrait)
            Return (world.GetCharacter(id).Name, id)
        End Get
    End Property

    Public ReadOnly Property Location As IAvatarLocationModel Implements IAvatarModel.Location
        Get
            Return New AvatarLocationModel(world)
        End Get
    End Property

    Public ReadOnly Property Others As IAvatarOthersModel Implements IAvatarModel.Others
        Get
            Return New AvatarOthersModel(world)
        End Get
    End Property

    Public Sub SetInteractionTarget(characterId As String) Implements IAvatarModel.SetInteractionTarget
        world.Avatar.SetTrait(InteractionCharacterIdTrait, characterId)
    End Sub
End Class
