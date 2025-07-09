using Spectre.Console;

namespace PresentationLayer
{
    public static class UserInput
    {
        public static string GetDateTimeInput(string prompt)
        {
            string format = Validation.GetRequiredDateTimeFormat();
            AnsiConsole.MarkupLine($"[yellow]Please enter {prompt} in format: {format}[/]");
            
            while (true)
            {
                string input = AnsiConsole.Ask<string>($"{prompt}: ");
                
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
    }
}