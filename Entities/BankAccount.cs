namespace Depi_Assigment.Entities
{
  public class BankAccount {
        public int Id { get; set; }
        public int AccountId { get; private set; }
        public Account Account { get; set; }

        public decimal Balance { get; private set; }

        private BankAccount() 
        {
        }

        public BankAccount(int accountId, decimal initialBalance)
        {
            AccountId = accountId;
            Balance = initialBalance; 
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
    }
}
