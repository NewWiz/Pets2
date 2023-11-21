using System.Linq;
using ConsoleApp2.Abstract;

namespace ConsoleApp2
{
    class StateManager
    {
        private IState _state;

        public void SwitchState(IState state)
        {
            _state = state;
        }

        public void Run(IState initialState)
        {
            _state = initialState;

            while (true)
            {
                _state.Render();
                var command = _state.GetCommand();
                Console.Clear();
                command.Execute();
            }
        }
    }
}