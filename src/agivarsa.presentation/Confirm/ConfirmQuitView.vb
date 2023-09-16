Friend Module ConfirmQuitView
    Friend Function Run(model As IWorldModel) As Boolean
        Return Confirm(ConfirmQuitPrompt)
    End Function
End Module
