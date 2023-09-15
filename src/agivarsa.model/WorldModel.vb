Public Class WorldModel
    Implements IWorldModel

    Public ReadOnly Property IsInPlay As Boolean Implements IWorldModel.IsInPlay
        Get
            Return False
        End Get
    End Property
End Class
