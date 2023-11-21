using ConsoleApp2.Pets;
using ConsoleApp2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2.Commands
{
    internal class SelfieCommand : ICommand
    {
        private Pet _pet;

        public SelfieCommand(Pet pet)
        {
            _pet = pet;
        }

        public void Execute()
        {
            _pet.Selfie();
        }
    }
}
