using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDConsole {
    public class StringUtilities {
        public int CountOccurances(string strCheck, char charFind) {
            if(String.IsNullOrEmpty(strCheck)) {
                return -1;
            }

            strCheck = strCheck.ToLower();
            charFind = Char.ToLower(charFind);

            return strCheck.Count(f => f == charFind);
        }
    }
}
