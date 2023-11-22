using ConsoleApp2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Pets
{
    //Dog class - inherits from Pet
    internal class Dog : Pet
    {
        public Dog() { }
        // Has 3 properties, name, breed, and category
        public Dog(string name, string breed, string category)
        {
            Name = name;
            Breed = breed;
            Category = category;
        }
        // Display info about pet
        public override void Display()
        {
            Console.WriteLine("Type: Dog, Name: {0}, Breed: {1}", Name, Breed);
        }
        // Cuddle with pet
        public override void Cuddle()
        {
            Console.WriteLine("*Bark!* You snugly cuddle up with {0} <3", Name);
        }
        // Take a selfie with pet
        public override void Selfie()
        {
            Console.WriteLine("*Click*, you snapped a selfie with {0}!", Name);
        }
        // Groom or brush pet
        public override void Brush()
        {
            Console.WriteLine("*Woof!* {0} licks you as you brush them.", Name);
        }
    }
}




