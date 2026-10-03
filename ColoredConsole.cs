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

        public static void WriteLine(string message="",Color color=default)
        {
            AnsiConsole.Write(new Text(message, new Style(foreground: color)));
            AnsiConsole.WriteLine();
        }

        public static void Write(string message,Color color)
        {
            AnsiConsole.Markup($"[color={color}]{message}[/]");
        }
    }
}