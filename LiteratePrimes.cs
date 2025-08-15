using System.Collections.Generic;

namespace literatePrimes
{
    public class PrimeGenerator
    {
        // Internal state for current generation run
        private static int[] primes;
        private static List<int> primeMultiples;

        private const int FirstPrime = 2;

        /// <summary>
        /// Returns the first n prime numbers.
        /// </summary>
        protected static int[] generate(int n)
        {
            if (n <= 0) return System.Array.Empty<int>();

            primes = new int[n];
            primeMultiples = new List<int>();

            setFirstPrime();
            findOtherPrimes();
            return primes;
        }

        private static void setFirstPrime()
        {
            primes[0] = FirstPrime;
            // Track the first prime factor multiples
            primeMultiples.Add(FirstPrime);
        }

        private static void findOtherPrimes()
        {
            int index = 1; // odd numbers start from 3
            for (int candidate = 3; index < primes.Length; candidate += 2)
            {
                if (isPrime(candidate))
                    primes[index++] = candidate;
            }
        }

        private static bool isPrime(int candidate)
        {
            if (isSquareOfNextPrime(candidate))
            {
                // when hit p^2, begin tracking the new prime factor multiples
                primeMultiples.Add(candidate);
                return false;
            }

            return isNotMultiple(candidate);
        }

        private static bool isSquareOfNextPrime(int candidate)
        {
            // the next prime factor index equals how many multiples we track
            int nextIndex = primeMultiples.Count;
            if (nextIndex >= primes.Length) return false;

            int nextPrime = primes[nextIndex];
            return candidate == nextPrime * nextPrime;
        }

        private static bool isNotMultiple(int candidate)
        {
            // start at 1 to skip the prime 2
            for (int i = 1; i < primeMultiples.Count; i++)
            {
                if (isMultiple(candidate, i))
                    return false;
            }
            return true;
        }

        private static bool isMultiple(int candidate, int i)
        {
            return candidate == nextOddMultiple(candidate, i);
        }

        private static int nextOddMultiple(int candidate, int i)
        {
            int multiple = primeMultiples[i];
            // step by twice the prime
            while (multiple < candidate)
            {
                multiple += 2 * primes[i];
            }

            primeMultiples[i] = multiple;
            return multiple;
        }
    }
}
