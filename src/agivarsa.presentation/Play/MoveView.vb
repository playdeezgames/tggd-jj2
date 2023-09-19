Friend Module MoveView

    Friend Function Run(model As IWorldModel) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = MoveWhichWayPrompt}
        prompt.AddChoice(NeverMindText)
        For Each routeName In model.Avatar.Location.Routes
            prompt.AddChoice(routeName)
        Next
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                Return False
            Case Else
                model.Avatar.Location.Move(answer)
                Return False
        End Select
    End Function
End Module
