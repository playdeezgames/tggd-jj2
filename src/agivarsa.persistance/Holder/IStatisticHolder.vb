Public Interface IStatisticHolder
    Function GetStatistic(statisticName As String) As Integer
    Sub SetStatistic(statisticName As String, statisticValue As Integer)
End Interface
