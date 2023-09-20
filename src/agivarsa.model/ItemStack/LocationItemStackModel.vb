Friend Class LocationItemStackModel
    Implements IItemStackModel
    Private ReadOnly location As ILocation
    Private ReadOnly itemName As String

    Public Sub New(location As ILocation, itemName As String)
        Me.location = location
        Me.itemName = itemName
    End Sub

    Public ReadOnly Property Name As String Implements IItemStackModel.Name
        Get
            Return itemName
        End Get
    End Property

    Public ReadOnly Property Count As Integer Implements IItemStackModel.Count
        Get
            Return location.Items.Count(Function(x) x.Name = Name)
        End Get
    End Property
End Class
