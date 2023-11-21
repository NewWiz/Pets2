using ConsoleApp2.Abstract;
using ConsoleApp2.Commands;
using ConsoleApp2.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2.State
{
    internal class BreedState : IState
    {
        private StateManager _manager;
        private IState _lastState;
        private List<Pet> _pets;
        private Pet _pet;

        public BreedState(StateManager stateManager, IState lastState, List<Pet> pets, Pet pet)
        {
            _manager = stateManager;
            _lastState = lastState;
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
