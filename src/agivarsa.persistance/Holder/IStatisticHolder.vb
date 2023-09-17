Public Interface IStatisticHolder
    Function GetStatistic(statisticName As String) As Integer
    Sub SetStatistic(statisticName As String, statisticValue As Integer)
    Function HasStatistic(statisticName As String) As Boolean
    Sub RemoveStatistic(statisticName As String)
End Interface
