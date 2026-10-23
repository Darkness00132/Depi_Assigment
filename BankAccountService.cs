namespace Depi_Assigment
{
    public class BankAccountService
    {
        private BankAccount account;

        public void CreateAccount()
        {
            if (account != null)
            {
                Console.WriteLine(
                    "An account has already been created!"
                );

                return;
            }

            Console.WriteLine(
                "===== Create New Account ====="
            );

            Console.Write("Enter account number: ");
            string accountNumberInput = Console.ReadLine();

            if (!int.TryParse(accountNumberInput, out int accountNumber) ||
                accountNumber <= 0)
            {
                Console.WriteLine(
                    "Invalid account number!"
                );

                return;
            }

            Console.Write("Enter account holder name: ");
            string accountHolderName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(accountHolderName))
            {
                Console.WriteLine(
                    "Account holder name cannot be empty!"
                );

                return;
            }

            Console.Write("Enter initial balance: ");
            string balanceInput = Console.ReadLine();

            if (!decimal.TryParse(balanceInput, out decimal initialBalance) ||
                initialBalance < 0)
            {
                Console.WriteLine(
                    "Invalid initial balance!"
                );

                return;
            }

            account = new BankAccount(
                accountNumber,
                accountHolderName,
                initialBalance
            );

            Console.WriteLine(
                "Account created successfully!"
            );
        }

        public void DisplayAccountInfo()
        {
            if (account == null)
            {
                Console.WriteLine(
                    "No account has been created yet!"
                );

                return;
            }

            Console.WriteLine(
                "===== Account Information ====="
            );

            Console.WriteLine(
                $"Account Number: {account.AccountNumber}"
            );

            Console.WriteLine(
                $"Account Holder: {account.AccountHolderName}"
            );

            Console.WriteLine(
                $"Current Balance: {account.Balance:F2} EGP"
            );
        }

        // Task 3 (Alaa): Show the current account balance.
        public void CheckBalance()
        {
            if (account == null)
            {
                ColoredConsole.WriteLine("No account has been created yet!", Spectre.Console.Color.Red);
                return;
            }

            ColoredConsole.WriteLine($"Current Balance: {account.Balance:F2} EGP", Spectre.Console.Color.Cyan);
        }

        // Task 3 (Alaa): Add a valid positive amount to the account.
        public void Deposit()
        {
            if (account == null)
            {
                ColoredConsole.WriteLine("No account has been created yet!", Spectre.Console.Color.Red);
                return;
            }

            ColoredConsole.WriteLine("Enter amount to deposit:", Spectre.Console.Color.Cyan);
            string? input = Console.ReadLine();

            if (!decimal.TryParse(input, out decimal amount) || amount <= 0)
            {
                ColoredConsole.WriteLine("Invalid amount! Please enter a positive number.", Spectre.Console.Color.Red);
                return;
            }

            decimal updatedBalance;
            try
            {
                updatedBalance = checked(account.Balance + amount);
            }
            catch (OverflowException)
            {
                ColoredConsole.WriteLine("Amount is too large.", Spectre.Console.Color.Red);
                return;
            }

            // BankAccount.Balance has a private setter in the existing project.
            // Preserve its public API: replace the internal account snapshot.
            account = new BankAccount(account.AccountNumber, account.AccountHolderName, updatedBalance);
            ColoredConsole.WriteLine($"Deposit successful! New Balance: {account.Balance:F2} EGP", Spectre.Console.Color.Green);
        }

        // Task 3 (Alaa): Withdraw a valid amount that does not exceed balance.
        public void Withdraw()
        {
            if (account == null)
            {
                ColoredConsole.WriteLine("No account has been created yet!", Spectre.Console.Color.Red);
                return;
            }

            ColoredConsole.WriteLine("Enter amount to withdraw:", Spectre.Console.Color.Cyan);
            string? input = Console.ReadLine();

            if (!decimal.TryParse(input, out decimal amount) || amount <= 0)
            {
                ColoredConsole.WriteLine("Invalid amount! Please enter a positive number.", Spectre.Console.Color.Red);
                return;
            }

            if (amount > account.Balance)
            {
                ColoredConsole.WriteLine("Insufficient balance!", Spectre.Console.Color.Red);
                return;
            }

            decimal updatedBalance = account.Balance - amount;
            account = new BankAccount(account.AccountNumber, account.AccountHolderName, updatedBalance);
            ColoredConsole.WriteLine($"Withdrawal successful! New Balance: {account.Balance:F2} EGP", Spectre.Console.Color.Green);
        }

    }  
}





