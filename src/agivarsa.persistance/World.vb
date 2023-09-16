Public Class World
    Inherits WorldDataClient
    Implements IWorld
    Public Sub New(data As WorldData)
        MyBase.New(data)
    End Sub
End Class
