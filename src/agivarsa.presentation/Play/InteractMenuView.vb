Friend Module InteractMenuView

    Friend Function Run(model As IWorldModel) As Boolean
        Dim interactableCharacters = model.Avatar.Others.Interactable
        Select Case interactableCharacters.Count
            Case 0
                Return NoInteractableCharacter(model)
            Case 1
                Return InteractWith(model, interactableCharacters.Single.id)
            Case Else
                Return ChooseInteractable(model, interactableCharacters)
        End Select
    End Function

    Private Function ChooseInteractable(model As IWorldModel, otherCharacters As IEnumerable(Of (name As String, id As String))) As Boolean
        Dim table = otherCharacters.ToDictionary(AddressOf ObfuscateCharacter, Function(x) x.id)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = InteractWithPrompt}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoices(table.Keys.ToArray)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return False
            Case Else
                Return InteractWith(model, table(answer))
        End Select
    End Function

    Private Function InteractWith(model As IWorldModel, otherCharacterId As String) As Boolean
        model.Avatar.Others.SetInteractionTarget(otherCharacterId)
        Return InteractionView.Run(model)
    End Function

    Private Function NoInteractableCharacter(model As IWorldModel) As Boolean
        MessageBox(NoCharacterToInteractWithMessage)
        Return False
    End Function
End Module
