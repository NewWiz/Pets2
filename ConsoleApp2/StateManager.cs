using System.Linq;
using ConsoleApp2.Abstract;

namespace ConsoleApp2
{
    class StateManager
    {
        private IState _state;

        // Switches the state to the given state
        public void SwitchState(IState state)
        {
            _state = state;
        }

        // Runs the program, the initial state being the main menu
        public void Run(IState initialState)
        {
            _state = initialState;

            // Infinite loop until you exit from the main menu to render, get input using console.readline and then executing the command.
            while (true)
            {
                // Renders the current state
                _state.Render();
                // Gets the command from input to the console to Execute();
                var command = _state.GetCommand();
                // Clear the console for the next state or command.
                Console.Clear();
                // Execute the command
                command.Execute();
            }
        }
    }
}