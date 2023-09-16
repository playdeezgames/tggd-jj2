Public Module Runner

    Public Sub Run()
        Console.Title = GameTitle
        Dim figlet As New FigletText(GameTitle) With
            {
                .Color = Color.Aqua,
                .Justification = Justify.Center
            }
        AnsiConsole.Write(figlet)
        AnsiConsole.WriteLine(GameSubtitle)
        OkPrompt()
        MainMenu.Run(New WorldModel)
    End Sub
End Module
