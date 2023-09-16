Friend Module ConfirmAbandonView
    Friend Function Run(model As IWorldModel) As Boolean
        If Confirm(ConfirmAbandonGamePrompt) Then
            model.Abandon()
        End If
        Return False
    End Function
End Module
