using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections;

namespace KMZI_2
{
    public class Hash_GOST
    {
        public string _c = "115341543208837762359290129054356496287982810492634369300756142191606025486080";
        private int[] index_fi = { 32,24,16,8,31,23,15,7,
                                   30,22,14,6,29,21,13,5,
                                   28,20,12,4,27,19,11,3,
                                   26,18,10,2,25,17,9,1 };

        int[,] s_blocks = { { 4, 10, 9, 2, 13, 8, 0, 14, 6, 11, 1, 12, 7, 15, 5, 3 },
                            { 14, 11, 4, 12, 6, 13, 15, 10, 2, 3, 8, 1, 0, 7, 5, 9 },
                            { 5, 8, 1, 13, 10, 3, 4, 2, 14, 15, 12, 7, 6, 0, 9, 11 },
                            { 7, 13, 10, 1, 0, 8, 9, 15, 14, 4, 6, 12, 11, 2, 5, 3 },
                            { 6, 12, 7, 1, 5, 15, 13, 8, 4, 10, 9, 14, 0, 3, 11, 2 },
                            { 4, 11, 10, 0, 7, 2, 1, 13, 3, 6, 8, 5, 9, 12, 15, 14 },
                            { 13, 11, 4, 1, 3, 15, 5, 9, 0, 10, 14, 7, 6, 8, 2, 12 },
                            { 1, 15, 13, 0, 5, 7, 10, 4, 9, 2, 3, 14, 6, 11, 8, 12 }, };

        int index;
        public Hash_GOST()
        {
            
        }

        public BigInteger BlockHashing(BigInteger hash, BigInteger block)
        {
            BigInteger[] keys;
            BigInteger result = 0;

            // Генерация ключей
            keys = GenerateKeys(hash, block); // ТУТ ДЛИНА КЛЮЧЕЙ НЕ СООТВЕТСТВУЕТ 32 БИТАМ. ИСПРАВИТЬ!!!

            // Рабзиваем хеш на 4 части по 64 бита. Каждая будет хешироваться отдельно
            byte[] temp = hash.ToByteArray();
            byte[] bBlock = new byte[32];

            if (temp.Length > 32)
            {
                Array.Copy(temp, 0, bBlock, bBlock.Length - 32, 32);
            }
else           
            {
                Array.Copy(temp, 0, bBlock, bBlock.Length - temp.Length, temp.Length);
            }
            byte[] b1 = new byte[8];
            byte[] b2 = new byte[8];
            byte[] b3 = new byte[8];
            byte[] b4 = new byte[8];

            Array.Copy(bBlock, 0, b1, 0, 8);
            Array.Copy(bBlock, 8, b2, 0, 8);
            Array.Copy(bBlock, 16, b3, 0, 8);
            Array.Copy(bBlock, 24, b4, 0, 8);

            // Шифрующее преобразование
            b1 = EncryptBlock(b1, keys[0]);
            b2 = EncryptBlock(b2, keys[1]);
            b3 = EncryptBlock(b3, keys[2]);
            b4 = EncryptBlock(b4, keys[3]);

            byte[] S = new byte[32];

            Array.Copy(b1, 0, S, 0, 8);
            Array.Copy(b2, 0, S, 8, 8);
            Array.Copy(b4, 0, S, 16, 8);
            Array.Copy(b3, 0, S, 24, 8);


            // Перемешивающее преобразование
            result = MixBlock(hash, S, block);

            return result;
        }

        private void FixLength(byte[] data, int length)
        {
            byte[] temp = new byte[length];
            if (data.Length > length)
            {
                Array.Copy(data, 0, temp, 0, length);
                data = new byte[length];
                Array.Copy(data, 0, temp, 0, length);
                //data = new byte[33];
            }
        }
        private BigInteger[] GenerateKeys(BigInteger hash, BigInteger block)
        {
            BigInteger[] K = new BigInteger[4];
            BigInteger c = BigInteger.Parse(_c);
            BigInteger[] con = { 0, 0, c, 0 };
            byte[] temp;
            BigInteger U = hash;
            BigInteger V = block;

            byte[] test = V.ToByteArray();
            test = U.ToByteArray();
            BigInteger W = U ^ V;
            test = W.ToByteArray();
            K[0] = Func_P(W);
            /*byte[]*/ test = K[0].ToByteArray();
            for (int i = 1; i < 4; i++)
            {
                U = Func_A(U) ^ con[i];
                test = U.ToByteArray();

                V = Func_A(Func_A(V));
                test = V.ToByteArray();
                W = U ^ V;

                test = W.ToByteArray();
                if (test.Length < 32)
                {
                    temp = new byte[33];
                    Array.Copy(test, 0, temp, 0, test.Length);
                    //Array.Copy(data, 0, temp, 0, 32);
                    W = new BigInteger(temp);
                }
                test = W.ToByteArray();

                K[i] = Func_P(W);
            }

            test = K[1].ToByteArray();
            test = K[2].ToByteArray();
            test = K[3].ToByteArray();

            return K;
        }

