using System;
using System.Collections.Generic;
using System.Text;

namespace Class7.Banking.Core
{
    public class BankAccount
    {
        private decimal _amount;
        private string _currency;

        public BankAccount(string currency)
        {
            _currency = currency;
        }

        public void Deposit(decimal amount)
        {
            _amount += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            _amount -= amount;
        }

        public decimal Amount => _amount;

        public string Currency => _currency;

        public override string ToString()
        {
            return Currency + " " + Amount.ToString();
        }
    }
}
