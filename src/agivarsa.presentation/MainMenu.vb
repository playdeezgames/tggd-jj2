Friend Module MainMenu
    Private ReadOnly commandTable As IReadOnlyDictionary(Of String, Func(Of IWorldModel, Boolean)) =
        New Dictionary(Of String, Func(Of IWorldModel, Boolean)) From
        {
            {ContinueGameText, AddressOf InPlayView.Run},
            {AbandonGameText, AddressOf ConfirmAbandonView.Run},
            {QuitText, AddressOf ConfirmQuitView.Run},
            {EmbarkText, AddressOf EmbarkView.Run}
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
    Friend Sub Run()
        Dim model As IWorldModel = New WorldModel
        Dim command As String
        Do
            AnsiConsole.Clear()
            command = PromptUser(MainMenuTitle, model, promptConditions)
        Loop Until commandTable(command)(model)
    End Sub
End Module
