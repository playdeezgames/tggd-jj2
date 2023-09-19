Public Interface IOtherModel
    ReadOnly Property Name As String
    ReadOnly Property Id As String
    ReadOnly Property Interactions As IEnumerable(Of String)
    Function Interact(interaction As String) As String()
End Interface
