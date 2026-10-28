
using Depi_Assigment;
using Depi_Assigment.Services;
using Spectre.Console;

ColoredConsole.WelcomeMessage();

List<string> allowedCommands =
    ["info", "create", "balance", "withdraw", "deposit", "exit"];

while (true)
{
    ColoredConsole.WriteLine(
        "Please enter a command (or type 'exit' to quit):",
        Color.Cyan);

    string? input = Console.ReadLine()?.ToLower().Trim();

    if (string.IsNullOrEmpty(input) || !allowedCommands.Contains(input))
    {
        ColoredConsole.WriteLine("Invalid command.", Color.Red);
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
            {
                ColoredConsole.WriteLine("Enter your name:", Color.Aquamarine1);
                string name = Console.ReadLine();

                bankService.CreateAccount(name);
                break;
            }

        case "info":
        case "balance":
            {
                ColoredConsole.WriteLine("Enter your name:", Color.Aquamarine1);
                string name = Console.ReadLine();

                if (input == "info")
                    bankService.DisplayAccountInfo(name);
                else
                    bankService.CheckBalance(name);

                break;
            }

        case "deposit":
        case "withdraw":
            {
                ColoredConsole.WriteLine("Enter your name:", Color.Aquamarine1);
                string name = Console.ReadLine();

                ColoredConsole.WriteLine("Enter the amount:", Color.Aquamarine1);
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                if (input == "deposit")
                    bankService.Deposit(name, amount);
                else
                    bankService.Withdraw(name, amount);

                break;
            }
    }

    ColoredConsole.WriteLine();
}