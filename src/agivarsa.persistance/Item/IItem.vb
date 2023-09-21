Public Interface IItem
    Inherits IHolder
    Property Name As String
    Property ItemType As String
    ReadOnly Property Id As Integer
End Interface
