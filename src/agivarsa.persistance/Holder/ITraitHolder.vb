Public Interface ITraitHolder
    Function GetTrait(traitName As String) As String
    Sub SetTrait(traitName As String, traitValue As String)
    Function HasTrait(traitName As String) As Boolean
    Sub RemoveTrait(traitName As String)
End Interface
