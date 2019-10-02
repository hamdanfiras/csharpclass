using Class7.Banking.Core;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Class7.Banking.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Customer> customers = GenerateCustomers();
            var threeOrMore = customers
                .Where(c => c.Accounts != null && c.Accounts.Count > 2)
                .ToList();

            List<string> threeOrMoreJustName = customers
               .Where(c => c.Accounts != null && c.Accounts.Count > 2)
               .Select(c => c.FullName)
               .ToList();

            int maxAccountCount = customers.Max(c => c.Accounts.Count);

            var orderedCustomers = customers
                .OrderBy(c => c.Accounts.Count)
                .ToList();



            var first = customers.FirstOrDefault();
            var last = customers.LastOrDefault();

            var customerWithTopAccountNumbers = customers
                .OrderBy(c => c.Accounts.Count)
                .LastOrDefault();


            var threeOrMore2 = (from c in customers
                                where
           c.Accounts != null && c.Accounts.Count > 2
                                select c).ToList();


            var allAccountsUSD = customers
                .SelectMany(c => c.Accounts)
                .Where(c => c.Currency == "USD")
                .ToList();

            bool weHavePeopleWithMoreThan3Accounts =
                customers.Any(c => c.Accounts.Count > 3);

            var peopleWithBankAccountsThatAreDollarAndCredit =
                customers.Where(
                    c => c.Accounts.Any(
                        a => a.Currency == "USD"
                        && a is CreditBankAccount))
                .ToList();


            foreach (var cust in threeOrMore)
            {
                Console.WriteLine(cust.FullName);
            }
            Console.ReadLine();
        }

        private static List<Customer> MoreThan3Accounts(
            List<Customer> customers)
        {
            List<Customer> ret = new List<Customer>();
            foreach (var cust in customers)
            {
                if (cust.Accounts != null && cust.Accounts.Count > 2)
                {
                    ret.Add(cust);
                }
            }
            return ret;
        }

        private static List<Customer> GenerateCustomers()
        {
            List<string> names = new List<string>
            {
                "John Lennon",
                "Paul McCartney",
                "Christiano Ronaldo",
                "Firas Hamdan"
            };

            Random rnd = new Random();

            List<Customer> customers = new List<Customer>();

            int id = 1;
            foreach (string name in names)
            {
                Customer customer = new Customer();
                customer.Id = id;
                customer.FullName = name;
                customer.Accounts = new List<BankAccount>();
                customers.Add(customer);

                int numberOfAccounts = rnd.Next(2, 5);
                for (int i = 0; i < numberOfAccounts; i++)
                {
                    var isCredit = rnd.Next(0, 10) % 2 == 0;
                    var isDollar = rnd.Next(0, 10) % 2 == 0;
                    if (isCredit)
                    {
                        var limit = rnd.Next(500, 1300) * (isDollar ? 1 : 1500);
                        var bankAccount = new CreditBankAccount(isDollar ? "USD" : "LBP", limit);
                        customer.Accounts.Add(bankAccount);
                    }
                    else
                    {
                        var bankAccount = new CurrentBankAccount(isDollar ? "USD" : "LBP");
                        customer.Accounts.Add(bankAccount);
                    }
                }

                id++;
            }

            return customers;
        }

        private static void TestWithdrawal()
        {
            List<BankAccount> accounts = new List<BankAccount>();

            BankAccount accountA = new CreditBankAccount("USD", -1000);
            accountA.Deposit(500);
            BankAccount accountB = new CurrentBankAccount("USD");
            accountB.Deposit(1200);


            accounts.Add(accountA);
            accounts.Add(accountB);


            while (true)
            {
                Console.WriteLine("********************");
                Console.WriteLine("Please choose account:");
                for (int i = 0; i < accounts.Count; i++)
                {
                    Console.WriteLine("{0}: {1}", i + 1, accounts[i]);
                }
                if (int.TryParse(Console.ReadLine(), out int selectedIndex)
                    && accounts.Count >= selectedIndex
                    && selectedIndex > 0
                    )
                {
                    BankAccount selectedAccount = accounts[selectedIndex - 1];
                    Console.WriteLine("Select the amount to withdraw from this account: {0}", selectedAccount);

                    if (int.TryParse(Console.ReadLine(), out int amount))
                    {
                        selectedAccount.Withdraw(amount);

                        XmlSerializer serializer = new XmlSerializer(typeof(List<BankAccount>));
                        TextWriter writer = new StreamWriter("c:\\test\\bankaccounts.xml");

                        serializer.Serialize(writer, accounts);
                        writer.Close();

                        Console.WriteLine("Account after withdraw: {0}", selectedAccount);

                    }

                }
                else
                {
                    Console.WriteLine("Error. Please select one of the above");
                }
            }
        }
    }
}
