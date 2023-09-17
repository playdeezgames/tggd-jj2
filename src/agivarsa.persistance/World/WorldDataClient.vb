Public MustInherit Class WorldDataClient
    Implements IHolder
    Private ReadOnly data As WorldData
    Private ReadOnly traits As Dictionary(Of String, String)
    Private ReadOnly statistics As Dictionary(Of String, Integer)
    Sub New(data As WorldData, traits As Dictionary(Of String, String), statistics As Dictionary(Of String, Integer))
        Me.data = data
        Me.traits = traits
        Me.statistics = statistics
    End Sub
    Protected ReadOnly Property WorldData As WorldData
        Get
            Return data
        End Get
    End Property

    Public Sub SetTrait(traitName As String, traitValue As String) Implements ITraitHolder.SetTrait
        traits(traitName) = traitValue
    End Sub

    Public Sub SetStatistic(statisticName As String, statisticValue As Integer) Implements IStatisticHolder.SetStatistic
        statistics(statisticName) = statisticValue
    End Sub

    Public Sub RemoveStatistic(statisticName As String) Implements IStatisticHolder.RemoveStatistic
        statistics.Remove(statisticName)
    End Sub

    Public Sub RemoveTrait(traitName As String) Implements ITraitHolder.RemoveTrait
        traits.Remove(traitName)
    End Sub

    Public Function GetTrait(traitName As String) As String Implements ITraitHolder.GetTrait
        Return traits(traitName)
    End Function

    Public Function GetStatistic(statisticName As String) As Integer Implements IStatisticHolder.GetStatistic
        Return statistics(statisticName)
    End Function

    Public Function HasStatistic(statisticName As String) As Boolean Implements IStatisticHolder.HasStatistic
        Return statistics.ContainsKey(statisticName)
    End Function

    Public Function HasTrait(traitName As String) As Boolean Implements ITraitHolder.HasTrait
        Return traits.ContainsKey(traitName)
    End Function
End Class
