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
    internal class MainMenuState : IState
    {
        private StateManager _manager;
        private List<Pet> _pets;

        public MainMenuState(StateManager manager)
        {
            _manager = manager;
        }

        public MainMenuState(StateManager manager, List<Pet> pets)
        {
            _manager = manager;
            _pets = pets;
        }

        public void Render()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("------- Main Menu -----");
            Console.WriteLine("------- Pet Game ------");
            Console.WriteLine("[new] - new game ------");
            Console.WriteLine("[save] - save game ----");
            Console.WriteLine("[load] - load game ----");
            Console.WriteLine("[exit] - exit game ----");
            Console.WriteLine("-----------------------");
        }

        public ICommand GetCommand()
        {
            var command = Console.ReadLine();
            if (command == "new")
            {
                return new SwitchStateCommand(_manager, new PetMenuState(_manager));
            }    
            if (command == "load")
            {
                return new SwitchStateCommand(_manager, new LoadState(_manager, this));
            }
            else if (command == "save")
            {
                return new SwitchStateCommand(_manager, new SaveState(_manager, this, _pets));
            }
            else if (command == "exit")
            {
                Environment.Exit(0);
                return null;
            }
            else
            {
                return new InvalidCommand();
            }
        }
    }
}
