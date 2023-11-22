using ConsoleApp2.Abstract;
using ConsoleApp2.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Commands
{
    // The command that manages switching between states
    internal class SwitchStateCommand : ICommand
    {
        private StateManager _manager;
        private IState _newState;

        public SwitchStateCommand(StateManager manager, IState newState)
        {
            _manager = manager;
            _newState = newState;
        }

        public void Execute()
        {
            _manager.SwitchState(_newState);
        }
    }
}
