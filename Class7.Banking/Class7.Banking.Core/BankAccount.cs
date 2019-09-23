using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Class7.Banking.Core
{
    [XmlInclude(typeof(CreditBankAccount))]
    [XmlInclude(typeof(CurrentBankAccount))]

    public abstract class BankAccount
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
            if (ValidateWithdraw(amount))
            {
                _amount -= amount;
            }
        }

        protected abstract bool ValidateWithdraw(decimal amount);


        public decimal Amount => _amount;


        public string Currency { get { return _currency; } set { _currency = value; } }

       

        public override string ToString()
        {
            return Currency + " " + Amount.ToString();
        }
    }
}
