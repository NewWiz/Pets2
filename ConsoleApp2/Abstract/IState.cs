using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Abstract
{
    internal interface IState
    {
        void Render();
        ICommand GetCommand();
    }
}
