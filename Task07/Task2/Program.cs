using System;

namespace Task2
{
    class Program
    {
		static void Main(string[] args)
        {
			Office jhon = new Office("Джон");
			Office hugo = new Office("Хьюго");
			Office bill = new Office("Билл");

			Office.CameToWork(jhon);
			Office.CameToWork(hugo);
			Office.CameToWork(bill);
			Office.GoHome(jhon);
			Office.GoHome(hugo);
			Office.GoHome(bill);

			Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }

		delegate void Message(string name);
	}
}