        private byte[] EncryptBlock(byte[] block, BigInteger keys)
        {
            //int count = 0;
            int index = 0;

            byte[] result = new byte[64];
            byte[] temp = keys.ToByteArray();
            byte[] keys_temp = new byte[33];

            if (temp.Length < 32)
            {
                Array.Copy(temp, 0, keys_temp, 0, temp.Length);
            }
            //else
            //{
            //    Array.Copy(temp, 0, keys_temp, 0, 32);
            //}
            
            // Переводим байтовые значения текста и ключа в биты
            var key_bit = new BitArray(keys_temp);
            var text_bit = new BitArray(block);

            // массив для двоичного представления ключа
            int[,] binary_key = new int[8, 32];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (key_bit.Get(index))
                    {
                        binary_key[i, j] = 1;
                    }
                    index++;
                }
            }

            // Идём по блокам текста
            for (int i = 0; i < block.Length; i += 8)
            {
                // Выделяет место под старшую и младшую половину блока
                byte[] temp_senior_byte = new byte[4];
                byte[] temp_junior_byte = new byte[4];

                // Копируем блок текста в созданные половины, разбив его на старшую и младшую половины
                Array.Copy(block, i, temp_senior_byte, 0, 4);
                Array.Copy(block, i + 4, temp_junior_byte, 0, 4);

                // Преобразуем половины блока в массивы битов
                var senior_bits = new BitArray(temp_senior_byte);
                var junior_bits = new BitArray(temp_junior_byte);

                // Создаем численные массивы, поскольку массивы битов представлены в формате bool - а я хочу числа
                /* Стоит присмотреться. Возможно проще не создавать численные форматы, а работать с тем, что есть*/
                int[] senior_int = new int[32];
                int[] junior_int = new int[32];
                int[] junior_int_old = new int[32];

                // Копируем значения массива битов в численные массивы
                for (int m = 0; m < 32; m++)
                {
                    if (senior_bits.Get(m))
                    {
                        senior_int[m] = 1;
                    }
                    if (junior_bits.Get(m))
                    {
                        junior_int[m] = 1;
                        junior_int_old[m] = 1;
                    }
                }

                // Начинаем раунды преобразования
                index = 0;
                for (int j = 0; j < 32; j++)
                {

                    //Шаг 1 - сложение двоичных чисел по модулю 32
                    junior_int = Perform_Sum_By_32(junior_int, binary_key);
                    index = (index + 1) % 8; // меняем блок накладываемого ключа

                    // При шифровании ключ инвертируется на последние 8 раундов

                        if (j == 23)
                        {
                            binary_key = Invert_key_GOST(binary_key);
                        }

                    // Шаг 2 - разбиение младшей части на блоки по 4 бита с целью замены по таблице s-блоков
                    junior_int = Four_Bit_Replace(junior_int);

                    // Шаг 3 - циклический сдвиг влево на 11 бит
                    junior_int = Shift_Binary_Array(junior_int);

                    // Шаг 4 - Сложение младшей половины со старшей по модулю 2 (исключающее ИЛИ)
                    junior_int = Xor_Int_Arrays(junior_int, senior_int);

                    // Шаг 5 - Смена блоков местами
                    if (j == 31) // 32-й райнд. Новый младший блок становится старшим, старый младший остается и становится вместо нового младшего
                    {
                        junior_int.CopyTo(senior_int, 0);
                        junior_int_old.CopyTo(junior_int, 0);

                    }
                    else // 0-31-й раунд. Старый младший становится старшим, новый младший становится старым младшим
                    {
                        junior_int_old.CopyTo(senior_int, 0);
                        junior_int.CopyTo(junior_int_old, 0);
                    }
                }

                // переносим значения из int в BitArray
                for (int m = 0; m < junior_int.Length; m++)
                {
                    if (junior_int[m] == 1)
                    {
                        junior_bits[m] = true;
                    }
                    else
                    {
                        junior_bits[m] = false;
                    }

                    if (senior_int[m] == 1)
                    {
                        senior_bits[m] = true;
                    }
                    else
                    {
                        senior_bits[m] = false;
                    }
                }

                // Заносим результаты в выходной массив
                senior_bits.CopyTo(result, i);
                junior_bits.CopyTo(result, i + 4);
            }

