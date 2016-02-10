using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class User
    {
        public string Surname { get; protected set; } //фамилия
        public string Name { get; protected set; } //имя
        public string Patronymic { get; protected set; } //отчество
        public DateTime Birthdate { get; protected set; } //дата рождения
        public int Age { get; protected set; } //возраст

        public User()
        {
            Surname = "";
            Name = "";
            Patronymic = "";
            Birthdate = DateTime.Now;
            Age = 0;
        }

        public User(string s, string n, string p, DateTime d)
        {
            Surname = s;
            Name = n;
            Patronymic = p;
            Birthdate = d;
            if (DateTime.Now.Month > d.Month || DateTime.Now.Month == d.Month && DateTime.Now.Day >= d.Day)
                Age = DateTime.Now.Year - d.Year;
            else
                Age = DateTime.Now.Year - d.Year - 1;

        }
    }
}
