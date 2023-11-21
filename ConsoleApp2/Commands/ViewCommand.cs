using ConsoleApp2.Abstract;
using ConsoleApp2.Pets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Commands
{
    internal class ViewCommand : ICommand
    {
        private List<Pet> _pets;

        public ViewCommand(List<Pet> pets)
        {
            _pets = pets;
        }

        public void Execute()
        {
            if (_pets.Count != 0)
            {
                foreach (Pet pet in _pets)
                {
                    pet.Display();
                }
            }
            else
            {
                Console.WriteLine("There is nothing here.");
            }
        }
    }
}