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
            // Instantiate a new StateManager and runs the Main Menu. The manager is passed to each state when instantiated.
            var manager = new StateManager();
            manager.Run(new MainMenuState(manager));
        }
    }
}
