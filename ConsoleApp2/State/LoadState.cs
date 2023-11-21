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
    internal class LoadState : IState
    {
        private StateManager _manager;
        private IState _lastState;
        private List<Pet> _pets;

        public LoadState(StateManager manager, IState lastState)
        {
            _manager = manager;
            _lastState = lastState;
        }

        public void Render()
        {

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
            Console.WriteLine("[start] ---------------");
            Console.WriteLine("[back] ----------------");
            Console.WriteLine("-----------------------");
        }

        public ICommand GetCommand()
        {
            var input = Console.ReadLine();
            if (input == "back")
            {
                return new SwitchStateCommand(_manager, _lastState, _pets);
            } else if (input == "start")
            {
                return new SwitchStateCommand(_manager, new PetMenuState(_manager, _pets));
            }
            else
            {
                LoadCommand lc = new LoadCommand();
                _pets = lc.LoadFile(input);
                return new LoadCommand();
            }

        }
    }
}
