using ConsoleApp2.Abstract;
using ConsoleApp2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2.State
{
    // State for adding the breed of the pet
    internal class BreedState : IState
    {
        private StateManager _manager;
        private List<Pet> _pets;
        private Pet _pet;

        public BreedState(StateManager manager, IState lastState, List<Pet> pets, Pet pet)
        {
            _manager = manager;
            _pets = pets;
            _pet = pet;
        }

        public void Render()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("------- Add Pet -------");
            Console.WriteLine(" Enter the breed: -----");
            Console.WriteLine("[back] - go back ------");
            Console.WriteLine("-----------------------");
        }

        public ICommand GetCommand()
        {
            var input = Console.ReadLine();
            if (input == "back")
            {
                return new SwitchStateCommand(_manager, new PetMenuState(_manager, _pets));
            }
            else
            {
                if (input != null)
                {
                    // Inputs the breed of the pet then inputs it into the Pet list then returns to the add state
                    _pet.Breed = input;
                    _pets.Add(_pet);
                    return new SwitchStateCommand(_manager, new AddState(_manager, _pets));
                }
                else
                {
                    return new InvalidCommand();
                }
            }
        }
    }
}
