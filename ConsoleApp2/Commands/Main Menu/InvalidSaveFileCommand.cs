using ConsoleApp2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Commands
{
    internal class InvalidSaveFileCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("You must select a file first");
        }
    }
}
