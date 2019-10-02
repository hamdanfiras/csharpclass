using System;
using System.Collections.Generic;
using System.Text;

namespace Class7.Banking.Core
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<BankAccount> Accounts { get; set; }
    }
}
