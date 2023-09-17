Public Interface ILocation
    Property Name As String
    ReadOnly Property Id As Integer
    Sub AddCharacter(character As ICharacter)
    Sub RemoveCharacter(character As ICharacter)
End Interface
