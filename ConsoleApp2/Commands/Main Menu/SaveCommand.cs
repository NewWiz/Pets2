using ConsoleApp2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp2.Commands
{
    // class that executes the save command
    internal class SaveCommand : ICommand
    {
        private List<Pet> _pets;
        private string _fileName;

        // Takes in the current list of pets and a filename input by the user.
        public SaveCommand(List<Pet> pets, string fileName)
        {
            _pets = pets;
            _fileName = fileName;
        }

        public void Execute()
        {
            // Save directory file path (project folder)
            string directoryPath = @"..\..\..\Save Files";
            string path = String.Format("\\{0}.txt", _fileName);

            // Check if the directory does not exist
            if (!Directory.Exists(directoryPath))
            {
                // Create the directory
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine("Directory created successfully.");
            }
            // Checks if the pet list is null or empty (has not been instantiated or has not been added to)
            if (_pets != null && _pets.Count != 0)
            {
                // Convert the pets list into JsonData and save it to a .txt file
                string jsonData = JsonConvert.SerializeObject(_pets);
                File.WriteAllText(directoryPath+path, jsonData);
                Console.WriteLine("Save successful!");
            }
            else
            {
                // If null or empty prints:
                Console.WriteLine("Your pet list is empty");
            }
        }
    }
}
