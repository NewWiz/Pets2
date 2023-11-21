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
    internal class SaveState : IState
    {
        private StateManager _stateManager;
        private IState _lastState;
        private List<Pet> _pets;

        public SaveState(StateManager stateManager, IState lastState, List<Pet> pets)
        {
            _stateManager = stateManager;
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
                    return new SwitchStateCommand(_stateManager, _lastState, _pets);
                }
                else
                {
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
