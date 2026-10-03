using Depi_Assigment;

ColoredConsole.WelcomeMessage();

while (true) 
{
    List<string> allowedCommands = ["info", "create", "balance", "withdraw", "deposit"];

    ColoredConsole.WriteLine("[cyan]Please enter a command (or type 'exit' to quit):[/]");
    ColoredConsole.WriteLine();

    string? input = Console.ReadLine();
    ColoredConsole.WriteLine();

    if (input == null || !allowedCommands.Contains(input.ToLower()))
    {
        ColoredConsole.WriteLine("[red]Invalid command. Please try again.[/]");
        ColoredConsole.WriteLine();
        continue;
    }

    else if (input.ToLower() == "exit")
    {
        break;
    }
}
