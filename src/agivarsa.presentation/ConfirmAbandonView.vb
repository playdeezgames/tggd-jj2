Friend Module ConfirmAbandonView
    Friend Sub Run(model As IWorldModel)
        If Confirm(ConfirmAbandonGamePrompt) Then
            model.Abandon()
        End If
    End Sub
End Module
