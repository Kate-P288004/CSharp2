using System.Collections.Generic;

namespace literatePrimes
{
    public class PrimeGenerator
    {
        private static int[] primes;
        private static List<int> multiplesOfPrimeFactors;

        protected static int[] generate(int n)
        {
            primes = new int[n];
            multiplesOfPrimeFactors = new List<int>();
            set2AsFirstPrime();
            checkOddNumbersForSubsequentPrimes();
            return primes;
        }

        private static void set2AsFirstPrime()
        {
            primes[0] = 2;
            multiplesOfPrimeFactors.Add(2);
        }

        private static void checkOddNumbersForSubsequentPrimes()
        {
            int primeIndex = 1;
            for (int candidate = 3; primeIndex < primes.Length; candidate += 2)
            {
                if (isPrime(candidate))
                    primes[primeIndex++] = candidate;
            }
        }

        private static bool isPrime(int candidate)
        {
            if (isLeastRelevantMultipleOfLargerPrimeFactor(candidate))
            {
                multiplesOfPrimeFactors.Add(candidate);
                return false;
            }
            return isNotMultipleOfAnyPreviousPrimeFactor(candidate);
        }

        private static bool isLeastRelevantMultipleOfLargerPrimeFactor(int candidate)
        {
            int nextLargerPrimeFactor = primes[multiplesOfPrimeFactors.Count];
            int leastRelevantMultiple = nextLargerPrimeFactor * nextLargerPrimeFactor;
            return candidate == leastRelevantMultiple;
        }

        private static bool isNotMultipleOfAnyPreviousPrimeFactor(int candidate)
        {
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
            while (multiple < candidate)
                multiple += 2 * primes[n];
            multiplesOfPrimeFactors[n] = multiple;
            return multiple;
        }
    }
}
