using ConsoleApp2.Abstract;
using ConsoleApp2.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp2.Commands
{
    internal class SaveCommand : ICommand
    {
        private List<Pet> _pets;
        private string _fileName;

        public SaveCommand(List<Pet> pets, string fileName)
        {
            _pets = pets;
            _fileName = fileName;
        }

        public void Execute()
        {
            // Save directory file path
            string directoryPath = @"..\..\..\Save Files";
            string path = String.Format("\\{0}.txt", _fileName);

            // Check if the directory does not exist
            if (!Directory.Exists(directoryPath))
            {
                // Create the directory
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine("Directory created successfully.");
            }
            if (_pets != null && _pets.Count != 0)
            {
                string jsonData = JsonConvert.SerializeObject(_pets);
                File.WriteAllText(directoryPath+path, jsonData);
                Console.WriteLine("Save successful!");
            }
            else
            {
                Console.WriteLine("Your pet list is empty");
            }
        }
    }
}
