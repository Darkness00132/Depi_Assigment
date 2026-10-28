using Depi_Assigment.Data;
using Depi_Assigment.Entities;
using Spectre.Console;

namespace Depi_Assigment.Services
{
    public class BankAccountService
    {
        private readonly AppDbContext _context;

        public BankAccountService()
        {
            _context = new AppDbContext();
        }

        public void CreateAccount(string name)
        {
            var account = _context.BankAccounts
                .FirstOrDefault(a => a.Name == name);

            if (account != null)
            {
                ColoredConsole.WriteLine(
                    "An account with this name already exists.",
                    Color.Red);
                return;
            }

            var newAccount = new BankAccount
            {
                Name = name,
                Balance = 0
            };

            _context.BankAccounts.Add(newAccount);
            _context.SaveChanges();

            ColoredConsole.WriteLine(
                "Account created successfully!",
                Color.Green);
        }

        public void DisplayAccountInfo(string name)
        {
            var account = _context.BankAccounts
                .FirstOrDefault(a => a.Name == name);

            if (account == null)
            {
                ColoredConsole.WriteLine("Account not found.", Color.Red);
                return;
            }

            ColoredConsole.WriteLine("Account Information", Color.Cyan);
            ColoredConsole.WriteLine($"Name: {account.Name}", Color.White);
            ColoredConsole.WriteLine($"Balance: {account.Balance}", Color.Green);
        }

        public void CheckBalance(string name)
        {
            var account = _context.BankAccounts
                .FirstOrDefault(a => a.Name == name);

            if (account == null)
            {
                ColoredConsole.WriteLine("Account not found.", Color.Red);
                return;
            }

            ColoredConsole.WriteLine(
                $"Current balance: {account.Balance}",
                Color.Green);
        }

        public void Deposit(string name, decimal amount)
        {
            var account = _context.BankAccounts
                .FirstOrDefault(a => a.Name == name);

            if (account == null)
            {
                ColoredConsole.WriteLine("Account not found.", Color.Red);
                return;
            }

            if (amount <= 0)
            {
                ColoredConsole.WriteLine(
                    "Amount must be greater than zero.",
                    Color.Red);
                return;
            }

            account.Balance += amount;
            _context.SaveChanges();

            ColoredConsole.WriteLine(
                $"Deposit successful! New balance: {account.Balance}",
                Color.Green);
        }

        public void Withdraw(string name, decimal amount)
        {
            var account = _context.BankAccounts
                .FirstOrDefault(a => a.Name == name);

            if (account == null)
            {
                ColoredConsole.WriteLine("Account not found.", Color.Red);
                return;
            }

            if (amount <= 0)
            {
                ColoredConsole.WriteLine(
                    "Amount must be greater than zero.",
                    Color.Red);
                return;
            }

            if (account.Balance < amount)
            {
                ColoredConsole.WriteLine(
                    "Insufficient balance.",
                    Color.Red);
                return;
            }

            account.Balance -= amount;
            _context.SaveChanges();

            ColoredConsole.WriteLine(
                $"Withdrawal successful! New balance: {account.Balance}",
                Color.Green);
        }
    }
}
