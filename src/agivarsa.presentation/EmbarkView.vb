Friend Module EmbarkView
    Friend Sub Run(model As IWorldModel)
        model.Start()
        InPlayView.Run(model)
    End Sub
End Module
