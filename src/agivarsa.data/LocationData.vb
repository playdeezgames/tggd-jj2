Public Class LocationData
    Inherits HolderData
    Public Property CharacterIds As New HashSet(Of String)
    Public Property Routes As New Dictionary(Of String, RouteData)
    Public Property ItemIds As New HashSet(Of Integer)
End Class
