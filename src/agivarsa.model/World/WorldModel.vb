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
        Dim overworldLocation = InitializeOverworld(world)
        Dim hutLocation As ILocation = InitializeHut(world, overworldLocation)
        world.Avatar = InitializeAvatar(world, hutLocation)
    End Sub

    Private Shared Function InitializeAvatar(world As World, hutLocation As ILocation) As ICharacter
        Return world.CreateCharacter("avatar", "Tagon", AvatarCharacterType, hutLocation)
    End Function

    Private Shared Function InitializeHut(world As World, overworldLocation As ILocation) As ILocation
        Dim hutLocation = world.CreateLocation("Hut")
        hutLocation.CreateRoute("Out", overworldLocation)
        overworldLocation.CreateRoute("In", hutLocation)
        Return hutLocation
    End Function

    Private Function InitializeOverworld(world As World) As ILocation
        Dim locations(WorldColumns, WorldRows) As ILocation
        For Each column In Enumerable.Range(0, WorldColumns)
            For Each row In Enumerable.Range(0, WorldRows)
                locations(column, row) = world.CreateLocation($"({column},{row})")
                locations(column, row).SetTag(OverworldTag)
                locations(column, row).SetStatistic(ColumnStatistic, column)
                locations(column, row).SetStatistic(RowStatistic, row)
                If column > 0 Then
                    locations(column, row).CreateRoute(WestDirection, locations(column - 1, row))
                    locations(column - 1, row).CreateRoute(EastDirection, locations(column, row))
                End If
                If row > 0 Then
                    locations(column, row).CreateRoute(NorthDirection, locations(column, row - 1))
                    locations(column, row - 1).CreateRoute(SouthDirection, locations(column, row))
                End If
            Next
        Next
        InitializeYak(world, locations)
        InitializeShears(world, locations)
        Return locations(RNG.FromRange(0, WorldColumns - 1), RNG.FromRange(0, WorldRows - 1))
    End Function

    Private Sub InitializeShears(world As World, locations(,) As ILocation)
        Dim item = world.CreateItem("Shears", ShearsItemType)
        item.SetTag(CanShaveTag)
        locations(
            RNG.FromRange(0, WorldColumns - 1),
            RNG.FromRange(0, WorldRows - 1)).
                AddItem(Item)
    End Sub

    Private Shared Sub InitializeYak(world As World, locations(,) As ILocation)
        Dim yak = world.CreateCharacter("yak", "Yak", YakCharacterType, locations(RNG.FromRange(0, WorldColumns - 1), RNG.FromRange(0, WorldRows - 1)))
        yak.SetTag(CanShaveTag)
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
