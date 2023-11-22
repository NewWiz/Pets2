using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Abstract
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
        // Getters and setters for category. Categories are Dog, Cat, Bird
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

}
