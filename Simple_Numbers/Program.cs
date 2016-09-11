using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircularPrimes
{
    class Program
    {
        public static List<int> findPrimes()
        {
            List<int> res = new List<int>();
            for (int i = 2; i < 1000000; i++)
            {
                if  (isPrime(i))
                {   
                 res.Add(i);    
                }
            }
            return res;
        }

        public static bool isPrime(int i)
        {
            int b = Convert.ToInt32(Math.Sqrt(i));
            for (int j = 2; j <= b; j++)
            {
                if (i % j == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int findCountCircularPrimes(List<int> lstPrimes)
        {
            int count = 0;
            for (int i = 0; i < lstPrimes.Count; i++)
            {
                int num = lstPrimes[i];
                if (lstPrimes[i] < 10)
                {
                    count++;
                }
                else if (!(lstPrimes[i].ToString().Contains('2') || lstPrimes[i].ToString().Contains('4') || lstPrimes[i].ToString().Contains('6') || lstPrimes[i].ToString().Contains('8') || lstPrimes[i].ToString().Contains('0') || lstPrimes[i].ToString().Contains('5')))
                {
                    bool isCirCulPrime = true;
                    for (int j = 0; j < lstPrimes[i].ToString().Length; j++)
                    {
                        num = Rotate(num, lstPrimes[i].ToString().Length);
                        if (!isPrime(num))
                        {
                            isCirCulPrime = false;
                            break;
                        }
                    }
                    if (isCirCulPrime)
                    {
                        count++;
                        
                    }
                }
            }
            return count;
        }
        public static int Rotate(int iNumber, int noDigits)
        {
            int givenNo = iNumber;
            int reminder = (int)iNumber % 10; //last
            int quotient = (int)iNumber / 10; //without last
            return (int)((reminder * Math.Pow(10, noDigits - 1)) + quotient);
        }

        static void Main(string[] args)
        {
            List<int> Primes = findPrimes();
            int countCircularPrimes = findCountCircularPrimes(Primes);
                Console.WriteLine("{0}", countCircularPrimes);
            
            Console.ReadLine();
        }
    }
}