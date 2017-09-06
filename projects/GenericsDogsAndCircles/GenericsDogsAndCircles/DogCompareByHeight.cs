using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDogsAndCircles {
    public class DogCompareByHeight : IComparer<Dog> {
        public int Compare(Dog x, Dog y) {
            if(x.Height > y.Height) { //x is taller than y
                return 1;
            }
            if(y.Height > x.Height) { //y is taller than x
                return -1;
            }
            return 0;
        }
    }
}
