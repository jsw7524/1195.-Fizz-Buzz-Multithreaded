using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1195.Fizz_Buzz_Multithreaded
{
    public class FizzBuzz
    {
        private int n;
        private readonly object balanceLock = new object();
        int i ;
        public FizzBuzz(int n)
        {
            this.n = n;
            this.i = 1;
        }

        // printFizz() outputs "fizz".
        public void Fizz(Action printFizz)
        {
            while (true)
            {
                lock (balanceLock)
                {
                    if (i > n)
                    {
                        break;
                    }
                    if ((i % 3 == 0 && i%5!=0))
                    {
                        printFizz();
                        i++;
                    }

                }
            }
        }

        // printBuzzz() outputs "buzz".
        public void Buzz(Action printBuzz)
        {
            while (true)
            {
                lock (balanceLock)
                {
                    if (i > n)
                    {
                        break;
                    }
                    if ((i % 5 == 0 && i% 3!= 0))
                    {
                        printBuzz();
                        i++;
                    }

                }
            }
        }

        // printFizzBuzz() outputs "fizzbuzz".
        public void Fizzbuzz(Action printFizzBuzz)
        {
            while (true)
            {
                lock (balanceLock)
                {
                    if (i > n)
                    {
                        break;
                    }
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        printFizzBuzz();
                        i++;
                    }

                }
            }
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Number(Action<int> printNumber)
        {
            while (true)
            {
                lock (balanceLock)
                {
                    if (i>n)
                    {
                        break;
                    }
                    if (!(i%3==0 || i%5==0))
                    {
                        printNumber(i);
                        i++;
                    }

                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
