using System;
using System.Collections.Generic;
using System.Linq;
using QuickRep.WeatherV1;
using QuickRep.WeatherV2;
using QuickRep.WeatherV3;

// ReSharper disable UnusedParameter.Local
// ReSharper disable RedundantAssignment
// ReSharper disable UnusedVariable
// ReSharper disable NotAccessedVariable
#pragma warning disable 219

namespace QuickRep
{
    class Program
    {
        static void Main(string[] args)
        {
            NedarvningOgPolymorfi();
            Console.ReadKey();
        }

        public static void TyperOgVariable()
        {
            // Fire "simple" typer

            // int: hele tal, både positive og negative
            var year = 2017;

            // double: kommatal, både positive og negative
            double volume = 2.75;

            // string: tekst
            string name = "Per";    

            // bool: "true" eller "false"
            bool isMarried = false;

            // ...og sådan definerer vi en variabel
            // 1) type for variablen
            // 2) navn for variablen (camelCase)
            // ... kan efterfølges af
            // 3) =
            // 4) En værdi af samme type som angivet i 1)
            // Læses som "den angivne værdi gemmes i variablen"
            // HUSK semi-kolon (;) til sidst :-)
        }

        public static void Aritmetik()
        {
            int a = 15;
            int b = 10;

            // Vi kan benytte de almindelige regnearter,
            // plus lidt ekstra:
            int c = a + b;
            int d = a - b;
            int e = a * b;
            int f = a / b; // Heltalsdivision!
            int g = a % b; // Rest ved heltalsdivision
            int h = (a + b) * c; // Parenteser

            // Kan benytte samme variabel på begge sider:
            a = a + 30;

            // "Shortcuts"
            a++; // Det samme som a = a + 1;
            a--; // Det samme som a = a - 1;
            a += b; // Det samme som a = a + b;
            a -= b; // Det samme som a = a - b;
            a *= b; // Det samme som a = a * b;
            a /= b; // Det samme som a = a / b;


            // Kan benytte tilsvarende regnearter for double
            // Sammenligning kan være problematisk....
            double x = 1.5;
            double y = 2.3;
            double zeroMaybe = x - x*y/y;
        }

        public static void Logik()
        {
            int shoeSize = 47;

            // Et logisk udtryk er et udtryk, som kan være
            // enten sandt eller falsk
            bool hasBigFeet = (shoeSize > 45); // Er sandt
            bool hasSmallFeet = (shoeSize < 35); // Er falsk

            // > (større end) og < (mindre end) er logiske operatorer
            // Andre logiske operatorer er:
            bool match = (shoeSize == 42);  // == (lig med)
            bool noMatch = (shoeSize != 42);  // != (ikke lig med)
            bool smallerOrMatch = (shoeSize <= 42); // <= (mindre end, eller lig med)
            bool largerOrMatch = (shoeSize >= 42); // <= (større end, eller lig med)

            // Kan kombinere logiske udtryk:

            // &&: AND. Udtrykket A && B er sandt,
            // hvis A OG B er sande.
            bool bigAndSmall = hasBigFeet && hasSmallFeet;

            // ||: OR. Udtrykket A || B er sandt,
            // hvis A ELLER B er sande.
            bool bigOrSmall = hasBigFeet || hasSmallFeet;

            // !: NOT. Udtrykket !A er sandt,
            // hvis A er falsk.
            bool notSmallFeet = !hasSmallFeet;

            // ...yderligere kombination med parenteser
        }

        public static void StringOgConsole()
        {
            string firstName = "Per";
            string lastName = "Laursen";

            // Vi kan "plusse" strings med +
            // Dette giver "Per Laursen"
            string fullName = firstName + " " + lastName;

            // Vi kan også lave strings ud af andre værdier.
            // Her sker der en konvertering fra int til string
            int age = 49;
            string info = fullName + " er " + age + " år";

            // Udskriv en string på skærmen:
            Console.WriteLine(info);

            // Man kan også læse en string som brugeren indtaster
            string userInput = Console.ReadLine();

            // NYT: Man kan også lave en string med "string interpolation"
            string info2 = $"{fullName} er {age} år";
            Console.WriteLine(info2);
        }

