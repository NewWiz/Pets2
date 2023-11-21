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
    internal class CategoryState : IState
    {
        private StateManager _manager;
        private IState _lastState;
        private List<Pet> _pets;

        public CategoryState(StateManager stateManager, IState lastState, List<Pet> pets)
        {
            _manager = stateManager;
            _lastState = lastState;
            _pets = pets;
        }

        public void Render()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("----- Add Pet -----");
            Console.WriteLine("[dog] - add a dog -");
            Console.WriteLine("[cat] - add a cat -");
            Console.WriteLine("[bird] - add a bird");
            Console.WriteLine("[back] - go back --");
            Console.WriteLine("-------------------");
        }

        public ICommand GetCommand()
        {
            var input = Console.ReadLine();
            if (input == "dog")
            {
                Dog dog = new Dog();
                dog.Category = "Dog";
                return new SwitchStateCommand(_manager, new NameState(_manager, this, _pets, dog));
            }
            else if (input == "cat")
            {
                Cat cat = new Cat();
                cat.Category = "Cat";
                return new SwitchStateCommand(_manager, new NameState(_manager, this, _pets, cat)); ;
            }
            else if (input == "bird")
            {
                Bird bird = new Bird();
                bird.Category = "Bird";
                return new SwitchStateCommand(_manager, new NameState(_manager, this, _pets, bird)); ;
            }
            else if (input == "back")
            {
                return new SwitchStateCommand(_manager, _lastState);
            }
            else
            {
                return new InvalidCommand();
            }
        }
    }
}