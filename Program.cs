
using Depi_Assigment;
using Spectre.Console;

ColoredConsole.WelcomeMessage();

List<string> allowedCommands = ["info", "create", "balance", "withdraw", "deposit", "exit"];

while (true)
{
    ColoredConsole.WriteLine("Please enter a command (or type 'exit' to quit):", Color.Cyan);
    ColoredConsole.WriteLine();

    string? input = Console.ReadLine()?.ToLower().Trim();
    ColoredConsole.WriteLine();

    if (string.IsNullOrEmpty(input) || !allowedCommands.Contains(input))
    {
        ColoredConsole.WriteLine("Invalid command. Please try again.", Color.Red);
        ColoredConsole.WriteLine();
        continue;
    }

    if (input == "exit")
    {
        ColoredConsole.WriteLine("Exiting the bank system...", Color.Yellow);
        break;
    }

    switch (input)
    {
        case "create":
            BankService.CreateAccount();
            break;

        case "info":
            BankService.ShowAccountInfo();
            break;

        case "balance":
            BankService.CheckBalance();
            break;

        case "deposit":
            BankService.Deposit();
            break;

        case "withdraw":
            BankService.Withdraw();
            break;
    }

    ColoredConsole.WriteLine();
}