            return result;
        }

        private BigInteger MixBlock(BigInteger hash, byte[] S, BigInteger block)
        {
            BigInteger result = 0;
            byte[] temp = new byte[32];
            Array.Copy(S, 0, temp, 0, S.Length);
            BigInteger s = new BigInteger(temp);

            for (int i = 0; i < 12; i++)
            {
                s = Func_Ksi(s);
            }
            result = s ^ block;
            result = Func_Ksi(result);
            result = result ^ hash;
            for (int i = 0; i < 61; i++)
            {
                result = Func_Ksi(result);
            }

            return result;
        }

        private BigInteger Func_A(BigInteger block)
        {
            BigInteger result = 0;
            byte[] data = new byte[33];
            byte[] temp = block.ToByteArray();

            //Array.Reverse(temp);
            //Array.Reverse(temp);

            //if (temp.Length > 32)
            //{
                Array.Copy(temp, 0, data, 0, temp.Length);
                temp = new byte[32];
                //Array.Reverse(data);
                Array.Copy(data, 0, temp, 0, 32);
                //Array.Reverse(temp);
                //data = new byte[33];
            //}

            //Array.Copy(temp, 0, data, /*data.Length - temp.Length - 1*/0, temp.Length);

            byte[] y1 = new byte[9];
            byte[] y2 = new byte[9];
            byte[] y3 = new byte[9];
            byte[] y4 = new byte[9];

            Array.Copy(temp, 0, y1, 0, 8);
            Array.Copy(temp, 8, y2, 0, 8);
            Array.Copy(temp, 16, y3, 0, 8);
            Array.Copy(temp, 24, y4, 0, 8);

            BigInteger by1 = new BigInteger(y1);
            BigInteger by2 = new BigInteger(y2);
            BigInteger b = by1 ^ by2;

            temp = b.ToByteArray();

            Array.Copy(temp, 0, data, 0, temp.Length);
            Array.Copy(y4, 0, data, 8, 8);
            Array.Copy(y3, 0, data, 16, 8);
            Array.Copy(y2, 0, data, 24, 8);

            temp = new byte[32];
            Array.Copy(data, 0, temp, 0, 32);
            Array.Reverse(temp);
            data = new byte[33];

            Array.Copy(temp, 0, data, 0, 32);

            result = new BigInteger(data);

            byte[] test = result.ToByteArray();
            return result;
        }

        private BigInteger Func_P(BigInteger block)
        {
            BigInteger result = 0;
            byte[] data = block.ToByteArray();
            byte[] temp = new byte[33];
            //Array.Copy(data, 0, temp, 0, data.Length);

            //if (data.Length < 32)
           // {

                //result = new byte[4];
                Array.Copy(data, 0, temp, 0, data.Length);
                data = new byte[33];
                //Array.Copy(temp, 0, data, data.Length - temp.Length, temp.Length);
                Array.Copy(temp, 0, data, 0, temp.Length);
                temp = new byte[32];
           // }

            //for (int i = 0; i < 32; i++)
            //{
            //    result += temp[i] << i * 8;
            //}

            //BigInteger test = new BigInteger(temp);

            //Array.Copy(data, 0, temp, 0, 32);

            for (int i = 31; i >= 0; i--)
            {
                temp[i] = data[32 - index_fi[i]];   
            }

            //for (int i = 0; i < 32; i++)
            //{
            //    result += data[i] << i * 8;
            //}
            //if (temp.Length >= 32)
            //{
                Array.Copy(temp, 0, data, 0, 32);
                temp = new byte[33];
                Array.Copy(data, 0, temp, 0, 32);
                //data = new byte[33];
            //}
            result = new BigInteger(temp);

            return result;
        }

        private BigInteger Func_Ksi(BigInteger block)
        {
            BigInteger result = 0;
            byte[] tempResult = new byte[33];
            byte[] data = block.ToByteArray();
            byte[] temp = new byte[32];

            if (data.Length < 32)
            {               
                Array.Copy(data, 0, temp, 0, data.Length);
                data = new byte[32];
                Array.Copy(temp, 0, data, data.Length - temp.Length, temp.Length);
            }

            temp = new byte[2];

            Array.Copy(data, 0, temp, 0, 2);

            temp[0] = (byte)(temp[0] ^ data[2] ^ data[4] ^ data[6] ^ data[24] ^ data[30]);
            temp[1] = (byte)(temp[1] ^ data[3] ^ data[5] ^ data[7] ^ data[25] ^ data[31]);

            Array.Copy(temp, 0, tempResult, 0, 2);
            for (int i = 2; i < 32; i += 2)
            {
                tempResult[i] = data[32 - i];
                tempResult[i + 1] = data[33 - i];
            }

            result = new BigInteger(tempResult);

            return result;
        }

        public BigInteger[] CheckSum(byte[] inData)
        {
            BigInteger[] result = new BigInteger[inData.Length / 32 + 1];
            //BigInteger result = 0;
            BigInteger temp = 0;
            byte[] bTemp = new byte[33];

            // УБЕДИТЬСЯ В ПРАВИЛЬНОСТИ
            for (int i = 0; i < result.Length - 1; i++)
            {
                Array.Copy(inData, i * 32, bTemp, 0, 32);

                //for (int j = 0; j < 32; j++)
                //{
                //    temp += bTemp[j] << j * 8;
                //}

                //result[i] = temp;
                result[i] = new BigInteger(bTemp); // tempo
                result[result.Length - 1] += result[i];
            }

            return result;
        }

        private int[] Perform_Sum_By_32(int[] a, int[,] b)
        {
            int remainder = 0;

            for (int m = 31; m >= 0; m--)
            {
                if (a[m] == 0 && b[index, m] == 0 && remainder == 0)
                {
                    a[m] = 0;
                    remainder = 0;
                }
                else if ((a[m] == 0 && b[index, m] == 0 && remainder == 1) ||
                         (a[m] == 0 && b[index, m] == 1 && remainder == 0) ||
                         (a[m] == 1 && b[index, m] == 0 && remainder == 0))
                {
                    a[m] = 1;
                    remainder = 0;
                }
                else if ((a[m] == 0 && b[index, m] == 1 && remainder == 1) ||
                         (a[m] == 1 && b[index, m] == 0 && remainder == 1) ||
                         (a[m] == 1 && b[index, m] == 1 && remainder == 0))
                {
                    a[m] = 0;
                    remainder = 1;
                }
                else if (a[m] == 1 && b[index, m] == 1 && remainder == 1)
                {
                    a[m] = 1;
                    remainder = 1;
                }
            }

            return a;
        }

        private int[,] Invert_key_GOST(int[,] key)
        {
            for (int m = 0; m < key.GetLength(0) / 2; m++)
            {
                for (int n = 0; n < key.GetLength(1); n++)
                {
                    int k_temp = key[m, n];
                    key[m, n] = key[7 - m, n];
                    key[7 - m, n] = k_temp;
                }
            }
            return key;
        }

        private int[] Four_Bit_Replace(int[] block)
        {

            int[] blocks_4_bits = new int[8]; // Создаем массив для 4-х битных блоков
            for (int m = 0; m < blocks_4_bits.Length; m++)
            {
                for (int n = 0; n < 4; n++)
                {
                    if (block[m * 4 + n] == 1)
                    {
                        // Тут 4-х битное двоичное число преобразуется в десятичное
                        blocks_4_bits[m] += Convert.ToInt32(Math.Pow(Convert.ToDouble(2), Convert.ToDouble(3 - n)));
                    }
                }

                // Поиск по таблице и замена
                for (int x = 0; x < 16; x++)
                {
                    if (blocks_4_bits[m] == x)
                    {
                        blocks_4_bits[m] = s_blocks[7 - m, x];
                        break;
                    }
                }

                //преобразуем числа обратно в биты
                string binary_block = Convert.ToString(blocks_4_bits[m], 2);
                while (binary_block.Length < 4)
                {
                    // Делаем все значения 4-х битными
                    binary_block = binary_block.Insert(0, "0");
                }

                // В соответствии со значениями из обработанной строки делаем соответствующие замены в int-массиве
                for (int x = 0; x < binary_block.Length; x++)
                {
                    if (binary_block[x].ToString() == "0")
                    {
                        block[m * 4 + x] = 0;
                    }
                    else if (binary_block[x].ToString() == "1")
                    {
                        block[m * 4 + x] = 1;
                    }
                }
            }

            return block;
        }

        private int[] Shift_Binary_Array(int[] block)
        {
            string shifted_block = "";
            for (int m = 0; m < block.Length; m++)
            {
                shifted_block += block[(m + 11) % block.Length];
            }
            for (int m = 0; m < block.Length; m++)
            {
                if (shifted_block[m].ToString() == "0")
                {
                    block[m] = 0;
                }
                else
                {
                    block[m] = 1;
                }
            }

            return block;
        }

        private int[] Xor_Int_Arrays(int[] a, int[] b)
        {
            for (int m = 0; m < a.Length; m++)
            {
                if (a[m] == b[m])
                {
                    a[m] = 0;
                }
                else
                {
                    a[m] = 1;
                }
            }

            return a;
        }
    }
}
