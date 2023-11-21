using ConsoleApp2.Abstract;
using ConsoleApp2.Pets;
using ConsoleApp2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.State
{
    internal class PetMenuState : IState
    {
        private StateManager _manager;
        private List<Pet> _pets;

        public PetMenuState(StateManager manager)
        {
            _manager = manager;
            _pets = new List<Pet>();
        }

        public PetMenuState(StateManager manager, List<Pet> pets)
        {
            _manager = manager;
            _pets = pets;
        }

        public void Render()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("------ Pet Game -------");
            Console.WriteLine("[view] - view pets ----");
            Console.WriteLine("[add] - add a pet -----");
            Console.WriteLine("[sel] - select a pet --");
            Console.WriteLine("[menu] - main menu ----");
            Console.WriteLine("-----------------------");
        }

        public ICommand GetCommand()
        {
            var input = Console.ReadLine();
            if (input == "view")
            {
                return new ViewCommand(_pets);
            }
            else if (input == "add")
            {
                return new SwitchStateCommand(_manager, new CategoryState(_manager, this, _pets));
            }
            else if (input == "sel")
            {
                return new SwitchStateCommand(_manager, new SelectState(_manager, this, _pets));
            }
            else if (input == "menu")
            {
                return new SwitchStateCommand(_manager, new MainMenuState(_manager, _pets));
            }
            else
            {
                return new InvalidCommand();
            }
        }
    }
}
