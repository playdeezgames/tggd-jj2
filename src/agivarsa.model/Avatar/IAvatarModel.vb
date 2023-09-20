Public Interface IAvatarModel
    ReadOnly Property Name As String
    ReadOnly Property Location As IAvatarLocationModel
    ReadOnly Property Others As IAvatarOthersModel
    ReadOnly Property Inventory As IInventoryModel
End Interface
