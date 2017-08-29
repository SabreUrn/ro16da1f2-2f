using System;

namespace RepetitionExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Contact contact1 = new Contact("Jack Swigert", 1500, true);
            Contact contact2 = new Contact("Dennis Ritchie", 1970, false);

            contact2.Email = "unix@time.com";

            contact1.PrintSummary();
            Console.WriteLine();
            contact2.PrintSummary();
            */

            HomeTheaterTest.Run();

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
