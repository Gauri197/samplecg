using System;

namespace BankManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ScreenDescription sd = new ScreenDescription();
            do
            {
                sd.FirstScreen();
            } while (true);
        }
    }
}
