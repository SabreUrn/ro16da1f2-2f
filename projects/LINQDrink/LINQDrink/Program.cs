using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable UnusedParameter.Local

namespace LINQDrink
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Create drinks
            List<Drink> drinks = new List<Drink>();
            drinks.Add(new Drink("Cuba Libre", "Rum", 3, "Cola", 20));
            drinks.Add(new Drink("Russia Libre", "Vodka", 3, "Cola", 20));
            drinks.Add(new Drink("The Day After", "None", 0, "Water", 20));
            drinks.Add(new Drink("Red Mule", "Vodka", 3, "Fanta", 20));
            drinks.Add(new Drink("Double Straight", "Whiskey", 6, "None", 0));
            drinks.Add(new Drink("Pearly Temple", "None", 0, "Sprite", 20));
            drinks.Add(new Drink("High Spirit", "Vodka", 6, "Sprite", 20));
            drinks.Add(new Drink("Watered Down", "Whiskey", 3, "Water", 3));
            drinks.Add(new Drink("Caribbean Gold", "Rum", 6, "Fanta", 20));
            drinks.Add(new Drink("Siberian Zone", "Vodka", 6, "None", 0));
            #endregion

            //names of all drinks
            Console.WriteLine("Exercise 1:");
            drinks.ToList().ForEach(d => Console.WriteLine(d.Name));
            Console.WriteLine();

            //names of all non-alcoholic drinks
            Console.WriteLine("Exercise 2:");
            drinks.Where(d => d.AlcoholicPartAmount == 0).ToList().ForEach(d => Console.WriteLine(d.Name));
            Console.WriteLine();

            //names, alcohol parts, alcohol amounts of all alcoholic drinks
            Console.WriteLine("Exercise 3:");
            IEnumerable<Drink> namesNParts = from d in drinks
                                             where d.AlcoholicPartAmount > 0
                                             select d;
            foreach(Drink d in namesNParts) {
                Console.WriteLine("{0} contains {1} parts {2}",
                    d.Name, d.AlcoholicPartAmount, d.AlcoholicPart);
            }
            //drinks.Where(d => d.AlcoholicPartAmount > 0).ToList().foreach (d => console.writeline("{0} contains {1} parts {2}",
            //     d.name, d.alcoholicpartamount, d.alcoholicpart));
            Console.WriteLine();

            //names of all drinks alphabetically
            Console.WriteLine("Exercise 4:");
            drinks.OrderBy(d => d.Name).ToList().ForEach(d => Console.WriteLine(d.Name));
            Console.WriteLine();

            //amount of alchol in all drinks
            Console.WriteLine("Exercise 5:");
            drinks.ToList().ForEach(d => Console.WriteLine("{0} has {1} parts alcohol", d.Name, d.AlcoholicPartAmount));
            Console.WriteLine();

            //average amount of alcohol in drinks with alcohol'
            Console.WriteLine("Exercise 6:");
            double average = (from drink in drinks
                              where drink.AlcoholicPartAmount > 0
                              select drink.AlcoholicPartAmount)
                              .Average();
            Console.WriteLine(average);

            //names and alcohol parts of all drinks grouped by alcohol part
            Console.WriteLine("Exercise 7:");
            var grouped = from drink in drinks
                           group drink by drink.AlcoholicPart;
            foreach(var parts in grouped) {
                string contentOutput = ""; //string for printing out at the end of each parts. remove last ", ", better than cw
                contentOutput += parts.Key + "is used in";
                foreach(var drink in drinks) {
                    contentOutput += drink.Name + ", ";
                }
                contentOutput = contentOutput.Substring(0, contentOutput.Length - 3);
                contentOutput += ".";
                Console.WriteLine(contentOutput);
            }


            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
