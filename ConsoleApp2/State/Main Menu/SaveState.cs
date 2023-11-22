using ConsoleApp2.Abstract;
using ConsoleApp2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.State
{
    // Save State, all states inherit from IState
    internal class SaveState : IState
    {
        private StateManager _manager;
        private IState _lastState;
        private List<Pet> _pets;

        // Takes in the list of pets to save
        public SaveState(StateManager manager, IState lastState, List<Pet> pets)
        {
            _manager = manager;
            _lastState = lastState;
            _pets = pets;
        }

        public void Render()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("------ Save Game ------");
            Console.WriteLine(" Enter a file name: ---");
            Console.WriteLine("[back] ----------------");
            Console.WriteLine("-----------------------");
        }

        public ICommand GetCommand()
        {
            var input = Console.ReadLine();
            if (input != null)
            {
                if (input == "back")
                {
                    // Switches state passing in the current manager and the last state
                    return new SwitchStateCommand(_manager, _lastState);
                }
                else
                {
                    // Instantiates a new save command with the pets list and the input being the file name to save
                    return new SaveCommand(_pets, input);
                }

            }
            else
            {
                return new InvalidCommand();
            }
        }
    }
}
