using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1195.Fizz_Buzz_Multithreaded
{
    public class FizzBuzz
    {
        private int n;
        private readonly object balanceLock = new object();
        int i;
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
                    if ((i % 3 == 0 && i % 5 != 0))
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
                    if ((i % 5 == 0 && i % 3 != 0))
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
                    if (i > n)
                    {
                        break;
                    }
                    if (!(i % 3 == 0 || i % 5 == 0))
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
        private delegate void NumberDelegate(Action<int> printNumber);
        private delegate void BuzzDelegate(Action printNumber);
        private delegate void FizzDelegate(Action printNumber);
        private delegate void FizzbuzzDelegate(Action printNumber);

        static void Main(string[] args)
        {
            int n = 15;
            FizzBuzz fizzBuzz = new FizzBuzz(n);

            NumberDelegate fizzBuzzNumber = new NumberDelegate(fizzBuzz.Number);
            BuzzDelegate fizzBuzzBuzz = new BuzzDelegate(fizzBuzz.Buzz);
            FizzDelegate fizzBuzzFizz = new FizzDelegate(fizzBuzz.Fizz);
            FizzbuzzDelegate fizzBuzzFizzbuzz = new FizzbuzzDelegate(fizzBuzz.Fizzbuzz);

            fizzBuzzNumber.BeginInvoke(x => { Console.WriteLine(x); },null,null);
            fizzBuzzBuzz.BeginInvoke(() => { Console.WriteLine("Buzz"); },null,null);
            fizzBuzzFizz.BeginInvoke(() => { Console.WriteLine("Fizz"); }, null, null);
            fizzBuzzFizzbuzz.BeginInvoke(() => { Console.WriteLine("Fizzbuzz"); }, null, null);

            Console.ReadKey();
        }
    }
}
