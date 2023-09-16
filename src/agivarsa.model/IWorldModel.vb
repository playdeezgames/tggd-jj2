Public Interface IWorldModel
    ReadOnly Property IsInPlay As Boolean
    Sub Start()
    Sub Abandon()
    Function Load(filename As String) As Boolean
End Interface
