using System;

namespace Task2
{
    class Program
    {
		static void Main(string[] args)
        {
			TimeEvent T = new TimeEvent();

			Person jhon = new Person ("Джон");
			Message greetingByJhon = new Message(jhon.Greeting);

			Person hugo = new Person ("Хьюго");
			Message greetingByHugo = new Message(hugo.Greeting);
			Message greetingByUs = greetingByJhon;
			if (greetingByUs != null)
				greetingByUs("Хьюго");
			Message farewellByHugo = new Message(hugo.Farewell);
			Message farewellByUs = farewellByHugo; 

			Person bill = new Person ("Билл");
			Message greetingByBill = new Message(bill.Greeting);
			greetingByUs += greetingByHugo;
			if (greetingByUs != null)
				greetingByUs("Билл");
			Message farewellByBill = new Message(bill.Farewell);
			farewellByUs += farewellByBill;

			jhon.GoHome();
			if (farewellByUs != null)
				farewellByUs("Джон");

			hugo.GoHome();
			farewellByUs -= farewellByHugo;
			if (farewellByUs != null)
				farewellByUs("Хьюго");

			bill.GoHome();
			farewellByUs -= farewellByBill;
			if (farewellByUs != null)
				farewellByUs("Билл");

			Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }

		delegate void Message(string name);
	}
}
