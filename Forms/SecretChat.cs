using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Security.Cryptography;
using System.IO;
using System.Collections;

namespace KMZI_2
{
    public partial class SecretChat : Form
    {

        byte[] sKeyA;
        byte[] sKeyB;

        BigInteger p;
        BigInteger q;
        BigInteger n;
        BigInteger euler;
        BigInteger exp;
        BigInteger d;

        BigInteger[] keysA;
        BigInteger[] keysB;
        BigInteger[] keysS;

        byte[] junkBytes = Encoding.Default.GetBytes("0");

        PrimeNumbers pNumbers = new PrimeNumbers();
        BasicNumberTheoryMath basicMath = new BasicNumberTheoryMath();
        RSA rsa = new RSA();
        DES des = DES.Create();
        Random rnd = new Random();

        int[] key_replace_start = { 57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18,
                                    10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36,
                                    63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22,
                                    14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4 };

        // Конечная перестановка сжатия ключа
        int[] key_replace_compress = { 14, 17, 11, 24, 1, 5, 3, 28,
                                       15, 6, 21, 10, 23, 19, 12, 4,
                                       26, 8, 16, 7, 27, 20, 13, 2,
                                       41, 52, 31, 37, 47, 55, 30, 40,
                                       51, 45, 33, 48, 44, 49, 39, 56,
                                       34, 53, 46, 42, 50, 36, 29, 32 };

        int[] start_IP = { 58, 50, 42, 34, 26, 18, 10, 2,
                           60, 52, 44, 36, 28, 20, 12, 4,
                           62, 54, 46, 38, 30, 22, 14, 6,
                           64, 56, 48, 40, 32, 24, 16, 8,
                           57, 49, 41, 33, 25, 17, 9, 1,
                           59, 51, 43, 35, 27, 19, 11, 3,
                           61, 53, 45, 37, 29, 21, 13, 5,
                           63, 55, 47, 39, 31, 23, 15, 7 };

        // Конечная перестановка блока текста
        int[] end_IP = { 40, 8, 48, 16, 56, 24, 64, 32,
                         39, 7, 47, 15, 55, 23, 63, 31,
                         38, 6, 46, 14, 54, 22, 62, 30,
                         37, 5, 45, 13, 53, 21, 61, 29,
                         36, 4, 44, 12, 52, 20, 60, 28,
                         35, 3, 43, 11, 51, 19, 59, 27,
                         34, 2, 42, 10, 50, 18, 58, 26,
                         33, 1, 41, 9, 49, 17, 57, 25 };

        // Таблица расширения блока текста
        int[] p_box_expand = { 32, 1, 2, 3, 4, 5,
                               4, 5, 6, 7, 8, 9,
                               8, 9, 10, 11, 12, 13,
                               12, 13, 14, 15, 16, 17,
                               16, 17, 18, 19, 20, 21,
                               20, 21, 22, 23, 24, 25,
                               24, 25, 26, 27, 28, 29,
                               28, 29, 30, 31, 32, 1 };

        // Прямой p-бокс
        int[] p_box_straight = { 16, 7, 20, 21, 29, 12, 28, 17,
                                 1, 15, 23, 26, 5, 18, 31, 10,
                                 2, 8, 24, 14, 32, 27, 3, 9,
                                 19, 13, 30, 6, 22, 11, 4, 25 };

