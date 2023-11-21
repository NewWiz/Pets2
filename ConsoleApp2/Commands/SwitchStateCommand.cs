using ConsoleApp2.Abstract;
using ConsoleApp2.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Commands
{
    internal class SwitchStateCommand : ICommand
    {
        private StateManager _manager;
        private IState _newState;
        private List<Pet> _pets;
        private Pet _pet;

        public SwitchStateCommand() { }

        public SwitchStateCommand(StateManager manager, IState newState)
        {
            _manager = manager;
            _newState = newState;
        }

        public SwitchStateCommand(StateManager manager, IState newState, List<Pet> pets)
        {
            _manager = manager;
            _newState = newState;
            _pets = pets;
        }

        public void Execute()
        {
            _manager.SwitchState(_newState);
        }
    }
}
