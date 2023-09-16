Friend Module EmbarkView
    Friend Function Run(model As IWorldModel) As Boolean
        model.Start()
        ContinueGameView.Run(model)
        Return False
    End Function
End Module
