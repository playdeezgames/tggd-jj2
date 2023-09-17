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
End Class