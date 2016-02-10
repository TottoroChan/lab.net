using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Console.WriteLine("Введите строку:");
            string a = Console.ReadLine();
            MyString s = new MyString(a); //Преобразование строки в массив символов
            Console.WriteLine("Ваша строка, преобразованная в массив:");
            s.Print(); // вывод массива символов
            Console.WriteLine("Введите строку для сравнения:");
            a = Console.ReadLine();
            if (s.Equals(a) == false) Console.WriteLine("Строки не равны."); // сравнение массива и строки
            else Console.WriteLine("Строки равны.");
            Console.WriteLine("Массив преобразованный в строку:");
            Console.WriteLine(s.ToString()); //преобразование массива в строку
            

            Console.Write("\nНажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
