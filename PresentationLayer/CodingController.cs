using BusinessLogicLayer;
using BusinessLogicLayer.ComunicationClasses;
using Spectre.Console;

namespace PresentationLayer
{
    public class CodingController
    {
        private readonly BLLClass _businessLogic; // Corrected the class name

        public CodingController(BLLClass businessLogic) // Corrected the class name
        {
            _businessLogic = businessLogic;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                string[] options = {
                    "Add New Coding Session",
                    "View All Coding Sessions",
                    "Delete Coding Session",
                    "Update Coding Session",
                    "Exit"
                };

                AnsiConsole.Clear();
                AnsiConsole.Write(
                    new FigletText("Coding Time Tracker")
                        .Centered()
                        .Color(Color.Blue));

                int choice = UserInput.GetMenuSelection("Select an option:", options);

                switch (choice)
                {
                    case 0:
                        AddNewCodingSession();
                        break;
                    case 1:
                        ViewAllCodingSessions();
                        break;
                    case 2:
                        DeleteCodingSession();
                        break;
                    case 3:
                        UpdateCodingSession();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }
        }

        private void AddNewCodingSession()
        {
            AnsiConsole.Clear();
            AnsiConsole.WriteLine("Add New Coding Session");
            AnsiConsole.WriteLine("=====================");

            string? startTime = UserInput.GetDateTimeInput("Start Time");
            if (startTime == null) return;

            string? endTime = UserInput.GetDateTimeInput("End Time");
            if (endTime == null) return;

            OperationResult result = _businessLogic.AddTimeRecord(startTime, endTime);

            if (result.success)
            {
                AnsiConsole.MarkupLine($"[green]{result.message}[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]{result.message}[/]");
            }

            AnsiConsole.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ViewAllCodingSessions()
        {
            var records = _businessLogic.SeeTimeRecord();

            if (records.Count == 0)
            {
                AnsiConsole.MarkupLine("[yellow]No coding sessions found.[/]");
                AnsiConsole.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            AnsiConsole.Clear();
            AnsiConsole.WriteLine("View All Coding Sessions");
            AnsiConsole.WriteLine("========================");

            var table = new Table();
            table.AddColumn("ID");
            table.AddColumn("Start Date");
            table.AddColumn("End Date");
            table.AddColumn("Total Time");

            foreach (var record in records)
            {
                table.AddRow(
                    record.Id.ToString(),
                    record.StartDate,
                    record.EndDate,
                    record.Duration
                );
            }

            AnsiConsole.Write(table);
            AnsiConsole.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DeleteCodingSession()
        {
            var records = _businessLogic.SeeTimeRecord();

            if (records.Count == 0)
            {
                AnsiConsole.MarkupLine("[yellow]No coding sessions to delete.[/]");
                AnsiConsole.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            AnsiConsole.Clear();
            AnsiConsole.WriteLine("Delete Coding Session");
            AnsiConsole.WriteLine("=====================");

            var table = new Table();
            table.AddColumn("ID");
            table.AddColumn("Start Date");
            table.AddColumn("End Date");
            table.AddColumn("Total Time");

            foreach (var record in records)
            {
                table.AddRow(
                    record.Id.ToString(),
                    record.StartDate,
                    record.EndDate,
                    record.Duration
                );
            }

            AnsiConsole.Write(table);

            int? id = UserInput.GetIntInput("Enter the ID of the session to delete");
            if (id == null) return;

            var sessionToDelete = records.FirstOrDefault(r => r.Id == id);
            if (sessionToDelete != null)
            {
                var result = _businessLogic.DeleteTimeRecord(sessionToDelete);

                if (result.success)
                {
                    AnsiConsole.MarkupLine($"[green]{result.message}[/]");
                }
                else
                {
                    AnsiConsole.MarkupLine($"[red]{result.message}[/]");
                }
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]Session with ID {id} not found.[/]");
            }

            AnsiConsole.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void UpdateCodingSession()
        {
            var records = _businessLogic.SeeTimeRecord();

            if (records.Count == 0)
            {
                AnsiConsole.MarkupLine("[yellow]No coding sessions to update.[/]");
                AnsiConsole.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            AnsiConsole.Clear();
            AnsiConsole.WriteLine("Update Coding Session");
            AnsiConsole.WriteLine("=====================");

            var table = new Table();
            table.AddColumn("ID");
            table.AddColumn("Start Date");
            table.AddColumn("End Date");
            table.AddColumn("Total Time");

            foreach (var record in records)
            {
                table.AddRow(
                    record.Id.ToString(),
                    record.StartDate,
                    record.EndDate,
                    record.Duration
                );
            }

            AnsiConsole.Write(table);

            int? id = UserInput.GetIntInput("Enter the ID of the session to update");
            if (id == null) return;

            var sessionToUpdate = records.FirstOrDefault(r => r.Id == id);
            if (sessionToUpdate != null)
            {
                string? startTime = UserInput.GetDateTimeInput("New Start Time");
                if (startTime == null) return;

                string? endTime = UserInput.GetDateTimeInput("New End Time");
                if (endTime == null) return;

                sessionToUpdate.StartDate = startTime;
                sessionToUpdate.EndDate = endTime;

                var result = _businessLogic.UpdateTimeRecord(sessionToUpdate);

                if (result.success)
                {
                    AnsiConsole.MarkupLine($"[green]{result.message}[/]");
                }
                else
                {
                    AnsiConsole.MarkupLine($"[red]{result.message}[/]");
                }
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]Session with ID {id} not found.[/]");
            }

            AnsiConsole.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}