using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class SBAccount
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public double CurrentBalance { get; set; }

        public SBAccount() { }
        public SBAccount(int accountNumber, string customerName, string customerAddress, double currentBalance)
        {
            this.AccountNumber = accountNumber;
            this.CustomerName = customerName;
            this.CustomerAddress = customerAddress;
            this.CurrentBalance = currentBalance;
        }
    }
}
