Friend Module CharacterExtensions
    Friend Function CanInteract(interactee As ICharacter) As Boolean
        Return interactee.HasTag(CanShaveTag)
    End Function
End Module
