# Prime Generator

This project generates prime numbers using a custom algorithm in C#.

# How the Code Works

The program builds a list of prime numbers step by step.

First, it sets up an array to store found primes and a list to track multiples of primes.  
Next, it adds 2 as the very first prime number and stores it in multiples to skip even numbers.  
Then it starts from 3 and checks only odd numbers by moving forward by 2.  

Each odd number is checked in this way:  
If the number is the square of a known prime, it is not prime.  
If the number matches any stored multiple, it is not prime.  
Otherwise, the number is prime and is added to the list.  

For every new prime, the program tracks its multiples. For example, for prime 3 the multiples are 3, 9, 15 and so on. This makes the algorithm avoid repeated checks.  

The program continues until it finds the requested amount of primes. At the end, it returns the list of primes.

# Example Output

For the first 10 primes, the program returns

2, 3, 5, 7, 11, 13, 17, 19, 23, 29

# Files

LiteratePrimes.cs contains the prime generator logic.
