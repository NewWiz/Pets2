using ConsoleApp2.Abstract;
using ConsoleApp2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.State
{
    // State for selecting a pet
    internal class SelectState : IState
    {
        private StateManager _manager;
        private IState _lastState;
        private List<Pet> _pets;
        private Pet _pet;

        // Takes in the manager, last state, and list of pets
        public SelectState(StateManager manager, IState lastState, List<Pet> pets)
        {
            _manager = manager;
            _lastState = lastState;
            _pets = pets;
        }

        public void Render()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("------ Pet Game -------");
            Console.WriteLine(" Enter a pet name: ----");
            Console.WriteLine("[back] -- go back -----");
            Console.WriteLine("-----------------------");
        }

        public ICommand GetCommand()
        {
            var input = Console.ReadLine();
            if (input == "back")
            {
                return new SwitchStateCommand(_manager, _lastState);
            }
            else
            {
                // Instantiates the Select Command with the input name of pet to find and the pets list
                var sc = new SelectCommand(input, _pets);
                if (sc.GetPet() != null)
                {
                    // Returns a pet from the name entered in the input
                    _pet = sc.GetPet();
                    return new SwitchStateCommand(_manager, new PetActionMenuState(_manager, this, _pets, _pet));
                }
                else
                {
                    return new InvalidPetCommand();
                }
            }
        }
    }
}
