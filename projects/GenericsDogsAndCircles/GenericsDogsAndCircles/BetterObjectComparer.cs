using System;

namespace GenericsDogsAndCircles {
    public class BetterObjectComparer<T> where T : IComparable<T> {
        public T Largest(T obj1, T obj2, T obj3) {

            switch(obj1.CompareTo(obj2)) {
                case 1: //obj1 is larger than obj2
                    return (obj1.CompareTo(obj3) == 1 ? obj1 : obj3); //obj1 larger than obj3? return obj1. otherwise, return obj3
                case -1: //obj2 is larger than obj1
                    return (obj2.CompareTo(obj3) == 1 ? obj2 : obj3); //obj2 larger than obj3? return obj2. otherwise, return obj3
            }
            return default(T);
        }
    }
}
