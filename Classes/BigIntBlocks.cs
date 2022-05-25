using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace KMZI_2
{
    class BigIntBlocks
    {
        public BigInteger[] GenerateBlocks(byte[] inFile, int blockLength)
        {
            // Вычисляем необходимок кол-во блоков
            string[] blocks;
            BigInteger[] result;

            if (inFile.Length % blockLength == 0)
            {
                blocks = new string[inFile.Length / blockLength];
            }
            else
            {
                blocks = new string[inFile.Length / blockLength + 1];
            }
            result = new BigInteger[blocks.Length];

            // Формируем блоки
            for (int i = 0; i < blocks.Length; i++)
            {
                for (int j = 0; j < blockLength; j++)
                {
                    if (blockLength * i + j > inFile.Length - 1)
                    {
                        break;
                    }
                    else
                    {
                        string tmp = inFile[i * blockLength + j].ToString();

                        if (tmp == "0")
                        {
                            tmp = "777";
                        }

                        while (tmp.Length < 3)
                        {
                            tmp = tmp.Insert(0, "0");
                        }

                        blocks[i] += tmp;
                    }
                }
            }

            // Конвертируем строковый результат в числа
            for (int i = 0; i < blocks.Length; i++)
            {
                result[i] = BigInteger.Parse(blocks[i]);
            }

            return result;
        }

        // Метод работает только с 3-значными байтами
        public byte[] DecomposeBlocks(BigInteger block)
        {
            string tmp = "";
            string sBlock = block.ToString();
            while (sBlock.Length % 3 != 0)
            {
                sBlock = sBlock.Insert(0, "0");
            }

            byte[] result = new byte[sBlock.Length / 3];
            int count = 0;
            for (int i = 0; i < sBlock.Length; i += 3)
            {
                tmp = "";
                for (int j = 0; j < 3; j++)
                {
                    tmp += sBlock[i + j];
                }

                if (tmp == "777")
                {
                    result[count] = Convert.ToByte(null);
                }
                else
                {
                    result[count] = Convert.ToByte(tmp);
                }
                count++;
            }

            return result;
        }
    }
}
