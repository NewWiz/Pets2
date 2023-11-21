using ConsoleApp2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Commands
{
    internal class InvalidCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Invalid command");
        }
    }
}
