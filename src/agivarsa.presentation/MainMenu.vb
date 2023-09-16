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
            command = PromptUser(MainMenuTitle, model)
        Loop Until commandTable(command)(model)
    End Sub

    Private Function PromptUser(title As String, model As IWorldModel) As String
        Dim command As String
        Dim prompt As New SelectionPrompt(Of String) With
                        {
                            .Title = title
                        }
        For Each promptCondition In promptConditions
            If promptCondition.condition(model) Then
                prompt.AddChoice(promptCondition.text)
            End If
        Next
        command = AnsiConsole.Prompt(prompt)
        Return command
    End Function
End Module
