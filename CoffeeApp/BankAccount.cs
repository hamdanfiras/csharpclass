namespace CoffeeApp
{
    public class BankAccount
    {
        private decimal balance;

        public void Deposit(decimal value)
        {
            balance += value;
        }

        public void Withdraw(decimal value)
        {
            balance -= value;
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
        }
    }

  
}



//int i = 1;
//bool b = false;
//String s = "helo";
//string s1 = "firas";
//int ii = 0;

//var x = 8;

//StringBuilder sb = new StringBuilder();



//// int x = 8;

//DateTime dt = DateTime.Now;
//int thisYear = dt.Year;

//DateTime nextYearSameDay = dt.AddYears(1);
//int nextYear = nextYearSameDay.Year;

//int nextYear2 = dt.AddYears(1).Year;