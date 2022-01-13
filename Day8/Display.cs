using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class Display
    {
        public void display(SBAccount sba)
        {
            Console.WriteLine("{0,-10}{1,-15}{2,-20}{3,-10}", sba.AccountNumber,sba.CustomerName,sba.CustomerAddress,sba.CurrentBalance);
        }
        public void display(List<SBAccount> sba)
        {
            for (int i=0; i< sba.Count; i++)
            {
                Console.WriteLine("{0,-10}{1,-15}{2,-20}{3,-10}", sba[i].AccountNumber,sba[i].CustomerName,sba[i].CustomerAddress,sba[i].CurrentBalance);
            }
        }
        public void display(List<SBTransaction> sba)
        {
            for (int i = 0; i < sba.Count; i++)
            {
                Console.WriteLine("{0,-14} {1,-30} {2,-14} {3,-7} {4,-16} {5,-15}", sba[i].TransactionID,sba[i].TransactionTime,sba[i].AccountNumber,sba[i].Amount,sba[i].TransactionType,sba[i].UpdatedBalance);
            }
        }
    }
}
