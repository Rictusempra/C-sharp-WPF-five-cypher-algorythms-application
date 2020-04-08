﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFive
{
    class XOR
    {
            public static string EncodeDecrypt(string str, ushort secretKey)
            {
                var ch = str.ToArray(); //преобразуем строку в символы
                string newStr = "";      //переменная которая будет содержать зашифрованную строку
                foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
                    newStr += TopSecret(c, secretKey);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
                return newStr;
            }

            public static char TopSecret(char character, ushort secretKey)
            {
                character = (char)(character ^ secretKey); //Производим XOR операцию
                return character;
            }

    }
}
