using ConsoleApp2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Commands
{
    // Command that executes the cuddle function
    internal class CuddleCommand : ICommand
    {
        private Pet _pet;

        // Implement with the selected pet
        public CuddleCommand(Pet pet)
        {
            _pet = pet;
        }

        public void Execute()
        {
            _pet.Cuddle();
        }
    }
}
