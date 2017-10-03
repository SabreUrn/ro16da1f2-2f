﻿using System;
using System.Threading.Tasks;

namespace NumericalPi {
    public class PiCalc {
        public PiCalc() {
        }

        /// <summary>
        /// Executes the calculation of an 
        /// approximate value of pi.
        /// </summary>
        /// <param name="iterations">Number of iterations to perform</param>
        /// <returns>Approximate value of pi</returns>
        public double Calculate(int iterations) {
            int insideUnitCircle = 0;
            Task task1 = Task.Run(() => insideUnitCircle += Iterate(iterations));
            Task task2 = Task.Run(() => insideUnitCircle += Iterate(iterations));
            Task task3 = Task.Run(() => insideUnitCircle += Iterate(iterations));
            task1.Wait();
            task2.Wait();
            task3.Wait();
            //insideUnitCircle += Iterate(iterations);
            return insideUnitCircle * 4.0 / (iterations * 3);
        }

        /// <summary>
        /// Perform a number of "dart-throwing" simulations.
        /// </summary>
        /// <param name="iterations">Number of dart-throws to perform</param>
        /// <returns>Number of throws within the unit circle</returns>
        public int Iterate(int iterations) {
            Random _generator = new Random();
            int insideUnitCircle = 0;

            for (int i = 0; i < iterations; i++) {
                double x = _generator.NextDouble();
                double y = _generator.NextDouble();

                if (x * x + y * y < 1.0) {
                    insideUnitCircle++;
                }
            }

            return insideUnitCircle;
        }
    }
}