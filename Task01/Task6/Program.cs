using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {

            Boolean b = false, i = false, u = false;
            int caseSwitch, count = 0, k = 0; //count - проверка на действие. i - если число больше 0, то программа закрывается
            string s = "None", s1 = "Bold", s2 = "Italic", s3 = "Underline";
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Параметры надписи: {0}", s);
            do
            {
                Console.WriteLine("Введите:\n 1: bold\n 2: italic\n 3: underline");
                caseSwitch = Convert.ToInt32(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 1:
                        if ((b == false) && (i == false) && (u == false)&&(count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}", s1);
                            b = true;
                            count++;
                        }
                        if ((b == true) && (i == false) && (u == false) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}", s);
                            b = false;
                            count++;
                        }
                        if ((b == false) && (i == true) && (u == true) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}, {2}", s1, s2, s3);
                            b = true;
                            count++;
                        }
                        if ((b == false) && (i == true) && (u == false) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}", s1, s2);
                            b = true;
                            count++;
                        }
                        if ((b == false) && (i == false) && (u == true) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}", s1, s3);
                            b = true;
                            count++;
                        }
                        if ((b == true) && (i == true) && (u == true) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}", s2, s3);
                            b = false;
                            count++;
                        }
                        if ((b == true) && (i == true) && (u == false) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}", s2);
                            b = false;
                            count++;
                        }
                        if ((b == true) && (i == false) && (u == true) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}", s3);
                            b = false;
                            count++;
                        }
                        count = 0;
                        break;
                    case 2:
                        if ((b == false) && (i == false) && (u == false) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}", s2);
                            i = true;
                            count++;
                        }
                        if ((b == false) && (i == true) && (u == false) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}", s);
                            i = false;
                            count++;
                        }
                        if ((b == true) && (i == false) && (u == true) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}, {2}", s1, s2, s3);
                            i = true;
                            count++;
                        }
                        if ((b == true) && (i == false) && (u == false) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}", s1, s2);
                            i = true;
                            count++;
                        }
                        if ((b == false) && (i == false) && (u == true) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}", s2, s3);
                            i = true;
                            count++;
                        }
                        if ((b == true) && (i == true) && (u == true) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}", s1, s3);
                            i = false;
                            count++;
                        }
                        if ((b == true) && (i == true) && (u == false) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}", s1);
                            i = false;
                            count++;
                        }
                        if ((b == false) && (i == true) && (u == true) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}", s3);
                            i = false;
                            count++;
                        }
                        count = 0;
                        break;
                    case 3:
                        if ((b == false) && (i == false) && (u == false) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}", s1);
                            u = true;
                            count++;
                        }
                        if ((b == false) && (i == false) && (u == true) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}", s);
                            u = false;
                            count++;
                        }
                        if ((b == true) && (i == true) && (u == false) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}, {2}", s1, s2, s3);
                            u = true;
                            count++;
                        }
                        if ((b == true) && (i == false) && (u == false) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}", s1, s3);
                            u = true;
                            count++;
                        }
                        if ((b == false) && (i == true) && (u == false) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}", s2, s3);
                            u = true;
                            count++;
                        }
                        if ((b == true) && (i == true) && (u == true) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}", s1, s2);
                            u = false;
                            count++;
                        }
                        if ((b == true) && (i == false) && (u == true) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}, {2}", s1, s2, s3);
                            u = false;
                            count++;
                        }
                        if ((b == false) && (i == true) && (u == true) && (count == 0))
                        {
                            Console.WriteLine("Параметры надписи: {0}, {1}, {2}", s1, s2, s3);
                            u = false;
                            count++;
                        }
                        count = 0;
                        break;
                    default:
                        Console.WriteLine("Неверное значение.");
                        break;
                }
            } while (k == 0);
        }
    }
}
