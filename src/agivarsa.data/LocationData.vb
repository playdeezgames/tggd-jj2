﻿Public Class LocationData
    Inherits HolderData
    Public Property CharacterIds As New HashSet(Of Integer)
    Public Property Routes As New Dictionary(Of String, RouteData)
End Class
