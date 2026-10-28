namespace Depi_Assigment.Entities
{
  public class BankAccount {
    public int AccountNumber { get; private set; }
    
    public decimal Balance { get; private set; }

    private BankAccount() 
    {
    }

    public BankAccount(int accountNumber, decimal initialBalance)
    {
      AccountNumber = accountNumber;
      Balance = initialBalance; 
    } 
  }
}
