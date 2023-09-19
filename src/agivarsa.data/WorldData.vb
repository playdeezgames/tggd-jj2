Imports System.Xml

Public Class WorldData
    Inherits HolderData
    Public Property Locations As New List(Of LocationData)
    Public Property Characters As New Dictionary(Of String, CharacterData)
    Public Property Items As New List(Of ItemData)
End Class
