using System;
using System.Collections.Generic;
using System.Text;

namespace Aug11
{
    public class App
    {
        public static void Main()
        {
            ScreenDescription desc = new ScreenDescription();
            do
            {
                desc.showFirstScreen();
            } while (true);
        }
    }
}
