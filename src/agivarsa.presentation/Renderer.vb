Public Module Renderer
    Private Const GameTitle As String = "AGIVARSA"
    Private Const GameSubtitle As String = "A Game in VB.NET About Requiring Some Assembly"
    Private Const QuitText As String = "Quit"

    Public Sub Run()
        Dim figlet As New FigletText(GameTitle) With
            {
                .Color = Color.Aqua,
                .Justification = Justify.Center
            }
        AnsiConsole.Write(figlet)
        AnsiConsole.WriteLine(GameSubtitle)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = String.Empty}
        prompt.AddChoice(QuitText)
        AnsiConsole.Prompt(prompt)
    End Sub
End Module
