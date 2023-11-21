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
    internal class LoadCommand : ICommand
    {
        private List<Pet> _pets = new List<Pet>();

        public void Execute()
        {
            Console.WriteLine("Successfully loaded save file.");
        }

        public List<Pet> LoadFile(string input)
        {
            string directoryPath = @"..\..\..\Save Files";
            string path = $"\\{input}.txt";

            if(File.Exists(directoryPath+path))
            {
                string jsonData = File.ReadAllText(directoryPath + path);
                var dictionaryList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonData);
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
                Console.WriteLine("Successfully loaded save file.");
            }
            else
            {
                Console.WriteLine("That file does not exist.");
            }
            return _pets;

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
