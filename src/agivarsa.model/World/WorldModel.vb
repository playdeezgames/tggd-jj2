Imports System.Text.Json

Public Class WorldModel
    Implements IWorldModel
    Private worldData As WorldData

    Public ReadOnly Property IsInPlay As Boolean Implements IWorldModel.IsInPlay
        Get
            Return worldData IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property Avatar As IAvatarModel Implements IWorldModel.Avatar
        Get
            Return If(IsInPlay, New AvatarModel(New World(worldData)), Nothing)
        End Get
    End Property

    Public Sub Start() Implements IWorldModel.Start
        worldData = New WorldData
        InitializeWorld(New World(worldData))
    End Sub

    Private Sub InitializeWorld(world As World)
        'overworld
        Dim overworldLocation = InitializedOverworld(world)

        Dim hutLocation = world.CreateLocation("Hut")
        hutLocation.CreateRoute("Out", overworldLocation)
        overworldLocation.CreateRoute("In", hutLocation)

        world.Avatar = world.CreateCharacter("Tagon", hutLocation)
    End Sub

    Private Function InitializedOverworld(world As World) As ILocation
        Const WorldColumns = 7
        Const WorldRows = 7
        Dim locations(WorldColumns, WorldRows) As ILocation
        For Each column In Enumerable.Range(0, WorldColumns)
            For Each row In Enumerable.Range(0, WorldRows)
                locations(column, row) = world.CreateLocation($"({column},{row})")
                locations(column, row).SetTag("Overworld")
                locations(column, row).SetStatistic("Column", column)
                locations(column, row).SetStatistic("Row", row)
                If column > 0 Then
                    locations(column, row).CreateRoute("West", locations(column - 1, row))
                    locations(column - 1, row).CreateRoute("East", locations(column, row))
                End If
                If row > 0 Then
                    locations(column, row).CreateRoute("North", locations(column, row - 1))
                    locations(column, row - 1).CreateRoute("South", locations(column, row))
                End If
            Next
        Next
        Return locations(RNG.FromRange(0, WorldColumns - 1), RNG.FromRange(0, WorldRows - 1))
    End Function

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
