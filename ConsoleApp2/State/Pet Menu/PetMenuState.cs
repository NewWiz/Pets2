using ConsoleApp2.Abstract;
using ConsoleApp2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.State
{
    // This is the Pet Game Menu
    internal class PetMenuState : IState
    {
        private StateManager _manager;
        private List<Pet> _pets;

        // If entering a new game from the Main Menu, instantiates a new list of Pets
        public PetMenuState(StateManager manager)
        {
            _manager = manager;
            if (_pets == null)
            {
                _pets = new List<Pet>();
            }
        }

        // If an active game has already started then it takes in the already instantiated list
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
                // View a list of current pets
                return new ViewCommand(_pets);
            }
            else if (input == "add")
            {
                // Takes you to the category state to enter a new pet
                return new SwitchStateCommand(_manager, new CategoryState(_manager, this, _pets));
            }
            else if (input == "sel")
            {
                // Selects a pet from the list of pets
                return new SwitchStateCommand(_manager, new SelectState(_manager, this, _pets));
            }
            else if (input == "menu")
            {
                // Back to main menu
                return new SwitchStateCommand(_manager, new MainMenuState(_manager, _pets));
            }
            else
            {
                // Error handling
                return new InvalidCommand();
            }
        }
    }
}
