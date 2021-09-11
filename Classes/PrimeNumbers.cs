﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMZI_2
{
    class PrimeNumbers
    {
        long[] primeCollection = { 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 57 };

        public int primeMin = 3;
        public int primeMax = 2147483647;

        public bool IsPrime(long digit)
        {
            if (primeCollection.Contains(digit))
            {
                return true;
            }
            else
            {
                if (digit > 1 && digit % 2 != 0)
                {
                    for (int i = 3; i < Math.Sqrt(digit) + 1; i++)
                    {
                        if (digit % i == 0)
                        {
                            return false;
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Возвращает пару простых чисел P и Q, подбираемых исходя из полученного числа
        /// </summary>
        public int[] GeneratePrimePair(int seed)
        {
            int[] pair = { 3, 5 };


            int i = seed - 1;
            while (!IsPrime(i) && i >= primeMin)
            {
                i--;
            }
            if (IsPrime(i) && i >= primeMin)
            {
                pair[0] = i;
            }
            else
            {
                i = seed;
                while (!IsPrime(i) || i < primeMin)
                {
                    i++;
                }
                if (IsPrime(i))
                {
                    pair[0] = i;
                }
            }

            if (IsPrime(seed) && seed != pair[0] && seed > primeMin && seed < primeMax)
            {
                pair[1] = seed;
            }
            else
            {
                i = seed;
                while ((!IsPrime(i) || i == pair[0]) && i < primeMax)
                {
                    i++;
                    //if (i == pair[0])
                    //{
                    //    i++;
                    //}
                }
                if (IsPrime(i))
                {
                    pair[1] = i;
                }
                else
                {
                    i = seed - 1;
                    while (!IsPrime(i) || i > primeMax)
                    {
                        i--;
                    }
                    if (IsPrime(i))
                    {
                        pair[1] = i;
                    }
                }
            }

            return pair;
        }
    }
}
