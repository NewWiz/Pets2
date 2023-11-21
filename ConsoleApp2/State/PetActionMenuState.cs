using ConsoleApp2.Abstract;
using ConsoleApp2.Commands;
using ConsoleApp2.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.State
{
    internal class PetActionMenuState : IState
    {
        private StateManager _manager;
        private List<Pet> _pets;
        private Pet _pet;

        public PetActionMenuState(StateManager manager, List<Pet> pets, Pet pet)
        {
            _manager = manager;
            _pets = pets;
            _pet = pet;
        }

        public void Render()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("------ Pet Game -------");
            Console.WriteLine("[cuddle] - cuddle pet -");
            Console.WriteLine("[selfie] - snap a pic -");
            Console.WriteLine("[groom] - brush pet ---");
            Console.WriteLine("[back] - pet menu -----");
            Console.WriteLine("-----------------------");
        }

        public ICommand GetCommand()
        {
            var input = Console.ReadLine();
            if (input == "cuddle")
            {
                _pet.Cuddle();
                return new CuddleCommand(_pet);
            }
            else if (input == "selfie")
            {
                _pet.Selfie();
                return new SelfieCommand(_pet);
            }
            else if (input == "groom")
            {
                _pet.Brush();
                return new GroomCommand(_pet);
            }
            else if (input == "back")
            {
                return new SwitchStateCommand(_manager, new PetMenuState(_manager, _pets));
            }
            else
            {
                return new InvalidCommand();
            }
        }
    }

}
