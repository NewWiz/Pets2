using ConsoleApp2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Commands
{
    // Command for selecting a pet to take actions with
    internal class SelectCommand : ICommand
    {
        private List<Pet> _pets;
        private string _input;

        // Takes in an input of the pet name and the list of pets
        public SelectCommand(string input, List<Pet> pets)
        {
            _pets = pets;
            _input = input;
        }

        // Execute must be implemented as it is abstract but it can't be used to fetch pet since it needs a return value.
        public void Execute()
        {

        }

        // function to get pet, returns said pet
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
