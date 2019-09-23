using Class7.Banking.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Class7.Banking.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //BankAccount a = new BankAccount();
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
