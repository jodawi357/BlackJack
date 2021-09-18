using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Console
{
    public class ProgramUI
    {
        public void Run()
        {
            MainMenu();
        }
        public void MainMenu()
        {
            bool menuLoop = true;
            while(menuLoop == true)
            {
                System.Console.WriteLine("BlackJack Table\n\n" +
                    "Press 'Spacebar' to have a seat.\n" +
                    "Press any other key to exit.");
                System.Console.ReadKey();
            }
        }
        

    }
}

// Output Channel Consumer is operating with reduced functionality due to a missing dependency service: Microsoft.VisualStudio.Shell.OutputChannelStore (0.1).