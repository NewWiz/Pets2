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
    internal class ViewState : IState
    {
        private StateManager _manager;
        private IState _lastState;
        private List<Pet> _pets;

        public ViewState(StateManager stateManager, IState lastState, List<Pet> pets)
        {
            _manager = stateManager;
            _lastState = lastState;
            _pets = pets;
        }

        public void Render()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("------ View Pets ------");
            Console.WriteLine("[view] - view pets ----");
            Console.WriteLine("[back] - go back ------");
            Console.WriteLine("-----------------------");
        }

        public ICommand GetCommand()
        {
            var input = Console.ReadLine();
            if (input == "view")
            {
                return new ViewCommand(_pets);
            }
            else if (input == "back")
            {
                return new SwitchStateCommand(_manager, _lastState, _pets);
            }
            else
            {
                return new InvalidCommand();
            }
        }
    }
}
