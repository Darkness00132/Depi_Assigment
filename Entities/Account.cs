namespace Depi_Assigment.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}
