using System;
using System.Collections.Generic;
using System.Text;

namespace Class7.Banking.Core
{
    public class CurrentBankAccount : BankAccount
    {
        public CurrentBankAccount() : base("USD")
        {
        }
        public CurrentBankAccount(string currency) : base(currency)
        {
        }

        //public override void Withdraw(decimal amount)
        //{
        //    if (Amount - amount >= 0)
        //    {
        //        base.Withdraw(amount);
        //    }
        //}

        protected override bool ValidateWithdraw(decimal amount)
        {
            return amount > 0 && Amount - amount >= 0;
        }


        public override string ToString()
        {
            return "Current Account: " + base.ToString();
        }

        
    } 
}
