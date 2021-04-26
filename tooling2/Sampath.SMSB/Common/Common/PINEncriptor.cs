using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.Common
{
    public static class PINEncriptor
    {
        public static String Encrypt(int pin)
        {
            String EncodedPin = "";
            int[] pinarray = new int[4];
            char[,] KeyMap = new char[5, 10];
            string sentence = "0000000000)(*&^%$#@!ASDFGHJKL;ZXCVBNM<>/QWERTYUIOP";
            char[] charArr = sentence.ToCharArray();
            int o = charArr.Length;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    KeyMap[i, j] = sentence[((i * 10) + j)];
                }
            }

            pinarray = ToDigitArray(pin);
            int k = 0;
            for (int i = 1; i <= 4; i++)
            {
                EncodedPin += KeyMap[i, pinarray[k]];
                k += 1;
            }
            return EncodedPin;
        }
        public static int[] ToDigitArray(int n)
        {
            int[] result = new int[GetDigitArrayLength(n)];
            for (int i = 0; i < result.Length; i++)
            {
                result[result.Length - i - 1] = n % 10;
                n /= 10;
            }
            return result;
        }
        private static int GetDigitArrayLength(int n)
        {
            if (n == 0)
                return 1;
            return 1 + (int)Math.Log10(n);
        }
    }
}
