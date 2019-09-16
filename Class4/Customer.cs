using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Class4
{
    public class Customer
    {
        private ArrayList bankAccounts;

        public Customer()
        {
            bankAccounts = new ArrayList();
        }

        public void AddAccount(BankAccount account)
        {
            // Must have unique ids
            foreach (object o in this.bankAccounts)
            {
                if (o is BankAccount)
                {
                    BankAccount acc = (BankAccount)o;
                    if (acc.Id == account.Id)
                    {
                        throw new ApplicationException("Cannot have duplicate ids");
                    }
                }
            }

            bankAccounts.Add(account);
        }

        public ArrayList BankAccounts
        {
            get
            {
                return bankAccounts;
            }
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (object o in this.bankAccounts)
            {
                if (o is BankAccount)
                {
                    BankAccount acc = (BankAccount)o;
                    total += acc.Balance;
                }
            }
            return total;
        }
    }
}