        public static void ConditionalStatements()
        {
            // Formål: udfør en "code block" (samling af statements)
            // een gang, hvis en betingelse er sand. Hvis betingelsen
            // er falsk, udføres koden ikke.

            int cash = 20;
            double price = 18.95;

            if (cash > price)
            {
                Console.WriteLine("Jeg købte noget!");
                Console.WriteLine("Det var en pakke figenpålæg!");
            }


            // Ofte vil vi også gerne gøre noget specifikt,
            // når betingelsen er falsk

            if (cash > price)
            {
                Console.WriteLine("Jeg købte noget!");
            }
            else
            {
                Console.WriteLine("Jeg havde ikke råd...");
            }


            // I tilfælde hvor begge kodeblokke er små,
            // kan denne konstruktion bruges:

            Console.WriteLine(cash > price ? "Jeg købte noget!" : "Jeg havde ikke råd...");


            // Hvis der er mere end to situationer,
            // for hvilke der skal gøres noget forskelligt
            // KUN EEN af blokkene bliver udført:
            //   Den først for hvilken betingelsen er sand, eller
            //   Den afsluttende else

            if (cash > 2 * price)
            {
                Console.WriteLine("Jeg købte mindst to pakker figenpålæg!");
            }
            else if (cash > 2 * price)
            {
                Console.WriteLine("Jeg købte en pakke figenpålæg!");
            }
            else
            {
                Console.WriteLine("Jeg havde ikke råd...");
            }


            // Betingelsen kan være simpel eller kompleks,
            // så længe det er et logisk udtryk.

            if ((cash > 42) && !(price / 3 > cash) || (cash/2 < 100))
            {
                Console.WriteLine("Uhhh...?");
            }


            // Switch-statement: God når noget simpelt skal gøres,
            // afhængigt af en specifik værdi af en variabel

            switch (cash)
            {
                case 0:
                    Console.WriteLine("I have nothing...");
                    break;
                case 10:
                    Console.WriteLine("I have a 10-kr coin...");
                    break;
                default:
                    Console.WriteLine("I have " + cash + " kr.");
                    break;
            }
        }

