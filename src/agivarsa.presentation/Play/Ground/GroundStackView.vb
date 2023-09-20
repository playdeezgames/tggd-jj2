Friend Module GroundStackView
    Friend Function Run(model As IWorldModel, itemName As String) As Boolean
        Dim itemStack = model.Avatar.Location.Inventory.GetStack(itemName)
        Select Case itemStack.Count
            Case 0
                MessageBox($"There are no {itemName} on the ground.")
                Return False
            Case 1
                Return GroundDetailView.Run(model, itemStack.Single)
            Case Else
                Return ShowStackMenu(model, itemStack)
        End Select
    End Function

    Private Function ShowStackMenu(model As IWorldModel, itemStack As IEnumerable(Of IItemModel)) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{itemStack.First.Name}(x{itemStack.Count})[/]"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoice(TakeAllText)
        If itemStack.Count > 2 Then
            prompt.AddChoice(TakeHalfText)
        End If
        prompt.AddChoice(TakeOneText)
        Dim table = itemStack.ToDictionary(Function(x) x.UniqueName, Function(x) x)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return False
            Case TakeAllText
                Return TakeAction.Run(model, itemStack.ToArray)
            Case TakeHalfText
                Return TakeAction.Run(model, itemStack.Take(itemStack.Count \ 2).ToArray)
            Case TakeOneText
                Return TakeAction.Run(model, itemStack.First)
            Case Else
                Return GroundDetailView.Run(model, table(answer))
        End Select
    End Function
End Module
