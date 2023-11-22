using ConsoleApp2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2.Commands
{
    // Executes the groom or 'brush' command
    internal class GroomCommand : ICommand
    {
        private Pet _pet;

        // Implement with the selected pet
        public GroomCommand(Pet pet)
        {
            _pet = pet;
        }

        public void Execute()
        {
            _pet.Brush();
        }
    }
}
