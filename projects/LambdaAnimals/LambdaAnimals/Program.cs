using System;
using System.Collections.Generic;

namespace LambdaAnimals {
    class Program {
        static void Main(string[] args) {
            Func<string> catType = () => { return "cat"; };
            Func<string> catSound = () => { return "meow"; };
            Func<string> dogType = () => { return "dog"; };
            Func<string> dogSound = () => { return "woof"; };

            // Create some Animal objects
            Animal cat1 = new Animal(catType, catSound);
            Animal cat2 = new Animal(catType, catSound);
            Animal cat3 = new Animal(catType, catSound);
            Animal dog1 = new Animal(dogType, dogSound);
            Animal dog2 = new Animal(dogType, dogSound);


            // Create a List<Animal>, and insert the Animal 
            // objects into the List
            List<Animal> animalList = new List<Animal>();
            animalList.Add(cat1);
            animalList.Add(cat2);
            animalList.Add(cat3);
            animalList.Add(dog1);
            animalList.Add(dog2);


            // Print out all Animal objects (or those matching
            // your selection criterion).
            foreach (Animal animal in animalList.FindAll((Animal a) => a.AnimalType == "cat")) { //find all cats
                Console.WriteLine(animal);
            }


            KeepConsoleWindowOpen();
        }


        private static void KeepConsoleWindowOpen() {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
