using Depi_Assigment;
using Depi_Assigment.Services;
using Spectre.Console;

ColoredConsole.WelcomeMessage();

var bankService = new BankAccountService();
List<string> allowedCommands =
    ["info", "create", "balance", "withdraw", "deposit", "exit"];

while (true)
{
    ColoredConsole.WriteLine(
        "Enter a command (info, create, balance, withdraw, deposit, exit):",
        Color.Cyan);

    string input = (Console.ReadLine() ?? "").Trim().ToLower();
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

    if (input is not ("info" or "create" or "balance" or "withdraw" or "deposit"))
    {
        ColoredConsole.WriteLine("Invalid command.", Color.Red);
        continue;
    }

    ColoredConsole.WriteLine("Enter your name:", Color.Aquamarine1);
    string name = Console.ReadLine() ?? "";

    ColoredConsole.WriteLine("Enter your password:", Color.Aquamarine1);
    string password = Console.ReadLine() ?? "";
    var bankService = new BankAccountService();

    switch (input)
    {
        case "create":
            bankService.CreateAccount(name, password);
            break;

        case "info":
            bankService.DisplayAccountInfo(name, password);
            break;
            {
                ColoredConsole.WriteLine("Enter your name:", Color.Aquamarine1);
                string name = Console.ReadLine();

                bankService.CreateAccount(name);
                break;
            }

        case "info":
        case "balance":
            bankService.CheckBalance(name, password);
            break;

        case "deposit":
        case "withdraw":
            ColoredConsole.WriteLine("Enter the amount:", Color.Aquamarine1);

            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                ColoredConsole.WriteLine("Invalid amount.", Color.Red);
                break;
            }

            if (input == "deposit")
                bankService.Deposit(name, password, amount);
            else
                bankService.Withdraw(name, password, amount);
            break;
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