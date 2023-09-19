Friend Class ItemDataClient
    Inherits WorldDataClient
    Protected ReadOnly ItemId As Integer
    Protected ReadOnly Property ItemData As ItemData
        Get
            Return WorldData.Items(ItemId)
        End Get
    End Property
    Public Sub New(data As WorldData, itemId As Integer, traits As Dictionary(Of String, String), statistics As Dictionary(Of String, Integer), tags As HashSet(Of String))
        MyBase.New(data, traits, statistics, tags)
        Me.ItemId = itemId
    End Sub
End Class
