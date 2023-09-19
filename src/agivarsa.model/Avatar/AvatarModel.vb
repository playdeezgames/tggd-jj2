﻿Friend Class AvatarModel
    Implements IAvatarModel

    Private ReadOnly world As IWorld
    Sub New(world As IWorld)
        Me.world = world
    End Sub
    Public ReadOnly Property CharacterName As String Implements IAvatarModel.CharacterName
        Get
            Return world.Avatar.Name
        End Get
    End Property

    Public ReadOnly Property LocationName As String Implements IAvatarModel.LocationName
        Get
            Return world.Avatar.Location.Name
        End Get
    End Property

    Public ReadOnly Property HasRoutes As Boolean Implements IAvatarModel.HasRoutes
        Get
            Return world.Avatar.Location.HasRoutes
        End Get
    End Property

    Public ReadOnly Property RouteNames As IEnumerable(Of String) Implements IAvatarModel.RouteNames
        Get
            Return world.Avatar.Location.Routes.Select(Function(x) x.Name)
        End Get
    End Property

    Public ReadOnly Property CanInteract As Boolean Implements IAvatarModel.CanInteract
        Get
            Return world.Avatar.Others.Any(AddressOf CharacterExtensions.CanInteract)
        End Get
    End Property

    Public ReadOnly Property HasOthers As Boolean Implements IAvatarModel.HasOthers
        Get
            Return world.Avatar.Others.Any
        End Get
    End Property

    Public ReadOnly Property OtherCharacterNames As IEnumerable(Of (name As String, id As String)) Implements IAvatarModel.OtherCharacterNames
        Get
            Return world.Avatar.Others.Select(Function(x) (x.Name, x.Id))
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

    Public Sub Move(routeName As String) Implements IAvatarModel.Move
        Dim route = world.Avatar.Location.Routes.Single(Function(x) x.Name = routeName)
        world.Avatar.Location = route.Destination
    End Sub

    Public Sub SetInteractionTarget(characterId As String) Implements IAvatarModel.SetInteractionTarget
        world.Avatar.SetTrait(InteractionCharacterIdTrait, characterId)
    End Sub
End Class
