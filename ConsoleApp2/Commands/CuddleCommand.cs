using ConsoleApp2.Abstract;
using ConsoleApp2.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Commands
{
    internal class CuddleCommand : ICommand
    {
        private Pet _pet;

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