        byte[,,] s_table = { // S1
                      { { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 },
                        { 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 },
                        { 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 },
                        { 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 } },
                      // S2
                      { { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13 ,12, 0, 5 ,10 },
                        { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
                        { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 },
                        { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 } },
                      // S3
                      { { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 },
                        { 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 },
                        { 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 },
                        { 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 } },
                      // S4
                      { { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
                        { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 },
                        { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 },
                        { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 } },
                      // S5
                      { { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
                        { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 },
                        { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 },
                        { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 } },
                      // S6
                      { { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
                        { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
                        { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 },
                        { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 } },
                      // S7
                      { { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
                        { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 },
                        { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 },
                        { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 } },
                      // S8
                      { { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
                        { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 },
                        { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 },
                        { 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 } } };


        public SecretChat()
        {
            InitializeComponent();

            keysA = GenerateKeys();
            keysB = GenerateKeys();
            keysS = GenerateKeys();

            listBox2.Items.Add(DateTime.Now + ": Открытый ключ UserA " + keysA[0]);
            listBox2.Items.Add(DateTime.Now + ": Секретный ключ UserA " + keysA[1]);
            listBox2.Items.Add(DateTime.Now + ": Открытый ключ UserB " + keysB[0]);
            listBox2.Items.Add(DateTime.Now + ": Секретный ключ UserB " + keysB[1]);
            listBox2.Items.Add(DateTime.Now + ": Открытый ключ Сервера " + keysS[0]);
            listBox2.Items.Add(DateTime.Now + ": Секретный ключ Сервера " + keysS[1]);
        }

        private void SecretChat_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.Add(DateTime.Now + " UserA: " + textBox1.Text);
            
            // тут по диффи хеллману надо сгенерировать сессионные ключи
            int a = rnd.Next(1000000000, int.MaxValue);
            int b = rnd.Next(1000000000, int.MaxValue);
            int c = rnd.Next(1000000000, int.MaxValue);
            while (b == a)
            {
                b = rnd.Next(1000000000, int.MaxValue);
            }
            while (b == c)
            {
                c = rnd.Next(1000000000, int.MaxValue);
            }

            listBox2.Items.Add(DateTime.Now + ": Д-Х секретный ключ UserA: " + a.ToString());
            listBox2.Items.Add(DateTime.Now + ": Д-Х секретный ключ Сервера: " + b.ToString());
            listBox2.Items.Add(DateTime.Now + ": Д-Х секретный ключ UserB: " + c.ToString());
            // 0 - открытый ключ
            // 1 - секретный клч
            // 2 - модуль n

            // предварительно генерируем набор ключей
            // Отправитель и получатель:
            // -сессионные ключи для общения с сервером
            // -свои закрытые ключи RSA
            // -открытые ключи rsa сервера

            // Сервер:
            // -сессионные ключи для связи с поучателем и отправителем
            // -открытые ключи отправителя и получателя
            // -свой закрытый ключ
            byte[] message = Encoding.UTF8.GetBytes(textBox1.Text);          
            var hash = GetHash(Encoding.UTF8.GetBytes(textBox1.Text)); // вычисляется хэш
            listBox4.Items.Add(DateTime.Now + ": Получен хэш сообщения");

            textBox1.Clear();
            hash = ProcessHash(hash, false, keysS[0], keysS[1], keysS[2]); // Шифруем хэш по RSA открытым ключом сервера
            listBox4.Items.Add(DateTime.Now + ": Хэш сообщения зашифрован");

            sKeyA = GenerateSessionKey(message, a, b);
            listBox4.Items.Add(DateTime.Now + ": Выработан сессионный ключ между отправителем и сервером: " + sKeyA.ToString());

            message = ProcessMesssage(message, sKeyA, true); // Шифруем хэш сессионным ключом по DES или ГОСТ отправитель-сервер
            listBox4.Items.Add(DateTime.Now + ": Сообщение зашифровано");
            listBox4.Items.Add(DateTime.Now + ": Сообщение отправлено на сервер");




            // Далее отправили зашифрованное сообщение и зашифрованный хэш на сервер
            listBox2.Items.Add(DateTime.Now.ToString() + ": Сообщение попало на сервер");

            if (!checkBox1.Checked)
            {
                hash = ProcessHash(hash, true, keysS[0], keysS[1], keysS[2]); // Расшифровываем хэш по RSA по закрытому ключу сервера
            }
            listBox2.Items.Add(DateTime.Now.ToString() + ": Хэш расшифрован ");

            message = ProcessMesssage(message, sKeyA, false); // Расшифровываем сообщение сессионным ключом отправитель-сервер

            var hashTemp = GetHash(message); // Вычисляем хэш полученного сообщения
            listBox2.Items.Add(DateTime.Now.ToString() + ": Хэш расшифрованного сообщения получен");
            listBox2.Items.Add(DateTime.Now.ToString() + ": Сравнение хэшей...");

            BigInteger temp1 = new BigInteger(hash.Concat(new byte[] { 0 }).ToArray());
            BigInteger temp2 = new BigInteger(hashTemp.Concat(new byte[] { 0 }).ToArray());
           
            if (temp1 == temp2)
            {
                listBox2.Items.Add(DateTime.Now.ToString() + ": Подлинность сообщения подтверждена");
            }
            else
            {
                listBox2.Items.Add(DateTime.Now.ToString() + ": Ошибка. Подлинность сообщения не подтверждена");
                listBox1.Items.Add(DateTime.Now.ToString() + ": Ошибка на стороне сервера.");
                return;
            }

            // Сверяем полученный и расшифрованный хэши
            // Если не совпали, сообщаем отправителю об ошибке на стороне сервера
            // Иначе продолжаем...

            hash = ProcessHash(hash, false, keysB[0], keysB[1], keysB[2]); // Шифруем хэш открым ключом получателя по RSA
            listBox2.Items.Add(DateTime.Now.ToString() + ": Хэш зашифрован");

            sKeyB = GenerateSessionKey(message, c, b);
            listBox2.Items.Add(DateTime.Now + ": Выработан сессионный ключ между сервером и получателем: " + sKeyB.ToString());
            message = ProcessMesssage(message, sKeyB, true); // Шифруем сообщение сессионным клчом сервер-получатель
            listBox2.Items.Add(DateTime.Now.ToString() + ": Сообщение зашифровано");

            // Далее отправили зашифрованное сообщение и зашифрованный хэш получателю
            listBox2.Items.Add(DateTime.Now.ToString() + ": Сообщение отправлено получателю");




            if (!checkBox2.Checked)
            {
                hash = ProcessHash(hash, true, keysB[0], keysB[1], keysB[2]); // Получатель расшифровывает хэш своим закрытым ключом
                listBox5.Items.Add(DateTime.Now + ": Полученный хэш расшифрован");
            }

            message = ProcessMesssage(message, sKeyB, false); // Получатель расшифровывает сообщщение сессионным ключом
            listBox5.Items.Add(DateTime.Now + ": Сообщение расшифровано");

            hashTemp = GetHash(message); // Получаем хэш полученного сообщения
            listBox5.Items.Add(DateTime.Now + ": Хэш расшифрованного сообщения получен");

            temp1 = new BigInteger(hash.Concat(new byte[] { 0 }).ToArray());
            temp2 = new BigInteger(hashTemp.Concat(new byte[] { 0 }).ToArray());
            // Сверяем вычисленный и расшифрованный хэши
            // Если хэши не совпали, сообщаем отправителю об ошибке на стороне получателя
            // Иначе, выводим получателю полученное сообщение
            if (temp1 == temp2)
            {
                listBox3.Items.Add(DateTime.Now.ToString() + " UserA: " + Encoding.UTF8.GetString(message));
            }
            else
            {
                listBox1.Items.Add(DateTime.Now.ToString() + ": Ошибка на стороне получателя");
            }
        }

        private byte[] GenerateSessionKey(byte[] data, int secretKeyUser, int secretKeyServer)
        {
            int count = data.Length;
            int realCount = data.Length;
            while (count % 8 != 0)
            {
                count++;
            }
            p = BigInteger.Parse(pNumbers.GeneratePrime(20));
            bool isOk = false;
            int g = 0;
            while (!isOk)
            {
                if (p >= int.MaxValue)
                {
                    g = rnd.Next(2, int.MaxValue);
                }
                else
                {
                    g = rnd.Next(2, (int)p);
                }

                for (int i = 0; i < 5; i++)
                {
                    BigInteger temp = basicMath.Find_ModularExpo(g, rnd.Next(0, int.MaxValue), p);
                    if (temp == 1)
                    {
                        break;
                    }
                    else
                    {
                        isOk = true;
                    }
                    
                }                
            }

            BigInteger A = basicMath.Find_ModularExpo(g, secretKeyUser, p);
            byte[] result = basicMath.Find_ModularExpo(A, secretKeyServer, p).ToByteArray();
            byte[] temp1 = Encoding.UTF8.GetBytes((count - realCount).ToString());
            result[0] = temp1[0];
            
            byte[] temp2 = new byte[7];
            if (result.Length < 7)
            {               
                for (int i = 0; i < 7; i++)
                {
                    temp2[i] = result[i % 7];
                }
            }
            if (result.Length > 7)
            {
                Array.Copy(result, 0, temp2, 0, 7);
            }

            return temp2;
        }

        private byte[] GetHash(byte[] data)
        {
            SHA1 sha = SHA1.Create();
            byte[] result = sha.ComputeHash(data);

            return result;
        }

        private byte[] ProcessHash(byte[] data, bool encrypting, BigInteger exp, BigInteger d, BigInteger n)
        {
            BigInteger result = 0;
            BigInteger data2 = new BigInteger(data.Concat(new byte[] { 0 }).ToArray());

            if (encrypting)
            {
                result = basicMath.Find_ModularExpo(data2, d, n);                               
            }
            else
            {
                result = basicMath.Find_ModularExpo(data2, exp, n);
            }

            return result.ToByteArray();
        }
        private BigInteger[] GenerateKeys()
        {
            BigInteger[] result = new BigInteger[3];

            p = BigInteger.Parse(pNumbers.GeneratePrime(50));
            q = BigInteger.Parse(pNumbers.GeneratePrime(50));
            while (p == q)
            {
                q = BigInteger.Parse(pNumbers.GeneratePrime(50));
            }
            n = p * q;
            euler = (p - 1) * (q - 1);
            exp = rsa.GetExp(euler, p);
            d = basicMath.Find_Inversion(exp, euler);

            result[0] = exp;
            result[1] = d;
            result[2] = n;
            return result;
        }

        private byte[] ProcessMesssage(byte[] message, byte[] key, bool encryption)
        {
            byte[] result = ECB_Mode(message, key, encryption);

            return result;
        }

        private byte[] ECB_Mode(byte[] data, byte[] bKey, bool encryption)
        {
            byte[] result;
            // Проверка длины ключа
            //if (!Check_KeyLength(bKey))
            //{
            //    byte[] temp = new byte[bKey.Length];
            //    bKey = new byte[7];
            //    Array.Copy(temp, 0, bKey, 0, 7);
            //}

            //// Проверка корректности формата ключа при расшифровании
            //if (!encryption)
            //{
            //    //if (!Check_KeyCorrectness(bKey[0]))
            //       // return;
            //}

            // Делаем текст сообщения четным при шифровании
            if (encryption)
            {
                // Считаем, сколько байтов не хватает шифруемому тексту до кратности 8-ми
                int count = data.Length;
                while (count % 8 != 0)
                {
                    count++;
                }

                byte[] inTemp = new byte[data.Length]; // переносим входные данные во временный массив
                data.CopyTo(inTemp, 0);
                data = new byte[count]; // расширяем массив входных данных

                // Расширяем исходный массив байтов на нужное количество и в конце приписываем несколько байтов
                for (int i = 0; i < inTemp.Length; i++)
                {
                    data[i] = inTemp[i];
                }
                for (int i = inTemp.Length; i < data.Length; i++)
                {
                    data[i] = junkBytes[0];
                }

                // Вместо первого символа ключа подставим число, равное количеству символов, приписанных в конце
                // чтобы потом убрать их из расшифрованного текста
                //byte k = Convert.ToByte(count - inTemp.Length); 
                inTemp = null;
                //bKey[0] = k;
            }
            //тест
            //string tempsss = "";
            //bKey[0] = 51;
            //for (int i = 1; i < 7; i++)
            //{
            //    //tempsss += bKey[i].ToString();
            //    bKey[i] = 48;
            //}

            // Формируем раундовый ключ для дальнейшего шифрования
            BitArray[] key = Generate_Round_Key(bKey, encryption);

            result = new byte[data.Length];

            // Если шифротекст не кратен 8, то его невозможно обработать
            if (!encryption)
            {
                if (data.Length % 8 != 0)
                {
                    //inBox.Clear();
                    //inFile = null;
                    //MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    //return;
                }
            }

            // Идём по каждому блоку текста (64 бита каждый)
            for (int i = 0; i < data.Length; i += 8)
            {
                // Выполним стартовую перестановку
                byte[] temp = new byte[8];
                Array.Copy(data, i, temp, 0, temp.Length);
                var temp_bits = new BitArray(temp);
                var temp_bits2 = new BitArray(temp);
                for (int m = 0; m < temp_bits.Length; m++)
                {
                    temp_bits2[m] = temp_bits[start_IP[m] - 1];
                }

                // Разбили блок текста на две половины
                var bits_senior = new BitArray(32);
                var temp_senior = new BitArray(32);
                var bits_junior = new BitArray(32);
                var temp_junior = new BitArray(32);

                for (int j = 0; j < bits_senior.Length; j++)
                {
                    bits_senior[j] = temp_bits2[j];
                    temp_senior[j] = temp_bits2[j];
                    bits_junior[j] = temp_bits2[bits_senior.Length + j];
                    temp_junior[j] = temp_bits2[bits_senior.Length + j];
                }

                // Начинаем 16 раундов преобразования
                for (int j = 0; j < 16; j++)
                {
                    // Запомним правый блок до преобразования
                    var bits_junior_old = new BitArray(bits_junior.Length);
                    for (int m = 0; m < bits_junior.Length; m++)
                    {
                        bits_junior_old[m] = bits_junior[m];
                    }

                    var bits_senior_old = new BitArray(bits_senior.Length);
                    for (int m = 0; m < bits_senior.Length; m++)
                    {
                        bits_senior_old[m] = bits_senior[m];
                    }

                    // Шаг 1 - Расширим правый блок до 48 бит с помощью P-бокса
                    for (int m = 0; m < temp_junior.Length; m++)
                    {
                        temp_junior[m] = bits_junior[m];
                    }
                    bits_junior = new BitArray(48, false); // Инициализируем массив большего размера
                    for (int m = 0; m < bits_junior.Length; m++)
                    {
                        bits_junior[m] = temp_junior[p_box_expand[m] - 1];
                    }
                    /* Закончили расширять блок*/

                    // Шаг 2 - XOR-им блок с элементом раундового ключа
                    bits_junior.Xor(key[j]);

                    // Шаг 3 - делаем замену с использованием s-блоков
                    bits_junior = S_Block_Replace(bits_junior);

                    // Шаг 4 - делаем перетасовку битов с помощью прямого P-бокса
                    for (int m = 0; m < temp_junior.Length; m++)
                    {
                        temp_junior[m] = bits_junior[m];
                    }
                    for (int m = 0; m < bits_junior.Length; m++)
                    {
                        bits_junior[m] = temp_junior[p_box_straight[m] - 1];
                    }

                    //Шаг 5 - БЕЗ ПОНЯТИЯ. Вроде XOR-им получившийся правый блок с левым
                    bits_senior.Xor(bits_junior);

                    //Шаг 6 - меняем блоки местами
                    if (j != 15) // Ели не последний раунд, то меняем местами
                    {
                        // Преобразованная старшая половина становится младшей
                        for (int m = 0; m < bits_senior.Length; m++)
                        {
                            bits_junior[m] = bits_senior[m];
                        }
                        // Старая младшая половина становится старшей
                        for (int m = 0; m < bits_senior.Length; m++)
                        {
                            bits_senior[m] = bits_junior_old[m];
                        }
                    }
                    else // В последнем раунде...
                    {
                        // ...старая половина так и остается, а младшая остается такой, какой была до преобзразования
                        for (int m = 0; m < bits_senior.Length; m++)
                        {
                            bits_junior[m] = bits_junior_old[m];
                        }
                    }
                }

                // Конечная перестановка по end_IP
                temp = new byte[8];
                bits_senior.CopyTo(temp, 0);
                bits_junior.CopyTo(temp, 4);
                temp_bits = new BitArray(temp);
                temp_bits2 = new BitArray(temp);
                for (int m = 0; m < temp_bits.Length; m++)
                {
                    temp_bits2[m] = temp_bits[end_IP[m] - 1];
                }
                temp_bits2.CopyTo(result, i);
            }

            // При расшифровке удаляем лишние байты
            if (!encryption)
            {
                result = OutFile_CutBlocks(result, bKey[0]);
            }

            // Вывод результата

            return result;
        }

        private BitArray[] Generate_Round_Key(byte[] key, bool encryption)
        {
            int count = 0;
            string binary_key = "";
            string temp = "";
            //byte[] k = Encoding.Default.GetBytes(key);

            BitArray key_bits = new BitArray(key);
            // Конвертирование в двоичную форму
            for (int i = 0; i < key.Length; i++)
            {
                temp = Convert.ToString(key[i], 2);
                char[] sReverse = temp.ToCharArray();
                Array.Reverse(sReverse);
                temp = new string(sReverse);

                while (temp.Length < 8)
                {
                    temp = temp.Insert(0, "0");
                }

                binary_key += temp;
            }

            // 1. Добавление контрольных битов (до 64 бит)
            for (int i = 0; i < 64; i++)
            {
                if (i == 7 || i == 15 || i == 23 || i == 31 || i == 39 || i == 47 || i == 55 || i == 63)
                {
                    if (count % 2 != 0)
                    {
                        binary_key = binary_key.Insert(i, "0");
                    }
                    else
                    {
                        binary_key = binary_key.Insert(i, "1");
                    }
                    count = 0;
                    continue;
                }
                if (binary_key[i] == '1')
                    count++;
            }

            // 2. Начальная перестановка ключа (преобразует обратно в 56 бит)
            char[] temp2 = new char[key_replace_start.Length];
            for (int i = 0; i < key_replace_start.Length; i++)
            {
                temp2[i] = binary_key[key_replace_start[i] - 1];
            }

            char[] left_block = new char[28];
            char[] right_block = new char[28];

            // 3. Разбили ключ на 2 блока
            Array.Copy(temp2, 0, left_block, 0, 28);
            Array.Copy(temp2, 28, right_block, 0, 28);

            char[,] round_key = new char[16, 48]; // Массив под раундовый ключ

            // Делаем подключи
            for (int i = 0; i < 16; i++)
            {
                // 4. Циклический сдвиг влево на 1-2 бита
                if (i != 0 && i != 1 && i != 8 && i != 15)
                {
                    char[] temp3 = { left_block[0], left_block[1] };
                    char[] temp4 = { right_block[0], right_block[1] };
                    for (int j = 0; j < right_block.Length - 2; j++)
                    {
                        left_block[j] = left_block[j + 2];
                        right_block[j] = right_block[j + 2];
                    }
                    int index = 0;
                    for (int j = left_block.Length - 2; j < left_block.Length; j++)
                    {
                        left_block[j] = temp3[index];
                        right_block[j] = temp4[index];
                        index++;
                    }
                }
                else
                {
                    char temp3 = left_block[0];
                    char temp4 = right_block[0];
                    for (int j = 0; j < left_block.Length - 1; j++)
                    {
                        left_block[j] = left_block[j + 1];
                        right_block[j] = right_block[j + 1];
                    }
                    left_block[left_block.Length - 1] = temp3;
                    right_block[right_block.Length - 1] = temp4;
                }

                // 5. Объединяем два блока обратно в один
                char[] temp5 = new char[56];
                left_block.CopyTo(temp5, 0);
                right_block.CopyTo(temp5, 28);

                // 6. Производим перестановку сжатия
                char[] temp6 = new char[key_replace_compress.Length];
                for (int j = 0; j < key_replace_compress.Length; j++)
                {
                    temp6[j] = temp5[key_replace_compress[j] - 1];
                }

                // 7. Результат заносим в массив как элемент раундового ключа
                if (encryption)
                {
                    for (int j = 0; j < temp6.Length; j++)
                    {
                        round_key[i, j] = temp6[j];
                    }
                }
                // При расшифровании ключ будет инвертирован (Не во всех режимах)
                else
                {
                    for (int j = 0; j < temp6.Length; j++)
                    {
                        round_key[15 - i, j] = temp6[j];
                    }
                }
            }

            // Переносим результат генерации в массив другого формата
            BitArray[] key1 = new BitArray[16];
            for (int i = 0; i < key1.Length; i++)
            {
                key1[i] = new BitArray(48, false);
                for (int j = 0; j < key1[i].Length; j++)
                {
                    if (round_key[i, j] == '1')
                        key1[i][j] = true;
                }
            }
            return key1;
        }

        private BitArray S_Block_Replace(BitArray block)
        {
            int index = 0;
            int str; // Номер строки для s-блока
            int clmn; // Номер столбца для s-блока
            string bin = ""; // Сюда будут заноситься биты дял обработки
            BitArray result_block = new BitArray(32, false);

            // Блок текста разделится на 8 векторов по 6 бит
            int[,] int_block = new int[8, 6];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (block[index] == true)
                        int_block[i, j] = 1;

                    index++;
                }
            }

            // Идём по каждому блоку
            for (int i = 0; i < 8; i++)
            {
                str = 0;
                clmn = 0;
                bin = "";

                bin += int_block[i, 0].ToString() + int_block[i, 5].ToString();
                for (int m = 0; m < bin.Length; m++)
                {
                    if (bin[m] == '1')
                        str += Convert.ToInt32(Math.Pow(2, bin.Length - m - 1));
                }

                bin = "";
                for (int j = 1; j < 5; j++)
                {
                    bin += int_block[i, j];
                }
                for (int m = 0; m < bin.Length; m++)
                {
                    if (bin[m] == '1')
                        clmn += Convert.ToInt32(Math.Pow(2, bin.Length - m - 1));
                }

                // Получаем число из таблицы
                byte[] b = { Convert.ToByte(s_table[i, str, clmn]) };
                var binary = new BitArray(b);

                // Переносим полученное число в результирующий массив
                for (int m = 0; m < 4; m++)
                {
                    result_block[i * 4 + m] = binary[m]; //ТУТ БЫЛА СДЕЛАНА ИНВЕРСИЯ, НО ЭТО НЕ ПОМОГЛО
                }
            }

            return result_block;
        }

        private byte[] OutFile_CutBlocks(byte[] data, byte first)
        {
            byte[] outTemp = new byte[data.Length]; // Копируем выходные данные во временный массив
            data.CopyTo(outTemp, 0);
            // Пересоздаем выходной массив по принципу: длина минус число ранее приписанных байт              
            int test = Convert.ToInt32(Convert.ToChar(first).ToString());
            data = new byte[outTemp.Length - Convert.ToInt32(Convert.ToChar(first).ToString())];
            // Заносим данные обратно в массив
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = outTemp[i];
            }
            outTemp = null;

            return data;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Add(DateTime.Now + " UserB: " + textBox2.Text);

            // тут по диффи хеллману надо сгенерировать сессионные ключи
            int a = rnd.Next(1000000000, int.MaxValue);
            int b = rnd.Next(1000000000, int.MaxValue);
            int c = rnd.Next(1000000000, int.MaxValue);
            while (b == a)
            {
                b = rnd.Next(1000000000, int.MaxValue);
            }
            while (b == c)
            {
                c = rnd.Next(1000000000, int.MaxValue);
            }

            listBox2.Items.Add(DateTime.Now + ": Д-Х секретный ключ UserA: " + a.ToString());
            listBox2.Items.Add(DateTime.Now + ": Д-Х секретный ключ Сервера: " + b.ToString());
            listBox2.Items.Add(DateTime.Now + ": Д-Х секретный ключ UserB: " + c.ToString());

            byte[] message = Encoding.UTF8.GetBytes(textBox2.Text);
            var hash = GetHash(Encoding.UTF8.GetBytes(textBox2.Text)); // вычисляется хэш
            listBox5.Items.Add(DateTime.Now + ": Получен хэш сообщения");

            textBox2.Clear();
            hash = ProcessHash(hash, false, keysS[0], keysS[1], keysS[2]); // Шифруем хэш по RSA открытым ключом сервера
            listBox5.Items.Add(DateTime.Now + ": Хэш сообщения зашифрован");

            sKeyB = GenerateSessionKey(message, c, b);
            listBox5.Items.Add(DateTime.Now + ": Выработан сессионный ключ между отправителем и сервером" + sKeyB.ToString());

            message = ProcessMesssage(message, sKeyB, true); // Шифруем хэш сессионным ключом по DES или ГОСТ отправитель-сервер
            listBox5.Items.Add(DateTime.Now + ": Сообщение зашифровано");
            listBox5.Items.Add(DateTime.Now + ": Сообщение отправлено на сервер");



            // Далее отправили зашифрованное сообщение и зашифрованный хэш на сервер
            listBox2.Items.Add(DateTime.Now.ToString() + ": Сообщение попало на сервер");

            if (!checkBox1.Checked)
            {
                hash = ProcessHash(hash, true, keysS[0], keysS[1], keysS[2]); // Расшифровываем хэш по RSA по закрытому ключу сервера
            }
            listBox2.Items.Add(DateTime.Now.ToString() + ": Хэш расшифрован ");

            message = ProcessMesssage(message, sKeyB, false); // Расшифровываем сообщение сессионным ключом отправитель-сервер

            var hashTemp = GetHash(message); // Вычисляем хэш полученного сообщения
            listBox2.Items.Add(DateTime.Now.ToString() + ": Хэш расшифрованного сообщения получен");
            listBox2.Items.Add(DateTime.Now.ToString() + ": Сравнение хэшей...");

            BigInteger temp1 = new BigInteger(hash.Concat(new byte[] { 0 }).ToArray());
            BigInteger temp2 = new BigInteger(hashTemp.Concat(new byte[] { 0 }).ToArray());

            if (temp1 == temp2)
            {
                listBox2.Items.Add(DateTime.Now.ToString() + ": Подлинность сообщения подтверждена");
            }
            else
            {
                listBox2.Items.Add(DateTime.Now.ToString() + ": Ошибка. Подлинность сообщения не подтверждена");
                listBox3.Items.Add(DateTime.Now.ToString() + ": Ошибка на стороне сервера.");
                return;
            }


            hash = ProcessHash(hash, false, keysA[0], keysA[1], keysA[2]); // Шифруем хэш открым ключом получателя по RSA
            listBox2.Items.Add(DateTime.Now.ToString() + ": Хэш зашифрован");

            sKeyA = GenerateSessionKey(message, a, b);
            listBox2.Items.Add(DateTime.Now + ": Выработан сессионный ключ между сервером и получателем: " + sKeyA.ToString());

            message = ProcessMesssage(message, sKeyA, true); // Шифруем сообщение сессионным клчом сервер-получатель
            listBox2.Items.Add(DateTime.Now.ToString() + ": Сообщение зашифровано");

            // Далее отправили зашифрованное сообщение и зашифрованный хэш получателю
            listBox2.Items.Add(DateTime.Now.ToString() + ": Сообщение отправлено получателю");




            if (!checkBox2.Checked)
            {
                hash = ProcessHash(hash, true, keysA[0], keysA[1], keysA[2]); // Получатель расшифровывает хэш своим закрытым ключом
                listBox4.Items.Add(DateTime.Now + ": Полученный хэш расшифрован");
            }

            message = ProcessMesssage(message, sKeyA, false); // Получатель расшифровывает сообщщение сессионным ключом
            listBox4.Items.Add(DateTime.Now + ": Сообщение расшифровано");

            hashTemp = GetHash(message); // Получаем хэш полученного сообщения
            listBox4.Items.Add(DateTime.Now + ": Хэш расшифрованного сообщения получен");

            temp1 = new BigInteger(hash.Concat(new byte[] { 0 }).ToArray());
            temp2 = new BigInteger(hashTemp.Concat(new byte[] { 0 }).ToArray());
            // Сверяем вычисленный и расшифрованный хэши
            // Если хэши не совпали, сообщаем отправителю об ошибке на стороне получателя
            // Иначе, выводим получателю полученное сообщение
            if (temp1 == temp2)
            {
                listBox1.Items.Add(DateTime.Now.ToString() + " UserB: " + Encoding.UTF8.GetString(message));
            }
            else
            {
                listBox3.Items.Add(DateTime.Now.ToString() + ": Ошибка на стороне получателя");
            }
        }
    }
}
