using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Pets
{
    // abstract class since it has abstract methods, no need to instantiate this class.
    abstract class Pet
    {
        // Encapsulation of data
        private string _name;
        private string _breed;
        private string _category;

        // Getters and setters for name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        // Getters and setters for breed
        public string Breed
        {
            get { return _breed; }
            set { _breed = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        // abstract methods which are overriden in child classes
        public abstract void Display();
        public abstract void Cuddle();
        public abstract void Selfie();
        public abstract void Brush();

    }
    // All types of pets inherit from Pet. You have to choose a pet type in the menu when selecting '1'.
    // Dog class
    class Dog : Pet
    {
        public Dog() { }
        public Dog(string name, string breed, string category)
        {
            Name = name;
            Breed = breed;
            Category = category;
        }
        public override void Display()
        {
            Console.WriteLine("Type: Dog, Name: {0}, Breed: {1}", Name, Breed);
        }

        public override void Cuddle()
        {
            Console.WriteLine("*Bark!* You snugly cuddle up with {0} <3", Name);
        }

        public override void Selfie()
        {
            Console.WriteLine("*Click*, you snapped a selfie with {0}!", Name);
        }
        public override void Brush()
        {
            Console.WriteLine("*Woof!* {0} licks you as you brush them.", Name);
        }
    }
    // Cat class
    class Cat : Pet
    {
        public Cat() { }
        public Cat(string name, string breed, string category)
        {
            Name = name;
            Breed = breed;
            Category = category;
        }
        public override void Display()
        {
            Console.WriteLine("Type: Cat, Name: {0}, Breed: {1}", Name, Breed);
        }

        public override void Cuddle()
        {
            Console.WriteLine("*Meow!* You snugly cuddle up with {0} <3", Name);
        }

        public override void Selfie()
        {
            Console.WriteLine("*Click*, you snapped a selfie with {0}!", Name);
        }
        public override void Brush()
        {
            Console.WriteLine("*Purrr!* {0} purrs as you brush them.", Name);
        }
    }
    // Bird class
    class Bird : Pet
    {
        public Bird() { }
        public Bird(string name, string breed, string category)
        {
            Name = name;
            Breed = breed;
            Category = category;
        }
        public override void Display()
        {
            Console.WriteLine("Type: Bird, Name: {0}, Breed: {1}", Name, Breed);
        }

        public override void Cuddle()
        {
            Console.WriteLine("*Tweet!* You snugly cuddle up with {0} <3", Name);
        }

        public override void Selfie()
        {
            Console.WriteLine("*Click*, you snapped a selfie with {0}!", Name);
        }
        public override void Brush()
        {
            Console.WriteLine("*Cooo!* {0} looks delighted as you brush them.", Name);
        }
    }
}
