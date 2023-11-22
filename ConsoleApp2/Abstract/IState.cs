using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Abstract
{
    // an interface class for all the states
    internal interface IState
    {
        // Renders the State
        void Render();
        // Get the command to execute
        ICommand GetCommand();
    }
}
