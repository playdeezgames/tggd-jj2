Public MustInherit Class WorldDataClient
    Private ReadOnly data As WorldData
    Sub New(data As WorldData)
        Me.data = data
    End Sub
    Protected ReadOnly Property WorldData As WorldData
        Get
            Return data
        End Get
    End Property
End Class
