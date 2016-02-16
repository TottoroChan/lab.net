using System;
using System.Diagnostics;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] array = new int[200];
			Stopwatch[] speed = new Stopwatch[50];
			for (int i = 0; i < 50; i++)
			{
				speed[i] = new Stopwatch();
				speed[i].Start();
				array.SearchOfElements();
				speed[i].Stop();
			}
			speed.TimeSort();
			Stopwatch s = speed[(speed.Length) / 2];
			Console.WriteLine
				("Время поиска положительных элементов = {0}", s.Elapsed);

			Stopwatch[] speedDelegat = new Stopwatch[50];
			for (int i = 0; i < 50; i++)
			{
				speedDelegat[i] = new Stopwatch();
				speedDelegat[i].Start();
				array.SearchOfElements();
				speedDelegat[i].Stop();
			}
			speedDelegat.TimeSort();
			Stopwatch sd = speedDelegat[(speedDelegat.Length) / 2];
			Console.WriteLine
				("Поиск элементов с помощью делегата = {0}", sd.Elapsed);

			Stopwatch[] speedAnonim = new Stopwatch[50];
			for (int i = 0; i < 50; i++)
			{
				speedAnonim[i] = new Stopwatch();
				speedAnonim[i].Start();
				array.SearchOfElements();
				speedAnonim[i].Stop();
			}
			speedAnonim.TimeSort();
			Stopwatch sa = speedAnonim[(speedAnonim.Length) / 2];
			Console.WriteLine
				("Поиск с помощью анонимного делегата = {0}", sa.Elapsed);

			Stopwatch[] speedLambda = new Stopwatch[50];
			for (int i = 0; i < 50; i++)
			{
				speedLambda[i] = new Stopwatch();
				speedLambda[i].Start();
				array.SearchOfElements();
				speedLambda[i].Stop();
			}
			speedLambda.TimeSort();
			Stopwatch sla = speedLambda[(speedLambda.Length) / 2];
			Console.WriteLine
				("Поиск с помощью лямбда-выражений = {0}", sla.Elapsed);

			Stopwatch[] speedLinq = new Stopwatch[50];
			for (int i = 0; i < 50; i++)
			{
				speedLinq[i] = new Stopwatch();
				speedLinq[i].Start();
				array.SearchOfElements();
				speedLinq[i].Stop();
			}
			speedLinq.TimeSort();
			Stopwatch sli = speedLinq[(speedLinq.Length) / 2];
			Console.WriteLine
				("Поиск с помощью LINQ-выражения = {0}", sli.Elapsed);

			Stopwatch[] sort = new Stopwatch[5];
			sort[0] = s;
			sort[1] = sa;
			sort[2] = sd;
			sort[3] = sli;
			sort[4] = sla;
			sort.TimeSort();
			if (sort[4] == s)
				Console.WriteLine
				("Медленее всех работает обычная сортировка");
			else if (sort[4] == sd)
				Console.WriteLine
				("Медленне всех работает сортировка с делегатом");
			else if (sort[4] == sa)
				Console.WriteLine
				("Медленне всех рыботает сортировка с анонимным делегатом");
			else if (sort[4] == sli)
				Console.WriteLine
				("Медленне всех работает сортировка с LINQ-выражений");
			else if (sort[4] == sla)
				Console.WriteLine
				("Медленне всех работает сортировка с лямбда-выражениями");

			if (sort[0] == s)
				Console.WriteLine
				("Быстрее всех работает обычная сортировка");
			else if (sort[0] == sd)
				Console.WriteLine
				("Быстрее всех работает сортировка с делегатом");
			else if (sort[0] == sa)
				Console.WriteLine
				("Быстрее всех работает сортировка с анонимным делегатом");
			else if (sort[0] == sli)
				Console.WriteLine
				("Быстрее всех работает сортировка с LINQ-выражений");
			else if (sort[0] == sla)
				Console.WriteLine
				("Быстрее всех работает сортировка с лямбда-выражениями");

			Console.Write("Нажмите любую клавишу для закрытия программы.");
			Console.ReadKey();
		}
	}
}
