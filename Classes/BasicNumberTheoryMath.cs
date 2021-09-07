using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace KMZI_2
{
    class BasicNumberTheoryMath
    {
        public BigInteger Find_ModularExpo(BigInteger a, BigInteger x, BigInteger p)
        {
            //string x1 = Convert.ToString(x, 2);
            if( x < 0)
            {
                x = Find_Inversion(x, p);
            }

            string x1 = Convert_ToBinary(x);

            BigInteger answer = a;
            for (int i = 1; i < x1.Length; i++)
            {
                if (x1[i] == '1')
                {
                    answer = answer * answer * a % p;
                }
                else
                {
                    answer = answer * answer % p;
                }
            }
            return answer;
        }

        public BigInteger Find_GCD(BigInteger a, BigInteger b)
        {
           // a = Math.Abs(a);
           // b = Math.Abs(b);

            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;

        }

        public int Find_Inversion(BigInteger x, BigInteger p)//чекнуть
        {
            int d = 0;
            if (Find_GCD(x, p) == 1)
            {              
                while (x * d % p != 1)
                {
                    d++;
                }
            }
            return d;
        }

        public BigInteger PRNG (BigInteger seed)
        {
            BigInteger result = 0;
            return result;
        }

        public string Convert_ToBinary(BigInteger dec)
        {
            string result = "";
            while(dec > 1)
            {
                if(dec % 2 == 0)
                {
                    result = result.Insert(0, "0");
                }
                else
                {
                    result = result.Insert(0, "1");
                }
                dec /= 2;
            }
            result = result.Insert(0, "1");

            return result;
        }
        //int[] generate_key(int startIndex, int length)
        //{
        //    int a = 936; // Множитель (0 <= a < mod)
        //    int c = 1399; // Приращение (0 <= c < mod)
        //    int x = startIndex; // Начальное значение (0 <= x < mod)
        //    int[] key = new int[text_byte.Length];
        //    key[0] = x;

        //    for (int i = 1; i < length; i++)
        //    {
        //        key[i] = (a * key[i - 1] + c) % mod;
        //    }
        //    //for (int i = 0; i < length; i++)
        //    //{
        //    //    key[i] %= 256;
        //    //}
        //    return key;
        //}
    }
}
