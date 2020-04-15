using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace lab2
{
    class Trisemus
    {
       public static char[] alphabet = "abcdefghijklmnopqrstuvwxyz. ".ToCharArray();
       public static int columns = 7;
        int rows = alphabet.Length / columns;
        public char[] keyWord = "tanya".Distinct().ToArray();

        public string createTableAndDecryptText(string message)
        {
            // Создаем таблицу
            var table = new char[rows, columns];

            // Вписываем в нее ключевое слово
            for (var i = 0; i < keyWord.Length; i++)
            {
                table[i / columns, i % columns] = keyWord[i];
            }

            // Исключаем уникальные символы ключевого слова из алфавита
            alphabet = alphabet.Except(keyWord).ToArray();

            // Вписываем алфавит
            for (var i = 0; i < alphabet.Length; i++)
            {
                int position = i + keyWord.Length;
                table[position / columns, position % columns] = alphabet[i];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    Console.Write(table[i, j] + " ");
                Console.WriteLine();
            }

            // Создаем место для будущего зашифрованного сообщения
            var result = new char[message.Length];

            // Шифруем сообщение
            for (var k = 0; k < message.Length; k++)
            {
                char symbol = message[k];
                // Пытаемся найти символ в таблице
                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < columns; j++)
                    {
                        if (symbol == table[i, j])
                        {
                            symbol = table[(i + 1) % rows, j]; // Смещаемся циклически на следующую строку таблицы и запоминаем новый символ
                            i = rows; // Завершаем цикл по строкам
                            break; // Завершаем цикл по колонкам
                        }
                    }
                }
                // Записываем найденный символ
                result[k] = symbol;
               
            }
            return new string(result);
        }

        public void WriteFile(string text, string path)
        {
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }
        }
        public string ReadFile()
        {

            using (FileStream fstream = File.OpenRead(@"E:\SomeDir\text.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);

                return textFromFile;
            }
        }

    }
}
