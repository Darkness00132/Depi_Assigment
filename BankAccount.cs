namespace Depi_Assigment
{
  public class BankAccount {
    public int AccountNumber { get; private set; }
    
    public string AccountHolderName { get; private set; }
    
    public decimal Balance { get; private set; }
    
    public BankAccount(int accountNumber, string accountHolderName, decimal initialBalance)
    {
      AccountNumber = accountNumber;
      AccountHolderName = accountHolderName;
      Balance = initialBalance; 
    } 
  }
}
