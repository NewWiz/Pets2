using ConsoleApp2.Abstract;
using ConsoleApp2.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Commands
{
    internal class SelectCommand : ICommand
    {
        private List<Pet> _pets;
        private string _input;

        public SelectCommand(string input, List<Pet> pets)
        {
            _pets = pets;
            _input = input;
        }

        public void Execute()
        {

        }

        public Pet GetPet()
        {
            foreach (Pet pet in _pets)
            {
                if (pet.Name == _input)
                {
                    return pet;
                }
                else
                {
                    Console.WriteLine("That pet is not on the list.");
                }
            }
            return null;
        }
    }
}
