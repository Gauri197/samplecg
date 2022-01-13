using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
	class InsufficientBalanceException : Exception
	{
		public InsufficientBalanceException(string message) : base(message)
		{

		}
	}
	class AccountAlreadyExistException : Exception
	{
		public AccountAlreadyExistException(string message) : base(message)
		{

		}
	}
	class NoDataFoundException : Exception
    {
		public NoDataFoundException(string message) : base(message)
        {

        }
	}
}
