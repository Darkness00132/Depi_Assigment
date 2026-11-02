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

        public void CreateAccount(string name, string password)
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
                Name = name,
                Password = password,
                BankAccounts = new List<BankAccount>
                {
                    new BankAccount(0, 0)
                }
            };

            _context.Accounts.Add(account);
            _context.SaveChanges();

            ColoredConsole.WriteLine(
                "Account created successfully!",
                Color.Green);
        }

        private BankAccount? Login(string name, string password)
        {
            var bankAccount = _context.BankAccounts
                .Include(b => b.Account)
                .FirstOrDefault(b => b.Account.Name == name
                                  && b.Account.Password == password);

            if (bankAccount == null)
            {
                ColoredConsole.WriteLine("Invalid name or password.", Color.Red);
                return null;
            }

            return bankAccount;
        }

        public void DisplayAccountInfo(string name, string password)
        {
            var bankAccount = Login(name, password);
            if (bankAccount == null) return;

            ColoredConsole.WriteLine($"Name: {bankAccount.Account.Name}", Color.Cyan);
            ColoredConsole.WriteLine($"Account ID: {bankAccount.AccountId}", Color.Cyan);
            ColoredConsole.WriteLine($"Balance: {bankAccount.Balance}", Color.Green);
        }

        public void CheckBalance(string name, string password)
        {
            var bankAccount = Login(name, password);
            if (bankAccount == null) return;

            ColoredConsole.WriteLine(
                $"Current balance: {bankAccount.Balance}",
                Color.Green);
        }

        public void Deposit(string name, string password, decimal amount)
        {
            var bankAccount = Login(name, password);
            if (bankAccount == null) return;

            bankAccount.Deposit(amount);
            _context.SaveChanges();

            ColoredConsole.WriteLine(
                $"Deposit successful! New balance: {bankAccount.Balance}",
                Color.Green);
        }

        public void Withdraw(string name, string password, decimal amount)
        {
            var bankAccount = Login(name, password);
            if (bankAccount == null) return;

            if (bankAccount.Balance < amount)
            {
                ColoredConsole.WriteLine("Insufficient balance.", Color.Red);
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
