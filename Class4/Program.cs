using System;
using System.Collections;
using System.Collections.Specialized;

namespace Class4
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDictionary dictionary = new ListDictionary();
            dictionary.Add(10, "Adam");
            dictionary.Add(20, "Georges");
            dictionary.Add("Foo", "BAr");

            if (dictionary["Foo"] is string)
            {
                string s = (string)dictionary["Foo"];
                Console.WriteLine(s);
            }

            if (dictionary["Foo"] is string s1)
            {
                Console.WriteLine(s1);
            }

            object o = (string)dictionary["Foo"];

            Queue q = new Queue();
            q.Enqueue(2);
            q.Enqueue("Hello");

            int x = (int)q.Peek();
            int y = (int)q.Dequeue();

            Stack s = new Stack();
            s.Push(6);
            s.Push("djdjdj");

            int x1 = (int)s.Pop();


            Console.ReadLine();
        }

        private static void Banking()
        {
            Customer jess = new Customer();

            BankAccount account1 = new BankAccount(1);
            account1.Deposit(1000);
            jess.AddAccount(account1);

            BankAccount account2 = new BankAccount(2);
            account2.Deposit(2000);
            jess.AddAccount(account2);

            try
            {
                BankAccount account3 = new BankAccount(3);
                account3.Deposit(2000);
                jess.AddAccount(account3);
            }
            catch (ApplicationException)
            {
                Console.WriteLine("Cannot add duplicates, sorry");
            }

            foreach (object o in jess.BankAccounts)
            {
                if (o is BankAccount)
                {
                    BankAccount acc = (BankAccount)o;
                    Console.WriteLine("Account no: {0}, Balance: {1}", acc.Id, acc.Balance);
                }
            }

            Console.WriteLine("Total wealth: " + jess.Total());
        }

        private static void SimpleArrayList()
        {
            ArrayList arr = new ArrayList();
            arr.Add(5);
            arr.Add("hello");
            arr.Add(new ArrayList());
            arr.Add(new BankAccount(8));
        }

        private static void ProblemWithArraySize()
        {
            int[] arr = new int[] { 2, 3, 5 };
            int[] arr2 = new int[4];

            for (int i = 0; i < arr.Length; i++)
            {
                arr2[i] = arr[i];
            }
        }

        private static void MultiDimensionalArray()
        {
            int[][] mArray = new int[4][];
            mArray[0] = new int[10];
            mArray[0][0] = 1;
            mArray[0][1] = 10;
            mArray[1] = new int[20];
        }

        private static void SimpleArray()
        {
            int[] grades = new int[4];

            for (int i = 0; i < grades.Length; i++)
            {
                grades[i] = (i + 1) * 10;
            }
                
            foreach (var grade in grades)
            {
                Console.WriteLine(grade);
            }

            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine(grades[i]);
            }

            Console.ReadLine();
        }
    }

    
}
