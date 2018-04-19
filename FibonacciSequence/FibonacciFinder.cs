using System;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciSequence
{
    /// <summary>
    /// Static class with one public method to find Fibonacci Sequence
    /// </summary>
    public static class FibonacciFinder
    {
        /// <summary>
        /// Gets Fibonacci sequence to the nth element with checking
        /// </summary>
        /// <param name="n">
        /// Number of element
        /// </param>
        /// <returns>
        /// Array of longs with Fibonacci sequence
        /// </returns>
        public static IEnumerable<BigInteger> GetNthFibonacci(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            return GetNthFibonacciHelper(n);
        }


        /// <summary>
        /// Gets Fibonacci sequence to the nth element
        /// </summary>
        /// <param name="n">
        /// Number of element
        /// </param>
        /// <returns>
        /// Array of longs with Fibonacci sequence
        /// </returns>
        private static IEnumerable<BigInteger> GetNthFibonacciHelper(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            BigInteger previos = 1;
            BigInteger beforePrevios = -1;

            for (int i = 0; i < n; i++)
            {
                BigInteger sum;
                sum = previos + beforePrevios;
                beforePrevios = previos;
                previos = sum;
                yield return sum;
            }
        }
    }
}
