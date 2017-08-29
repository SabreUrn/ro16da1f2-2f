using System;
using System.Collections.Generic;

namespace Sandbox {
    public class InsertCodeHere {
        public void MyCode() {
            //Opgave 1
            /*
            int cash = 12;
            double price = 12.95;
            bool canBuy = cash > price;

            Console.WriteLine("I can afford it: {0}", canBuy);
            */

            //Opgave 2
            /*
            int tvScreenSize = 55;
            bool tvOLEDTech = false;

            Console.WriteLine(tvOLEDTech ? (tvScreenSize >= 50 ? "That's a very nice TV!" : "That's a fancy TV!") : "That's a... TV...");

            for(int i = 0; i <= 30; i++) {
                if(i % 4 == 0) {
                    Console.WriteLine("{0} is divisible by 4.", i);
                } else {
                    Console.WriteLine("{0} is not divisible by 4.", i);
                }
            }
            */

            //Opgave 3
            /*
            List<int> minListe = new List<int>();
            minListe.Add(8);
            minListe.Add(14);
            minListe.Add(3);
            minListe.Add(-2);
            minListe.Add(47);

            foreach(int i in minListe) {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            Console.WriteLine("reverse listing start");
            for (int i = minListe.Count - 1; i >= 0; i--) {
                Console.WriteLine(minListe[i]);
            }


            Dictionary<string, int> mineTests = new Dictionary<string, int>();
            mineTests.Add("Matematik", 65);
            mineTests.Add("Idræt", 80);
            mineTests.Add("Biologi", 90);
            mineTests.Add("IT", 75);

            foreach(KeyValuePair<string, int> kvp in mineTests) {
                Console.WriteLine(kvp.Key);
            }

            Console.WriteLine();
            Console.WriteLine("average start");
            Console.WriteLine("average = {0}", DictionaryAverage(mineTests));
            mineTests.Remove("Biologi");
            mineTests.Remove("Idræt");
            Console.WriteLine("new average = {0}", DictionaryAverage(mineTests));
            */
        }

        public int DictionaryAverage(Dictionary<string, int> dict) {
            int average = 0;
            foreach(KeyValuePair<string, int> kvp in dict) {
                average += kvp.Value;
            }
            average /= dict.Count;

            return average;
        }
    }
}