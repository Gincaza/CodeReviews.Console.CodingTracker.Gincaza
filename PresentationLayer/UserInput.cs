using Spectre.Console;

namespace PresentationLayer;

public static class UserInput
{
    public static string? GetDateTimeInput(string prompt, bool allowBack = true)
    {
        string format = Validation.GetRequiredDateTimeFormat();
        AnsiConsole.MarkupLine($"[yellow]Please enter {prompt} in format: {format}[/]");
        
        if (allowBack)
        {
            AnsiConsole.MarkupLine("[blue]Press 'B' to go back[/]");
        }
        
        while (true)
        {
            string input = AnsiConsole.Ask<string>($"{prompt}: ");
            
            if (allowBack && (input.ToUpper() == "B" || input.ToUpper() == "BACK"))
            {
                return null; // Return null to indicate user wants to go back
            }
            
            if (Validation.IsValidDateTimeFormat(input))
            {
                return input;
            }
            
            AnsiConsole.MarkupLine($"[red]Invalid format. Please use the format: {format}[/]");
        }
    }

    public static int GetMenuSelection(string title, string[] options)
    {
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .PageSize(10)
                .AddChoices(options));

        return Array.IndexOf(options, selection);
    }

    public static int? GetIntInput(string prompt, bool allowBack = true)
    {
        if (allowBack)
        {
            AnsiConsole.MarkupLine("[blue]Press 'B' to go back[/]");
        }

        while (true)
        {
            string input = AnsiConsole.Ask<string>($"{prompt}: ");

            if (allowBack && (input.ToUpper() == "B" || input.ToUpper() == "BACK"))
            {
                return null; // Return null to indicate user wants to go back
            }

            if (int.TryParse(input, out int result))
            {
                return result;
            }

            AnsiConsole.MarkupLine("[red]Invalid input. Please enter a number.[/]");
        }
    }
}