using ConsoleApp2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Pets
{
    // Bird class inherits from Pet
    internal class Bird : Pet
    {
        public Bird() { }
        // Has 3 properties, name, breed, and category
        public Bird(string name, string breed, string category)
        {
            Name = name;
            Breed = breed;
            Category = category;
        }
        // Display info about pet
        public override void Display()
        {
            Console.WriteLine("Type: Bird, Name: {0}, Breed: {1}", Name, Breed);
        }

        // Cuddle with pet
        public override void Cuddle()
        {
            Console.WriteLine("*Tweet!* You snugly cuddle up with {0} <3", Name);
        }

        // Take a selfie with pet
        public override void Selfie()
        {
            Console.WriteLine("*Click*, you snapped a selfie with {0}!", Name);
        }

        // Groom or brush pet
        public override void Brush()
        {
            Console.WriteLine("*Cooo!* {0} looks delighted as you brush them.", Name);
        }
    }
}
