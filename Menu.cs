using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Ezednevnik
{
    internal class Menu
    {

        public void Show()
        {
            int pos = 2;
            ConsoleKeyInfo key;
            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");


                key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow && pos != 1)
                {
                    pos--;
                    if (pos == 1)
                    {
                        pos = 3;
                    }
                }

                if (key.Key == ConsoleKey.DownArrow && pos != 5)
                {
                    pos++;
                    if (pos == 4)
                    {
                        pos = 2;
                    }
                }


                Console.SetCursorPosition(0, 10);
            } while (key.Key != ConsoleKey.Spacebar) ;
         /*   return key;
*/
        }
    }
}
