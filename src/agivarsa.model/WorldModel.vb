Imports System.Text.Json

Public Class WorldModel
    Implements IWorldModel
    Private worldData As WorldData

    Public ReadOnly Property IsInPlay As Boolean Implements IWorldModel.IsInPlay
        Get
            Return worldData IsNot Nothing
        End Get
    End Property

    Public Sub Start() Implements IWorldModel.Start
        worldData = New WorldData
        InitializeWorld(New World(worldData))
    End Sub

    Private Sub InitializeWorld(world As World)
        Dim location = world.CreateLocation()
        location.Name = "Start"
    End Sub

    Public Sub Abandon() Implements IWorldModel.Abandon
        worldData = Nothing
    End Sub

    Public Function Load(filename As String) As Boolean Implements IWorldModel.Load
        Try
            worldData = JsonSerializer.Deserialize(Of WorldData)(System.IO.File.ReadAllText(filename))
            Return True
        Catch
            Return False
        End Try
    End Function

    Public Function Save(filename As String) As Boolean Implements IWorldModel.Save
        Try
            System.IO.File.WriteAllText(filename, JsonSerializer.Serialize(worldData))
            Return True
        Catch
            Return False
        End Try
    End Function
End Class
