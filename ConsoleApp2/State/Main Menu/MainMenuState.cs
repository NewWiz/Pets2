using ConsoleApp2.Abstract;
using ConsoleApp2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.State
{
    // This is the main menu where you can start a new game, save your game, or load a game from a save file
    internal class MainMenuState : IState
    {
        private StateManager _manager;
        private List<Pet> _pets;

        // Two constructors, one for starting and one with a pets list when game is active
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
            // Render is first called after instantiating the state, renders the state
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
                // Opens the PetMenu State
                return new SwitchStateCommand(_manager, new PetMenuState(_manager));
            }    
            if (command == "load")
            {
                // Opens the load state
                return new SwitchStateCommand(_manager, new LoadState(_manager, this));
            }
            else if (command == "save")
            {
                // Opens the save state
                return new SwitchStateCommand(_manager, new SaveState(_manager, this, _pets));
            }
            else if (command == "exit")
            {
                // exits the program with a code of 0
                Environment.Exit(0);
                return null;
            }
            else
            {
                // error handling for invalid commands
                return new InvalidCommand();
            }
        }
    }
}
