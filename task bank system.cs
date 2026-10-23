
namespace day1
لهف{
    public class BankAccount
    {

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
    }


    internal class Program
    {

        static void Main(string[] args)
        {;


            BankAccountService service = new BankAccountService();

            service.CreateAccount();

            Console.WriteLine();

            service.DisplayAccountInfo();
        }
    }  
}





