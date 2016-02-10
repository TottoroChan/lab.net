using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            int c = 0; 
            // S - строка в которой считается длина слов; c - среднее количество букв в слове;
            Console.WriteLine("Введите строку для подсчёта средней длины слова:");
            s = Console.ReadLine();
            //разделение строки на подстроки без учета символов пунктуации.
            string[] word = s.Split('\r', '\n', ' ', ',', '.', ':', ';', '\"', '!', '?');
            for (int i = 0; i < word.Length; i++)
                c += word[i].Length;
            c /= word.Length; 
            Console.WriteLine("Средняя длина слова в строке: {0}", c);
            
            Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
