Public Module Renderer
    Public Sub Run()
        Dim figlet As New FigletText("AGIVARSA") With
            {
                .Color = Color.Aqua,
                .Justification = Justify.Center
            }
        AnsiConsole.Write(figlet)
        AnsiConsole.WriteLine("A Game in VB.NET About Requiring Some Assembly")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = String.Empty}
        prompt.AddChoice("Quit")
        AnsiConsole.Prompt(prompt)
    End Sub
End Module
