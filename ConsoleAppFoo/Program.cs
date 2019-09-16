using System;

namespace ConsoleAppFoo
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime.Now.ToUniversalTime();

            Foo foo = new Foo();
            foo.Baz = "WOW";

            foo.Bar();
            int l = foo.Bar("Firas");
            int l2 = foo.Bar("Firas", "Jessica", 8);
            int l3 = foo.Bar(z: 8, y: "hello", s: "wow");
            int l4 = foo.Bar("Firas", "Jessica");
            //int l4 = foo.Bar("Firas", "Jessica", 10);

            // calling out
            int i1, i2;
            bool b = Foo.TakeMeHigher("black mamba", out i1, out i2);
            Console.WriteLine("Result: {0}, {1}, {2}", b, i1, i2);

            foo.TheField = 4;

            var s = Foo.Sum(3, 6, 7, 8);
            Console.WriteLine(s);

            try
            {
                int intInput = int.Parse(Console.ReadLine());
                decimal x1 = 7 / intInput;
                Console.WriteLine(intInput);

                if (intInput % 2 == 0)
                {
                    ApplicationException ex = new ApplicationException("I don't like even number");
                    throw ex;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("YOu entered a wrong input");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Come on man, we cannot divide by zero");
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Don't know man what happened");
                throw;
            }
            finally
            {
                Console.WriteLine("in all cases");
            }

            int outValue;
            if (int.TryParse("67", out outValue))
            {
                Console.WriteLine("Success {0}", outValue);
            }
            else
            {
                Console.WriteLine("Failure");
            }

            int outValue2;
            bool bl = int.TryParse("dfdf", out outValue2);
            if (bl)
            {
                Console.WriteLine("Success {0}", outValue2);
            }
            else
            {
                Console.WriteLine("Failure");
            }

            if (int.TryParse("567", out int outValue3))
            {
                Console.WriteLine("Success {0}", outValue3);
            }

            string fName = FullName("John", "Lennon");
            string fName2 = FullName("Firas", "Hamdan", "M");

            Console.WriteLine("================");
            int x = 7;
            int y = x;
            y = 8;
            Console.WriteLine($"{x} {y}");

            Foo f = new Foo();
            f.Baz = "Nice";

            Foo f1 = f;
            f1.Baz = "Great";

            Foo f4 = null;

            Point p = new Point();
            p.X = 2;

            Console.WriteLine(f1 == f);
            Console.WriteLine($"{f.Baz} {f1.Baz}");

            string s1 = "hello";
            string s2 = s1;
            s2 = "hi";
            Console.WriteLine($"{s1} {s2}");



            Console.ReadLine();
        }

        //static string FullName(string firstName, string lastName)
        //{
        //    //  return $"{firstName} {lastName}";
        //    //return firstName + " " + lastName;
        //    string fullN = FullName(firstName, lastName, string.Empty);
        //    return fullN;
        //}

        static string FullName(string firstName, string lastName, string middleName = "")
        {
            //return $"{firstName} {middleName} {lastName}";
            return firstName + " " + middleName + " " + lastName;
        }

        // Let the first function reuse the second function
        // make them one function using optional parameters
    }

    public class Foo
    {
        public string Baz { get; set; }

        private int theField;
        public int TheField
        {
            get
            {
                // nothing
                return theField;
            }
            set
            {
                //nothing
                theField = value;
            }
        }

        public void Bar()
        {
            Sum();
            Console.WriteLine("Hello " + Baz);
        }

        public int Bar(string s)
        {
            return s.Length;
        }

        //public int Bar(string s, string y)
        //{
        //    return s.Length + y.Length;
        //}

        public int Bar(string s, string y, int z = 10)
        {
            return s.Length + y.Length + z;
        }

        public static bool TakeMeHigher(string s, out int i, out int j)
        {
            i = s.Length;
            j = i * 2;
            return j > 10;
        }

        public static int Sum(params int[] values)
        {
            // Bar();
            int sum = 0;
            foreach (int i in values)
            {
                sum += i;
            }
            return sum;
        }
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class WeirdoException : ApplicationException
    {

    }
}

// since int.Parse can generate a runtime exception, we must use int.TryParse function
// public static bool TryParse(string s, out int result);
// create a new console project and test the tryparse code for int
// Console output: Success 14
// Console output: Failed to parse

//int i1, i2;
//bool b = Foo.TakeMeHigher("black mamba", out i1, out i2);
//public static bool TakeMeHigher(string s, out int i, out int j)
//{
//    i = s.Length;
//    j = i * 2;
//    return j > 10;
//}


// Create FullName function, that takes two strings firstname and lastname and returns 
//full name
// create and overload of Fullname that takes middle name in addition to first and lastname
// Let the first function reuse the second function
// make them one function using optional parameters