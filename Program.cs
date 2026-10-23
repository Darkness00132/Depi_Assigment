
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

    var bankService = new BankAccountService();

    switch (input)
    {
        case "create":
            bankService.CreateAccount();
            break;

        case "info":
            bankService.DisplayAccountInfo();
            break;

        case "balance":
            bankService.CheckBalance();
            break;

        case "deposit":
            bankService.Deposit();
            break;

        case "withdraw":
            bankService.Withdraw();
            break;
    }

    ColoredConsole.WriteLine();
}
