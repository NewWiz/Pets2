using ConsoleApp2.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate a new StateManager
            var manager = new StateManager();
            manager.Run(new MainMenuState(manager));
        }
    }
}
