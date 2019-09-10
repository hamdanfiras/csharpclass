using System;
using System.Text;

namespace CoffeeApp
{
    class Program
    {
        static void X()
        {
        }

        static void Main(string[] args)
        {
            Car myBMW = new Car();
            int theSpeed = myBMW.GetSpeed();
            Console.WriteLine(theSpeed);

     

            myBMW.SetSpeed(30);
            int newSpeed = myBMW.GetSpeed();
            Console.WriteLine(newSpeed);

            myBMW.Color = "red";
            string myBMWColor = myBMW.Color;

            int x = 4;
            decimal y = x;

            decimal x1 = 1.2m;
            int y1 = (int)x1;

            string name = "Firas";
            string greeting = "hello, " + name;

            StringBuilder sb = new StringBuilder();
            sb.Append("Hello");
            sb.Append(",");
            sb.Append(1);
            sb.Insert(0, "sdsds");
            string s = sb.ToString();

            Console.ReadLine();
        }
    }

    public class Car
    {
        private int speed;
        public int GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(int newSpeed)
        {
            if (newSpeed > 180) speed = 180;
            speed = newSpeed;
        }

        //private string color;
        //public string GetColor()
        //{
        //    return color;
        //}
        //public void SetColor(string vcolor)
        //{
        //    color = vcolor;
        //}

        private string color;
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        //private int make;
        //public int Make
        //{
        //    get { return make; }
        //    set { make = value; }
        //}

        public int Make { get; set; }

        public int Age()
        {
            return DateTime.Now.Year - Make;
        }

        public int Age2
        {
            get
            {
                return DateTime.Now.Year - Make;
            }
        }
    }

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