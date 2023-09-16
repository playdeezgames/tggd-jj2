Public MustInherit Class WorldDataClient
    Implements IHolder
    Private ReadOnly data As WorldData
    Private ReadOnly traits As Dictionary(Of String, String)
    Sub New(data As WorldData, traits As Dictionary(Of String, String))
        Me.data = data
        Me.traits = traits
    End Sub
    Protected ReadOnly Property WorldData As WorldData
        Get
            Return data
        End Get
    End Property

    Public Sub SetTrait(traitName As String, traitValue As String) Implements ITraitHolder.SetTrait
        traits(traitName) = traitValue
    End Sub

    Public Function GetTrait(traitName As String) As String Implements ITraitHolder.GetTrait
        Return traits(traitName)
    End Function
End Class
