using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDConsole {
    class Program {
        static void Main(string[] args) {
            StringUtilities strUtils = new StringUtilities();
            string strCheck = "usa usa usa ass blast usa";
            char charFind = 's';

            Console.WriteLine($"Instances of {charFind} found in {strCheck}: " + strUtils.CountOccurances(strCheck, charFind));
            Console.ReadKey();
        }
    }
}