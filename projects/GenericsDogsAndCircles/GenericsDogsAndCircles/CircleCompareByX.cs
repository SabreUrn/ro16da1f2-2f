using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDogsAndCircles {
    public class CircleCompareByX : IComparer<Circle> {
        public int Compare(Circle x, Circle y) {
            if(x.X > y.X) { //x has a greater x-coord value than y
                return 1;
            }
            if(y.X > x.X) { //y has a greater x-coord value than x
                return -1;
            }
            return 0;
        }
    }
}
