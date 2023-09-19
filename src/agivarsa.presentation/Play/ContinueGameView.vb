Friend Module ContinueGameView
    Private ReadOnly commandTable As IReadOnlyDictionary(Of String, Func(Of IWorldModel, Boolean)) =
        New Dictionary(Of String, Func(Of IWorldModel, Boolean)) From
        {
            {MoveText, AddressOf MoveView.Run},
            {InteractText, AddressOf InteractMenuView.Run},
            {MainMenuText, AddressOf GameMenuAction.Run}
        }
    Private ReadOnly promptConditions As IReadOnlyList(Of (text As String, condition As Func(Of IWorldModel, Boolean))) =
        New List(Of (text As String, condition As Func(Of IWorldModel, Boolean))) From
        {
            (MoveText, Function(m) m.Avatar.Location.HasRoutes),
            (InteractText, Function(m) m.Avatar.Others.HasInteractables),
            (MainMenuText, Function(m) True)
        }
    Friend Function Run(model As IWorldModel) As Boolean
        Dim command As String
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Character: {model.Avatar.Name}")
            AnsiConsole.MarkupLine($"Location: {model.Avatar.Location.Name}")
            If model.Avatar.Others.Exist Then
                AnsiConsole.MarkupLine($"Others: {String.Join(", ", model.Avatar.Others.LegacyAll.Select(Function(x) x.name))}")
            End If
            If model.Avatar.Location.HasRoutes Then
                AnsiConsole.MarkupLine($"Exits: {String.Join(", ", model.Avatar.Location.Routes)}")
            End If
            command = PromptUser(NowWhatPrompt, model, promptConditions)
        Loop Until commandTable(command)(model)
        Return False
    End Function
End Module
