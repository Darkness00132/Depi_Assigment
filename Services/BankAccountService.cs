using Depi_Assigment.Data;
using Depi_Assigment.Entities;
using Microsoft.EntityFrameworkCore;
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
            var existingAccount = _context.Accounts
                .FirstOrDefault(a => a.Name == name);

            if (existingAccount != null)
            {
                ColoredConsole.WriteLine(
                    "An account with this name already exists.",
                    Color.Red);
                return;
            }

            var account = new Account
            {
                Name = name
            };

            account.BankAccounts = new List<BankAccount>
            {
                new BankAccount(0, 0)
            };

            _context.Accounts.Add(account);
            _context.SaveChanges();

            ColoredConsole.WriteLine(
                "Account created successfully!",
                Color.Green);
        }

        public void DisplayAccountInfo(string name)
        {
            var account = _context.Accounts
                .Include(a => a.BankAccounts)
                .FirstOrDefault(a => a.Name == name);

            if (account == null)
            {
                ColoredConsole.WriteLine("Account not found.", Color.Red);
                return;
            }

            ColoredConsole.WriteLine($"Name: {account.Name}", Color.Cyan);

            foreach (var bankAccount in account.BankAccounts)
            {
                ColoredConsole.WriteLine(
                    $"Account ID: {bankAccount.AccountId}",
                    Color.Cyan);

                ColoredConsole.WriteLine(
                    $"Balance: {bankAccount.Balance}",
                    Color.Green);
            }
        }

        public void CheckBalance(string name)
        {
            var bankAccount = _context.BankAccounts
                .Include(b => b.Account)
                .FirstOrDefault(b => b.Account.Name == name);

            if (bankAccount == null)
            {
                ColoredConsole.WriteLine("Account not found.", Color.Red);
                return;
            }

            ColoredConsole.WriteLine(
                $"Current balance: {bankAccount.Balance}",
                Color.Green);
        }

        public void Deposit(string name, decimal amount)
        {
            var bankAccount = _context.BankAccounts
                .Include(b => b.Account)
                .FirstOrDefault(b => b.Account.Name == name);

            if (bankAccount == null)
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

            bankAccount.Deposit(amount);
            _context.SaveChanges();

            ColoredConsole.WriteLine(
                $"Deposit successful! New balance: {bankAccount.Balance}",
                Color.Green);
        }

        public void Withdraw(string name, decimal amount)
        {
            var bankAccount = _context.BankAccounts
                .Include(b => b.Account)
                .FirstOrDefault(b => b.Account.Name == name);

            if (bankAccount == null)
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

            if (bankAccount.Balance < amount)
            {
                ColoredConsole.WriteLine(
                    "Insufficient balance.",
                    Color.Red);
                return;
            }

            bankAccount.Withdraw(amount);
            _context.SaveChanges();

            ColoredConsole.WriteLine(
                $"Withdrawal successful! New balance: {bankAccount.Balance}",
                Color.Green);
        }
    }
}