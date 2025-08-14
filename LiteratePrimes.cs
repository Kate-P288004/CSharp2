using System.Collections.Generic;

namespace literatePrimes
{
    public class PrimeGenerator
    {
        //Internal state for current generation run
        private static int[] primes;
        private static List<int> multiplesOfPrimeFactors;

        /// <summary>
        /// Returns the first prime number
        /// </summary>
       
        protected static int[] generate(int n)
        {
            if (n <= 0) return System.Array.Empty<int>();

            primes = new int[n];
            multiplesOfPrimeFactors = new List<int>();

            set2AsFirstPrime();
            checkOddNumbersForSubsequentPrimes();
            return primes;
        }

        private static void set2AsFirstPrime()
        {
            primes[0] = 2;
            //Track the first prime factor multiples
            multiplesOfPrimeFactors.Add(2);
        }

        private static void checkOddNumbersForSubsequentPrimes()
        {
            int primeIndex = 1;
            //odd numbers start from 3
            for (int candidate = 3; primeIndex < primes.Length; candidate += 2)
            {
                if (isPrime(candidate))
                    primes[primeIndex++] = candidate;
            }
        }

        private static bool isPrime(int candidate)
        {
            if (IsSquareOfNextPrimeFactor(candidate))
            {
                //when hit p^2,begin tracking the new prime factor multiples
                multiplesOfPrimeFactors.Add(candidate);
                return false;
            }

            return isNotMultipleOfAnyPreviousPrimeFactor(candidate); ;
        }

        private static bool IsSquareOfNextPrimeFactor(int candidate)
        {
            //The next prime factor is the one at index equal to how many multiples we have track.
            int nextIndex = multiplesOfPrimeFactors.Count;

            if (nextIndex >= primes.Length) return false; 

            int nextLargerPrimeFactor = primes[nextIndex];
            int leastRelevantMultiple = nextLargerPrimeFactor * nextLargerPrimeFactor;

            return candidate == leastRelevantMultiple;
        }

        private static bool isNotMultipleOfAnyPreviousPrimeFactor(int candidate)
        {
            //Start at 1 to skip the prime 2
            for (int n = 1; n < multiplesOfPrimeFactors.Count; n++)
            {
                if (isMultipleOfNthPrimeFactor(candidate, n))
                    return false;
            }
            return true;
        }

        private static bool isMultipleOfNthPrimeFactor(int candidate, int n)
        {
            return candidate ==
                   smallestOddNthMultipleNotLessThanCandidate(candidate, n);
        }

        private static int smallestOddNthMultipleNotLessThanCandidate(int candidate, int n)
        {
            int multiple = multiplesOfPrimeFactors[n];
            //Multiple by twice the prime 
            while (multiple < candidate)
            {
                multiple += 2 * primes[n];
            }

            multiplesOfPrimeFactors[n] = multiple;
            return multiple;
        }
    }
}
