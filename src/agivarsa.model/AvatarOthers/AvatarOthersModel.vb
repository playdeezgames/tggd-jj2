Friend Class AvatarOthersModel
    Implements IAvatarOthersModel

    Private world As IWorld

    Public Sub New(world As IWorld)
        Me.world = world
    End Sub

    Public ReadOnly Property HasInteractees As Boolean Implements IAvatarOthersModel.HasInteractees
        Get
            Return world.Avatar.Others.Any(AddressOf CharacterExtensions.CanInteract)
        End Get
    End Property

    Public ReadOnly Property Exist As Boolean Implements IAvatarOthersModel.Exist
        Get
            Return world.Avatar.Others.Any
        End Get
    End Property
    Public ReadOnly Property All As IEnumerable(Of IOtherModel) Implements IAvatarOthersModel.All
        Get
            Return world.Avatar.Others.Select(Function(x) New OtherModel(world, x.Id))
        End Get
    End Property

    Public ReadOnly Property Interactees As IEnumerable(Of IOtherModel) Implements IAvatarOthersModel.Interactees
        Get
            Return world.
                Avatar.
                Others.
                Where(AddressOf CharacterExtensions.CanInteract).
                Select(Function(x) New OtherModel(world, x.Id))
        End Get
    End Property

    Public Property CurrentInteractee As IOtherModel Implements IAvatarOthersModel.CurrentInteractee
        Get
            If world.Avatar.HasTrait(InteractionCharacterIdTrait) Then
                Return New OtherModel(world, world.Avatar.GetTrait(InteractionCharacterIdTrait))
            End If
            Return Nothing
        End Get
        Set(value As IOtherModel)
            If value IsNot Nothing Then
                world.Avatar.SetTrait(InteractionCharacterIdTrait, value.Id)
            Else
                world.Avatar.RemoveTrait(InteractionCharacterIdTrait)
            End If
        End Set
    End Property
End Class
