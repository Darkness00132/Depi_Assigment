using Spectre.Console;

namespace Depi_Assigment
{
    public static class ColoredConsole
    {
        public static void WelcomeMessage()
        {
            AnsiConsole.MarkupLine("[bold Gray100]Welcome to our bank[/]!");

            AnsiConsole.WriteLine();

            var tableOfServices = new Table()
                .Border(TableBorder.Rounded)
                .BorderColor(Color.Gray100)
                .AddColumn("[bold]Service[/]")
                .AddColumn("[bold]Command[/]");

            tableOfServices
                .AddRow("[bold]Account Information[/]", "[cyan]info[/]")
                .AddRow("[bold]Create Account[/]", "[green]create[/]")
                .AddRow("[bold]Check Balance[/]", "[cyan]balance[/]")
                .AddRow("[bold]Withdraw[/]", "[red]withdraw[/]")
                .AddRow("[bold]Deposit[/]", "[green]deposit[/]");

            AnsiConsole.Write(tableOfServices);
            AnsiConsole.WriteLine();
        }

        public static void WriteLine(string message="")
        {
            AnsiConsole.MarkupLine(message);
        }

        public static void Write(string message)
        {
            AnsiConsole.Markup(message);
        }

        public static void LoadingAnimation(string message)
        {
            AnsiConsole
                .Status()
                .Start(message, ctx => { });
        }
    }
}