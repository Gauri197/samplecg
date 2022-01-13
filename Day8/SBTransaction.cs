using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class SBTransaction
    {
        public int TransactionID { get; set; }
        public DateTime TransactionTime { get; set; }
        public int AccountNumber { get; set; }
        public double Amount { get; set; }
        public string TransactionType { get; set; }
        public double UpdatedBalance { get; set; }
        public SBTransaction()
        {

        }
        public SBTransaction(int TransactionID, DateTime TransactionTime, int AccountNumber, double Amount, string TransactionType, double UpdatedBalance)
        {
            this.TransactionID = TransactionID;
            this.TransactionTime = TransactionTime;
            this.AccountNumber = AccountNumber;
            this.Amount = Amount;
            this.TransactionType = TransactionType;
            this.UpdatedBalance = UpdatedBalance;
        }
    }
}
