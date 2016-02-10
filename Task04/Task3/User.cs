using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    class User
    {
        private string name, surname, patronymic;
        int day, mounth, year;

        public User()
        {
            name = "";
            surname = "";
            patronymic = "";
            day = 0;
            mounth = 0;
            year = 0;
        }

        public User(string s, string n, string p, int d, int m, int y)
        {
            surname = s;
            name = n;
            patronymic = p;
            day = d;            
            mounth = m;
            year = y;
        }

        public void Print()
        {
            Console.WriteLine("ФИО:{0} {1} {2}", surname, name, patronymic);
            Console.WriteLine("Дата рождения:{0}.{1}.{2}", day, mounth, year);
            Console.WriteLine("Возраст: {0}", DateTime.Now.Year - year);
        }
    }
}
