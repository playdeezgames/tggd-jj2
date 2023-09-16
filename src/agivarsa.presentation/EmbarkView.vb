Friend Module EmbarkView
    Friend Function Run(model As IWorldModel) As Boolean
        model.Start()
        InPlayView.Run(model)
        Return False
    End Function
End Module