        public static void RepetitionStatements()
        {
            // Formål: udfør en "code block" (samling af statements)
            // så længe en betingelse er sand. Koden kan udføres
            // nul, een eller flere gange. En enkelt udførelse af 
            // koden i kode-blokken kaldes en iteration.

            int cash = 60;
            int price = 16;

            while (cash > price)
            {
                Console.WriteLine("Jeg købte en pakke figenpålæg!");
                cash = cash - price;
            }


            // Fire elementer
            // 1) Initialisering (hvis nødvendigt)
            // 2) Betingelse (logisk udtryk)
            // 3) Ændring (noget skal ændres, som indgår i betingelsen,
            //    ellers risikerer vi en uendelig løkke)
            // 4) Handling (det som skal ske i hver iteration)

            cash = 100; // 1
            while (cash > price) // 2
            {
                Console.WriteLine("Jeg købte en pakke figenpålæg!"); // 4
                cash = cash - price; // 3
            }


            // Betingelsen behøver ikke have noget med tal at gøre

            string input = "";
            while (input != "quit")
            {
                input = Console.ReadLine();
                Console.WriteLine("Du skrev " + input);
            }


            // For-loop: Logisk det samme som while-loop, blot
            // med elementerne organiseret lidt anderledes:

            for (cash = 100; cash > price; cash = cash - price) // for (1;2;3)
            {
                Console.WriteLine("Jeg købte en pakke figenpålæg!"); // 4
            }

            // Arketypisk for-loop
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void DataStrukturerList()
        {
            // Collection-klasse: klasse til at rumme mange 
            // elementer af samme type. Type kan være simpel
            // eller en klasse-type.

            // List-klassen: elementer gemmes på positioner,
            // der specificeres ved et index. Første element
            // har index 0, næste index 1, osv..
            // List<T> kan KUN rumme elementer af typen T.

            List<int> numbers = new List<int>();


            // Indsættelse af element i liste. 
            // Listen skaber selv plads til elementer.

            numbers.Add(23); // Indsætter element bagerst i listen
            numbers.Insert(1, 47); // Indsætter element på index 1


            // Man benytter index til at referere til 
            // elementer i listen, med []-syntaksen.

            int aValue = numbers[3];
            numbers[2] = 93;


            // Et element slettes ved brug af index, 
            // eller ved at angive en specifik værdi:

            numbers.RemoveAt(2); // Slet element på index 2
            numbers.Remove(406); // Slet første forekomst af værdien 406


            // Mange nyttige properties/metoder til rådighed i List-klassen

            int noOfElement = numbers.Count; // Antal elementer i listen
            bool contains406 = numbers.Contains(406); // Er det angivne element i listen?
            numbers.Sort(); // Sortér elementerne i listen
            numbers.Clear(); // Slet alle elementer i listen


            // Foreach-loop er specielt designet til at udføre
            // en handling for hvert element i en collection

            int sum = 0;
            foreach (int number in numbers)
            {
                sum = sum + number;
            }
            Console.WriteLine($"Sum of elements is {sum}");
        }

        public static void DataStrukturerDictionary()
        {
            // Collection-klasse: klasse til at rumme mange 
            // elementer af samme type. Type kan være simpel
            // eller en klasse-type.

            // Dictionary-klassen: elementer gemmes på positioner,
            // der specificeres ved en nøgle. Alle nøgler skal
            // være unikke.
            // Dictionary<K,V> kan KUN rumme elementer af typen V,
            // udpeget af en nøgle af typen K.

            Dictionary<int, string> englishNumbers = new Dictionary<int, string>();


            // Indsættelse af element i Dictionary. 
            // Både nøgle og værdi skal angives.
            // Dictionary skaber selv plads til elementer.

            englishNumbers.Add(2, "Two");
            englishNumbers.Add(7, "Seven");
            englishNumbers[6] = "Six"; // Alternativt


            // Man benytter nøglen til at referere til 
            // elementer i listen, med []-syntaksen.

            string numberStr = englishNumbers[7];

            // Mere korrekt (undgå fejl)
            if (englishNumbers.ContainsKey(7))
            {
                numberStr = englishNumbers[7];
            }


            // Et element slettes ved brug af nøgle

            englishNumbers.Remove(2); // Slet element med nøglen 2.


            // Også nyttige properties/metoder til rådighed i Dictionary-klassen

            int noOfElement = englishNumbers.Count; // Antal elementer i Dictionary
            englishNumbers.Clear(); // Slet alle elementer i Dictionary


            // Kan trække alle nøgler hhv værdier ud af en Dictionary

            List<int> keys = englishNumbers.Keys.ToList();
            List<string> values = englishNumbers.Values.ToList();


            // Foreach-loop er også nyttig her

            foreach (string s in englishNumbers.Values)
            {
                Console.WriteLine(s);
            }
        }

        public static void BenytEnKlasse()
        {
            Engine engineA = new Engine("RollsRoyce", 8000);
            Engine engineB = new Engine("RollsRoyce", 8000);
            List<Engine> engines = new List<Engine> { engineA, engineB };


            // Når vi vil lave et nyt objekt, skal vi angive:
            // 1) Ordet "new"
            // 2) Navnet på den klasse, som objektet er en instans af
            // 3) Konkrete værdier svarende til de parametre, der er 
            //    defineret i klassens constructor.
            //
            // Desuden vil vi næsten altid definere en variabel, som 
            // refererer til det nye objekt. 
            // For denne variabel skal vi angive:
            // 1) Typen for variablen (svarer til objektets klasse)
            // 2) Navn for variablen (camelCase)

            Aeroplane plane = new Aeroplane("Airbus", "A320", 170, engines, 900);


            // Nu kan vi interagere med det nye objekt, gennem den variabel
            // som refererer til objektet.
            // Vi kan:
            // 1) Spørge på (og nogle gange ændre) en del af objektets
            //    TILSTAND, ved at benytte en PROPERTY
            // 2) Aktivere en del af objektets OPFØRSEL, ved at benytte
            //    en METODE

            int seats = plane.NoOfSeats; // Property
            plane.TurnOn(false); // Metode


            // Flere variable kan godt referere til samme objekt.

            Aeroplane plane2 = plane;
            plane2.NoOfSeats = 300;
            Console.WriteLine(plane.NoOfSeats); // Dette vil udskrive "300"
        }

        public static void Association()
        {
            // Som brugere af klassen WeatherStationV1 ser vi
            // aldrig de objekter, som objektet selv rummer

            WeatherStationV1 ws1 = new WeatherStationV1("Roskilde");

            ws1.PrintReport();
            Console.WriteLine();
            ws1.PrintReport();
        }

        public static void NedarvningSimpel()
        {
            // Når nedarvning er i spil, kan vi godt definere en
            // variabel af base-klassens type, og sætte den til at
            // referere til et objekt af en sub-klasses type

            BaroMeter b1 = new BaroMeter();
            SimulatedWeatherInstrumentV1 ins1 = new BaroMeter();

            ins1 = b1; // OK
            // b1 = ins1; // Nixen bixen!
        }

        public static void NedarvningOgPolymorfi()
        {
            List<SimulatedWeatherInstrumentV2> instruments = 
                new List<SimulatedWeatherInstrumentV2>();


            // Idet CloudCoverMeter og AnemoMeter arver fra 
            // SimulatedWeatherInstrumentV2, kan vi godt indsætte 
            // objekter af disse klasser i listen

            instruments.Add(new CloudCoverMeter());
            instruments.Add(new AnemoMeter());


            for (int i = 0; i < 5; i++)
            {
                foreach (SimulatedWeatherInstrumentV2 instrument in instruments)
                {
                    // NB: Selv om instrument er en variabel af typen
                    // SimulatedWeatherInstrumentV2, er det alligevel
                    // sub-klassens implementation af CurrentValue, som
                    // bliver kaldt (hvis sub-klassen har defineret en)!
                    //
                    // Dette er et eksempel på POLYMORFI

                    Console.WriteLine(instrument.CurrentValue);
                }
                Console.WriteLine();
            }


            // Endnu et eksempel på Polymorfi: vi får kaldt den
            // rigtige version af ToString.

            Object ws2 = new WeatherStationV2("Odense", instruments);
            Console.WriteLine(ws2);
        }

        public static void NedarvningOgInterfaces()
        {
            // Nu har WeatherStationV3-objektet intet kendskab
            // til de konkrete implementation af IWeatherInstrument,
            // som kalderen giver til objektet.
            //
            // Det er kalderen som "injicerer" afhængigheder til
            // konkrete IWeatherInstrument-implementationer

            WeatherStationV3 ws3 = new WeatherStationV3("Esbjerg");
            ws3.AddInstrument(new RealHygroMeter());
            ws3.AddInstrument(new SimulatedBaroMeter());
        }
    }
}
