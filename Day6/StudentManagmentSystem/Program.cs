using System;

namespace Student3rdPart
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInterface desc = new ScreenDescription();
            while (true)
            {
                desc.showFirstScreen();

            }
        }
    }
}
    

