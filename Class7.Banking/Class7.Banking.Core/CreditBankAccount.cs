using System;
using System.Collections.Generic;
using System.Text;

namespace Class7.Banking.Core
{
    public class CreditBankAccount : BankAccount
    {
        decimal _limit;
        public CreditBankAccount(string currency, decimal limit) : base(currency)
        {
            _limit = limit;
        }

        public decimal Limit => _limit;
        //public decimal Limit
        //{
        //    get
        //    {
        //        return _limit;
        //    }
        //}

        public override void Withdraw(decimal amount)
        {
            if (Amount - amount >= Limit)
            {
                base.Withdraw(amount);
            }
        }

        public override string ToString()
        {
            return "Credit Account: " + base.ToString();
        }
    }
}
