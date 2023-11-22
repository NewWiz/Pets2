using ConsoleApp2.Abstract;
using ConsoleApp2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.State
{
    // This is the menu to perform certain actions on your selected pet
    internal class PetActionMenuState : IState
    {
        private StateManager _manager;
        private IState _lastState;
        private List<Pet> _pets;
        private Pet _pet;

        public PetActionMenuState(StateManager manager, IState lastState, List<Pet> pets, Pet pet)
        {
            _manager = manager;
            _lastState = lastState;
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
            Console.WriteLine("[back] - select pet ---");
            Console.WriteLine("-----------------------");
        }

        // Takes the command then performs the function overridden from the Pet abstract class
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
                // Return to the pet menu
                return new SwitchStateCommand(_manager, _lastState);
            }
            else
            {
                return new InvalidCommand();
            }
        }
    }

}
