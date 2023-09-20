Public Interface IItemModel
    ReadOnly Property Name As String
    ReadOnly Property UniqueName As String
    Sub Drop()
    Sub Take()
End Interface
