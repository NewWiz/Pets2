using ConsoleApp2.Abstract;
using ConsoleApp2.Pets;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Commands
{
    // Command that loads save files
    internal class LoadCommand : ICommand
    {
        //creates a new list for pets
        private List<Pet> _pets = new List<Pet>();

        // Once finished loading the file StateManager will call to execute the success message
        public void Execute()
        {
            Console.WriteLine("Successfully loaded save file.");
        }

        // Main function that loads save files, takes in input name by user and returns the list of pets after adding each pet from the save file into a list.
        public List<Pet> LoadFile(string input)
        {
            string directoryPath = @"..\..\..\Save Files";
            string path = $"\\{input}.txt";

            // checks if the file exists or not
            if(File.Exists(directoryPath+path))
            {
                // uses newtonsoft.json to deserialze the data from the save file into a dictionary list of string, string. Could not directly deserialize into a Pet list since Pet is an abstract class
                string jsonData = File.ReadAllText(directoryPath + path);
                var dictionaryList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonData);

                // iterates through the dictionary to find the category key and to determine which type of pet it is then adds the pet to the Pet list.
                foreach (var dictionary in dictionaryList)
                {
                    if (dictionary.ContainsKey("Category") && dictionary.ContainsValue("Dog"))
                    {
                        Dog dog = new Dog(GetName(dictionary), GetBreed(dictionary), "Dog");
                        _pets.Add(dog);
                    }
                    else if (dictionary.ContainsKey("Category") && dictionary.ContainsValue("Cat"))
                    {
                        Cat cat = new Cat(GetName(dictionary), GetBreed(dictionary), "Cat");
                        _pets.Add(cat);
                    }
                    else if (dictionary.ContainsKey("Category") && dictionary.ContainsValue("Bird"))
                    {
                        Bird bird = new Bird(GetName(dictionary), GetBreed(dictionary), "Bird");
                        _pets.Add(bird);
                    }
                }
            }
            else
            {
                // If file does not exist 
                Console.WriteLine("That file does not exist.");
            }
            // return the list of pets
            return _pets;

            // simple functions, reusable code for getting the pet's name and breed
            string GetName(Dictionary<string, string> dict)
            {
                dict.TryGetValue("Name", out string name);
                return name;
            }

            string GetBreed(Dictionary<string, string> dict)
            {
                dict.TryGetValue("Name", out string breed);
                return breed;
            }

        }
    }
}
