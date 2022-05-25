using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace KMZI_2
{
    class MySHA
    {
        public static BigInteger[] K { get; set; }

        public MySHA()
        {
            K = new BigInteger[4] { 0x5A827999,
                                    0x6ED9EBA1,
                                    0x8F1BBCDC,
                                    0xCA62C1D6 };
        }

        public BigInteger ShiftLeft(BigInteger digit, int shift)
        {
            digit &= 0xFFFFFFFF;

            return ((digit << shift) | (digit >> (32 - shift))) & 0xFFFFFFFF;
        }

        public BigInteger[] CutBlocks_80(byte[] inBlock)
        {
            BigInteger[] result = new BigInteger[80];

            for (int i = 0; i < 16; i++)
            {
               /// лепим 32-битные слова из 4-х байт
                result[i] = (uint)(inBlock[i * 4 + 3] + (inBlock[i * 4 + 2] << 8) + (inBlock[i * 4 + 1] << 16) + (inBlock[i * 4] << 24));
            }

            for (int i = 16; i < 80; i++)
            {
                result[i] =  ShiftLeft((result[i - 3] ^ result[i - 8] ^ result[i - 14] ^ result[i - 16]), 1);
            }

            return result;
        }
        public BigInteger[] Rounds(BigInteger A, BigInteger B, BigInteger C, BigInteger D, BigInteger E, BigInteger[] block)
        {
            BigInteger F = 0;
            BigInteger k = 0;

            for (int i = 0; i < 80; i++)
            {
                if (i >= 0 && i < 20)
                {
                    F = (B & C) | (~B & D);
                    k = K[0];
                }
                else if (i >= 20 && i < 40)
                {
                    F = B ^ C ^ D;
                    k = K[1];
                }
                else if ( i >= 40 && i < 60)
                {
                    F = (B & C) | (B & D) | (C & D);
                    k = K[2];
                }
                else if (i >= 60 && i < 80)
                {
                    F = B ^ C ^ D;
                    k = K[3];
                }

                F = (ShiftLeft(A, 5) + F + E + k + block[i]) & 0xFFFFFFFF;
                E = D;
                D = C;
                C = ShiftLeft(B, 30);
                B = A;
                A = F;
                
            }

            BigInteger[] result = new BigInteger[5];

            result[0] = A;
            result[1] = B;
            result[2] = C;
            result[3] = D;
            result[4] = E;

            return result;
        }
    }
}
