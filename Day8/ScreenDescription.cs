using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class ScreenDescription 
    {
        BankRepository br = new BankRepository();
        Display dis = new Display();
        public void FirstScreen()
        {
            Console.WriteLine("-----Welcome to Engine-------");
            Console.WriteLine("Enter a choice:\n1.Create new account \n2.Get account details\n3.Get all account details\n4.Deposite Amount\n5.Withraw Amount\n6.Get transaction details");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    createAccount();
                    break;
                case 2:
                    GetAccountDetails();
                    break;
                case 3:
                    GetAllAccountDetails();
                    break;
                case 4:
                    Deposite();
                    break;
                case 5:
                    Withdraw();
                    break;
                case 6:
                    GetTransactionDetails();
                    break;
                default:
                    Console.WriteLine("Enter valid choice:");
                    break;
            }
        }
        public void createAccount()
        {
            Console.WriteLine("Enter Account Number:");
            int acNo = int.Parse(Console.ReadLine());
            try
            {
                if (br.UserExists(acNo, true))
                {
                    Console.WriteLine("Enter Customer Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Customer Address:");
                    string address = Console.ReadLine();
                    br.NewAccount(new SBAccount(acNo, name, address, 0));
                }
                else
                {
                    throw new AccountAlreadyExistException("User Already Exists");
                }
            }
            catch (AccountAlreadyExistException e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }
        public void GetAccountDetails()
        {
            Console.WriteLine("Enter Account Number:");
            int acNo = int.Parse(Console.ReadLine());
            try
            {
                if (br.UserExists(acNo, true))
                {
                    throw new NoDataFoundException("User Not Found");
                }
                else
                {
                    Console.WriteLine("{0,-10}{1,-15}{2,-20}{3,-10}", "AcNumber", " CusName", "CusAddress", "Balance");
                    dis.display(br.GetAccountDetails(acNo));
                }
            }
            catch (NoDataFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetAllAccountDetails()
        {
            Console.WriteLine("{0,-10}{1,-15}{2,-20}{3,-10}", "AcNumber", " CusName", "CusAddress", "Balance");
            dis.display(br.GetAccountDetails());
        }
        public void Deposite()
        {
            Console.WriteLine("Enter Account Number:");
            int acNo = int.Parse(Console.ReadLine());
            try
            {
                if (br.UserExists(acNo, true))
                {
                    throw new NoDataFoundException("User Not Found");
                }
                else
                {
                    Console.WriteLine("Enter amount to deposite:");
                    double amount = double.Parse(Console.ReadLine());
                    br.DepositAmount(acNo, amount);
                }
            }
            catch (NoDataFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Withdraw()
        {
            Console.WriteLine("Enter Account Number:");
            int acNo = int.Parse(Console.ReadLine());
            try
            {
                if (br.UserExists(acNo, true))
                {
                    throw new NoDataFoundException("User Not Found");
                }
                else
                {
                    Console.WriteLine("Enter amount to withdraw:");
                    double amount = double.Parse(Console.ReadLine());
                    try
                    {
                        if (br.WithdrawAmount(acNo, amount, true))
                        {
                            Console.WriteLine($"{amount} withdrawn...");
                        }
                        else
                        {
                            throw new InsufficientBalanceException("Insufficientn Balance!");
                        }
                    }
                    catch (InsufficientBalanceException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (NoDataFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetTransactionDetails()
        {
            Console.WriteLine("Enter Account Number:");
            int acNo = int.Parse(Console.ReadLine());
            try
            {
                if (br.UserExists(acNo, true))
                {
                    throw new NoDataFoundException("User Not Found");
                }
                else
                {
                    Console.WriteLine("{0,-14} {1,-30} {2,-14} {3,-7} {4,-16} {5,-15}", "TransactionID", " TransactionTime", "AccountNumber", "Amount", "TransactionType", "UpdatedBalance");
                    dis.display(br.GetTransactions(acNo));
                }
            }
            catch (NoDataFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
