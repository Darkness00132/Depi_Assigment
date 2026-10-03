using Depi_Assigment;
using Spectre.Console;

ColoredConsole.WelcomeMessage();

while (true)
{
    List<string> allowedCommands = ["info", "create", "balance", "withdraw", "deposit"];

    ColoredConsole.WriteLine("Please enter a command (or type 'exit' to quit):",Color.Cyan);
    ColoredConsole.WriteLine();

    string? input = Console.ReadLine();
    ColoredConsole.WriteLine();

    if (input == null || !allowedCommands.Contains(input.ToLower()))
    {
        ColoredConsole.WriteLine("Invalid command. Please try again.",Color.Red);
        ColoredConsole.WriteLine();
        continue;
    }

    else if (input.ToLower() == "exit")
    {
        break;
    }
}
