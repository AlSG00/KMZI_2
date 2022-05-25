using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace KMZI_2
{
    public class BasicNumberTheoryMath
    {

        public BigInteger Find_ModularExpo(BigInteger a, BigInteger x, BigInteger p)
        {
            if(x < 0)
            {
                a = Find_Inversion(a, p);
                x = AbsValue(x);
            }

            string x1 = Convert_ToBinary(x, 0, false);

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
            return answer % p;
        }

        public BigInteger Find_GCD(BigInteger a, BigInteger b)
        {
            a = AbsValue(a);
            b = AbsValue(b);

            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public BigInteger Find_Inversion(BigInteger x, BigInteger mod)
        {
            BigInteger result = 0;
            BigInteger q = 0;
            BigInteger[] U = { mod, 1, 0 };
            BigInteger[] V = { x, 0, 1 };
            BigInteger[] T = { 0, 0, 0 };

            while (true)
            {
                if (V[0] == 0)
                {
                    result = U[2];
                    break;
                }
                else
                {
                    q = U[0] / V[0];

                    T[0] = U[0] % V[0];
                    T[1] = U[1] - q * V[1];
                    T[2] = U[2] - q * V[2];

                    for (int i = 0; i < 3; i++)
                    {
                        U[i] = V[i];
                        V[i] = T[i];
                    }
                }
            }

            if (result < 0)
            {
                result += mod;
            }
            if (result * x % mod != 1)
            {
                return 0;
            }

            return result;
        }

        //Функция специально для BigInteger
        public BigInteger AbsValue(BigInteger x)
        {
            if(x < 0)
            {
                return x * (-1);
            }

            return x;
        }

        public string Convert_ToBinary(BigInteger dec, int minLength, bool cut)
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

            while (result.Length < minLength)
            {
                result = result.Insert(0, "0");
            }

            if (cut == true)
            {
                string temp = "";
                for (int i = 0; i < minLength; i++)
                {
                    temp = temp.Insert(0, result[result.Length - 1 - i].ToString());
                }
                result = temp;
            }

            return result;
        }
    }
}
