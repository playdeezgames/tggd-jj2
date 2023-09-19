Friend Module InteractionView
    Friend Function Run(model As IWorldModel) As Boolean
        Dim target = model.Avatar.InteractionTarget
        MessageBox($"{model.Avatar.CharacterName} interacts with {target.name}.")
        Return False
    End Function
End Module
