using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Employee : User
    {
        public int WorkExperience { get; protected set; } // стаж работы
        public String Post { get; protected set; } // должность

        public Employee()
        {
            Surname = "";
            Name = "";
            Patronymic = "";
            Birthdate = DateTime.Now;
            Age = 0;
            WorkExperience = 0;
            Post = " ";
        }

        public Employee(string s, string n, string p, DateTime d, int we, string wp)
        {
            Surname = s;
            Name = n;
            Patronymic = p;
            Birthdate = d;
            if (DateTime.Now.Month > d.Month || DateTime.Now.Month == d.Month && DateTime.Now.Day >= d.Day)
                Age = DateTime.Now.Year - d.Year;
            else
                Age = DateTime.Now.Year - d.Year - 1;
            WorkExperience = we;
            Post = wp;
        }

        public void Print()
        {
            Console.WriteLine("ФИО:{0} {1} {2}", Surname, Name, Patronymic);
            Console.WriteLine("Дата рождения:{0}", Birthdate.ToShortDateString());
            Console.WriteLine("Возраст: {0}", Age);
            Console.WriteLine("Должность: {0}", Post);
            Console.WriteLine("Стаж работы: {0}", WorkExperience);
        }
    }
}
