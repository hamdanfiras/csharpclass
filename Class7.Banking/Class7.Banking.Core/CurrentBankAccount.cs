using System;
using System.Collections.Generic;
using System.Text;

namespace Class7.Banking.Core
{
    public class CurrentBankAccount : BankAccount
    {
        public CurrentBankAccount(string currency) : base(currency)
        {
        }

        public override void Withdraw(decimal amount)
        {
            if (Amount - amount >= 0)
            {
                base.Withdraw(amount);
            }
        }


        public override string ToString()
        {
            return "Current Account: " + base.ToString();
        }
    } 
}
