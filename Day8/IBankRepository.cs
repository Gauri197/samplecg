using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    interface IBankRepository 
    {
        void NewAccount(SBAccount acc);
        SBAccount GetAccountDetails(int AccountNo);
        void DepositAmount(int AccountNo, double amount);
        Boolean WithdrawAmount(int AccountNo, double amount, Boolean status);
        List<SBTransaction> GetTransactions(int AccountNo);
        Boolean UserExists(int AccountNo, Boolean status);



    }
}
