using System;

namespace Task4
{
    class MyString
    {
        public char[] str;
        public int size;
        
        public MyString()
        {
            str = null;
            size = 0;
        }

        public MyString(string a)
        {
            str = a.ToCharArray();
            size = a.Length;
        }

        public void Print()
        {
            for (int i = 0; i < str.Length; i++)
                Console.Write(str[i]);
            Console.WriteLine();
        }

        public bool Equals(string a)
        {
            if (size == a.Length)
            {
                for (int i = 0; i < size; i++)
                    if (str[i] != a[i]) return false;
                return true;
            }
            else return false;

        }

        public override string ToString()
        {
            string str1="";
            for (int i = 0; i < str.Length; i++)
                str1 += str[i];
            return str1;
        }
    }
}
