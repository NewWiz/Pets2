using ConsoleApp2.Abstract;
using ConsoleApp2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.State
{
    // State for loading from a file
    internal class LoadState : IState
    {
        private StateManager _manager;
        private IState _lastState;
        private List<Pet> _pets;

        // Takes in the statemanager and laststate for the back function
        public LoadState(StateManager manager, IState lastState)
        {
            _manager = manager;
            _lastState = lastState;
        }

        public void Render()
        {
            // List current save files
            string directoryPath = @"..\..\..\Save Files";

            if (Directory.Exists(directoryPath)) {
                string[] files = Directory.GetFiles(directoryPath);
                if (files.Length != 0)
                {
                    Console.WriteLine("Save Files:");
                    foreach (string file in files)
                    Console.WriteLine(Path.GetFileNameWithoutExtension(file));
                }
                else
                {
                    Console.WriteLine("There are no active saves.");
                }
            }
            else
            {
                Console.WriteLine("There are no active saves.");
            }

            Console.WriteLine("-----------------------");
            Console.WriteLine("------ Load Game ------");
            Console.WriteLine("Enter the file name ---");
            Console.WriteLine("[start] -- start game -");
            Console.WriteLine("[back] ---- go back ---");
            Console.WriteLine("-----------------------");
        }

        public ICommand GetCommand()
        {
            var input = Console.ReadLine();
            if (input == "back")
            {
                return new SwitchStateCommand(_manager, _lastState);
            } else if (input == "start")
            {
                // You cannot start unless you pick a save file
                if (_pets != null)
                {
                    return new SwitchStateCommand(_manager, new PetMenuState(_manager, _pets));
                }
                else
                {
                    return new InvalidSaveFileCommand();
                }
            }
            else
            {
                // Runs LoadFile() from LoadCommand to load the file.
                LoadCommand lc = new LoadCommand();
                _pets = lc.LoadFile(input);
                // Executes the success message
                return new LoadCommand();
            }

        }
    }
}
