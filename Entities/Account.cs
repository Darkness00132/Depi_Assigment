namespace Depi_Assigment.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; } = string.Empty;

        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}
