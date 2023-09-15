Public Class WorldModel
    Implements IWorldModel
    Private worldData As WorldData

    Public ReadOnly Property IsInPlay As Boolean Implements IWorldModel.IsInPlay
        Get
            Return worldData IsNot Nothing
        End Get
    End Property

    Public Sub Start() Implements IWorldModel.Start
        worldData = New WorldData
    End Sub

    Public Sub Abandon() Implements IWorldModel.Abandon
        worldData = Nothing
    End Sub
End Class
