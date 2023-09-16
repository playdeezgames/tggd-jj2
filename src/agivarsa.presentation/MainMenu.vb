Friend Module MainMenu
    Private ReadOnly commandTable As IReadOnlyDictionary(Of String, Func(Of IWorldModel, Boolean)) =
        New Dictionary(Of String, Func(Of IWorldModel, Boolean)) From
        {
            {AbandonGameText, AddressOf ConfirmAbandonView.Run},
            {ContinueGameText, AddressOf InPlayView.Run},
            {EmbarkText, AddressOf EmbarkView.Run},
            {LoadGameText, AddressOf LoadGameView.Run},
            {QuitText, AddressOf ConfirmQuitView.Run},
            {SaveGameText, AddressOf SaveGameView.Run}
        }
    Private ReadOnly promptConditions As IReadOnlyList(Of (text As String, condition As Func(Of IWorldModel, Boolean))) =
        New List(Of (text As String, condition As Func(Of IWorldModel, Boolean))) From
        {
            (ContinueGameText, Function(m) m.IsInPlay),
            (SaveGameText, Function(m) m.IsInPlay),
            (AbandonGameText, Function(m) m.IsInPlay),
            (EmbarkText, Function(m) Not m.IsInPlay),
            (LoadGameText, Function(m) Not m.IsInPlay),
            (QuitText, Function(m) Not m.IsInPlay)
        }
    Friend Function Run(model As IWorldModel)
        Dim command As String
        Do
            AnsiConsole.Clear()
            command = PromptUser(MainMenuTitle, model, promptConditions)
        Loop Until commandTable(command)(model)
        Return True
    End Function
End Module
