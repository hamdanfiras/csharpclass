namespace Class4
{
    public class BankAccount
    {
        private decimal balance;

        public BankAccount(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public void Deposit(decimal value) { balance += value; }

        public void Withdraw(decimal value) { balance -= value; }

        public decimal Balance { get { return balance; } }
    }
}
// Add Id property to BankAccount class of type int
// Make the Id obligatory by adding it to the constructor and marking it's setter as private
// Create Customer class
// Add BankAccounts array as a private field
// Add AddAccount function that adds to the accounts
// Add TotalAmount function that sums the balance in all account 
