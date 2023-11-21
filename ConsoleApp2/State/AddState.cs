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
    internal class AddState : IState
    {
        private StateManager _manager;
        private List<Pet> _pets;

        public AddState(StateManager manager, List<Pet> pets)
        {
            _manager = manager;
            _pets = pets;
        }

        public void Render()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("------- Add Pet -------");
            Console.WriteLine("[add] - add a pet -----");
            Console.WriteLine("[back] - go back ------");
            Console.WriteLine("-----------------------");
        }

        public ICommand GetCommand()
        {
            var input = Console.ReadLine();
            if (input == "add")
            {
                return new SwitchStateCommand(_manager, new CategoryState(_manager, this, _pets));
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