Friend Class CharacterItemStackModel
    Implements IItemStackModel
    Private ReadOnly character As ICharacter
    Private ReadOnly itemName As String

    Public Sub New(character As ICharacter, itemName As String)
        Me.character = character
        Me.itemName = itemName
    End Sub

    Public ReadOnly Property Name As String Implements IItemStackModel.Name
        Get
            Return itemName
        End Get
    End Property

    Public ReadOnly Property Count As Integer Implements IItemStackModel.Count
        Get
            Return character.Items.Count(Function(x) x.Name = Name)
        End Get
    End Property
End Class
