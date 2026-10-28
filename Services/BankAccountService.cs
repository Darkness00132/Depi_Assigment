using Depi_Assigment.Data;
using Depi_Assigment.Entities;

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
            // TODO: 
            // 1. Check if an account with this name already exists.
            // 2. If it exists, display a red error message and return.
            // 3. Otherwise, create a new account with the given name.
            // 4. Save the account to the database.
        }

        public void DisplayAccountInfo(string name)
        {
            // TODO:
            // 1. Find the account by name.
            // 2. If it doesn't exist, display an error message and return.
            // 3. Otherwise, display the account information.
        }

        public void CheckBalance(string name)
        {
            // TODO:
            // 1. Find the account by name.
            // 2. If it doesn't exist, display an error message and return.
            // 3. Otherwise, display the current balance.
        }

        public void Deposit(string name, decimal amount)
        {
            // TODO:
            // 1. Find the account by name.
            // 2. If it doesn't exist, display an error message and return.
            // 3. Add the amount to the account balance.
            // 4. Save the changes to the database.
            // 5. Display a success message.
        }

        public void Withdraw(string name, decimal amount)
        {
            // TODO:
            // 1. Find the account by name.
            // 2. If it doesn't exist, display an error message and return.
            // 3. Check if the account has enough balance.
            // 4. If the balance is insufficient, display an error message and return.
            // 5. Subtract the amount from the account balance.
            // 6. Save the changes to the database.
            // 7. Display a success message.
        }
    }
}