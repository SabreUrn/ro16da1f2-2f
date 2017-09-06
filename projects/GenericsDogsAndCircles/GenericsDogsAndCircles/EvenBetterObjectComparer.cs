using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDogsAndCircles {
    public class EvenBetterObjectComparer<T> {
        public T Largest<T>(T obj1, T obj2, T obj3, IComparer<T> comparer) {
            if(comparer.Compare(obj1, obj2) == 1) { //obj1 is greater than obj2
                return (comparer.Compare(obj2, obj3) == 1 ? obj2 : obj3); //is obj2 greater than obj3? return obj2. otherwise, return obj3.
            }
            if(comparer.Compare(obj1, obj2) == -1) {    //obj2 is greater than obj1. if we arrive in this statement, we can be sure
                                                        //that obj1 is not greater, but this safeguards against two objects with equal values
                return (comparer.Compare(obj2, obj3) == 1 ? obj2 : obj3); //is obj2 greater than obj3? return obj2. otherwise, return obj3.
            }
            if(comparer.Compare(obj1, obj3) != 0) { //if we arrive at this statement, we know two things: obj1 is not greater than obj2; obj2 is not greater than obj1.
                return (comparer.Compare(obj1, obj3) == 1 ? obj1 : obj3);   //therefore, return obj1 if it's greater than obj3 and obj3 otherwise.
            }
            return default(T); //obj1 not greater than obj2. obj2 not greater than obj1. obj1 (thus also obj2) and obj3 are equally big. return default (all code paths now return a value)
        }
    }//end class
}//end namespace
