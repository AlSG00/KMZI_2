using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections;
using System.Diagnostics;

namespace KMZI_2
{
    public class MyMD5
    {
        public uint[] tTable { get; set; }

        public MyMD5()
        {
            tTable = GenerateTable();
        }

        // Таблица значений циклического сдвига
        public int[] sTable = { 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22,
                                5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20,
                                4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23,
                                6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21 };
        public uint[] GenerateTable()
        {
            uint[] result = new uint[64];
            double bigPow = Math.Pow(2, 32);
          
            for (int i = 0; i < 64; i++)
            {
                // T[i] = 2^32 * |sin(i + 1)|
                result[i] =  (uint)(bigPow * Math.Abs(Math.Sin(i + 1)));
            }

            return result;
        }

        public BigInteger[] CutBlocks_32(byte[] inBlock)
        {
            byte[] temp = new byte[4];
            BigInteger[] result = new BigInteger[16];

            for (int i = 0; i < result.Length; i++)
            {
                Array.Copy(inBlock, i * 4, temp, 0, 4);
                result[i] = (uint)(temp[0] + (temp[1] << 8) + (temp[2] << 16) + (temp[3] << 24));
            }

            return result;
        }
         
        public BigInteger ShiftLeft(BigInteger digit, int shift)
        {
            digit &= 0xFFFFFFFF;

            return ((digit << shift) | (digit >> (32 - shift))) & 0xFFFFFFFF;
        }

        public BigInteger[] Rounds(BigInteger A, BigInteger B, BigInteger C, BigInteger D, BigInteger[] block)
        {
            BigInteger F = 0;
            int g = 0;

            for (int i = 0; i < 64; i++)
            {
                if (i >= 0 && i < 16)
                {
                    F = (B & C) | (~B & D);
                    g = i;
                }
                else if (i >= 16 && i < 32)
                {
                    F = (B & D) | (~D & C);
                    g = (5 * i + 1) % 16;
                }
                else if (i >= 32 && i < 48)
                {
                    F = B ^ C ^ D;
                    g = (3 * i + 5) % 16;
                }
                else if (i >= 48 && i < 64)
                {
                    F = C ^ (~D | B);
                    g = (7 * i) % 16;
                }

                F = (F + A + tTable[i] + block[g]);
                A = D;
                D = C;
                C = B;
                B = (B + ShiftLeft(F, sTable[i])) & 0xFFFFFFFF;
            }

            BigInteger[] result = new BigInteger[4];

            result[0] = A;
            result[1] = B;
            result[2] = C;
            result[3] = D;

            return result;
        }
    }
}
