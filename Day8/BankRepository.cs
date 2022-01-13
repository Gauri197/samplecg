using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    class BankRepository : IBankRepository
    {
        List<SBAccount> sbac = new List<SBAccount>();
        List<SBTransaction> sbtr = new List<SBTransaction>();
        SBAccount sba = new SBAccount();
        SBTransaction sbt = new SBTransaction();
        int TransactionID = 100;

        public void NewAccount(SBAccount acc)
        {
            sbac.Add(acc);
        }
        public SBAccount GetAccountDetails(int AccountNo)
        {
            SBAccount sb = new SBAccount();
            for (int i=0; i<sbac.Count; i++)
            {
                if (AccountNo == sbac[i].AccountNumber)
                {
                    sb = sbac[i];
                }
            }
            return sb;
        }
        public List<SBAccount> GetAccountDetails()
        {
            return sbac;
        }
        public void DepositAmount(int AccountNo, double amount)
        {
            for (int i = 0; i < sbac.Count; i++)
            {
                if (AccountNo == sbac[i].AccountNumber)
                {
                    sbac[i].CurrentBalance += amount;
                    sbtr.Add(new SBTransaction(TransactionID++, DateTime.Now, AccountNo, amount, "Deposit", sbac[i].CurrentBalance));
                }
            }
        }
        public Boolean WithdrawAmount(int AccountNo, double amount, Boolean status)
        {
            for (int i = 0; i < sbac.Count; i++)
            {
                if (AccountNo == sbac[i].AccountNumber)
                {
                    if(sbac[i].CurrentBalance > amount)
                    {
                        sbac[i].CurrentBalance -= amount;
                        sbtr.Add(new SBTransaction(TransactionID++, DateTime.Now, AccountNo, amount, "Withdraw", sbac[i].CurrentBalance));
                    }
                    else
                    {
                        status = false;
                    }
                }
            }
            return status;
        }
        public List<SBTransaction> GetTransactions(int AccountNo)
        {
            List<SBTransaction> trDetails = new List<SBTransaction>();
            for (int i = 0; i < sbtr.Count; i++)
            {
                if (AccountNo == sbtr[i].AccountNumber)
                {
                    trDetails.Add(sbtr[i]);
                }
            }
            return trDetails;
        }
        public Boolean UserExists(int AccountNo, Boolean status)
        {
            int count = 0;
            for (int i = 0; i < sbtr.Count; i++)
            {
                if (AccountNo == sbtr[i].AccountNumber)
                {
                    count++;
                }
            }
            if (count!=0)
            {
                status = false;
            }
            return status;
        }
    }
}
