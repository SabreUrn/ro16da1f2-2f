using System;
using System.Collections.Generic;
using System.Linq;

namespace TestExampleA {
    public class ListMethods {
        /// <summary>
        /// This method calculates the sum of the squares of the
        /// positive numbers in the list. 
        /// Examples: [2, 3, 5] = 2x2 + 3x3 + 5x5 = 4 + 9 + 25 = 38
        ///           [4, -2, 3] = 4x4 + 3x3 = 16 + 9 = 25 (-2 was excluded)
        /// If a null value or an empty list is given as parameter,
        /// the exception ArgumentException is thrown 
        /// </summary>
        public int SumOfSquaresOfPositives(List<int> numbers) {
            int sum = 0;

            // Implement the logic described above
            if(numbers == null || numbers.Count == 0) {
                throw new ArgumentException("Number list doesn't exist or is empty.");
            }

            IEnumerable<int> positiveNumbers =
                from number in numbers
                where number > 0
                select number;
            foreach(int i in positiveNumbers) {
                sum += Convert.ToInt32(Math.Pow(i, 2));
            }

            return sum;
        }
    }
}