using System;
using System.Text;

namespace CoffeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarMain();

            // Simple Types
            //SimpleTypesMain();

            // if (bool) { } else if (bool2) {} else { }

            if (DateTime.Now.Year % 4 == 0)
            {
                Console.WriteLine("Leap Year");
            }

            //string greeting = DateTime.Now.Hour < 11 ? "GoodMorning" : "hello";

            int x = 1;
            switch (x)
            {
                case 1:
                    Console.WriteLine(1);
                    break;
                default:
                    Console.WriteLine(x);
                    break;
            }

           


            Foo("", 5, 6, 7);

            int u = 9;
            string h = "hello";
            string s = $"{u}jkjflksdjfs {h} dfsdfsdf";

            Console.WriteLine(s);

            Console.ReadLine();
        }

        static void Foo(string s, params int[] ar)
        {
            foreach (var i in ar)
            {
                Console.WriteLine(i);
            }
        }

        private static void SimpleTypesMain()
        {
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
        }

        private static void CarMain()
        {
            Car myBMW = new Car();
            int theSpeed = myBMW.GetSpeed();
            Console.WriteLine(theSpeed);

            myBMW.SetSpeed(30);
            int newSpeed = myBMW.GetSpeed();
            Console.WriteLine(newSpeed);

            //myBMW.Color = "red";
            myBMW.Color = Color.Blue | Color.Red;
            Color myBMWColor = myBMW.Color;
            myBMW.Make = 2010;
            Console.WriteLine(myBMW.Age());
            myBMW.CarModel = Model.Sedan;

            Model m = Model.Motorcycle;

        }


    }
}

